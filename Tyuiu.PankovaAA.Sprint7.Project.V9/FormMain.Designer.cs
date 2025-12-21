namespace Tyuiu.PankovaPAA.Sprint7.App
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStripMain_PAA;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile_PAA;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen_PAA;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave_PAA;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit_PAA;

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemData_PAA;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDemo_PAA;

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp_PAA;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout_PAA;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGuide_PAA;

        private System.Windows.Forms.ToolStrip toolStripMain_PAA;
        private System.Windows.Forms.ToolStripButton toolStripButtonDemo_PAA;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen_PAA;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave_PAA;

        private System.Windows.Forms.ToolTip toolTipMain_PAA;

        private System.Windows.Forms.Label labelTitle_PAA;
        private System.Windows.Forms.Label labelStatus_PAA;
        private System.Windows.Forms.Button buttonExit_PAA;

        private System.Windows.Forms.DataGridView dataGridViewClips_PAA;

        // Панель управления (поиск/фильтр/сорт/CRUD)
        private System.Windows.Forms.Panel panelControls_PAA;
        private System.Windows.Forms.Label labelSearch_PAA;
        private System.Windows.Forms.TextBox textBoxSearch_PAA;

        private System.Windows.Forms.Label labelTheme_PAA;
        private System.Windows.Forms.ComboBox comboBoxTheme_PAA;

        private System.Windows.Forms.Label labelSort_PAA;
        private System.Windows.Forms.ComboBox comboBoxSort_PAA;

        private System.Windows.Forms.Button buttonApply_PAA;
        private System.Windows.Forms.Button buttonReset_PAA;

        private System.Windows.Forms.Button buttonAdd_PAA;
        private System.Windows.Forms.Button buttonEdit_PAA;
        private System.Windows.Forms.Button buttonDelete_PAA;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.menuStripMain_PAA = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit_PAA = new System.Windows.Forms.ToolStripMenuItem();

            this.toolStripMenuItemData_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDemo_PAA = new System.Windows.Forms.ToolStripMenuItem();

            this.toolStripMenuItemHelp_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGuide_PAA = new System.Windows.Forms.ToolStripMenuItem();

            this.toolStripMain_PAA = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDemo_PAA = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen_PAA = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave_PAA = new System.Windows.Forms.ToolStripButton();

            this.toolTipMain_PAA = new System.Windows.Forms.ToolTip(this.components);

            this.labelTitle_PAA = new System.Windows.Forms.Label();

this.labelStatus_PAA = new System.Windows.Forms.Label();
            this.buttonExit_PAA = new System.Windows.Forms.Button();

            this.panelControls_PAA = new System.Windows.Forms.Panel();
            this.labelSearch_PAA = new System.Windows.Forms.Label();
            this.textBoxSearch_PAA = new System.Windows.Forms.TextBox();
            this.labelTheme_PAA = new System.Windows.Forms.Label();
            this.comboBoxTheme_PAA = new System.Windows.Forms.ComboBox();
            this.labelSort_PAA = new System.Windows.Forms.Label();
            this.comboBoxSort_PAA = new System.Windows.Forms.ComboBox();
            this.buttonApply_PAA = new System.Windows.Forms.Button();
            this.buttonReset_PAA = new System.Windows.Forms.Button();
            this.buttonAdd_PAA = new System.Windows.Forms.Button();
            this.buttonEdit_PAA = new System.Windows.Forms.Button();
            this.buttonDelete_PAA = new System.Windows.Forms.Button();

            this.dataGridViewClips_PAA = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).BeginInit();
            this.menuStripMain_PAA.SuspendLayout();
            this.toolStripMain_PAA.SuspendLayout();
            this.panelControls_PAA.SuspendLayout();
            this.SuspendLayout();

            // -------------------- MenuStrip --------------------
            this.menuStripMain_PAA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripMenuItemFile_PAA,
                this.toolStripMenuItemData_PAA,
                this.toolStripMenuItemHelp_PAA
            });
            this.menuStripMain_PAA.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain_PAA.Name = "menuStripMain_PAA";
            this.menuStripMain_PAA.Size = new System.Drawing.Size(980, 24);
            this.menuStripMain_PAA.TabIndex = 0;

            // File
            this.toolStripMenuItemFile_PAA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripMenuItemOpen_PAA,
                this.toolStripMenuItemSave_PAA,
                new System.Windows.Forms.ToolStripSeparator(),
                this.toolStripMenuItemExit_PAA
            });
            this.toolStripMenuItemFile_PAA.Name = "toolStripMenuItemFile_PAA";
            this.toolStripMenuItemFile_PAA.Text = "Файл";

            this.toolStripMenuItemOpen_PAA.Name = "toolStripMenuItemOpen_PAA";
            this.toolStripMenuItemOpen_PAA.Text = "Открыть CSV";
            this.toolStripMenuItemOpen_PAA.Click += new System.EventHandler(this.buttonOpen_PAA_Click);

            this.toolStripMenuItemSave_PAA.Name = "toolStripMenuItemSave_PAA";
            this.toolStripMenuItemSave_PAA.Text = "Сохранить CSV";
            this.toolStripMenuItemSave_PAA.Click += new System.EventHandler(this.buttonSave_PAA_Click);

            this.toolStripMenuItemExit_PAA.Name = "toolStripMenuItemExit_PAA";
            this.toolStripMenuItemExit_PAA.Text = "Выход";
            this.toolStripMenuItemExit_PAA.Click += new System.EventHandler(this.buttonExit_PAA_Click);

            // Data
            this.toolStripMenuItemData_PAA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripMenuItemDemo_PAA
            });
            this.toolStripMenuItemData_PAA.Name = "toolStripMenuItemData_PAA";
            this.toolStripMenuItemData_PAA.Text = "Данные";

            this.toolStripMenuItemDemo_PAA.Name = "toolStripMenuItemDemo_PAA";
            this.toolStripMenuItemDemo_PAA.Text = "Demo";
            this.toolStripMenuItemDemo_PAA.Click += new System.EventHandler(this.buttonDemo_PAA_Click);

            // Help
            this.toolStripMenuItemHelp_PAA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripMenuItemAbout_PAA,
                this.toolStripMenuItemGuide_PAA
            });
            this.toolStripMenuItemHelp_PAA.Name = "toolStripMenuItemHelp_PAA";
            this.


