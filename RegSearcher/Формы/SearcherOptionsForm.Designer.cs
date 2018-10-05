namespace PradApp_Master___Utilizer
{
    partial class SearcherOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.RootsDGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CompTile = new System.Windows.Forms.Button();
            this.UnitWordTile = new System.Windows.Forms.Button();
            this.ValueKeyTile = new System.Windows.Forms.Button();
            this.NameKeyTile = new System.Windows.Forms.Button();
            this.RootTbox = new MetroFramework.Controls.MetroTextBox();
            this.DescrObjectTip = new System.Windows.Forms.ToolTip(this.components);
            this.UnMarkBtn = new System.Windows.Forms.Button();
            this.MarkAllBtn = new System.Windows.Forms.Button();
            this.AddRootBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.RootsDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(132, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 88;
            this.label1.Text = "Настройка поиска";
            // 
            // RootsDGV
            // 
            this.RootsDGV.AllowUserToAddRows = false;
            this.RootsDGV.AllowUserToDeleteRows = false;
            this.RootsDGV.AllowUserToResizeColumns = false;
            this.RootsDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.RootsDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.RootsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RootsDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.RootsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RootsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.RootsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RootsDGV.ColumnHeadersVisible = false;
            this.RootsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RootsDGV.DefaultCellStyle = dataGridViewCellStyle4;
            this.RootsDGV.GridColor = System.Drawing.Color.Silver;
            this.RootsDGV.Location = new System.Drawing.Point(12, 93);
            this.RootsDGV.Name = "RootsDGV";
            this.RootsDGV.RowHeadersVisible = false;
            this.RootsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RootsDGV.ShowCellErrors = false;
            this.RootsDGV.ShowCellToolTips = false;
            this.RootsDGV.ShowEditingIcon = false;
            this.RootsDGV.ShowRowErrors = false;
            this.RootsDGV.Size = new System.Drawing.Size(383, 152);
            this.RootsDGV.TabIndex = 89;
            this.RootsDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RootsDGV_CellContentClick);
            this.RootsDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.RootsDGV_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 45.68529F;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.FillWeight = 235.1738F;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 19.14101F;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.Text = "X";
            this.Column3.ToolTipText = "X";
            this.Column3.UseColumnTextForButtonValue = true;
            // 
            // CompTile
            // 
            this.CompTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.CompTile.FlatAppearance.BorderSize = 0;
            this.CompTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompTile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.CompTile.ForeColor = System.Drawing.Color.Black;
            this.CompTile.Location = new System.Drawing.Point(10, 16);
            this.CompTile.Name = "CompTile";
            this.CompTile.Size = new System.Drawing.Size(176, 37);
            this.CompTile.TabIndex = 93;
            this.CompTile.Text = "Зависимость от регистра";
            this.CompTile.UseVisualStyleBackColor = false;
            this.CompTile.Click += new System.EventHandler(this.CompTile_Click);
            // 
            // UnitWordTile
            // 
            this.UnitWordTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.UnitWordTile.FlatAppearance.BorderSize = 0;
            this.UnitWordTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnitWordTile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.UnitWordTile.ForeColor = System.Drawing.Color.Black;
            this.UnitWordTile.Location = new System.Drawing.Point(197, 16);
            this.UnitWordTile.Name = "UnitWordTile";
            this.UnitWordTile.Size = new System.Drawing.Size(176, 37);
            this.UnitWordTile.TabIndex = 92;
            this.UnitWordTile.Text = "Целое предложение";
            this.UnitWordTile.UseVisualStyleBackColor = false;
            this.UnitWordTile.Click += new System.EventHandler(this.UnitWordTile_Click);
            // 
            // ValueKeyTile
            // 
            this.ValueKeyTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ValueKeyTile.FlatAppearance.BorderSize = 0;
            this.ValueKeyTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ValueKeyTile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ValueKeyTile.ForeColor = System.Drawing.Color.Black;
            this.ValueKeyTile.Location = new System.Drawing.Point(10, 59);
            this.ValueKeyTile.Name = "ValueKeyTile";
            this.ValueKeyTile.Size = new System.Drawing.Size(176, 37);
            this.ValueKeyTile.TabIndex = 91;
            this.ValueKeyTile.Text = "Значение ключа";
            this.ValueKeyTile.UseVisualStyleBackColor = false;
            this.ValueKeyTile.Click += new System.EventHandler(this.ValueKeyTile_Click);
            // 
            // NameKeyTile
            // 
            this.NameKeyTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.NameKeyTile.FlatAppearance.BorderSize = 0;
            this.NameKeyTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NameKeyTile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.NameKeyTile.ForeColor = System.Drawing.Color.Black;
            this.NameKeyTile.Location = new System.Drawing.Point(197, 59);
            this.NameKeyTile.Name = "NameKeyTile";
            this.NameKeyTile.Size = new System.Drawing.Size(176, 37);
            this.NameKeyTile.TabIndex = 90;
            this.NameKeyTile.Text = "Имя ключа";
            this.NameKeyTile.UseVisualStyleBackColor = false;
            this.NameKeyTile.Click += new System.EventHandler(this.NameKeyTile_Click);
            // 
            // RootTbox
            // 
            this.RootTbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.RootTbox.CustomButton.Image = null;
            this.RootTbox.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.RootTbox.CustomButton.Name = "";
            this.RootTbox.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.RootTbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.RootTbox.CustomButton.TabIndex = 1;
            this.RootTbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.RootTbox.CustomButton.UseSelectable = true;
            this.RootTbox.CustomButton.Visible = false;
            this.RootTbox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.RootTbox.Lines = new string[0];
            this.RootTbox.Location = new System.Drawing.Point(35, 40);
            this.RootTbox.MaxLength = 32767;
            this.RootTbox.Name = "RootTbox";
            this.RootTbox.PasswordChar = '\0';
            this.RootTbox.PromptText = "Пользовательский путь";
            this.RootTbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RootTbox.SelectedText = "";
            this.RootTbox.SelectionLength = 0;
            this.RootTbox.SelectionStart = 0;
            this.RootTbox.ShortcutsEnabled = true;
            this.RootTbox.Size = new System.Drawing.Size(360, 24);
            this.RootTbox.Style = MetroFramework.MetroColorStyle.White;
            this.RootTbox.TabIndex = 95;
            this.RootTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RootTbox.UseCustomBackColor = true;
            this.RootTbox.UseSelectable = true;
            this.RootTbox.UseStyleColors = true;
            this.RootTbox.WaterMark = "Пользовательский путь";
            this.RootTbox.WaterMarkColor = System.Drawing.Color.DimGray;
            this.RootTbox.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // DescrObjectTip
            // 
            this.DescrObjectTip.BackColor = System.Drawing.Color.White;
            this.DescrObjectTip.ForeColor = System.Drawing.Color.Black;
            // 
            // UnMarkBtn
            // 
            this.UnMarkBtn.BackgroundImage = global::PradApp_Master___Utilizer.Properties.Resources.UnMarkAll;
            this.UnMarkBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UnMarkBtn.FlatAppearance.BorderSize = 0;
            this.UnMarkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.UnMarkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnMarkBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UnMarkBtn.ForeColor = System.Drawing.Color.White;
            this.UnMarkBtn.Location = new System.Drawing.Point(33, 3);
            this.UnMarkBtn.Name = "UnMarkBtn";
            this.UnMarkBtn.Size = new System.Drawing.Size(14, 14);
            this.UnMarkBtn.TabIndex = 97;
            this.DescrObjectTip.SetToolTip(this.UnMarkBtn, "Убрать метки со всех элементов");
            this.UnMarkBtn.UseVisualStyleBackColor = false;
            this.UnMarkBtn.Click += new System.EventHandler(this.UnMarkBtn_Click);
            // 
            // MarkAllBtn
            // 
            this.MarkAllBtn.BackgroundImage = global::PradApp_Master___Utilizer.Properties.Resources.MarkAll;
            this.MarkAllBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MarkAllBtn.FlatAppearance.BorderSize = 0;
            this.MarkAllBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.MarkAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MarkAllBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MarkAllBtn.ForeColor = System.Drawing.Color.White;
            this.MarkAllBtn.Location = new System.Drawing.Point(13, 3);
            this.MarkAllBtn.Name = "MarkAllBtn";
            this.MarkAllBtn.Size = new System.Drawing.Size(14, 14);
            this.MarkAllBtn.TabIndex = 98;
            this.DescrObjectTip.SetToolTip(this.MarkAllBtn, "Пометить все элементы");
            this.MarkAllBtn.UseVisualStyleBackColor = false;
            this.MarkAllBtn.Click += new System.EventHandler(this.MarkAllBtn_Click);
            // 
            // AddRootBtn
            // 
            this.AddRootBtn.BackgroundImage = global::PradApp_Master___Utilizer.Properties.Resources.Add;
            this.AddRootBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddRootBtn.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.AddRootBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.AddRootBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRootBtn.Location = new System.Drawing.Point(12, 40);
            this.AddRootBtn.Name = "AddRootBtn";
            this.AddRootBtn.Size = new System.Drawing.Size(24, 24);
            this.AddRootBtn.TabIndex = 96;
            this.DescrObjectTip.SetToolTip(this.AddRootBtn, "Добавить в список разделов");
            this.AddRootBtn.UseVisualStyleBackColor = true;
            this.AddRootBtn.Click += new System.EventHandler(this.AddRootBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UnitWordTile);
            this.groupBox1.Controls.Add(this.NameKeyTile);
            this.groupBox1.Controls.Add(this.ValueKeyTile);
            this.groupBox1.Controls.Add(this.CompTile);
            this.groupBox1.Location = new System.Drawing.Point(12, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 107);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.CloseBtn.ForeColor = System.Drawing.Color.White;
            this.CloseBtn.Location = new System.Drawing.Point(12, 366);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(383, 27);
            this.CloseBtn.TabIndex = 94;
            this.CloseBtn.Text = "Закрыть";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.UnMarkBtn);
            this.panel1.Controls.Add(this.MarkAllBtn);
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 22);
            this.panel1.TabIndex = 100;
            // 
            // SearcherOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(407, 403);
            this.Controls.Add(this.AddRootBtn);
            this.Controls.Add(this.RootTbox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.RootsDGV);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(423, 442);
            this.MinimumSize = new System.Drawing.Size(423, 442);
            this.Name = "SearcherOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SearcherOptions_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SearcherOptions_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.RootsDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView RootsDGV;
        private System.Windows.Forms.Button CompTile;
        private System.Windows.Forms.Button UnitWordTile;
        private System.Windows.Forms.Button ValueKeyTile;
        private System.Windows.Forms.Button NameKeyTile;
        private MetroFramework.Controls.MetroTextBox RootTbox;
        private System.Windows.Forms.Button AddRootBtn;
        private System.Windows.Forms.Button UnMarkBtn;
        private System.Windows.Forms.Button MarkAllBtn;
        private System.Windows.Forms.ToolTip DescrObjectTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
    }
}