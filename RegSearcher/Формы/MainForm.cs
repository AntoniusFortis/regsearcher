using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
/*
todo: 
1. сделать ограничение на глубину рекурсии для parallel.foreach
2. уменьшить сами функции поиска
 */
namespace PradApp_Master___Utilizer
{
    public partial class MainForm : Form
    {
        /// <summary>Выбранные пути реестра</summary>
        private IEnumerable<Hive> _selectedHives;

        /// <summary>Список найденных разделов</summary>
        private readonly List<string> _foundRoots = new List<string>();

        /// <summary>Значение для поиска (берётся из TargetTbox)</summary>
        private string _target;

        /// <summary>Флаг прекращение поиска</summary>
        private static bool _stopSearch;

        /// <summary>Название файла, где хранятся пользовательские пути</summary>
        private const string StorageFile = "storage.dat";

        /// <summary>Минимальный размер массива для параллельной обработки</summary>
        private const int MinSizeArrayToParallel = 10;

        ////////////////////////////////////////////////////
       
        public MainForm() => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResultDGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Перерисуем окно
            Restyler.WindowsReStyle(Handle);

            Searcher.AddHive(Registry.ClassesRoot, true);
            Searcher.AddHive(Registry.CurrentUser, true);
            Searcher.AddHive(Registry.CurrentConfig, true);
            Searcher.AddHive(Registry.LocalMachine, true);
            Searcher.AddHive(Registry.Users, true);