toolStripMenuItemHelp_PAA.Text = "Справка";

            this.toolStripMenuItemAbout_PAA.Name = "toolStripMenuItemAbout_PAA";
            this.toolStripMenuItemAbout_PAA.Text = "О программе";
            this.toolStripMenuItemAbout_PAA.Click += new System.EventHandler(this.toolStripMenuItemAbout_PAA_Click);

            this.toolStripMenuItemGuide_PAA.Name = "toolStripMenuItemGuide_PAA";
            this.toolStripMenuItemGuide_PAA.Text = "Руководство";
            this.toolStripMenuItemGuide_PAA.Click += new System.EventHandler(this.toolStripMenuItemGuide_PAA_Click);

            // -------------------- ToolStrip --------------------
            this.toolStripMain_PAA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripButtonDemo_PAA,
                this.toolStripButtonOpen_PAA,
                this.toolStripButtonSave_PAA
            });
            this.toolStripMain_PAA.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain_PAA.Name = "toolStripMain_PAA";
            this.toolStripMain_PAA.Size = new System.Drawing.Size(980, 25);
            this.toolStripMain_PAA.TabIndex = 1;

            this.toolStripButtonDemo_PAA.Name = "toolStripButtonDemo_PAA";
            this.toolStripButtonDemo_PAA.Text = "Demo";
            this.toolStripButtonDemo_PAA.ToolTipText = "Загрузить демонстрационные данные";
            this.toolStripButtonDemo_PAA.Click += new System.EventHandler(this.buttonDemo_PAA_Click);

            this.toolStripButtonOpen_PAA.Name = "toolStripButtonOpen_PAA";
            this.toolStripButtonOpen_PAA.Text = "Открыть";
            this.toolStripButtonOpen_PAA.ToolTipText = "Загрузить данные из CSV (папка Data)";
            this.toolStripButtonOpen_PAA.Click += new System.EventHandler(this.buttonOpen_PAA_Click);

            this.toolStripButtonSave_PAA.Name = "toolStripButtonSave_PAA";
            this.toolStripButtonSave_PAA.Text = "Сохранить";
            this.toolStripButtonSave_PAA.ToolTipText = "Сохранить данные в CSV (папка Data)";
            this.toolStripButtonSave_PAA.Click += new System.EventHandler(this.buttonSave_PAA_Click);

            // -------------------- Title --------------------
            this.labelTitle_PAA.AutoSize = true;
            this.labelTitle_PAA.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle_PAA.Location = new System.Drawing.Point(20, 60);
            this.labelTitle_PAA.Name = "labelTitle_PAA";
            this.labelTitle_PAA.Size = new System.Drawing.Size(251, 30);
            this.labelTitle_PAA.TabIndex = 2;
            this.labelTitle_PAA.Text = "Каталог видеоклипов";

            // -------------------- panelControls --------------------
            this.panelControls_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls_PAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls_PAA.Controls.Add(this.labelSearch_PAA);
            this.panelControls_PAA.Controls.Add(this.textBoxSearch_PAA);
            this.panelControls_PAA.Controls.Add(this.labelTheme_PAA);
            this.panelControls_PAA.Controls.Add(this.comboBoxTheme_PAA);
            this.panelControls_PAA.Controls.Add(this.labelSort_PAA);
            this.panelControls_PAA.Controls.Add(this.comboBoxSort_PAA);
            this.panelControls_PAA.Controls.Add(this.buttonApply_PAA);
            this.panelControls_PAA.Controls.Add(this.buttonReset_PAA);
            this.panelControls_PAA.Controls.Add(this.buttonAdd_PAA);
            this.panelControls_PAA.Controls.Add(this.buttonEdit_PAA);
            this.panelControls_PAA.Controls.Add(this.buttonDelete_PAA);
            this.panelControls_PAA.Location = new System.Drawing.Point(20, 105);
            this.panelControls_PAA.Name = "panelControls_PAA";
            this.panelControls_PAA.Size = new System.Drawing.Size(940, 68);
            this.


