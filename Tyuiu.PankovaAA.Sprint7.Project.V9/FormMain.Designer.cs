namespace Tyuiu.PankovaPAA.Sprint7.App
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

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
            this.labelTitle_PAA = new System.Windows.Forms.Label();
            this.buttonExit_PAA = new System.Windows.Forms.Button();
            this.labelStatus_PAA = new System.Windows.Forms.Label();
            this.dataGridViewClips_PAA = new System.Windows.Forms.DataGridView();
            this.buttonDemo_PAA = new System.Windows.Forms.Button();
            this.buttonOpen_PAA = new System.Windows.Forms.Button();
            this.buttonSave_PAA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle_PAA
            // 
            this.labelTitle_PAA.AutoSize = true;
            this.labelTitle_PAA.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle_PAA.Location = new System.Drawing.Point(20, 20);
            this.labelTitle_PAA.Name = "labelTitle_PAA";
            this.labelTitle_PAA.Size = new System.Drawing.Size(251, 30);
            this.labelTitle_PAA.TabIndex = 0;
            this.labelTitle_PAA.Text = "Каталог видеоклипов";
            // 
            // buttonDemo_PAA
            // 
            this.buttonDemo_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDemo_PAA.Location = new System.Drawing.Point(530, 22);
            this.buttonDemo_PAA.Name = "buttonDemo_PAA";
            this.buttonDemo_PAA.Size = new System.Drawing.Size(80, 27);
            this.buttonDemo_PAA.TabIndex = 1;
            this.buttonDemo_PAA.Text = "Demo";
            this.buttonDemo_PAA.UseVisualStyleBackColor = true;
            this.buttonDemo_PAA.Click += new System.EventHandler(this.buttonDemo_PAA_Click);
            // 
            // buttonOpen_PAA
            // 
            this.buttonOpen_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen_PAA.Location = new System.Drawing.Point(616, 22);
            this.buttonOpen_PAA.Name = "buttonOpen_PAA";
            this.buttonOpen_PAA.Size = new System.Drawing.Size(80, 27);
            this.buttonOpen_PAA.TabIndex = 2;
            this.buttonOpen_PAA.Text = "Открыть";
            this.buttonOpen_PAA.UseVisualStyleBackColor = true;
            this.buttonOpen_PAA.Click += new System.EventHandler(this.buttonOpen_PAA_Click);
            // 
            // buttonSave_PAA
            // 
            this.buttonSave_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave_PAA.Location = new System.Drawing.Point(702, 22);
            this.buttonSave_PAA.Name = "buttonSave_PAA";
            this.buttonSave_PAA.Size = new System.Drawing.Size(90, 27);
            this.buttonSave_PAA.TabIndex = 3;
            this.buttonSave_PAA.Text = "Сохранить";
            this.buttonSave_PAA.UseVisualStyleBackColor = true;
            this.buttonSave_PAA.Click += new System.EventHandler(this.buttonSave_PAA_Click);
            //
            // dataGridViewClips_PAA
            // 
            this.dataGridViewClips_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClips_PAA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClips_PAA.Location = new System.Drawing.Point(20, 70);
            this.dataGridViewClips_PAA.Name = "dataGridViewClips_PAA";
            this.dataGridViewClips_PAA.Size = new System.Drawing.Size(772, 420);
            this.dataGridViewClips_PAA.TabIndex = 4;
            // 
            // buttonExit_PAA
            // 
            this.buttonExit_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit_PAA.Location = new System.Drawing.Point(717, 515);
            this.buttonExit_PAA.Name = "buttonExit_PAA";
            this.buttonExit_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonExit_PAA.TabIndex = 6;
            this.buttonExit_PAA.Text = "Выход";
            this.buttonExit_PAA.UseVisualStyleBackColor = true;
            this.buttonExit_PAA.Click += new System.EventHandler(this.buttonExit_PAA_Click);
            // 
            // labelStatus_PAA
            // 
            this.labelStatus_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus_PAA.AutoSize = true;
            this.labelStatus_PAA.Location = new System.Drawing.Point(20, 519);
            this.labelStatus_PAA.Name = "labelStatus_PAA";
            this.labelStatus_PAA.Size = new System.Drawing.Size(118, 15);
            this.labelStatus_PAA.TabIndex = 5;
            this.labelStatus_PAA.Text = "Готово. Клип(ов): 0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 560);
            this.Controls.Add(this.buttonSave_PAA);
            this.Controls.Add(this.buttonOpen_PAA);
            this.Controls.Add(this.buttonDemo_PAA);
            this.Controls.Add(this.dataGridViewClips_PAA);
            this.Controls.Add(this.labelStatus_PAA);
            this.Controls.Add(this.buttonExit_PAA);
            this.Controls.Add(this.labelTitle_PAA);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог видеоклипов";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}