            // Извлекаем из файла все записи
            LoadData();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e) => Restyler.MouseCapture(Handle);

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var streamWriter = new System.IO.StreamWriter(StorageFile))
            {
                for (int i = 5; i < Searcher.HivesList.Count; ++i)
                {
                    streamWriter.WriteLine(Searcher.HivesList[i].RegKey);
                }
            }
        }

        private void SearchBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Action<RegistryKey> action; 

            switch (Searcher.CurrentSearchMode)
            {
                case Searcher.SearchModes.Variables:
                {
                    action = SearchVariables;
                    break;
                }
                case Searcher.SearchModes.Values:
                {
                    action = SearchValues;
                    break;
                }
                case Searcher.SearchModes.Roots:
                {
                    action = SearchRoots;
                    break;
                }
                default:
                {
                    return;
                }
            }

            //if (_selectedHives.Count() < MinSizeArrayToParallel)
            //{
                foreach (var hive in _selectedHives)
                {
                    action(hive.RegKey);
                }
            //}
            //else
            //{
            //    Parallel.ForEach(_selectedHives, hive => action(hive.RegKey));
            //}
            //GC.Collect();
        }
        
        private void SearchRootFlow_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //FoundRoots.Sort();
            foreach (var root in _foundRoots)
            {
                ResultDGV.Rows.Add(false, root);
            }
            LResInfo.Text = $@"Найдено разделов: {_foundRoots.Count}";
            StartBtn.Text = @"Поиск";
            SetControlsState(true);
         }

        /// <summary>Функция переключения видимости некоторых элементов</summary>
        private void SetControlsState(bool flag)
        {
            // !flag - во время поиска
            // flag - а обычном режиме
            LCurRoot.Visible = !flag;
            CancelSearchLink.Visible = !flag;
            LResInfo.Visible = flag;
            ProgressSearch.Visible = !flag;
            BackBtn.Visible = flag;

            SaveBtn.Enabled = flag;
            ResultDGV.Enabled = flag;
            RemoveBtn.Enabled = flag;
            OptionsBtn.Enabled = flag;
            MarkBtn.Enabled = flag;
            UnMarkBtn.Enabled = flag;
            TargetTbox.Enabled = flag;
        }
        
        private void RemoveSelectedItems(string item, string title, RegistryKey key, int rowIndex)
        {
            // Удаление из строки корневого раздела
            string temp = item.Remove(0, title.Length + 1);
            string val = temp.Remove(0, temp.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase) + 1);
            switch (Searcher.CurrentSearchMode)
            {
                case Searcher.SearchModes.Roots:
                    try
                    {
                        key.DeleteSubKeyTree(temp);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                    break;
                default:
                    temp = temp.Remove(temp.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase), temp.Length - temp.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase));
                    RegistryKey regkey = key.OpenSubKey(temp, true);
                    if (regkey != null)
                    {
                        try
                        {
                            regkey.DeleteValue(val);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                    break;
            }
            ResultDGV.Rows.RemoveAt(rowIndex);
            _foundRoots.Remove(item);
        }

        private void SearchVariables(RegistryKey key)
        {
            if (_stopSearch)
                return;

            string keyName = key.Name;

            LCurRoot.Text = keyName;

            string[] subKeys = key.GetSubKeyNames(), values = key.GetValueNames();

            if (values.Length < MinSizeArrayToParallel)
            {
                foreach (var val in values)
                {
                    if (_stopSearch)
                        break;

                    if (IsSuitable(val))
                        _foundRoots.Add($"{keyName}\\{val}");
                }
            }
            else
            {
                Parallel.ForEach(values, (val, loopState) =>
                {
                    if (_stopSearch)
                        loopState.Stop();

                    if (IsSuitable(val))
                        _foundRoots.Add($"{keyName}\\{val}");
                });
            }

            if (subKeys.Length < MinSizeArrayToParallel)
            {
                foreach (var subkey in subKeys)
                {
                    if (_stopSearch)
                        break;

                    SearchValues(key.OpenSubKey(subkey));
                }
            }
            else
            {
                Parallel.ForEach(subKeys, (subkey, loopState) =>
                {
                    if (_stopSearch)
                        loopState.Stop();

                    SearchVariables(key.OpenSubKey(subkey));
                });
            }
        }
        
        private void SearchValues(RegistryKey key)
        {
            if (_stopSearch)
                return;

            string keyName = key.Name;

            LCurRoot.Text = keyName;

            string[] subKeys = key.GetSubKeyNames(), values = key.GetValueNames();

            if (values.Length < MinSizeArrayToParallel)
            {
                foreach (var val in values)
                {
                    if (_stopSearch)
                        break;

                    if (IsSuitable(key.GetValue(val).ToString()))
                        _foundRoots.Add($"{keyName}\\{val}");
                }
            }
            else
            {
                Parallel.ForEach(values, (val, loopState) =>
                {
                    if (_stopSearch)
                        loopState.Stop();

                    if (IsSuitable(key.GetValue(val).ToString()))
                        _foundRoots.Add($"{keyName}\\{val}");
                });
            }

            if (subKeys.Length < MinSizeArrayToParallel)
            {
                foreach (var subkey in subKeys)
                {
                    if (_stopSearch)
                        break;

                    SearchValues(key.OpenSubKey(subkey));
                }
            }
            else
            {
                Parallel.ForEach(subKeys, (subkey, loopState) =>
                {
                    if (_stopSearch)
                        loopState.Stop();

                    SearchValues(key.OpenSubKey(subkey));
                });
            }
        }
        
        private void SearchRoots(RegistryKey key)
        {
            if (_stopSearch)
                return;

            string keyName = key.Name;

            LCurRoot.Text = keyName;

            string[] subKeys = key.GetSubKeyNames();
            if (subKeys.Length < MinSizeArrayToParallel)
            {
                foreach (var subkey in subKeys)
                {
                    if (_stopSearch)
                        break;

                    if (IsSuitable(subkey))
                        _foundRoots.Add($"{keyName}\\{subkey}");

                    SearchRoots(key.OpenSubKey(subkey));
                }
            }
            else
            {
                Parallel.ForEach(subKeys, (subkey, loopState) =>
                {
                    if (_stopSearch)
                        loopState.Break();

                    if (IsSuitable(subkey))
                        _foundRoots.Add($"{keyName}\\{subkey}");

                    SearchRoots(key.OpenSubKey(subkey));
                });
            }
        }
        
        private bool IsSuitable(string str)
        {
            var suitable = Searcher.IsUnitString ? str.Equals(_target, Searcher.ComparisonType) 
                : str.Contains(_target, Searcher.ComparisonType);
            return suitable;
        }
        
        private DialogResult Msg(string msg, string title = "", MessageBoxButtons btns = MessageBoxButtons.YesNo,
            MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(this, msg, title, btns, icon);
        }

        /// <summary>Функция загрузки пользовательских путей из файла</summary>
        private void LoadData()
        {
            if (!System.IO.File.Exists(StorageFile))
            {
                return;
            }

            using (var sr = new System.IO.StreamReader(StorageFile))
            {
                for (int i = 4; i < Searcher.HivesList.Count; ++i)
                {
                    string str = sr.ReadLine();
                    if (string.IsNullOrEmpty(str))
                        break;

                    if (str.Contains(Consts.Hkcr))
                    {
                        str = str.Remove(0, Consts.Hkcr.Length + 1);
                        Searcher.AddHive(Registry.ClassesRoot.OpenSubKey(str));
                        continue;
                    }
                    if (str.Contains(Consts.Hkcu))
                    {
                        str = str.Remove(0, Consts.Hkcu.Length + 1);
                        Searcher.AddHive(Registry.CurrentUser.OpenSubKey(str));
                        continue;
                    }
                    if (str.Contains(Consts.Hkcc))
                    {
                        str = str.Remove(0, Consts.Hkcc.Length + 1);
                        Searcher.AddHive(Registry.CurrentConfig.OpenSubKey(str));
                        continue;
                    }
                    if (str.Contains(Consts.Hklm))
                    {
                        str = str.Remove(0, Consts.Hklm.Length + 1);
                        Searcher.AddHive(Registry.LocalMachine.OpenSubKey(str));
                        continue;
                    }
                    if (str.Contains(Consts.Hku))
                    {
                        str = str.Remove(0, Consts.Hku.Length + 1);
                        Searcher.AddHive(Registry.Users.OpenSubKey(str));
                    }
                }
            }
        }

        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            SearcherOptionsForm searchOptionsForm = new SearcherOptionsForm();
            searchOptionsForm.ShowDialog();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            _stopSearch = false;

            if (string.IsNullOrEmpty(TargetTbox.Text))
            {
                Msg("Текстовое поле не должно быть пустым!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Отсеиваем невыбранные
            _selectedHives = Searcher.HivesList.Where(x => x.IsSelected);

            if (!_selectedHives.Any())
            {
                Msg("Вы не выбрали разделы, в которых будет произведён поиск!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MainTabControl.SelectTab("ResultTabPage");
            _target = TargetTbox.Text;
            StartBtn.Text = @"Отмена";
            ResultDGV.Rows.Clear();
            _foundRoots.Clear();
            SearchBackgroundWorker.RunWorkerAsync();
            SetControlsState(false);
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (ResultDGV.RowCount == 0)
            {
                Msg("Список результатов пуст!", "Удалить", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialogResult = Msg("Вы уверены, что хотите удалить выбранные элементы?", "Удалить");
            if (dialogResult == DialogResult.No)
                return;

            for (int i = 0; i < ResultDGV.RowCount; ++i)
            {
                if (ResultDGV[0, i].Value.Equals(true))
                {
                    var tmp = _foundRoots[i];

                    if (tmp.Contains(Consts.Hkcr))
                        RemoveSelectedItems(tmp, Consts.Hkcr, Registry.ClassesRoot, i);
                    else if (tmp.Contains(Consts.Hkcu))
                        RemoveSelectedItems(tmp, Consts.Hkcu, Registry.CurrentUser, i);
                    else if (tmp.Contains(Consts.Hkcc))
                        RemoveSelectedItems(tmp, Consts.Hkcc, Registry.CurrentConfig, i);
                    else if (tmp.Contains(Consts.Hklm))
                        RemoveSelectedItems(tmp, Consts.Hklm, Registry.LocalMachine, i);
                    else if (tmp.Contains(Consts.Hku))
                        RemoveSelectedItems(tmp, Consts.Hku, Registry.Users, i);
                    --i;
                }
            }
            LResInfo.Text = $@"Найдено разделов: {_foundRoots.Count}";
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectTab("MainTabPage");
            BackBtn.Visible = false;
        }

        private void MinimizeAppBtn_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void CloseAppBtn_Click(object sender, EventArgs e) => Application.Exit();

        private void MarkBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ResultDGV.RowCount; ++i)
            {
                if (ResultDGV[0, i].Value.Equals(false))
                    ResultDGV[0, i].Value = true;
            }
        }

        private void UnMarkBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ResultDGV.RowCount; ++i)
            {
                if (ResultDGV[0, i].Value.Equals(true))
                    ResultDGV[0, i].Value = false;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ResultDGV.RowCount == 0)
            {
                Msg("Пустой список нельзя сохранить!", "Сохранить результаты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SaveDataFileDialog.ShowDialog() != DialogResult.OK)
                return;

            using (var reportFile = new System.IO.StreamWriter(SaveDataFileDialog.FileName))
            {
                string text = "";
                text += $"{DateTime.Now}{Environment.NewLine}";
                text += $"Предмет поиска: {TargetTbox.Text}{Environment.NewLine}";
                text += $"В разделах:{Environment.NewLine}";

                foreach (var hive in _selectedHives)
                {
                    text += $"{hive.RegKey.Name}{Environment.NewLine}";
                }

                text += "\tТип поиска: ";
                switch (Searcher.CurrentSearchMode)
                {
                    case Searcher.SearchModes.Variables:
                        {
                            text += $"Имя ключа{Environment.NewLine}";
                            break;
                        }
                    case Searcher.SearchModes.Values:
                        {
                            text += $"Значение ключа{Environment.NewLine}";
                            break;
                        }
                    case Searcher.SearchModes.Roots:
                        {
                            text += $"Раздел{Environment.NewLine}";
                            break;
                        }
                }

                text += $"\tЗависимость от регистра: {(Searcher.ComparisonType == StringComparison.Ordinal ? "есть" : "нет")}";

                reportFile.WriteLine(text);

                reportFile.WriteLine($"\tЦелое слово: {(Searcher.IsUnitString ? "да" : "нет")}");
                reportFile.WriteLine("Результат:");

                foreach (DataGridViewRow row in ResultDGV.Rows)
                {
                    reportFile.WriteLine($"{row.Cells[0].Value} - {row.Cells[1].Value}");
                }
            }
        }

        private void CancelSearchLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartBtn.Text = @"Поиск";
            _stopSearch = true;
            SearchBackgroundWorker.CancelAsync();
            SetControlsState(true);
        }
    }
}