panelControls_PAA.TabIndex = 3;

            // Search
            this.labelSearch_PAA.AutoSize = true;
            this.labelSearch_PAA.Location = new System.Drawing.Point(10, 10);
            this.labelSearch_PAA.Name = "labelSearch_PAA";
            this.labelSearch_PAA.Size = new System.Drawing.Size(42, 15);
            this.labelSearch_PAA.TabIndex = 0;
            this.labelSearch_PAA.Text = "Поиск";

            this.textBoxSearch_PAA.Location = new System.Drawing.Point(10, 30);
            this.textBoxSearch_PAA.Name = "textBoxSearch_PAA";
            this.textBoxSearch_PAA.Size = new System.Drawing.Size(210, 23);
            this.textBoxSearch_PAA.TabIndex = 1;

            // Theme filter
            this.labelTheme_PAA.AutoSize = true;
            this.labelTheme_PAA.Location = new System.Drawing.Point(235, 10);
            this.labelTheme_PAA.Name = "labelTheme_PAA";
            this.labelTheme_PAA.Size = new System.Drawing.Size(40, 15);
            this.labelTheme_PAA.TabIndex = 2;
            this.labelTheme_PAA.Text = "Тема";

            this.comboBoxTheme_PAA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTheme_PAA.FormattingEnabled = true;
            this.comboBoxTheme_PAA.Location = new System.Drawing.Point(235, 30);
            this.comboBoxTheme_PAA.Name = "comboBoxTheme_PAA";
            this.comboBoxTheme_PAA.Size = new System.Drawing.Size(160, 23);
            this.comboBoxTheme_PAA.TabIndex = 3;

            // Sort
            this.labelSort_PAA.AutoSize = true;
            this.labelSort_PAA.Location = new System.Drawing.Point(410, 10);
            this.labelSort_PAA.Name = "labelSort_PAA";
            this.labelSort_PAA.Size = new System.Drawing.Size(82, 15);
            this.labelSort_PAA.TabIndex = 4;
            this.labelSort_PAA.Text = "Сортировка";

            this.comboBoxSort_PAA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort_PAA.FormattingEnabled = true;
            this.comboBoxSort_PAA.Location = new System.Drawing.Point(410, 30);
            this.comboBoxSort_PAA.Name = "comboBoxSort_PAA";
            this.comboBoxSort_PAA.Size = new System.Drawing.Size(180, 23);
            this.comboBoxSort_PAA.TabIndex = 5;

            // Apply / Reset
            this.buttonApply_PAA.Location = new System.Drawing.Point(605, 29);
            this.buttonApply_PAA.Name = "buttonApply_PAA";
            this.buttonApply_PAA.Size = new System.Drawing.Size(85, 25);
            this.buttonApply_PAA.TabIndex = 6;
            this.buttonApply_PAA.Text = "Применить";
            this.buttonApply_PAA.UseVisualStyleBackColor = true;
            this.buttonApply_PAA.Click += new System.EventHandler(this.buttonApply_PAA_Click);

            this.buttonReset_PAA.Location = new System.Drawing.Point(695, 29);
            this.buttonReset_PAA.Name = "buttonReset_PAA";
            this.buttonReset_PAA.Size = new System.Drawing.Size(75, 25);
            this.buttonReset_PAA.TabIndex = 7;
            this.buttonReset_PAA.Text = "Сброс";
            this.buttonReset_PAA.UseVisualStyleBackColor = true;
            this.buttonReset_PAA.Click += new System.EventHandler(this.buttonReset_PAA_Click);

            // CRUD buttons
            this.buttonAdd_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd_PAA.Location = new System.Drawing.Point(775, 9);
            this.buttonAdd_PAA.Name = "buttonAdd_PAA";
            this.buttonAdd_PAA.Size = new System.Drawing.Size(150, 25);
            this.buttonAdd_PAA.TabIndex = 8;
            this.buttonAdd_PAA.Text = "Добавить клип";
            this.buttonAdd_PAA.UseVisualStyleBackColor = true;
            this.buttonAdd_PAA.Click += new System.EventHandler(this.buttonAdd_PAA_Click);

            this.buttonEdit_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit_PAA.


