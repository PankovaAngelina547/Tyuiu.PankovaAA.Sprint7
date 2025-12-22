
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tyuiu.PankovaPAA.Sprint7.App
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStripMain_PAA;
        private ToolStripMenuItem menuFile_PAA;
        private ToolStripMenuItem menuOpen_PAA;
        private ToolStripMenuItem menuSave_PAA;
        private ToolStripMenuItem menuExit_PAA;

        private ToolStripMenuItem menuData_PAA;
        private ToolStripMenuItem menuDemo_PAA;

        private ToolStripMenuItem menuHelp_PAA;
        private ToolStripMenuItem menuAbout_PAA;
        private ToolStripMenuItem menuGuide_PAA;

        private ToolStrip toolStripMain_PAA;
        private ToolStripButton toolDemo_PAA;
        private ToolStripButton toolOpen_PAA;
        private ToolStripButton toolSave_PAA;

        private Label labelTitle_PAA;
        private Label labelStatus_PAA;

        private DataGridView dataGridViewClips_PAA;

        private GroupBox groupBoxStats_PAA;
        private Label labelStats_PAA;
        private Chart chartThemes_PAA;

        private Button buttonExit_PAA;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStripMain_PAA = new MenuStrip();
            this.menuFile_PAA = new ToolStripMenuItem();
            this.menuOpen_PAA = new ToolStripMenuItem();
            this.menuSave_PAA = new ToolStripMenuItem();
            this.menuExit_PAA = new ToolStripMenuItem();

            this.menuData_PAA = new ToolStripMenuItem();
            this.menuDemo_PAA = new ToolStripMenuItem();

            this.menuHelp_PAA = new ToolStripMenuItem();
            this.menuAbout_PAA = new ToolStripMenuItem();
            this.menuGuide_PAA = new ToolStripMenuItem();

            this.toolStripMain_PAA = new ToolStrip();
            this.toolDemo_PAA = new ToolStripButton();
            this.toolOpen_PAA = new ToolStripButton();
            this.toolSave_PAA = new ToolStripButton();

            this.labelTitle_PAA = new Label();
            this.labelStatus_PAA = new Label();
            this.dataGridViewClips_PAA = new DataGridView();
            this.groupBoxStats_PAA = new GroupBox();
            this.labelStats_PAA = new Label();
            this.chartThemes_PAA = new Chart();
            this.buttonExit_PAA = new Button();

            ChartArea chartArea = new ChartArea();
            Series series = new Series();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThemes_PAA)).BeginInit();

            // MenuStrip
            this.menuStripMain_PAA.Items.AddRange(new ToolStripItem[] {
                this.menuFile_PAA,
                this.menuData_PAA,
                this.menuHelp_PAA
            });

            this.menuFile_PAA.Text = "Файл";
            this.menuFile_PAA.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuOpen_PAA,
                this.menuSave_PAA,
                new ToolStripSeparator(),
                this.menuExit_PAA
            });

            this.menuOpen_PAA.Text = "Открыть";
            this.menuOpen_PAA.Click += (s, e) => buttonOpen_PAA_Click(s, e);

            this.menuSave_PAA.Text = "Сохранить";
            this.menuSave_PAA.Click += (s, e) => buttonSave_PAA_Click(s, e);

            this.menuExit_PAA.Text = "Выход";
            this.menuExit_PAA.Click += (s, e) => Close();

            this.menuData_PAA.Text = "Данные";
            this.menuData_PAA.DropDownItems.Add(this.menuDemo_PAA);
            this.menuDemo_PAA.Text = "Demo";
            this.menuDemo_PAA.Click += (s, e) => buttonDemo_PAA_Click(s, e);

            this.menuHelp_PAA.Text = "Справка";
            this.menuHelp_PAA.DropDownItems.AddRange(new ToolStripItem[] {


this.menuAbout_PAA,
                this.menuGuide_PAA
            });

            this.menuAbout_PAA.Text = "О программе";
            this.menuAbout_PAA.Click += toolStripMenuItemAbout_PAA_Click;

            this.menuGuide_PAA.Text = "Руководство";
            this.menuGuide_PAA.Click += toolStripMenuItemGuide_PAA_Click;

            // ToolStrip
            this.toolStripMain_PAA.Items.AddRange(new ToolStripItem[] {
                this.toolDemo_PAA,
                this.toolOpen_PAA,
                this.toolSave_PAA
            });

            this.toolDemo_PAA.Text = "Demo";
            this.toolDemo_PAA.Click += buttonDemo_PAA_Click;

            this.toolOpen_PAA.Text = "Открыть";
            this.toolOpen_PAA.Click += buttonOpen_PAA_Click;

            this.toolSave_PAA.Text = "Сохранить";
            this.toolSave_PAA.Click += buttonSave_PAA_Click;

            // Title
            this.labelTitle_PAA.Text = "Каталог видеоклипов";
            this.labelTitle_PAA.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle_PAA.Location = new System.Drawing.Point(20, 60);

            // DataGridView
            this.dataGridViewClips_PAA.Location = new System.Drawing.Point(20, 100);
            this.dataGridViewClips_PAA.Size = new System.Drawing.Size(900, 300);
            this.dataGridViewClips_PAA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Stats
            this.groupBoxStats_PAA.Text = "Статистика";
            this.groupBoxStats_PAA.Location = new System.Drawing.Point(20, 410);
            this.groupBoxStats_PAA.Size = new System.Drawing.Size(420, 120);

            this.labelStats_PAA.Location = new System.Drawing.Point(10, 20);
            this.labelStats_PAA.Size = new System.Drawing.Size(400, 90);

            this.groupBoxStats_PAA.Controls.Add(this.labelStats_PAA);

            // Chart
            chartArea.AxisX.Interval = 1;
            this.chartThemes_PAA.ChartAreas.Add(chartArea);

            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            this.chartThemes_PAA.Series.Add(series);

            this.chartThemes_PAA.Location = new System.Drawing.Point(460, 410);
            this.chartThemes_PAA.Size = new System.Drawing.Size(460, 220);

            // Status
            this.labelStatus_PAA.Location = new System.Drawing.Point(20, 640);
            this.labelStatus_PAA.Text = "Готово";

            // Exit
            this.buttonExit_PAA.Text = "Выход";
            this.buttonExit_PAA.Location = new System.Drawing.Point(845, 640);
            this.buttonExit_PAA.Click += (s, e) => Close();

            // Form
            this.ClientSize = new System.Drawing.Size(940, 680);
            this.Controls.AddRange(new Control[] {
                this.menuStripMain_PAA,
                this.toolStripMain_PAA,
                this.labelTitle_PAA,
                this.dataGridViewClips_PAA,
                this.groupBoxStats_PAA,
                this.chartThemes_PAA,
                this.labelStatus_PAA,
                this.buttonExit_PAA
            });

            this.MainMenuStrip = this.menuStripMain_PAA;
            this.Text = "Каталог видеоклипов";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThemes_PAA)).EndInit();
        }
    }
}