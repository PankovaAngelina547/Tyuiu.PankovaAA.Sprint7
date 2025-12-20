using Tyuiu.PankovaPAA.Sprint7.App;

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
        private System.Windows.Forms.Button buttonExit_PAA;
        private System.Windows.Forms.Label labelStatus_PAA;

        private System.Windows.Forms.DataGridView dataGridViewClips_PAA;
        private System.Windows.Forms.Button buttonDemo_PAA;
        private System.Windows.Forms.Button buttonOpen_PAA;
        private System.Windows.Forms.Button buttonSave_PAA;

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
            this.buttonExit_PAA = new System.Windows.Forms.Button();
            this.labelStatus_PAA = new System.Windows.Forms.Label();
            this.dataGridViewClips_PAA = new System.Windows.Forms.DataGridView();
            this.buttonDemo_PAA = new System.Windows.Forms.Button();
            this.buttonOpen_PAA = new System.Windows.Forms.Button();
            this.buttonSave_PAA = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).BeginInit();
            this.menuStripMain_PAA.SuspendLayout();


this.toolStripMain_PAA.SuspendLayout();
            this.SuspendLayout();

            // -------------------- MenuStrip --------------------
            this.menuStripMain_PAA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripMenuItemFile_PAA,
                this.toolStripMenuItemData_PAA,
                this.toolStripMenuItemHelp_PAA
            });
            this.menuStripMain_PAA.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain_PAA.Name = "menuStripMain_PAA";
            this.menuStripMain_PAA.Size = new System.Drawing.Size(820, 24);
            this.menuStripMain_PAA.TabIndex = 0;
            this.menuStripMain_PAA.Text = "menuStripMain_PAA";

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
            this.toolStripMenuItemHelp_PAA.Text = "Справка";

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
            this.toolStripMain_PAA.Size = new System.Drawing.Size(820, 25);
            this.toolStripMain_PAA.TabIndex = 1;

            this.toolStripButtonDemo_PAA.

Name = "toolStripButtonDemo_PAA";
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

            // -------------------- Buttons (top right) --------------------
            this.buttonDemo_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDemo_PAA.Location = new System.Drawing.Point(530, 63);
            this.buttonDemo_PAA.Name = "buttonDemo_PAA";
            this.buttonDemo_PAA.Size = new System.Drawing.Size(80, 27);
            this.buttonDemo_PAA.TabIndex = 3;
            this.buttonDemo_PAA.Text = "Demo";
            this.buttonDemo_PAA.UseVisualStyleBackColor = true;
            this.buttonDemo_PAA.Click += new System.EventHandler(this.buttonDemo_PAA_Click);

            this.buttonOpen_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen_PAA.Location = new System.Drawing.Point(616, 63);
            this.buttonOpen_PAA.Name = "buttonOpen_PAA";
            this.buttonOpen_PAA.Size = new System.Drawing.Size(80, 27);
            this.buttonOpen_PAA.TabIndex = 4;
            this.buttonOpen_PAA.Text = "Открыть";
            this.buttonOpen_PAA.UseVisualStyleBackColor = true;
            this.buttonOpen_PAA.Click += new System.EventHandler(this.buttonOpen_PAA_Click);

            this.buttonSave_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave_PAA.Location = new System.Drawing.Point(702, 63);
            this.buttonSave_PAA.Name = "buttonSave_PAA";
            this.buttonSave_PAA.Size = new System.Drawing.Size(90, 27);
            this.buttonSave_PAA.TabIndex = 5;
            this.buttonSave_PAA.Text = "Сохранить";
            this.buttonSave_PAA.UseVisualStyleBackColor = true;
            this.buttonSave_PAA.Click += new System.EventHandler(this.buttonSave_PAA_Click);

            // -------------------- DataGridView --------------------
            this.dataGridViewClips_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClips_PAA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClips_PAA.Location = new System.Drawing.Point(20, 105);
            this.dataGridViewClips_PAA.Name = "dataGridViewClips_PAA";

this.dataGridViewClips_PAA.Size = new System.Drawing.Size(772, 385);
            this.dataGridViewClips_PAA.TabIndex = 6;

            // -------------------- Status + Exit --------------------
            this.labelStatus_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus_PAA.AutoSize = true;
            this.labelStatus_PAA.Location = new System.Drawing.Point(20, 519);
            this.labelStatus_PAA.Name = "labelStatus_PAA";
            this.labelStatus_PAA.Size = new System.Drawing.Size(118, 15);
            this.labelStatus_PAA.TabIndex = 7;
            this.labelStatus_PAA.Text = "Готово. Клип(ов): 0";

            this.buttonExit_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit_PAA.Location = new System.Drawing.Point(717, 515);
            this.buttonExit_PAA.Name = "buttonExit_PAA";
            this.buttonExit_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonExit_PAA.TabIndex = 8;
            this.buttonExit_PAA.Text = "Выход";
            this.buttonExit_PAA.UseVisualStyleBackColor = true;
            this.buttonExit_PAA.Click += new System.EventHandler(this.buttonExit_PAA_Click);

            // -------------------- ToolTip --------------------
            this.toolTipMain_PAA.SetToolTip(this.buttonDemo_PAA, "Загрузить демонстрационные данные");
            this.toolTipMain_PAA.SetToolTip(this.buttonOpen_PAA, "Загрузить CSV из папки Data");
            this.toolTipMain_PAA.SetToolTip(this.buttonSave_PAA, "Сохранить CSV в папку Data");
            this.toolTipMain_PAA.SetToolTip(this.dataGridViewClips_PAA, "Таблица каталога видеоклипов");

            // -------------------- FormMain --------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 560);

            this.Controls.Add(this.toolStripMain_PAA);
            this.Controls.Add(this.menuStripMain_PAA);

            this.Controls.Add(this.buttonSave_PAA);
            this.Controls.Add(this.buttonOpen_PAA);
            this.Controls.Add(this.buttonDemo_PAA);
            this.Controls.Add(this.dataGridViewClips_PAA);
            this.Controls.Add(this.labelStatus_PAA);
            this.Controls.Add(this.buttonExit_PAA);
            this.Controls.Add(this.labelTitle_PAA);

            this.MainMenuStrip = this.menuStripMain_PAA;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог видеоклипов";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).EndInit();
            this.menuStripMain_PAA.ResumeLayout(false);
            this.menuStripMain_PAA.PerformLayout();
            this.toolStripMain_PAA.ResumeLayout(false);
            this.toolStripMain_PAA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}