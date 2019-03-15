using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegSearcher
{
    public partial class MainForm : Form
    {
        /// <summary>Выбранные пути реестра</summary>
        private IEnumerable<ValueTuple<RegistryKey, bool>> _selectedHives;

        /// <summary>Название файла, где хранятся пользовательские пути</summary>
        private const string StorageFile = "storage.dat";

        private readonly Searcher _searcher = Searcher.GetInstance();

        ////////////////////////////////////////////////////
        public MainForm() => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResultDGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Перерисуем окно
            Restyler.WindowsReStyle(Handle);

            _searcher.AddHive(Registry.ClassesRoot, true);
            _searcher.AddHive(Registry.CurrentUser, true);
            _searcher.AddHive(Registry.CurrentConfig, true);
            _searcher.AddHive(Registry.LocalMachine, true);
            _searcher.AddHive(Registry.Users, true);

            // Извлекаем из файла все записи
            LoadData();

            //CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e) => Restyler.MouseCapture(Handle);

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var streamWriter = new System.IO.StreamWriter(StorageFile))
            {
                for (int i = 5; i < _searcher.HivesList.Count; ++i)
                {
                    streamWriter.WriteLine(_searcher.HivesList[i].Item1);
                }
            }
        }

        private void SearchBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _searcher.Start(_selectedHives);
        }

        private void SearchRootFlow_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            foreach (var root in _searcher.FoundRoots)
            {
                ResultDGV.Rows.Add(false, root);
            }

            LResInfo.Text = $@"Найдено разделов: {_searcher.FoundRoots.Count}";
            StartBtn.Text = @"Поиск";
            SetControlsState(true);
        }

        /// <summary>Функция переключения видимости некоторых элементов</summary>
        private void SetControlsState(bool flag)
        {
            // !flag - во время поиска
            // flag - а обычном режиме
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
            switch (_searcher.CurrentMode)
            {
                case Searcher.SearchModes.Roots:
                {
                    try
                    {
                        key.DeleteSubKeyTree(temp);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    break;
                }
                default:
                {
                    temp = temp.Remove(temp.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase),
                        temp.Length - temp.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase));
                    try
                    {
                        key.OpenSubKey(temp, true)?.DeleteValue(val);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    break;
                }
            }

            ResultDGV.Rows.RemoveAt(rowIndex);
            _searcher.FoundRoots.Remove(item);
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

                for (int i = 4; i < _searcher.HivesList.Count; ++i)
                {
                    string str = sr.ReadLine();
                    if (string.IsNullOrEmpty(str))
                        break;

                    if (str.Contains(Consts.Hkcr))
                    {
                        str = str.Remove(0, Consts.Hkcr.Length + 1);
                        _searcher.AddHive(Registry.ClassesRoot.OpenSubKey(str));
                        continue;
                    }
                    if (str.Contains(Consts.Hkcu))
                    {
                        str = str.Remove(0, Consts.Hkcu.Length + 1);
                        _searcher.AddHive(Registry.CurrentUser.OpenSubKey(str));
                        continue;
                    }
                    if (str.Contains(Consts.Hkcc))
                    {
                        str = str.Remove(0, Consts.Hkcc.Length + 1);
                        _searcher.AddHive(Registry.CurrentConfig.OpenSubKey(str));
                        continue;
                    }
                    if (str.Contains(Consts.Hklm))
                    {
                        str = str.Remove(0, Consts.Hklm.Length + 1);
                        _searcher.AddHive(Registry.LocalMachine.OpenSubKey(str));
                        continue;
                    }
                    if (str.Contains(Consts.Hku))
                    {
                        str = str.Remove(0, Consts.Hku.Length + 1);
                        _searcher.AddHive(Registry.Users.OpenSubKey(str));
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
            if (string.IsNullOrEmpty(TargetTbox.Text))
            {
                Msg("Текстовое поле не должно быть пустым!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Отсеиваем невыбранные
            _selectedHives = _searcher.HivesList.Where(x => x.Item2);

            if (!_selectedHives.Any())
            {
                Msg("Вы не выбрали разделы, в которых будет произведён поиск!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MainTabControl.SelectTab("ResultTabPage");
            _searcher.Target = TargetTbox.Text;
            StartBtn.Text = @"Отмена";
            ResultDGV.Rows.Clear();
            _searcher.FoundRoots.Clear();
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
                if (!ResultDGV[0, i].Value.Equals(true))
                    continue;
                var tmp = _searcher.FoundRoots[i];
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
            LResInfo.Text = $@"Найдено разделов: {_searcher.FoundRoots.Count}";
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
                var text = new StringBuilder();

                text.AppendLine(DateTime.Now.ToString());
                text.AppendLine($"Предмет поиска: {TargetTbox.Text}");
                text.AppendLine("В разделах:");

                foreach (var hive in _selectedHives)
                {
                    text.AppendLine(hive.Item1.Name);
                }

                text.Append("\tТип поиска: ");
                switch (_searcher.CurrentMode)
                {
                    case Searcher.SearchModes.Variables:
                        {
                            text.AppendLine("Имя ключа");
                            break;
                        }
                    case Searcher.SearchModes.Values:
                        {
                            text.AppendLine("Значение ключа");
                            break;
                        }
                    case Searcher.SearchModes.Roots:
                        {
                            text.AppendLine("Раздел");
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                text.AppendLine($"\tЗависимость от регистра: {(_searcher.ComparisonType == StringComparison.Ordinal ? "есть" : "нет")}");
                text.AppendLine($"\tЦелое слово: {(_searcher.IsUnitString ? "да" : "нет")}");
                text.AppendLine("\tРезультат:");

                foreach (DataGridViewRow row in ResultDGV.Rows)
                {
                    text.AppendLine(row.Cells[1].Value.ToString());
                }

                reportFile.WriteLine(text);
                //reportFile.Dispose();
            }
        }

        private void CancelSearchLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartBtn.Text = @"Поиск";
            _searcher.Stop();
            SearchBackgroundWorker.CancelAsync();
            SetControlsState(true);
        }
    }
}