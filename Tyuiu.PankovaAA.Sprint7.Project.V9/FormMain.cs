using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tyuiu.PankovaAA.Sprint7.Lib;

namespace Tyuiu.PankovaAA.Sprint7.Project.V9
{
    public partial class FormMain : Form
    {
        private List<VideoClip> videoClips;
        private string? currentFilePath;
        private DataTable? dataTable;
        private List<VideoClip> originalClips;

        // Элементы управления для поиска/фильтрации
        private TextBox textBoxSearch_PAA = null!;
        private ComboBox comboBoxFilterField_PAA = null!;
        private TextBox textBoxFilterValue_PAA = null!;
        private ComboBox comboBoxSortField_PAA = null!;
        private RadioButton radioButtonAsc_PAA = null!;
        private RadioButton radioButtonDesc_PAA = null!;

        public FormMain()
        {
            InitializeComponent();
            InitializeDataTable();
            InitializeControlPanels();
            SetupToolTips();
            videoClips = new List<VideoClip>();
            originalClips = new List<VideoClip>();
        }

        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataGridViewMain_PAA.DataSource = dataTable;
        }

        private void InitializeControlPanels()
        {
            // Панель для поиска и фильтрации
            Panel panelControls_PAA = new Panel();
            panelControls_PAA.Dock = DockStyle.Top;
            panelControls_PAA.Height = 100;
            panelControls_PAA.BackColor = SystemColors.Control;
            panelControls_PAA.BorderStyle = BorderStyle.FixedSingle;

            // Поиск
            Label labelSearch_PAA = new Label();
            labelSearch_PAA.Text = "Поиск:";
            labelSearch_PAA.Location = new Point(20, 15);
            labelSearch_PAA.Size = new Size(50, 25);
            panelControls_PAA.Controls.Add(labelSearch_PAA);

            textBoxSearch_PAA = new TextBox();
            textBoxSearch_PAA.Location = new Point(75, 15);
            textBoxSearch_PAA.Size = new Size(200, 25);
            textBoxSearch_PAA.TextChanged += TextBoxSearch_PAA_TextChanged;
            panelControls_PAA.Controls.Add(textBoxSearch_PAA);

            // Фильтрация
            Label labelFilter_PAA = new Label();
            labelFilter_PAA.Text = "Фильтр по:";
            labelFilter_PAA.Location = new Point(20, 55);
            labelFilter_PAA.Size = new Size(70, 25);
            panelControls_PAA.Controls.Add(labelFilter_PAA);

            comboBoxFilterField_PAA = new ComboBox();
            comboBoxFilterField_PAA.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterField_PAA.Items.AddRange(new string[] { "Тема", "Страна", "Дата", "Стоимость" });
            comboBoxFilterField_PAA.Location = new Point(95, 55);
            comboBoxFilterField_PAA.Size = new Size(100, 25);
            comboBoxFilterField_PAA.SelectedIndex = 0;
            comboBoxFilterField_PAA.SelectedIndexChanged += ComboBoxFilterField_PAA_SelectedIndexChanged;
            panelControls_PAA.Controls.Add(comboBoxFilterField_PAA);

            Label labelFilterValue_PAA = new Label();
            labelFilterValue_PAA.Text = "Значение:";
            labelFilterValue_PAA.Location = new Point(205, 55);
            labelFilterValue_PAA.Size = new Size(70, 25);
            panelControls_PAA.Controls.Add(labelFilterValue_PAA);

            textBoxFilterValue_PAA = new TextBox();
            textBoxFilterValue_PAA.Location = new Point(280, 55);
            textBoxFilterValue_PAA.Size = new Size(150, 25);
            textBoxFilterValue_PAA.TextChanged += TextBoxFilterValue_PAA_TextChanged;
            panelControls_PAA.Controls.Add(textBoxFilterValue_PAA);

            // Сортировка
            Label labelSort_PAA = new Label();
            labelSort_PAA.Text = "Сортировка:";
            labelSort_PAA.Location = new Point(450, 15);
            labelSort_PAA.Size = new Size(80, 25);
            panelControls_PAA.Controls.Add(labelSort_PAA);

            comboBoxSortField_PAA = new ComboBox();
            comboBoxSortField_PAA.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortField_PAA.Items.AddRange(new string[] { "Название", "Длительность", "Стоимость", "Дата", "Тема" });
            comboBoxSortField_PAA.Location = new Point(535, 15);
            comboBoxSortField_PAA.Size = new Size(120, 25);
            comboBoxSortField_PAA.SelectedIndex = 0;
            comboBoxSortField_PAA.SelectedIndexChanged += ComboBoxSortField_PAA_SelectedIndexChanged;
            panelControls_PAA.Controls.Add(comboBoxSortField_PAA);

            radioButtonAsc_PAA = new RadioButton();
            radioButtonAsc_PAA.Text = "По возрастанию";
            radioButtonAsc_PAA.Checked = true;
            radioButtonAsc_PAA.Location = new Point(535, 45);
            radioButtonAsc_PAA.Size = new Size(140, 25);
            radioButtonAsc_PAA.CheckedChanged += RadioButtonSort_CheckedChanged;
            panelControls_PAA.Controls.Add(radioButtonAsc_PAA);

            radioButtonDesc_PAA = new RadioButton();
            radioButtonDesc_PAA.Text = "По убыванию";
            radioButtonDesc_PAA.Location = new Point(535, 70);
            radioButtonDesc_PAA.Size = new Size(120, 25);
            radioButtonDesc_PAA.CheckedChanged += RadioButtonSort_CheckedChanged;
            panelControls_PAA.Controls.Add(radioButtonDesc_PAA);

            // Кнопка Графика
            Button buttonChartNow_PAA = new Button();
            buttonChartNow_PAA.Text = "Показать график";
            buttonChartNow_PAA.Location = new Point(700, 40);
            buttonChartNow_PAA.Size = new Size(150, 30);
            buttonChartNow_PAA.Click += ButtonChartNow_PAA_Click;
            panelControls_PAA.Controls.Add(buttonChartNow_PAA);

            // Кнопка Статистики
            Button buttonStatsNow_PAA = new Button();
            buttonStatsNow_PAA.Text = "Показать статистику";
            buttonStatsNow_PAA.Location = new Point(860, 40);
            buttonStatsNow_PAA.Size = new Size(150, 30);
            buttonStatsNow_PAA.Click += ButtonStatsNow_PAA_Click;
            panelControls_PAA.Controls.Add(buttonStatsNow_PAA);

            // Кнопка сброса
            Button buttonResetNow_PAA = new Button();
            buttonResetNow_PAA.Text = "Сбросить все";
            buttonResetNow_PAA.Location = new Point(1020, 40);
            buttonResetNow_PAA.Size = new Size(100, 30);
            buttonResetNow_PAA.Click += ButtonResetNow_PAA_Click;
            panelControls_PAA.Controls.Add(buttonResetNow_PAA);

            // Добавляем панель на форму
            this.Controls.Add(panelControls_PAA);
            panelControls_PAA.BringToFront();

            // Перемещаем DataGridView ниже
            dataGridViewMain_PAA.Top = panelControls_PAA.Bottom;
            dataGridViewMain_PAA.Height = this.ClientSize.Height - panelControls_PAA.Height - panelBottom_PAA.Height - 50;
        }

