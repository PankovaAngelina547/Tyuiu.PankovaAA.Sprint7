namespace Tyuiu.PankovaAA.Sprint7.Project.V9
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dataGridViewMain_PAA = new System.Windows.Forms.DataGridView();
            this.menuStrip_PAA = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBottom_PAA = new System.Windows.Forms.Panel();
            this.buttonAbout_PAA = new System.Windows.Forms.Button();
            this.buttonHelp_PAA = new System.Windows.Forms.Button();
            this.labelSortInfo_PAA = new System.Windows.Forms.Label();
            this.labelFilterInfo_PAA = new System.Windows.Forms.Label();
            this.labelStats_PAA = new System.Windows.Forms.Label();
            this.toolTip_PAA = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain_PAA)).BeginInit();
            this.menuStrip_PAA.SuspendLayout();
            this.panelBottom_PAA.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMain_PAA
            // 
            this.dataGridViewMain_PAA.AllowUserToAddRows = false;
            this.dataGridViewMain_PAA.AllowUserToDeleteRows = false;
            this.dataGridViewMain_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMain_PAA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMain_PAA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain_PAA.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewMain_PAA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewMain_PAA.Name = "dataGridViewMain_PAA";
            this.dataGridViewMain_PAA.ReadOnly = true;
            this.dataGridViewMain_PAA.RowHeadersWidth = 62;
            this.dataGridViewMain_PAA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMain_PAA.Size = new System.Drawing.Size(1200, 500);
            this.dataGridViewMain_PAA.TabIndex = 0;
            this.dataGridViewMain_PAA.SelectionChanged += new System.EventHandler(this.dataGridViewMain_PAA_SelectionChanged);
            // 
            // menuStrip_PAA
            // 
            this.menuStrip_PAA.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip_PAA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.редактированиеToolStripMenuItem,
            this.анализToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip_PAA.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_PAA.Name = "menuStrip_PAA";
            this.menuStrip_PAA.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip_PAA.Size = new System.Drawing.Size(1200, 35);
            this.menuStrip_PAA.TabIndex = 1;
            this.menuStrip_PAA.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(186, 34);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(186, 34);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(186, 34);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(154, 29);
            this.редактированиеToolStripMenuItem.Text = "Редактирование";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(225, 34);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(225, 34);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(225, 34);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // анализToolStripMenuItem
            // 
            this.анализToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статистикаToolStripMenuItem,
            this.графикToolStripMenuItem});
            this.анализToolStripMenuItem.Name = "анализToolStripMenuItem";
            this.анализToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.анализToolStripMenuItem.Text = "Анализ";
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(199, 34);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            this.статистикаToolStripMenuItem.Click += new System.EventHandler(this.статистикаToolStripMenuItem_Click);
            // 
            // графикToolStripMenuItem
            // 
            this.графикToolStripMenuItem.Name = "графикToolStripMenuItem";
            this.графикToolStripMenuItem.Size = new System.Drawing.Size(199, 34);
            this.графикToolStripMenuItem.Text = "График";
            this.графикToolStripMenuItem.Click += new System.EventHandler(this.графикToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(95, 29);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(222, 34);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.buttonAbout_PAA_Click);
            // 
            // panelBottom_PAA
            // 
            this.panelBottom_PAA.Controls.Add(this.buttonAbout_PAA);
            this.panelBottom_PAA.Controls.Add(this.buttonHelp_PAA);
            this.panelBottom_PAA.Controls.Add(this.labelSortInfo_PAA);
            this.panelBottom_PAA.Controls.Add(this.labelFilterInfo_PAA);
            this.panelBottom_PAA.Controls.Add(this.labelStats_PAA);
            this.panelBottom_PAA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom_PAA.Location = new System.Drawing.Point(0, 600);
            this.panelBottom_PAA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottom_PAA.Name = "panelBottom_PAA";
            this.panelBottom_PAA.Size = new System.Drawing.Size(1200, 100);
            this.panelBottom_PAA.TabIndex = 2;
            // 
            // buttonAbout_PAA
            // 
            this.buttonAbout_PAA.Location = new System.Drawing.Point(1090, 30);
            this.buttonAbout_PAA.Name = "buttonAbout_PAA";
            this.buttonAbout_PAA.Size = new System.Drawing.Size(90, 40);
            this.buttonAbout_PAA.TabIndex = 5;
            this.buttonAbout_PAA.Text = "О прогр.";
            this.buttonAbout_PAA.UseVisualStyleBackColor = true;
            this.buttonAbout_PAA.Click += new System.EventHandler(this.buttonAbout_PAA_Click);
            // 
            // buttonHelp_PAA
            // 
            this.buttonHelp_PAA.Location = new System.Drawing.Point(1000, 30);
            this.buttonHelp_PAA.Name = "buttonHelp_PAA";
            this.buttonHelp_PAA.Size = new System.Drawing.Size(80, 40);
            this.buttonHelp_PAA.TabIndex = 4;
            this.buttonHelp_PAA.Text = "Справка";
            this.buttonHelp_PAA.UseVisualStyleBackColor = true;
            this.buttonHelp_PAA.Click += new System.EventHandler(this.buttonHelp_PAA_Click);
            // 
            // labelSortInfo_PAA
            // 
            this.labelSortInfo_PAA.AutoSize = true;
            this.labelSortInfo_PAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSortInfo_PAA.ForeColor = System.Drawing.Color.Blue;
            this.labelSortInfo_PAA.Location = new System.Drawing.Point(300, 70);
            this.labelSortInfo_PAA.Name = "labelSortInfo_PAA";
            this.labelSortInfo_PAA.Size = new System.Drawing.Size(0, 20);
            this.labelSortInfo_PAA.TabIndex = 3;
            // 
            // labelFilterInfo_PAA
            // 
            this.labelFilterInfo_PAA.AutoSize = true;
            this.labelFilterInfo_PAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFilterInfo_PAA.ForeColor = System.Drawing.Color.Green;
            this.labelFilterInfo_PAA.Location = new System.Drawing.Point(300, 40);
            this.labelFilterInfo_PAA.Name = "labelFilterInfo_PAA";
            this.labelFilterInfo_PAA.Size = new System.Drawing.Size(0, 20);
            this.labelFilterInfo_PAA.TabIndex = 2;
            // 
            // labelStats_PAA
            // 
            this.labelStats_PAA.AutoSize = true;
            this.labelStats_PAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStats_PAA.Location = new System.Drawing.Point(20, 40);
            this.labelStats_PAA.Name = "labelStats_PAA";
            this.labelStats_PAA.Size = new System.Drawing.Size(20, 25);
            this.labelStats_PAA.TabIndex = 1;
            this.labelStats_PAA.Text = "-";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelBottom_PAA);
            this.Controls.Add(this.dataGridViewMain_PAA);
            this.Controls.Add(this.menuStrip_PAA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_PAA;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1222, 756);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог видеоклипов - Панькова А.А.";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain_PAA)).EndInit();
            this.menuStrip_PAA.ResumeLayout(false);
            this.menuStrip_PAA.PerformLayout();
            this.panelBottom_PAA.ResumeLayout(false);
            this.panelBottom_PAA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }



        private System.Windows.Forms.DataGridView dataGridViewMain_PAA;
        private System.Windows.Forms.MenuStrip menuStrip_PAA;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Panel panelBottom_PAA;
        private System.Windows.Forms.Label labelStats_PAA;
        private System.Windows.Forms.Label labelFilterInfo_PAA;
        private System.Windows.Forms.Label labelSortInfo_PAA;
        private System.Windows.Forms.Button buttonHelp_PAA;
        private System.Windows.Forms.Button buttonAbout_PAA;
        private System.Windows.Forms.ToolTip toolTip_PAA;
    }
}