Location = new System.Drawing.Point(775, 36);
            this.buttonEdit_PAA.Name = "buttonEdit_PAA";
            this.buttonEdit_PAA.Size = new System.Drawing.Size(150, 25);
            this.buttonEdit_PAA.TabIndex = 9;
            this.buttonEdit_PAA.Text = "Изменить";
            this.buttonEdit_PAA.UseVisualStyleBackColor = true;
            this.buttonEdit_PAA.Click += new System.EventHandler(this.buttonEdit_PAA_Click);

            this.buttonDelete_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete_PAA.Location = new System.Drawing.Point(775, 63);
            this.buttonDelete_PAA.Visible = false; // место зарезервировано, кнопка ниже таблицы будет удобнее
            this.buttonDelete_PAA.Name = "buttonDelete_PAA";
            this.buttonDelete_PAA.Size = new System.Drawing.Size(150, 25);
            this.buttonDelete_PAA.TabIndex = 10;
            this.buttonDelete_PAA.Text = "Удалить";
            this.buttonDelete_PAA.UseVisualStyleBackColor = true;

            // -------------------- DataGridView --------------------
            this.dataGridViewClips_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClips_PAA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClips_PAA.Location = new System.Drawing.Point(20, 180);
            this.dataGridViewClips_PAA.Name = "dataGridViewClips_PAA";
            this.dataGridViewClips_PAA.Size = new System.Drawing.Size(940, 360);
            this.dataGridViewClips_PAA.TabIndex = 4;

            // -------------------- Status + Exit --------------------
            this.labelStatus_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus_PAA.AutoSize = true;
            this.labelStatus_PAA.Location = new System.Drawing.Point(20, 554);
            this.labelStatus_PAA.Name = "labelStatus_PAA";
            this.labelStatus_PAA.Size = new System.Drawing.Size(118, 15);
            this.labelStatus_PAA.TabIndex = 5;
            this.labelStatus_PAA.Text = "Готово. Клип(ов): 0";

            this.buttonExit_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit_PAA.Location = new System.Drawing.Point(885, 550);
            this.buttonExit_PAA.Name = "buttonExit_PAA";
            this.buttonExit_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonExit_PAA.TabIndex = 6;
            this.buttonExit_PAA.Text = "Выход";
            this.buttonExit_PAA.UseVisualStyleBackColor = true;
            this.buttonExit_PAA.Click += new System.EventHandler(this.buttonExit_PAA_Click);

            // -------------------- ToolTip --------------------
            this.toolTipMain_PAA.SetToolTip(this.textBoxSearch_PAA, "Поиск по коду и теме (частичное совпадение)");
            this.toolTipMain_PAA.SetToolTip(this.comboBoxTheme_PAA, "Фильтр по теме");
            this.toolTipMain_PAA.SetToolTip(this.comboBoxSort_PAA, "Выбор сортировки");
            this.toolTipMain_PAA.SetToolTip(this.buttonApply_PAA, "Применить поиск/фильтр/сортировку");
            this.toolTipMain_PAA.SetToolTip(this.buttonReset_PAA, "Сбросить фильтры и показать всё");
            this.toolTipMain_PAA.SetToolTip(this.buttonAdd_PAA, "Добавить новый видеоклип");
            this.toolTipMain_PAA.SetToolTip(this.buttonEdit_PAA, "Редактировать выбранный клип");
            this.toolTipMain_PAA.SetToolTip(this.dataGridViewClips_PAA, "Таблица каталога видеоклипов");

            // -------------------- FormMain --------------------
            this.AutoScaleDimensions = new System.


Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 585);

            this.Controls.Add(this.toolStripMain_PAA);
            this.Controls.Add(this.menuStripMain_PAA);

            this.Controls.Add(this.labelTitle_PAA);
            this.Controls.Add(this.panelControls_PAA);
            this.Controls.Add(this.dataGridViewClips_PAA);
            this.Controls.Add(this.labelStatus_PAA);
            this.Controls.Add(this.buttonExit_PAA);

            this.MainMenuStrip = this.menuStripMain_PAA;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог видеоклипов";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).EndInit();
            this.menuStripMain_PAA.ResumeLayout(false);
            this.menuStripMain_PAA.PerformLayout();
            this.toolStripMain_PAA.ResumeLayout(false);
            this.toolStripMain_PAA.PerformLayout();
            this.panelControls_PAA.ResumeLayout(false);
            this.panelControls_PAA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}