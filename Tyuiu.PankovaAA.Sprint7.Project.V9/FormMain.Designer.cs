using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tyuiu.PankovaPAA.Sprint7
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
        private ToolStripMenuItem menuHelp_PAA;
        private ToolStripMenuItem menuAbout_PAA;
        private ToolStripMenuItem menuGuide_PAA;

        private ToolStrip toolStripMain_PAA;
        private ToolStripButton toolOpen_PAA;
        private ToolStripButton toolSave_PAA;

        private Label labelTitle_PAA;
        private Label labelStatus_PAA;
        private DataGridView dataGridViewClips_PAA;
        private Button buttonExit_PAA;

        private Label labelCount_PAA;
        private Label labelSum_PAA;
        private Label labelAvg_PAA;
        private Label labelMin_PAA;
        private Label labelMax_PAA;
        private TextBox textBoxStats_PAA;

        private GroupBox groupBoxAdd_PAA;
        private Label labelCode_PAA;
        private TextBox textBoxCode_PAA;
        private Label labelTheme_PAA;
        private TextBox textBoxTheme_PAA;
        private Label labelDate_PAA;
        private DateTimePicker dateTimePicker_PAA;
        private Label labelDuration_PAA;
        private NumericUpDown numericUpDownDuration_PAA;
        private Label labelCost_PAA;
        private NumericUpDown numericUpDownCost_PAA;
        private Label labelActor_PAA;
        private ComboBox comboBoxActor_PAA;
        private Button buttonAddClip_PAA;

        private GroupBox groupBoxSearch_PAA;
        private Label labelSearch_PAA;
        private TextBox textBoxSearch_PAA;
        private Button buttonSearch_PAA;
        private Button buttonClearSearch_PAA;

        private GroupBox groupBoxFilter_PAA;
        private Label labelFilterMin_PAA;
        private NumericUpDown numericUpDownFilterMin_PAA;
        private Label labelFilterMax_PAA;
        private NumericUpDown numericUpDownFilterMax_PAA;
        private Button buttonFilter_PAA;

        private GroupBox groupBoxStats_PAA;
        private Label labelStats_PAA;
        private Chart chartThemes_PAA;

        private Button buttonLoad_PAA;
        private Button buttonSave_PAA;
        private Button buttonSort_PAA;
        private Button buttonStats_PAA;
        private Button buttonChart_PAA;
        private Button buttonExportExcel_PAA;
        private Button buttonAbout_PAA;
        private Button buttonHelp_PAA;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            // Создание всех элементов
            this.menuStripMain_PAA = new System.Windows.Forms.MenuStrip();
            this.menuFile_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuData_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGuide_PAA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain_PAA = new System.Windows.Forms.ToolStrip();
            this.toolOpen_PAA = new System.Windows.Forms.ToolStripButton();
            this.toolSave_PAA = new System.Windows.Forms.ToolStripButton();
            this.labelTitle_PAA = new System.Windows.Forms.Label();
            this.labelStatus_PAA = new System.Windows.Forms.Label();
            this.dataGridViewClips_PAA = new System.Windows.Forms.DataGridView();
            this.buttonExit_PAA = new System.Windows.Forms.Button();

            // Новые элементы
            this.groupBoxAdd_PAA = new System.Windows.Forms.GroupBox();
            this.labelCode_PAA = new System.Windows.Forms.Label();
            this.textBoxCode_PAA = new System.Windows.Forms.TextBox();
            this.labelTheme_PAA = new System.Windows.Forms.Label();
            this.textBoxTheme_PAA = new System.Windows.Forms.TextBox();
            this.labelDate_PAA = new System.Windows.Forms.Label();
            this.dateTimePicker_PAA = new System.Windows.Forms.DateTimePicker();
            this.labelDuration_PAA = new System.Windows.Forms.Label();
            this.numericUpDownDuration_PAA = new System.Windows.Forms.NumericUpDown();
            this.labelCost_PAA = new System.Windows.Forms.Label();
            this.numericUpDownCost_PAA = new System.Windows.Forms.NumericUpDown();
            this.labelActor_PAA = new System.Windows.Forms.Label();
            this.comboBoxActor_PAA = new System.Windows.Forms.ComboBox();
            this.buttonAddClip_PAA = new System.Windows.Forms.Button();
            this.groupBoxSearch_PAA = new System.Windows.Forms.GroupBox();
            this.labelSearch_PAA = new System.Windows.Forms.Label();
            this.textBoxSearch_PAA = new System.Windows.Forms.TextBox();
            this.buttonSearch_PAA = new System.Windows.Forms.Button();
            this.buttonClearSearch_PAA = new System.Windows.Forms.Button();
            this.groupBoxFilter_PAA = new System.Windows.Forms.GroupBox();
            this.labelFilterMin_PAA = new System.Windows.Forms.Label();
            this.numericUpDownFilterMin_PAA = new System.Windows.Forms.NumericUpDown();
            this.labelFilterMax_PAA = new System.Windows.Forms.Label();
            this.numericUpDownFilterMax_PAA = new System.Windows.Forms.NumericUpDown();
            this.buttonFilter_PAA = new System.Windows.Forms.Button();
            this.groupBoxStats_PAA = new System.Windows.Forms.GroupBox();
            this.labelStats_PAA = new System.Windows.Forms.Label();
            this.labelCount_PAA = new System.Windows.Forms.Label();
            this.labelSum_PAA = new System.Windows.Forms.Label();
            this.labelAvg_PAA = new System.Windows.Forms.Label();
            this.labelMin_PAA = new System.Windows.Forms.Label();
            this.labelMax_PAA = new System.Windows.Forms.Label();
            this.textBoxStats_PAA = new System.Windows.Forms.TextBox();
            this.chartThemes_PAA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonLoad_PAA = new System.Windows.Forms.Button();
            this.buttonSave_PAA = new System.Windows.Forms.Button();
            this.buttonSort_PAA = new System.Windows.Forms.Button();
            this.buttonStats_PAA = new System.Windows.Forms.Button();
            this.buttonChart_PAA = new System.Windows.Forms.Button();
            this.buttonExportExcel_PAA = new System.Windows.Forms.Button();
            this.buttonAbout_PAA = new System.Windows.Forms.Button();
            this.buttonHelp_PAA = new System.Windows.Forms.Button();

            // Настройка компонентов
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration_PAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost_PAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilterMin_PAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilterMax_PAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThemes_PAA)).BeginInit();

            // menuStripMain_PAA
            this.menuStripMain_PAA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile_PAA,
            this.menuData_PAA,
            this.menuHelp_PAA});
            this.menuStripMain_PAA.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain_PAA.Name = "menuStripMain_PAA";
            this.menuStripMain_PAA.Size = new System.Drawing.Size(984, 24);
            this.menuStripMain_PAA.TabIndex = 0;

            // menuFile_PAA
            this.menuFile_PAA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen_PAA,
            this.menuSave_PAA,
            new System.Windows.Forms.ToolStripSeparator(),
            this.menuExit_PAA});
            this.menuFile_PAA.Name = "menuFile_PAA";
            this.menuFile_PAA.Size = new System.Drawing.Size(48, 20);
            this.menuFile_PAA.Text = "Файл";

            // menuOpen_PAA
            this.menuOpen_PAA.Name = "menuOpen_PAA";
            this.menuOpen_PAA.Size = new System.Drawing.Size(180, 22);
            this.menuOpen_PAA.Text = "Открыть";
            this.menuOpen_PAA.Click += new System.EventHandler(this.buttonLoad_PAA_Click);

            // menuSave_PAA
            this.menuSave_PAA.Name = "menuSave_PAA";
            this.menuSave_PAA.Size = new System.Drawing.Size(180, 22);
            this.menuSave_PAA.Text = "Сохранить";
            this.menuSave_PAA.Click += new System.EventHandler(this.buttonSave_PAA_Click);

            // menuExit_PAA
            this.menuExit_PAA.Name = "menuExit_PAA";
            this.menuExit_PAA.Size = new System.Drawing.Size(180, 22);
            this.menuExit_PAA.Text = "Выход";
            this.menuExit_PAA.Click += new System.EventHandler(this.buttonExit_PAA_Click);

            // menuData_PAA
            this.menuData_PAA.Name = "menuData_PAA";
            this.menuData_PAA.Size = new System.Drawing.Size(57, 20);
            this.menuData_PAA.Text = "Данные";

            // menuHelp_PAA
            this.menuHelp_PAA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout_PAA,
            this.menuGuide_PAA});
            this.menuHelp_PAA.Name = "menuHelp_PAA";
            this.menuHelp_PAA.Size = new System.Drawing.Size(65, 20);
            this.menuHelp_PAA.Text = "Справка";

            // menuAbout_PAA
            this.menuAbout_PAA.Name = "menuAbout_PAA";
            this.menuAbout_PAA.Size = new System.Drawing.Size(180, 22);
            this.menuAbout_PAA.Text = "О программе";
            this.menuAbout_PAA.Click += new System.EventHandler(this.buttonAbout_PAA_Click);

            // menuGuide_PAA
            this.menuGuide_PAA.Name = "menuGuide_PAA";
            this.menuGuide_PAA.Size = new System.Drawing.Size(180, 22);
            this.menuGuide_PAA.Text = "Руководство";
            this.menuGuide_PAA.Click += new System.EventHandler(this.buttonHelp_PAA_Click);

            // toolStripMain_PAA
            this.toolStripMain_PAA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpen_PAA,
            this.toolSave_PAA});
            this.toolStripMain_PAA.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain_PAA.Name = "toolStripMain_PAA";
            this.toolStripMain_PAA.Size = new System.Drawing.Size(984, 25);
            this.toolStripMain_PAA.TabIndex = 1;

            // toolOpen_PAA
            this.toolOpen_PAA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolOpen_PAA.Image = ((System.Drawing.Image)(resources.GetObject("toolOpen_PAA.Image")));
            this.toolOpen_PAA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpen_PAA.Name = "toolOpen_PAA";
            this.toolOpen_PAA.Size = new System.Drawing.Size(66, 22);
            this.toolOpen_PAA.Text = "Открыть";
            this.toolOpen_PAA.Click += new System.EventHandler(this.buttonLoad_PAA_Click);

            // toolSave_PAA
            this.toolSave_PAA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolSave_PAA.Image = ((System.Drawing.Image)(resources.GetObject("toolSave_PAA.Image")));
            this.toolSave_PAA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave_PAA.Name = "toolSave_PAA";
            this.toolSave_PAA.Size = new System.Drawing.Size(73, 22);
            this.toolSave_PAA.Text = "Сохранить";
            this.toolSave_PAA.Click += new System.EventHandler(this.buttonSave_PAA_Click);

            // labelTitle_PAA
            this.labelTitle_PAA.AutoSize = true;
            this.labelTitle_PAA.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle_PAA.Location = new System.Drawing.Point(20, 55);
            this.labelTitle_PAA.Name = "labelTitle_PAA";
            this.labelTitle_PAA.Size = new System.Drawing.Size(232, 30);
            this.labelTitle_PAA.TabIndex = 2;
            this.labelTitle_PAA.Text = "Каталог видеоклипов";

            // dataGridViewClips_PAA
            this.dataGridViewClips_PAA.AllowUserToAddRows = false;
            this.dataGridViewClips_PAA.AllowUserToDeleteRows = false;
            this.dataGridViewClips_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClips_PAA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClips_PAA.Location = new System.Drawing.Point(20, 90);
            this.dataGridViewClips_PAA.Name = "dataGridViewClips_PAA";
            this.dataGridViewClips_PAA.Size = new System.Drawing.Size(944, 250);
            this.dataGridViewClips_PAA.TabIndex = 3;

            // groupBoxAdd_PAA
            this.groupBoxAdd_PAA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAdd_PAA.Controls.Add(this.labelCode_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.textBoxCode_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.labelTheme_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.textBoxTheme_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.labelDate_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.dateTimePicker_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.labelDuration_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.numericUpDownDuration_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.labelCost_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.numericUpDownCost_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.labelActor_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.comboBoxActor_PAA);
            this.groupBoxAdd_PAA.Controls.Add(this.buttonAddClip_PAA);
            this.groupBoxAdd_PAA.Location = new System.Drawing.Point(20, 350);
            this.groupBoxAdd_PAA.Name = "groupBoxAdd_PAA";
            this.groupBoxAdd_PAA.Size = new System.Drawing.Size(944, 80);
            this.groupBoxAdd_PAA.TabIndex = 4;
            this.groupBoxAdd_PAA.TabStop = false;
            this.groupBoxAdd_PAA.Text = "Добавление нового клипа";

            // labelCode_PAA
            this.labelCode_PAA.AutoSize = true;
            this.labelCode_PAA.Location = new System.Drawing.Point(10, 25);
            this.labelCode_PAA.Name = "labelCode_PAA";
            this.labelCode_PAA.Size = new System.Drawing.Size(29, 13);
            this.labelCode_PAA.TabIndex = 0;
            this.labelCode_PAA.Text = "Код:";

            // textBoxCode_PAA
            this.textBoxCode_PAA.Location = new System.Drawing.Point(45, 22);
            this.textBoxCode_PAA.Name = "textBoxCode_PAA";
            this.textBoxCode_PAA.Size = new System.Drawing.Size(80, 20);
            this.textBoxCode_PAA.TabIndex = 1;

            // labelTheme_PAA
            this.labelTheme_PAA.AutoSize = true;
            this.labelTheme_PAA.Location = new System.Drawing.Point(135, 25);
            this.labelTheme_PAA.Name = "labelTheme_PAA";
            this.labelTheme_PAA.Size = new System.Drawing.Size(37, 13);
            this.labelTheme_PAA.TabIndex = 2;
            this.labelTheme_PAA.Text = "Тема:";

            // textBoxTheme_PAA
            this.textBoxTheme_PAA.Location = new System.Drawing.Point(178, 22);
            this.textBoxTheme_PAA.Name = "textBoxTheme_PAA";
            this.textBoxTheme_PAA.Size = new System.Drawing.Size(120, 20);
            this.textBoxTheme_PAA.TabIndex = 3;

            // labelDate_PAA
            this.labelDate_PAA.AutoSize = true;
            this.labelDate_PAA.Location = new System.Drawing.Point(310, 25);
            this.labelDate_PAA.Name = "labelDate_PAA";
            this.labelDate_PAA.Size = new System.Drawing.Size(36, 13);
            this.labelDate_PAA.TabIndex = 4;
            this.labelDate_PAA.Text = "Дата:";

            // dateTimePicker_PAA
            this.dateTimePicker_PAA.Location = new System.Drawing.Point(352, 22);
            this.dateTimePicker_PAA.Name = "dateTimePicker_PAA";
            this.dateTimePicker_PAA.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker_PAA.TabIndex = 5;

            // labelDuration_PAA
            this.labelDuration_PAA.AutoSize = true;
            this.labelDuration_PAA.Location = new System.Drawing.Point(485, 25);
            this.labelDuration_PAA.Name = "labelDuration_PAA";
            this.labelDuration_PAA.Size = new System.Drawing.Size(73, 13);
            this.labelDuration_PAA.TabIndex = 6;
            this.labelDuration_PAA.Text = "Длительность:";

            // numericUpDownDuration_PAA
            this.numericUpDownDuration_PAA.Location = new System.Drawing.Point(564, 22);
            this.numericUpDownDuration_PAA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDuration_PAA.Name = "numericUpDownDuration_PAA";
            this.numericUpDownDuration_PAA.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownDuration_PAA.TabIndex = 7;
            this.numericUpDownDuration_PAA.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});

            // labelCost_PAA
            this.labelCost_PAA.AutoSize = true;
            this.labelCost_PAA.Location = new System.Drawing.Point(655, 25);
            this.labelCost_PAA.Name = "labelCost_PAA";
            this.labelCost_PAA.Size = new System.Drawing.Size(65, 13);
            this.labelCost_PAA.TabIndex = 8;
            this.labelCost_PAA.Text = "Стоимость:";

            // numericUpDownCost_PAA
            this.numericUpDownCost_PAA.DecimalPlaces = 2;
            this.numericUpDownCost_PAA.Location = new System.Drawing.Point(726, 22);
            this.numericUpDownCost_PAA.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCost_PAA.Name = "numericUpDownCost_PAA";
            this.numericUpDownCost_PAA.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownCost_PAA.TabIndex = 9;

            // labelActor_PAA
            this.labelActor_PAA.AutoSize = true;
            this.labelActor_PAA.Location = new System.Drawing.Point(815, 25);
            this.labelActor_PAA.Name = "labelActor_PAA";
            this.labelActor_PAA.Size = new System.Drawing.Size(41, 13);
            this.labelActor_PAA.TabIndex = 10;
            this.labelActor_PAA.Text = "Актёр:";

            // comboBoxActor_PAA
            this.comboBoxActor_PAA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActor_PAA.FormattingEnabled = true;
            this.comboBoxActor_PAA.Location = new System.Drawing.Point(862, 22);
            this.comboBoxActor_PAA.Name = "comboBoxActor_PAA";
            this.comboBoxActor_PAA.Size = new System.Drawing.Size(70, 21);
            this.comboBoxActor_PAA.TabIndex = 11;

            // buttonAddClip_PAA
            this.buttonAddClip_PAA.Location = new System.Drawing.Point(10, 50);
            this.buttonAddClip_PAA.Name = "buttonAddClip_PAA";
            this.buttonAddClip_PAA.Size = new System.Drawing.Size(922, 23);
            this.buttonAddClip_PAA.TabIndex = 12;
            this.buttonAddClip_PAA.Text = "Добавить клип";
            this.buttonAddClip_PAA.Click += new System.EventHandler(this.buttonAddClip_PAA_Click);

            // groupBoxSearch_PAA
            this.groupBoxSearch_PAA.Controls.Add(this.labelSearch_PAA);
            this.groupBoxSearch_PAA.Controls.Add(this.textBoxSearch_PAA);
            this.groupBoxSearch_PAA.Controls.Add(this.buttonSearch_PAA);
            this.groupBoxSearch_PAA.Controls.Add(this.buttonClearSearch_PAA);
            this.groupBoxSearch_PAA.Location = new System.Drawing.Point(20, 440);
            this.groupBoxSearch_PAA.Name = "groupBoxSearch_PAA";
            this.groupBoxSearch_PAA.Size = new System.Drawing.Size(300, 80);
            this.groupBoxSearch_PAA.TabIndex = 5;
            this.groupBoxSearch_PAA.TabStop = false;
            this.groupBoxSearch_PAA.Text = "Поиск по теме";

            // labelSearch_PAA
            this.labelSearch_PAA.AutoSize = true;
            this.labelSearch_PAA.Location = new System.Drawing.Point(10, 25);
            this.labelSearch_PAA.Name = "labelSearch_PAA";
            this.labelSearch_PAA.Size = new System.Drawing.Size(42, 13);
            this.labelSearch_PAA.TabIndex = 0;
            this.labelSearch_PAA.Text = "Поиск:";

            // textBoxSearch_PAA
            this.textBoxSearch_PAA.Location = new System.Drawing.Point(58, 22);
            this.textBoxSearch_PAA.Name = "textBoxSearch_PAA";
            this.textBoxSearch_PAA.Size = new System.Drawing.Size(150, 20);
            this.textBoxSearch_PAA.TabIndex = 1;

            // buttonSearch_PAA
            this.buttonSearch_PAA.Location = new System.Drawing.Point(214, 20);
            this.buttonSearch_PAA.Name = "buttonSearch_PAA";
            this.buttonSearch_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch_PAA.TabIndex = 2;
            this.buttonSearch_PAA.Text = "Найти";
            this.buttonSearch_PAA.Click += new System.EventHandler(this.buttonSearch_PAA_Click);

            // buttonClearSearch_PAA
            this.buttonClearSearch_PAA.Location = new System.Drawing.Point(214, 49);
            this.buttonClearSearch_PAA.Name = "buttonClearSearch_PAA";
            this.buttonClearSearch_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonClearSearch_PAA.TabIndex = 3;
            this.buttonClearSearch_PAA.Text = "Сбросить";
            this.buttonClearSearch_PAA.Click += new System.EventHandler(this.buttonClearSearch_PAA_Click);

            // groupBoxFilter_PAA
            this.groupBoxFilter_PAA.Controls.Add(this.labelFilterMin_PAA);
            this.groupBoxFilter_PAA.Controls.Add(this.numericUpDownFilterMin_PAA);
            this.groupBoxFilter_PAA.Controls.Add(this.labelFilterMax_PAA);
            this.groupBoxFilter_PAA.Controls.Add(this.numericUpDownFilterMax_PAA);
            this.groupBoxFilter_PAA.Controls.Add(this.buttonFilter_PAA);
            this.groupBoxFilter_PAA.Location = new System.Drawing.Point(330, 440);
            this.groupBoxFilter_PAA.Name = "groupBoxFilter_PAA";
            this.groupBoxFilter_PAA.Size = new System.Drawing.Size(300, 80);
            this.groupBoxFilter_PAA.TabIndex = 6;
            this.groupBoxFilter_PAA.TabStop = false;
            this.groupBoxFilter_PAA.Text = "Фильтр по длительности";

            // labelFilterMin_PAA
            this.labelFilterMin_PAA.AutoSize = true;
            this.labelFilterMin_PAA.Location = new System.Drawing.Point(10, 25);
            this.labelFilterMin_PAA.Name = "labelFilterMin_PAA";
            this.labelFilterMin_PAA.Size = new System.Drawing.Size(24, 13);
            this.labelFilterMin_PAA.TabIndex = 0;
            this.labelFilterMin_PAA.Text = "От:";

            // numericUpDownFilterMin_PAA
            this.numericUpDownFilterMin_PAA.Location = new System.Drawing.Point(40, 22);
            this.numericUpDownFilterMin_PAA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFilterMin_PAA.Name = "numericUpDownFilterMin_PAA";
            this.numericUpDownFilterMin_PAA.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownFilterMin_PAA.TabIndex = 1;
            this.numericUpDownFilterMin_PAA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});

            // labelFilterMax_PAA
            this.labelFilterMax_PAA.AutoSize = true;
            this.labelFilterMax_PAA.Location = new System.Drawing.Point(130, 25);
            this.labelFilterMax_PAA.Name = "labelFilterMax_PAA";
            this.labelFilterMax_PAA.Size = new System.Drawing.Size(25, 13);
            this.labelFilterMax_PAA.TabIndex = 2;
            this.labelFilterMax_PAA.Text = "До:";

            // numericUpDownFilterMax_PAA
            this.numericUpDownFilterMax_PAA.Location = new System.Drawing.Point(161, 22);
            this.numericUpDownFilterMax_PAA.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFilterMax_PAA.Name = "numericUpDownFilterMax_PAA";
            this.numericUpDownFilterMax_PAA.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownFilterMax_PAA.TabIndex = 3;
            this.numericUpDownFilterMax_PAA.Value = new decimal(new int[] {
            3600,
            0,
            0,
            0});

            // buttonFilter_PAA
            this.buttonFilter_PAA.Location = new System.Drawing.Point(214, 20);
            this.buttonFilter_PAA.Name = "buttonFilter_PAA";
            this.buttonFilter_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter_PAA.TabIndex = 4;
            this.buttonFilter_PAA.Text = "Применить";
            this.buttonFilter_PAA.Click += new System.EventHandler(this.buttonFilter_PAA_Click);

            // groupBoxStats_PAA
            this.groupBoxStats_PAA.Controls.Add(this.labelStats_PAA);
            this.groupBoxStats_PAA.Controls.Add(this.labelCount_PAA);
            this.groupBoxStats_PAA.Controls.Add(this.labelSum_PAA);
            this.groupBoxStats_PAA.Controls.Add(this.labelAvg_PAA);
            this.groupBoxStats_PAA.Controls.Add(this.labelMin_PAA);
            this.groupBoxStats_PAA.Controls.Add(this.labelMax_PAA);
            this.groupBoxStats_PAA.Controls.Add(this.textBoxStats_PAA);
            this.groupBoxStats_PAA.Location = new System.Drawing.Point(20, 530);
            this.groupBoxStats_PAA.Name = "groupBoxStats_PAA";
            this.groupBoxStats_PAA.Size = new System.Drawing.Size(400, 150);
            this.groupBoxStats_PAA.TabIndex = 7;
            this.groupBoxStats_PAA.TabStop = false;
            this.groupBoxStats_PAA.Text = "Статистика";

            // labelStats_PAA
            this.labelStats_PAA.AutoSize = true;
            this.labelStats_PAA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelStats_PAA.Location = new System.Drawing.Point(10, 20);
            this.labelStats_PAA.Name = "labelStats_PAA";
            this.labelStats_PAA.Size = new System.Drawing.Size(75, 15);
            this.labelStats_PAA.TabIndex = 0;
            this.labelStats_PAA.Text = "Общая стат.:";

            // labelCount_PAA
            this.labelCount_PAA.AutoSize = true;
            this.labelCount_PAA.Location = new System.Drawing.Point(10, 45);
            this.labelCount_PAA.Name = "labelCount_PAA";
            this.labelCount_PAA.Size = new System.Drawing.Size(69, 13);
            this.labelCount_PAA.TabIndex = 1;
            this.labelCount_PAA.Text = "Количество:";

            // labelSum_PAA
            this.labelSum_PAA.AutoSize = true;
            this.labelSum_PAA.Location = new System.Drawing.Point(10, 65);
            this.labelSum_PAA.Name = "labelSum_PAA";
            this.labelSum_PAA.Size = new System.Drawing.Size(44, 13);
            this.labelSum_PAA.TabIndex = 2;
            this.labelSum_PAA.Text = "Сумма:";

            // labelAvg_PAA
            this.labelAvg_PAA.AutoSize = true;
            this.labelAvg_PAA.Location = new System.Drawing.Point(10, 85);
            this.labelAvg_PAA.Name = "labelAvg_PAA";
            this.labelAvg_PAA.Size = new System.Drawing.Size(57, 13);
            this.labelAvg_PAA.TabIndex = 3;
            this.labelAvg_PAA.Text = "Среднее:";

            // labelMin_PAA
            this.labelMin_PAA.AutoSize = true;
            this.labelMin_PAA.Location = new System.Drawing.Point(10, 105);
            this.labelMin_PAA.Name = "labelMin_PAA";
            this.labelMin_PAA.Size = new System.Drawing.Size(57, 13);
            this.labelMin_PAA.TabIndex = 4;
            this.labelMin_PAA.Text = "Минимум:";

            // labelMax_PAA
            this.labelMax_PAA.AutoSize = true;
            this.labelMax_PAA.Location = new System.Drawing.Point(10, 125);
            this.labelMax_PAA.Name = "labelMax_PAA";
            this.labelMax_PAA.Size = new System.Drawing.Size(63, 13);
            this.labelMax_PAA.TabIndex = 5;
            this.labelMax_PAA.Text = "Максимум:";

            // textBoxStats_PAA
            this.textBoxStats_PAA.Location = new System.Drawing.Point(200, 20);
            this.textBoxStats_PAA.Multiline = true;
            this.textBoxStats_PAA.Name = "textBoxStats_PAA";
            this.textBoxStats_PAA.ReadOnly = true;
            this.textBoxStats_PAA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStats_PAA.Size = new System.Drawing.Size(190, 120);
            this.textBoxStats_PAA.TabIndex = 6;

            // chartThemes_PAA
            chartArea1.Name = "ChartArea1";
            this.chartThemes_PAA.ChartAreas.Add(chartArea1);
            this.chartThemes_PAA.Location = new System.Drawing.Point(430, 530);
            this.chartThemes_PAA.Name = "chartThemes_PAA";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartThemes_PAA.Series.Add(series1);
            this.chartThemes_PAA.Size = new System.Drawing.Size(534, 150);
            this.chartThemes_PAA.TabIndex = 8;
            this.chartThemes_PAA.Text = "chartThemes_PAA";

            // buttonLoad_PAA
            this.buttonLoad_PAA.Location = new System.Drawing.Point(640, 440);
            this.buttonLoad_PAA.Name = "buttonLoad_PAA";
            this.buttonLoad_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad_PAA.TabIndex = 9;
            this.buttonLoad_PAA.Text = "Загрузить";
            this.buttonLoad_PAA.Click += new System.EventHandler(this.buttonLoad_PAA_Click);

            // buttonSave_PAA
            this.buttonSave_PAA.Location = new System.Drawing.Point(721, 440);
            this.buttonSave_PAA.Name = "buttonSave_PAA";
            this.buttonSave_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonSave_PAA.TabIndex = 10;
            this.buttonSave_PAA.Text = "Сохранить";
            this.buttonSave_PAA.Click += new System.EventHandler(this.buttonSave_PAA_Click);

            // buttonSort_PAA
            this.buttonSort_PAA.Location = new System.Drawing.Point(802, 440);
            this.buttonSort_PAA.Name = "buttonSort_PAA";
            this.buttonSort_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonSort_PAA.TabIndex = 11;
            this.buttonSort_PAA.Text = "Сортировать";
            this.buttonSort_PAA.Click += new System.EventHandler(this.buttonSort_PAA_Click);

            // buttonStats_PAA
            this.buttonStats_PAA.Location = new System.Drawing.Point(883, 440);
            this.buttonStats_PAA.Name = "buttonStats_PAA";
            this.buttonStats_PAA.Size = new System.Drawing.Size(81, 23);
            this.buttonStats_PAA.TabIndex = 12;
            this.buttonStats_PAA.Text = "Статистика";
            this.buttonStats_PAA.Click += new System.EventHandler(this.buttonStats_PAA_Click);

            // buttonChart_PAA
            this.buttonChart_PAA.Location = new System.Drawing.Point(640, 469);
            this.buttonChart_PAA.Name = "buttonChart_PAA";
            this.buttonChart_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonChart_PAA.TabIndex = 13;
            this.buttonChart_PAA.Text = "График";
            this.buttonChart_PAA.Click += new System.EventHandler(this.buttonChart_PAA_Click);

            // buttonExportExcel_PAA
            this.buttonExportExcel_PAA.Location = new System.Drawing.Point(721, 469);
            this.buttonExportExcel_PAA.Name = "buttonExportExcel_PAA";
            this.buttonExportExcel_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonExportExcel_PAA.TabIndex = 14;
            this.buttonExportExcel_PAA.Text = "Excel";
            this.buttonExportExcel_PAA.Click += new System.EventHandler(this.buttonExportExcel_PAA_Click);

            // buttonAbout_PAA
            this.buttonAbout_PAA.Location = new System.Drawing.Point(802, 469);
            this.buttonAbout_PAA.Name = "buttonAbout_PAA";
            this.buttonAbout_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonAbout_PAA.TabIndex = 15;
            this.buttonAbout_PAA.Text = "О программе";
            this.buttonAbout_PAA.Click += new System.EventHandler(this.buttonAbout_PAA_Click);

            // buttonHelp_PAA
            this.buttonHelp_PAA.Location = new System.Drawing.Point(883, 469);
            this.buttonHelp_PAA.Name = "buttonHelp_PAA";
            this.buttonHelp_PAA.Size = new System.Drawing.Size(81, 23);
            this.buttonHelp_PAA.TabIndex = 16;
            this.buttonHelp_PAA.Text = "Справка";
            this.buttonHelp_PAA.Click += new System.EventHandler(this.buttonHelp_PAA_Click);

            // labelStatus_PAA
            this.labelStatus_PAA.AutoSize = true;
            this.labelStatus_PAA.Location = new System.Drawing.Point(20, 710);
            this.labelStatus_PAA.Name = "labelStatus_PAA";
            this.labelStatus_PAA.Size = new System.Drawing.Size(43, 13);
            this.labelStatus_PAA.TabIndex = 17;
            this.labelStatus_PAA.Text = "Готово";

            // buttonExit_PAA
            this.buttonExit_PAA.Location = new System.Drawing.Point(879, 705);
            this.buttonExit_PAA.Name = "buttonExit_PAA";
            this.buttonExit_PAA.Size = new System.Drawing.Size(75, 23);
            this.buttonExit_PAA.TabIndex = 18;
            this.buttonExit_PAA.Text = "Выход";
            this.buttonExit_PAA.UseVisualStyleBackColor = true;
            this.buttonExit_PAA.Click += new System.EventHandler(this.buttonExit_PAA_Click);

            // FormMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 741);
            this.Controls.Add(this.buttonExit_PAA);
            this.Controls.Add(this.labelStatus_PAA);
            this.Controls.Add(this.buttonHelp_PAA);
            this.Controls.Add(this.buttonAbout_PAA);
            this.Controls.Add(this.buttonExportExcel_PAA);
            this.Controls.Add(this.buttonChart_PAA);
            this.Controls.Add(this.buttonStats_PAA);
            this.Controls.Add(this.buttonSort_PAA);
            this.Controls.Add(this.buttonSave_PAA);
            this.Controls.Add(this.buttonLoad_PAA);
            this.Controls.Add(this.chartThemes_PAA);
            this.Controls.Add(this.groupBoxStats_PAA);
            this.Controls.Add(this.groupBoxFilter_PAA);
            this.Controls.Add(this.groupBoxSearch_PAA);
            this.Controls.Add(this.groupBoxAdd_PAA);
            this.Controls.Add(this.dataGridViewClips_PAA);
            this.Controls.Add(this.labelTitle_PAA);
            this.Controls.Add(this.toolStripMain_PAA);
            this.Controls.Add(this.menuStripMain_PAA);
            this.MainMenuStrip = this.menuStripMain_PAA;
            this.Name = "FormMain";
            this.Text = "Каталог видеоклипов - Панькова А.А.";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClips_PAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration_PAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost_PAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilterMin_PAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilterMax_PAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThemes_PAA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}