        private void SetupToolTips()
        {
            toolTip_PAA.SetToolTip(buttonHelp_PAA, "Справка");
            toolTip_PAA.SetToolTip(buttonAbout_PAA, "О программе");
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            labelFilterInfo_PAA.Visible = false;
            labelSortInfo_PAA.Visible = false;

            // ПУСТАЯ ТАБЛИЦА ПРИ ЗАПУСКЕ
            // Ничего не загружаем
        }

        // ========== ЗАГРУЗКА CSV ФАЙЛА (ИСПРАВЛЕНО для ;) ==========
        private void LoadCSVFile(string filePath)
        {
            try
            {
                videoClips.Clear();
                originalClips.Clear();
                currentFilePath = filePath;

                // Читаем все строки из CSV файла
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                if (lines.Length == 0)
                {
                    MessageBox.Show("Файл пуст", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Пропускаем заголовок (первую строку)
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Разделяем строку по ТОЧКЕ С ЗАПЯТОЙ
                    string[] parts = line.Split(';');

                    // Проверяем количество колонок
                    if (parts.Length >= 6)
                    {
                        int idIndex = 0;
                        int themeIndex = 1;
                        int titleIndex = 2;
                        int durationIndex = 3;
                        int dateIndex = 4;
                        int costIndex = 5;
                        int countryIndex = 6;

                        // Если есть ID в первой колонке, смещаем индексы
                        if (parts.Length >= 7)
                        {
                            // Есть ID колонка, используем ее
                            idIndex = 0;
                            themeIndex = 1;
                            titleIndex = 2;
                            durationIndex = 3;
                            dateIndex = 4;
                            costIndex = 5;
                            countryIndex = 6;
                        }
                        else
                        {
                            // Нет ID, генерируем его
                            idIndex = -1;
                            themeIndex = 0;
                            titleIndex = 1;
                            durationIndex = 2;
                            dateIndex = 3;
                            costIndex = 4;
                            countryIndex = 5;
                        }

                        var clip = new VideoClip
                        {
                            Id = idIndex >= 0 ? int.Parse(parts[idIndex].Trim()) : i,
                            Theme = parts[themeIndex].Trim(),
                            Title = parts[titleIndex].Trim(),
                            DurationText = parts[durationIndex].Trim(),
                            DurationSec = ParseDuration(parts[durationIndex].Trim()),
                            DateText = parts[dateIndex].Trim(),
                            CostText = parts[costIndex].Trim(),
                            Cost = ParseCost(parts[costIndex].Trim()),
                            Currency = ExtractCurrency(parts[costIndex].Trim()),
                            Country = parts[countryIndex].Trim()
                        };

                        videoClips.Add(clip);
                    }
                }

                // Сохраняем оригинальную копию
                originalClips = new List<VideoClip>(videoClips);

                // Обновляем интерфейс
                UpdateDataGridView();
                UpdateStats();
                ApplyFiltersAndSort();

                this.Text = $"Каталог видеоклипов - Панькова А.А. [{Path.GetFileName(filePath)}]";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Парсинг длительности из строки (например: "2 ч 58 мин" в секунды)
        private int ParseDuration(string durationText)
        {
            try
            {
                durationText = durationText.ToLower().Replace(" ", "");
                int hours = 0;
                int minutes = 0;

                if (durationText.Contains("ч"))
                {
                    string hourPart = durationText.Substring(0, durationText.IndexOf("ч")).Trim();
                    int.TryParse(new string(hourPart.Where(char.IsDigit).ToArray()), out hours);
                }

                if (durationText.Contains("мин"))
                {
                    string minPart = durationText;
                    if (durationText.Contains("ч"))
                    {
                        minPart = durationText.Substring(durationText.IndexOf("ч") + 1);
                    }
                    minPart = minPart.Substring(0, minPart.IndexOf("мин")).Trim();
                    int.TryParse(new string(minPart.Where(char.IsDigit).ToArray()), out minutes);
                }

                return hours * 3600 + minutes * 60;
            }
            catch
            {
                return 0;
            }
        }

        // Парсинг стоимости из строки - ИСПРАВЛЕНО на decimal?
        private decimal? ParseCost(string costText)
        {
            try
            {
                // Убираем лишние пробелы и приводим к нижнему регистру
                costText = costText.Trim().ToLower();

                // Удаляем все нецифровые символы, кроме точки, запятой и минуса
                string numericString = new string(costText
                    .Where(c => char.IsDigit(c) || c == '.' || c == ',' || c == '-')
                    .ToArray());

                if (string.IsNullOrEmpty(numericString))
                    return null;

                // Заменяем запятую на точку для парсинга
                numericString = numericString.Replace(',', '.');

                if (decimal.TryParse(numericString, out decimal result))
                {
                    // Проверяем множители
                    if (costText.Contains("млрд") || costText.Contains("billion"))
                        result *= 1000000000;
                    else if (costText.Contains("млн") || costText.Contains("million"))
                        result *= 1000000;
                    else if (costText.Contains("тыс") || costText.Contains("thousand"))
                        result *= 1000;

                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        // Извлечение валюты из строки стоимости
        private string ExtractCurrency(string costText)
        {
            costText = costText.ToLower();
            if (costText.Contains("$") || costText.Contains("доллар") || costText.Contains("usd"))
                return "USD";
            if (costText.Contains("€") || costText.Contains("евро") || costText.Contains("eur"))
                return "EUR";
            if (costText.Contains("₽") || costText.Contains("руб") || costText.Contains("rub"))
                return "RUB";
            return "N/A";
        }

        // === ОБРАБОТЧИКИ ПОИСКА И ФИЛЬТРАЦИИ В РЕАЛЬНОМ ВРЕМЕНИ ===
        private void TextBoxSearch_PAA_TextChanged(object? sender, EventArgs e)
        {
            ApplyFiltersAndSort();
        }

        private void ComboBoxFilterField_PAA_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFilterValue_PAA.Text))
            {
                ApplyFiltersAndSort();
            }
        }

        private void TextBoxFilterValue_PAA_TextChanged(object? sender, EventArgs e)
        {
            ApplyFiltersAndSort();
        }

        private void ComboBoxSortField_PAA_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFiltersAndSort();
        }

        private void RadioButtonSort_CheckedChanged(object? sender, EventArgs e)
        {
            ApplyFiltersAndSort();
        }

        private void ApplyFiltersAndSort()
        {
            if (originalClips == null || originalClips.Count == 0)
                return;

            List<VideoClip> filteredClips = new List<VideoClip>(originalClips);

            // Применяем поиск
            string searchTerm = textBoxSearch_PAA.Text.Trim();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                filteredClips = filteredClips.Where(clip =>
                    (clip.Title?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (clip.Theme?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (clip.Country?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (clip.DateText?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (clip.CostText?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)
                ).ToList();
            }

            // Применяем фильтр
            string filterValue = textBoxFilterValue_PAA.Text.Trim();
            if (!string.IsNullOrWhiteSpace(filterValue))
            {
                string filterBy = comboBoxFilterField_PAA.SelectedItem?.ToString() ?? "Тема";

                switch (filterBy)
                {
                    case "Тема":
                        filteredClips = filteredClips.Where(c =>
                            c.Theme?.Contains(filterValue, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                        break;
                    case "Страна":
                        filteredClips = filteredClips.Where(c =>
                            c.Country?.Contains(filterValue, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                        break;
                    case "Дата":
                        filteredClips = filteredClips.Where(c =>
                            c.DateText?.Contains(filterValue, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                        break;
                    case "Стоимость":
                        filteredClips = filteredClips.Where(c =>
                            c.CostText?.Contains(filterValue, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
                        break;
                }
            }

            // Применяем сортировку
            string sortBy = comboBoxSortField_PAA.SelectedItem?.ToString() ?? "Название";
            bool ascending = radioButtonAsc_PAA.Checked;

            switch (sortBy)
            {
                case "Название":
                    filteredClips = ascending
                        ? filteredClips.OrderBy(c => c.Title ?? "").ToList()
                        : filteredClips.OrderByDescending(c => c.Title ?? "").ToList();
                    break;
                case "Длительность":
                    filteredClips = ascending
                        ? filteredClips.OrderBy(c => c.DurationSec).ToList()
                        : filteredClips.OrderByDescending(c => c.DurationSec).ToList();
                    break;
                case "Стоимость":
                    // ИСПРАВЛЕНО: используется decimal? и 0m
                    filteredClips = ascending
                        ? filteredClips.OrderBy(c => c.Cost ?? 0m).ToList()
                        : filteredClips.OrderByDescending(c => c.Cost ?? 0m).ToList();
                    break;
                case "Дата":
                    filteredClips = ascending
                        ? filteredClips.OrderBy(c => c.DateText ?? "").ToList()
                        : filteredClips.OrderByDescending(c => c.DateText ?? "").ToList();
                    break;
                case "Тема":
                    filteredClips = ascending
                        ? filteredClips.OrderBy(c => c.Theme ?? "").ToList()
                        : filteredClips.OrderByDescending(c => c.Theme ?? "").ToList();
                    break;
            }

            // Обновляем отображение
            videoClips = filteredClips;
            UpdateDataGridView();
            UpdateStats();

            // Показываем информацию о фильтрах
            if (!string.IsNullOrWhiteSpace(searchTerm) || !string.IsNullOrWhiteSpace(filterValue))
            {
                labelFilterInfo_PAA.Text = $"Найдено: {filteredClips.Count} записей";
                if (!string.IsNullOrWhiteSpace(searchTerm))
                    labelFilterInfo_PAA.Text += $" | Поиск: '{searchTerm}'";
                if (!string.IsNullOrWhiteSpace(filterValue))
                    labelFilterInfo_PAA.Text += $" | Фильтр: {comboBoxFilterField_PAA.SelectedItem} = '{filterValue}'";
                labelFilterInfo_PAA.Visible = true;
            }
            else
            {
                labelFilterInfo_PAA.Visible = false;
            }

            // Показываем информацию о сортировке
            if (sortBy != "Название" || !ascending)
            {
                labelSortInfo_PAA.Text = $"Сортировка: {sortBy} {(ascending ? "↑" : "↓")}";
                labelSortInfo_PAA.Visible = true;
            }
            else
            {
                labelSortInfo_PAA.Visible = false;
            }
        }

        // === ОСНОВНЫЕ МЕТОДЫ ===
        private void UpdateDataGridView()
        {
            if (dataTable == null) return;

            dataTable.Clear();
            dataTable.Columns.Clear();

            if (videoClips == null || videoClips.Count == 0)
                return;

            // Создаем колонки
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Тема", typeof(string));
            dataTable.Columns.Add("Название", typeof(string));
            dataTable.Columns.Add("Длительность", typeof(string));
            dataTable.Columns.Add("Дата", typeof(string));
            dataTable.Columns.Add("Стоимость", typeof(string));
            dataTable.Columns.Add("Страна", typeof(string));

            // Заполняем данные
            foreach (var clip in videoClips)
            {
                dataTable.Rows.Add(
                    clip.Id,
                    clip.Theme ?? "",
                    clip.Title ?? "",
                    clip.DurationText ?? "",
                    clip.DateText ?? "",
                    clip.CostText ?? "",
                    clip.Country ?? ""
                );
            }

            dataGridViewMain_PAA.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void UpdateStats()
        {
            if (videoClips == null || videoClips.Count == 0)
            {
                labelStats_PAA.Text = "Записей: 0";
                return;
            }

            var costStats = StatsService.CalculateCostStats(videoClips);
            labelStats_PAA.Text = $"Записей: {videoClips.Count} | Со стоимостью: {costStats.Count} | Сумма: {costStats.Sum:N0}";
        }

        // === КНОПКИ ===
        private void ButtonChartNow_PAA_Click(object? sender, EventArgs e)
        {
            if (videoClips == null || videoClips.Count == 0)
            {
                MessageBox.Show("Нет данных для построения графика",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var themeStats = StatsService.CountByTheme(videoClips);

            if (themeStats.Count == 0)
            {
                MessageBox.Show("Нет данных для построения графика",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Простой график в MessageBox
            string chartText = "РАСПРЕДЕЛЕНИЕ ПО ТЕМАМ:\n\n";
            foreach (var stat in themeStats)
            {
                int barLength = (int)((stat.Value / (double)themeStats.Values.Max()) * 30);
                chartText += $"{stat.Key}: {new string('█', barLength)} {stat.Value}\n";
            }

            MessageBox.Show(chartText, "Гистограмма распределения",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonStatsNow_PAA_Click(object? sender, EventArgs e)
        {
            if (videoClips == null || videoClips.Count == 0)
            {
                MessageBox.Show("Нет данных для статистики",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var costStats = StatsService.CalculateCostStats(videoClips);
            var themeStats = StatsService.CountByTheme(videoClips);
            var countryStats = StatsService.CountByCountry(videoClips);

            string statsText = "СТАТИСТИКА КАТАЛОГА\n\n";
            statsText += $"Всего записей: {videoClips.Count}\n";
            statsText += $"Записей со стоимостью: {costStats.Count}\n";
            statsText += $"Общая сумма: {costStats.Sum:N0}\n";
            statsText += $"Средняя стоимость: {costStats.Avg:N2}\n";
            statsText += $"Минимальная стоимость: {costStats.Min:N2}\n";
            statsText += $"Максимальная стоимость: {costStats.Max:N2}\n\n";

            statsText += "ПО ТЕМАМ (топ-5):\n";
            int count = 0;
            foreach (var stat in themeStats.Take(5))
            {
                statsText += $"{stat.Key}: {stat.Value}\n";
                count++;
            }
            if (themeStats.Count > 5) statsText += $"... и еще {themeStats.Count - 5}\n";

            statsText += "\nПО СТРАНАМ (топ-3):\n";
            count = 0;
            foreach (var stat in countryStats.Take(3))
            {
                statsText += $"{stat.Key}: {stat.Value}\n";
                count++;
            }
            if (countryStats.Count > 3) statsText += $"... и еще {countryStats.Count - 3}\n";

            MessageBox.Show(statsText, "Статистика",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonResetNow_PAA_Click(object? sender, EventArgs e)
        {
            // Сбрасываем все фильтры
            textBoxSearch_PAA.Text = "";
            textBoxFilterValue_PAA.Text = "";
            comboBoxSortField_PAA.SelectedIndex = 0;
            radioButtonAsc_PAA.Checked = true;

            if (originalClips != null)
            {
                videoClips = new List<VideoClip>(originalClips);
                UpdateDataGridView();
                UpdateStats();
            }

            labelFilterInfo_PAA.Visible = false;
            labelSortInfo_PAA.Visible = false;
        }

        private void buttonHelp_PAA_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "КАТАЛОГ ВИДЕОКЛИПОВ\n\n" +
                "Использование:\n" +
                "1. Файл → Открыть: выберите CSV файл с данными (разделитель ;)\n" +
                "2. Поиск: вводите текст для поиска по всем полям\n" +
                "3. Фильтр: выбирайте поле и значение для точного фильтра\n" +
                "4. Сортировка: выбирайте поле и порядок сортировки\n" +
                "5. Все изменения применяются автоматически\n\n" +
                "Формат CSV: ID;Тема;Название;Длительность;Дата;Стоимость;Страна",
                "Справка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void buttonAbout_PAA_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Каталог видеоклипов\n" +
                "Разработчик: Панькова А.А.\n" +
                "Группа: ПИН6-25-1\n\n" +
                "Тюменский индустриальный университет\n" +
                "© 2025",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void выходToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void открытьToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите CSV файл с данными";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadCSVFile(openFileDialog.FileName);
                        MessageBox.Show($"Файл успешно загружен!\nЗаписей: {videoClips.Count}",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (videoClips == null || videoClips.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv";
                saveFileDialog.Title = "Сохранить данные в CSV";
                saveFileDialog.DefaultExt = "csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SaveToCSV(saveFileDialog.FileName);
                        MessageBox.Show($"Данные сохранены в файл:\n{saveFileDialog.FileName}",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении:\n{ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveToCSV(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Заголовок CSV с разделителем ;
                writer.WriteLine("ID;Тема;Название;Длительность;Дата;Стоимость;Страна");

                // Данные
                foreach (var clip in originalClips)
                {
                    writer.WriteLine($"{clip.Id};{clip.Theme};{clip.Title};{clip.DurationText};{clip.DateText};{clip.CostText};{clip.Country}");
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // Простой диалог добавления
            string title = Microsoft.VisualBasic.Interaction.InputBox("Введите название видеоклипа:", "Добавление записи");
            if (!string.IsNullOrWhiteSpace(title))
            {
                int newId = originalClips.Count > 0 ? originalClips.Max(c => c.Id) + 1 : 1;
                var newClip = new VideoClip
                {
                    Id = newId,
                    Title = title,
                    Theme = "Новая тема",
                    DurationText = "0 мин",
                    DateText = DateTime.Now.Year.ToString(),
                    CostText = "0 руб",
                    Country = "Не указана"
                };

                originalClips.Add(newClip);
                videoClips.Add(newClip);
                ApplyFiltersAndSort();
                MessageBox.Show("Запись добавлена", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void редактироватьToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (dataGridViewMain_PAA.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewMain_PAA.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < videoClips.Count)
                {
                    var clip = videoClips[selectedIndex];
                    string newTitle = Microsoft.VisualBasic.Interaction.InputBox("Введите новое название:", "Редактирование", clip.Title);
                    if (!string.IsNullOrWhiteSpace(newTitle))
                    {
                        clip.Title = newTitle;
                        // Обновляем в оригинальном списке
                        var origClip = originalClips.FirstOrDefault(c => c.Id == clip.Id);
                        if (origClip != null) origClip.Title = newTitle;

                        ApplyFiltersAndSort();
                        MessageBox.Show("Запись обновлена", "Информация",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void удалитьToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (dataGridViewMain_PAA.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewMain_PAA.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < videoClips.Count)
                {
                    var clip = videoClips[selectedIndex];

                    DialogResult result = MessageBox.Show($"Удалить запись: {clip.Title}?",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        originalClips.RemoveAll(c => c.Id == clip.Id);
                        ApplyFiltersAndSort();
                        MessageBox.Show("Запись удалена", "Информация",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewMain_PAA_SelectionChanged(object? sender, EventArgs e)
        {
            // Пустая реализация
        }

        // Обработчики для пунктов меню Анализ
        private void статистикаToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            ButtonStatsNow_PAA_Click(sender, e);
        }

        private void графикToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            ButtonChartNow_PAA_Click(sender, e);
        }
    }
}
