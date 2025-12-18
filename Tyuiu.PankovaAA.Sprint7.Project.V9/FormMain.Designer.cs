namespace Tyuiu.PankovaPAA.Sprint7.App
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelTitle_PAA;
        private System.Windows.Forms.Button buttonExit_PAA;
        private System.Windows.Forms.Label labelStatus_PAA;

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
            // buttonExit_PAA
            // 
            this.buttonExit_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit_PAA.Location = new System.Drawing.Point(697, 515);
            this.buttonExit_PAA.Name = "buttonExit_PAA";
            this.buttonExit_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonExit_PAA.TabIndex = 2;
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
            this.labelStatus_PAA.Size = new System.Drawing.Size(115, 15);
            this.labelStatus_PAA.TabIndex = 3;
            this.labelStatus_PAA.Text = "Data folder: (none)";
            // 
            // FormMain
            // рпоп
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.labelStatus_PAA);
            this.Controls.Add(this.buttonExit_PAA);
            this.Controls.Add(this.labelTitle_PAA);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог видеоклипов";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}