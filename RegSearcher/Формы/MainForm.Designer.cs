namespace RegSearcher
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StartBtn = new System.Windows.Forms.Button();
            this.SaveDataFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.DescrObjectTip = new System.Windows.Forms.ToolTip(this.components);
            this.CloseAppBtn = new System.Windows.Forms.Button();
            this.OptionsBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.UnMarkBtn = new System.Windows.Forms.Button();
            this.MarkBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.MinimizeAppBtn = new System.Windows.Forms.Button();
            this.SearchBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.TargetTbox = new MetroFramework.Controls.MetroTextBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MainTabPage = new System.Windows.Forms.TabPage();
            this.ResultTabPage = new System.Windows.Forms.TabPage();
            this.CancelSearchLink = new System.Windows.Forms.LinkLabel();
            this.ProgressSearch = new MetroFramework.Controls.MetroProgressSpinner();
            this.ResultDGV = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LResInfo = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            this.ResultTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(128)))), ((int)(((byte)(228)))));
            this.StartBtn.FlatAppearance.BorderSize = 0;
            this.StartBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.StartBtn.ForeColor = System.Drawing.Color.White;
            this.StartBtn.Location = new System.Drawing.Point(329, 268);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(142, 34);
            this.StartBtn.TabIndex = 76;
            this.StartBtn.Text = "Поиск";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // SaveDataFileDialog
            // 
            this.SaveDataFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            // 
            // DescrObjectTip
            // 
            this.DescrObjectTip.BackColor = System.Drawing.Color.White;
            this.DescrObjectTip.ForeColor = System.Drawing.Color.Black;
            // 
            // CloseAppBtn
            // 
            this.CloseAppBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseAppBtn.BackgroundImage = global::RegSearcher.Properties.Resources.AppExit;
            this.CloseAppBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseAppBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CloseAppBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.CloseAppBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseAppBtn.Location = new System.Drawing.Point(735, 7);
            this.CloseAppBtn.Name = "CloseAppBtn";
            this.CloseAppBtn.Size = new System.Drawing.Size(25, 25);
            this.CloseAppBtn.TabIndex = 78;
            this.DescrObjectTip.SetToolTip(this.CloseAppBtn, "Выйти из программы");
            this.CloseAppBtn.UseVisualStyleBackColor = true;
            this.CloseAppBtn.Click += new System.EventHandler(this.CloseAppBtn_Click);
            // 
            // OptionsBtn
            // 
            this.OptionsBtn.BackgroundImage = global::RegSearcher.Properties.Resources.Settings;
            this.OptionsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionsBtn.FlatAppearance.BorderSize = 0;
            this.OptionsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.OptionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsBtn.Location = new System.Drawing.Point(293, 268);
            this.OptionsBtn.Name = "OptionsBtn";
            this.OptionsBtn.Size = new System.Drawing.Size(34, 34);
            this.OptionsBtn.TabIndex = 86;
            this.DescrObjectTip.SetToolTip(this.OptionsBtn, "Настройка поиска");
            this.OptionsBtn.UseVisualStyleBackColor = false;
            this.OptionsBtn.Click += new System.EventHandler(this.OptionsBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.BackgroundImage = global::RegSearcher.Properties.Resources.SaveData;
            this.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveBtn.FlatAppearance.BorderSize = 0;
            this.SaveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBtn.ForeColor = System.Drawing.Color.White;
            this.SaveBtn.Location = new System.Drawing.Point(738, 4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(18, 18);
            this.SaveBtn.TabIndex = 84;
            this.DescrObjectTip.SetToolTip(this.SaveBtn, "Сохранить результаты поиска в файл");
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // UnMarkBtn
            // 
            this.UnMarkBtn.BackgroundImage = global::RegSearcher.Properties.Resources.UnMarkAll;
            this.UnMarkBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UnMarkBtn.FlatAppearance.BorderSize = 0;
            this.UnMarkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.UnMarkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnMarkBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UnMarkBtn.ForeColor = System.Drawing.Color.White;
            this.UnMarkBtn.Location = new System.Drawing.Point(53, 4);
            this.UnMarkBtn.Name = "UnMarkBtn";
            this.UnMarkBtn.Size = new System.Drawing.Size(15, 15);
            this.UnMarkBtn.TabIndex = 83;
            this.DescrObjectTip.SetToolTip(this.UnMarkBtn, "Убрать метки со всех элементов");
            this.UnMarkBtn.UseVisualStyleBackColor = false;
            this.UnMarkBtn.Click += new System.EventHandler(this.UnMarkBtn_Click);
            // 
            // MarkBtn
            // 
            this.MarkBtn.BackgroundImage = global::RegSearcher.Properties.Resources.MarkAll;
            this.MarkBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MarkBtn.FlatAppearance.BorderSize = 0;
            this.MarkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.MarkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MarkBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MarkBtn.ForeColor = System.Drawing.Color.White;
            this.MarkBtn.Location = new System.Drawing.Point(33, 4);
            this.MarkBtn.Name = "MarkBtn";
            this.MarkBtn.Size = new System.Drawing.Size(15, 15);
            this.MarkBtn.TabIndex = 83;
            this.DescrObjectTip.SetToolTip(this.MarkBtn, "Выбрать все элементы");
            this.MarkBtn.UseVisualStyleBackColor = false;
            this.MarkBtn.Click += new System.EventHandler(this.MarkBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.BackgroundImage = global::RegSearcher.Properties.Resources.RemoveMarked;
            this.RemoveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveBtn.FlatAppearance.BorderSize = 0;
            this.RemoveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RemoveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveBtn.ForeColor = System.Drawing.Color.White;
            this.RemoveBtn.Location = new System.Drawing.Point(8, 3);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(17, 17);
            this.RemoveBtn.TabIndex = 83;
            this.DescrObjectTip.SetToolTip(this.RemoveBtn, "Удалить выбранные элементы");
            this.RemoveBtn.UseVisualStyleBackColor = false;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // MinimizeAppBtn
            // 
            this.MinimizeAppBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeAppBtn.BackgroundImage = global::RegSearcher.Properties.Resources.AppMinimize;
            this.MinimizeAppBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinimizeAppBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MinimizeAppBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.MinimizeAppBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeAppBtn.Location = new System.Drawing.Point(704, 7);
            this.MinimizeAppBtn.Name = "MinimizeAppBtn";
            this.MinimizeAppBtn.Size = new System.Drawing.Size(25, 25);
            this.MinimizeAppBtn.TabIndex = 84;
            this.MinimizeAppBtn.UseVisualStyleBackColor = true;
            this.MinimizeAppBtn.Click += new System.EventHandler(this.MinimizeAppBtn_Click);
            // 
            // SearchBackgroundWorker
            // 
            this.SearchBackgroundWorker.WorkerSupportsCancellation = true;
            this.SearchBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SearchBackgroundWorker_DoWork);
            this.SearchBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SearchRootFlow_Completed);
            // 
            // TargetTbox
            // 
            this.TargetTbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetTbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.TargetTbox.CustomButton.Image = null;
            this.TargetTbox.CustomButton.Location = new System.Drawing.Point(599, 2);
            this.TargetTbox.CustomButton.Name = "";
            this.TargetTbox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.TargetTbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TargetTbox.CustomButton.TabIndex = 1;
            this.TargetTbox.CustomButton.Text = "X";
            this.TargetTbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TargetTbox.CustomButton.UseSelectable = true;
            this.TargetTbox.CustomButton.Visible = false;
            this.TargetTbox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.TargetTbox.Lines = new string[0];
            this.TargetTbox.Location = new System.Drawing.Point(72, 217);
            this.TargetTbox.MaxLength = 30000;
            this.TargetTbox.Multiline = true;
            this.TargetTbox.Name = "TargetTbox";
            this.TargetTbox.PasswordChar = '\0';
            this.TargetTbox.PromptText = "Введите что вы ищете";
            this.TargetTbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TargetTbox.SelectedText = "";
            this.TargetTbox.SelectionLength = 0;
            this.TargetTbox.SelectionStart = 0;
            this.TargetTbox.ShortcutsEnabled = true;
            this.TargetTbox.Size = new System.Drawing.Size(629, 32);
            this.TargetTbox.Style = MetroFramework.MetroColorStyle.White;
            this.TargetTbox.TabIndex = 80;
            this.TargetTbox.TabStop = false;
            this.TargetTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TargetTbox.UseCustomBackColor = true;
            this.TargetTbox.UseSelectable = true;
            this.TargetTbox.UseStyleColors = true;
            this.TargetTbox.WaterMark = "Введите что вы ищете";
            this.TargetTbox.WaterMarkColor = System.Drawing.Color.DimGray;
            this.TargetTbox.WaterMarkFont = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.MainTabPage);
            this.MainTabControl.Controls.Add(this.ResultTabPage);
            this.MainTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.MainTabControl.Location = new System.Drawing.Point(-2, 35);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(773, 572);
            this.MainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabControl.TabIndex = 87;
            // 
            // MainTabPage
            // 
            this.MainTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.MainTabPage.Controls.Add(this.OptionsBtn);
            this.MainTabPage.Controls.Add(this.TargetTbox);
            this.MainTabPage.Controls.Add(this.StartBtn);
            this.MainTabPage.Location = new System.Drawing.Point(4, 5);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabPage.Size = new System.Drawing.Size(765, 563);
            this.MainTabPage.TabIndex = 0;
            this.MainTabPage.Text = "0";
            // 
            // ResultTabPage
            // 
            this.ResultTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ResultTabPage.Controls.Add(this.CancelSearchLink);
            this.ResultTabPage.Controls.Add(this.ProgressSearch);
            this.ResultTabPage.Controls.Add(this.ResultDGV);
            this.ResultTabPage.Controls.Add(this.panel1);
            this.ResultTabPage.Location = new System.Drawing.Point(4, 5);
            this.ResultTabPage.Name = "ResultTabPage";
            this.ResultTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResultTabPage.Size = new System.Drawing.Size(765, 553);
            this.ResultTabPage.TabIndex = 1;
            this.ResultTabPage.Text = "1";
            // 
            // CancelSearchLink
            // 
            this.CancelSearchLink.AutoSize = true;
            this.CancelSearchLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.CancelSearchLink.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelSearchLink.LinkColor = System.Drawing.Color.Orange;
            this.CancelSearchLink.Location = new System.Drawing.Point(358, 207);
            this.CancelSearchLink.Name = "CancelSearchLink";
            this.CancelSearchLink.Size = new System.Drawing.Size(58, 17);
            this.CancelSearchLink.TabIndex = 91;
            this.CancelSearchLink.TabStop = true;
            this.CancelSearchLink.Text = "Отмена";
            this.CancelSearchLink.Visible = false;
            this.CancelSearchLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CancelSearchLink_LinkClicked);
            // 
            // ProgressSearch
            // 
            this.ProgressSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProgressSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.ProgressSearch.CustomBackground = true;
            this.ProgressSearch.Location = new System.Drawing.Point(306, 144);
            this.ProgressSearch.Maximum = 100;
            this.ProgressSearch.Name = "ProgressSearch";
            this.ProgressSearch.Size = new System.Drawing.Size(161, 161);
            this.ProgressSearch.Speed = 4F;
            this.ProgressSearch.Style = MetroFramework.MetroColorStyle.Yellow;
            this.ProgressSearch.TabIndex = 88;
            this.ProgressSearch.UseCustomBackColor = true;
            this.ProgressSearch.UseSelectable = true;
            this.ProgressSearch.Value = 30;
            this.ProgressSearch.Visible = false;
            // 
            // ResultDGV
            // 
            this.ResultDGV.AllowUserToAddRows = false;
            this.ResultDGV.AllowUserToDeleteRows = false;
            this.ResultDGV.AllowUserToResizeColumns = false;
            this.ResultDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.ResultDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ResultDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.ResultDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ResultDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ResultDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultDGV.ColumnHeadersVisible = false;
            this.ResultDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResultDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.ResultDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ResultDGV.Location = new System.Drawing.Point(1, 27);
            this.ResultDGV.Name = "ResultDGV";
            this.ResultDGV.RowHeadersVisible = false;
            this.ResultDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultDGV.ShowCellErrors = false;
            this.ResultDGV.ShowCellToolTips = false;
            this.ResultDGV.ShowEditingIcon = false;
            this.ResultDGV.ShowRowErrors = false;
            this.ResultDGV.Size = new System.Drawing.Size(763, 507);
            this.ResultDGV.TabIndex = 87;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 17.25889F;
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 17;
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 182.7412F;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.LResInfo);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.UnMarkBtn);
            this.panel1.Controls.Add(this.MarkBtn);
            this.panel1.Controls.Add(this.RemoveBtn);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 26);
            this.panel1.TabIndex = 85;
            // 
            // LResInfo
            // 
            this.LResInfo.AutoSize = true;
            this.LResInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LResInfo.Location = new System.Drawing.Point(91, 3);
            this.LResInfo.Name = "LResInfo";
            this.LResInfo.Size = new System.Drawing.Size(0, 15);
            this.LResInfo.TabIndex = 85;
            this.LResInfo.Visible = false;
            // 
            // BackBtn
            // 
            this.BackBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackBtn.BackgroundImage")));
            this.BackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackBtn.ForeColor = System.Drawing.Color.White;
            this.BackBtn.Location = new System.Drawing.Point(6, 10);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(33, 23);
            this.BackBtn.TabIndex = 88;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Visible = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(305, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 89;
            this.label1.Text = "RegSearcher 1.0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(767, 574);
            this.ControlBox = false;
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.MinimizeAppBtn);
            this.Controls.Add(this.CloseAppBtn);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(783, 613);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(783, 613);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegSearcher 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MainTabControl.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            this.ResultTabPage.ResumeLayout(false);
            this.ResultTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CloseAppBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button MinimizeAppBtn;
        private System.Windows.Forms.SaveFileDialog SaveDataFileDialog;
        private System.Windows.Forms.ToolTip DescrObjectTip;
        private System.ComponentModel.BackgroundWorker SearchBackgroundWorker;
        private MetroFramework.Controls.MetroTextBox TargetTbox;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage MainTabPage;
        private System.Windows.Forms.TabPage ResultTabPage;
        private System.Windows.Forms.Button OptionsBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LResInfo;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button UnMarkBtn;
        private System.Windows.Forms.Button MarkBtn;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.DataGridView ResultDGV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.LinkLabel CancelSearchLink;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroProgressSpinner ProgressSearch;
    }
}

