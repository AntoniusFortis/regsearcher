using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegSearcher
{
    public partial class SearcherOptionsForm : Form
    {
        /// <summary>Цвет кнопок, активированных параметров</summary>
        private readonly Color _disableColor = Color.FromArgb(225, 225, 225);

        /// <summary>Цвет кнопок, деактивированных параметров</summary>
        private readonly Color _enableColor = Color.GreenYellow;

        private readonly Searcher _searcher = Searcher.GetInstance();

        ////////////////////////////////////////////////////
        public SearcherOptionsForm() => InitializeComponent();
        
        private void SearcherOptions_Load(object sender, EventArgs e)
        {
            foreach (var hive in _searcher.HivesList)
            {
                RootsDGV.Rows.Add(hive.IsSelected, hive.RegKey.Name);
            }

            // Устанавливаем цвета кнопок по значению флагов
            UnitWordTile.BackColor = _searcher.IsUnitString ? _enableColor : _disableColor;
            CompTile.BackColor = _searcher.ComparisonType == StringComparison.Ordinal ? _enableColor : _disableColor;

            switch (_searcher.CurrentSearchMode)
            {
                case Searcher.SearchModes.Variables:
                    {
                        NameKeyTile.BackColor = _enableColor;
                        ValueKeyTile.Enabled = false;
                        break;
                    }
                case Searcher.SearchModes.Values:
                    {
                        ValueKeyTile.BackColor = _enableColor;
                        NameKeyTile.Enabled = false;
                        break;
                    }
            }
        }
        
        private void SearcherOptions_MouseDown(object sender, MouseEventArgs e) => Restyler.MouseCapture(Handle);

        private void TemplateFunc(Button btn, Action iftrue, Action iffalse)
        {
            if (btn.BackColor == _enableColor)
            {
                btn.BackColor = _disableColor;
                iftrue();
            }
            else
            {
                btn.BackColor = _enableColor;
                iffalse();
            }
        }

        private void NameKeyTile_Click(object sender, EventArgs e)
        {
            TemplateFunc(NameKeyTile, 
                () => {
                    _searcher.CurrentSearchMode = Searcher.SearchModes.Roots;
                    ValueKeyTile.Enabled = true;
                },
                () => {
                    _searcher.CurrentSearchMode = Searcher.SearchModes.Variables;
                    ValueKeyTile.Enabled = false;
                }
            );
        }
        
        private void ValueKeyTile_Click(object sender, EventArgs e)
        {
            TemplateFunc(ValueKeyTile,
                () => {
                    _searcher.CurrentSearchMode = Searcher.SearchModes.Roots;
                    NameKeyTile.Enabled = true;
                },
                () => {
                    _searcher.CurrentSearchMode = Searcher.SearchModes.Values;
                    NameKeyTile.Enabled = false;
                }

            );
        }
        
        private void UnitWordTile_Click(object sender, EventArgs e)
        {
            TemplateFunc(UnitWordTile,
                () => _searcher.IsUnitString = false,
                () => _searcher.IsUnitString = true
            );
        }

        private void CompTile_Click(object sender, EventArgs e)
        {
            TemplateFunc(CompTile,
                () => _searcher.ComparisonType = StringComparison.OrdinalIgnoreCase,
                () => _searcher.ComparisonType = StringComparison.Ordinal
            );
        }
         
        private void Msg(string msg, string title = "", MessageBoxButtons btns = MessageBoxButtons.YesNo,
            MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            MessageBox.Show(this, msg, title, btns, icon);
        }

        private void AddRootBtn_Click(object sender, EventArgs e)
        {

            string tmp = RootTbox.Text;

            if (tmp.Contains(Consts.Hkcr))
            {
                tmp = tmp.Remove(0, Consts.Hkcr.Length - 1);
                _searcher.AddHive(Registry.ClassesRoot.OpenSubKey(tmp));
            }
            else if (tmp.Contains(Consts.Hkcu))
            {
                tmp = tmp.Remove(0, Consts.Hkcu.Length + 1);
                _searcher.AddHive(Registry.CurrentUser.OpenSubKey(tmp));
            }
            else if (tmp.Contains(Consts.Hkcc))
            {
                tmp = tmp.Remove(0, Consts.Hkcc.Length - 1);
                _searcher.AddHive(Registry.CurrentConfig.OpenSubKey(tmp));
            }
            else if (tmp.Contains(Consts.Hklm))
            {
                tmp = tmp.Remove(0, Consts.Hklm.Length - 1);
                _searcher.AddHive(Registry.LocalMachine.OpenSubKey(tmp));
            }
            else if (tmp.Contains(Consts.Hku))
            {
                tmp = tmp.Remove(0, Consts.Hku.Length - 1);
                _searcher.AddHive(Registry.Users.OpenSubKey(tmp));
            }
            else
            {
                Msg($"Раздел '{tmp}' не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RootsDGV.Rows.Add(false, RootTbox.Text);
        }

        private void MarkAllBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RootsDGV.RowCount; ++i)
            {
                if (RootsDGV[0, i].Value.Equals(false))
                    RootsDGV[0, i].Value = true;
            }
        }

        private void UnMarkBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RootsDGV.RowCount; ++i)
            {
                if (RootsDGV[0, i].Value.Equals(true))
                    RootsDGV[0, i].Value = false;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e) => Close();

        private void RootsDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (RootsDGV[0, e.RowIndex].Value.Equals(true))
            {
                var tmp = _searcher.HivesList[e.RowIndex];
                tmp.IsSelected = true;
                _searcher.HivesList[e.RowIndex] = tmp;
            }
            else
            {
                var tmp = _searcher.HivesList[e.RowIndex];
                tmp.IsSelected = false;
                _searcher.HivesList[e.RowIndex] = tmp;
            }
        }

        private void RootsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (e.RowIndex < 5)
                {
                    Msg("Этот путь удалить нельзя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _searcher.HivesList.RemoveAt(e.RowIndex);
                RootsDGV.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
