using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tyuiu.PankovaPAA.Sprint7.Lib;

namespace Tyuiu.PankovaPAA.Sprint7
{
    public partial class FormMain : Form
    {
        private List<Actor> actors_PAA = new List<Actor>();
        private List<VideoClip> clips_PAA = new List<VideoClip>();
        private DataTable dataTableClips_PAA = new DataTable();

        public FormMain()
        {
            InitializeComponent();
            InitializeDataTable_PAA();
            SetupToolTips_PAA();
            LoadFromFile_PAA();
            UpdateActorComboBox_PAA();
            UpdateDisplay_PAA();
            UpdateStatisticsAndChart_PAA();

            // 🔴 Добавлены события для автоматического сохранения
            dataGridViewClips_PAA.CellValueChanged += (s, e) => OnDataChanged_PAA();
            dataGridViewClips_PAA.RowsRemoved += (s, e) => OnDataChanged_PAA();
            dataGridViewClips_PAA.UserDeletedRow += (s, e) => OnDataChanged_PAA();
            dataGridViewClips_PAA.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dataGridViewClips_PAA.IsCurrentCellDirty)
                    dataGridViewClips_PAA.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        private void OnDataChanged_PAA()
        {
            // обновить статистику и диаграмму после любых изменений в таблице
            UpdateStatisticsAndChart_PAA();
        }

        private bool ValidateClips_PAA(out string errorText)
        {
            errorText = "";

            // берём данные из твоего списка клипов
            var list = clips_PAA;

            for (int i = 0; i < list.Count; i++)
            {
                var c = list[i];

                if (c == null)
                {
                    errorText = $"Строка {i + 1}: пустая запись.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(c.Code))
                {
                    errorText = $"Строка {i + 1}: Code не может быть пустым.";
                    return false;
                }

                if (c.DurationSec <= 0)
                {
                    errorText = $"Строка {i + 1}: DurationSec должен быть > 0.";
                    return false;
                }

                if (c.Cost < 0)
                {
                    errorText = $"Строка {i + 1}: Cost не может быть отрицательной.";
                    return false;
                }

                if (c.RecordDate > DateTime.Now)
                {
                    errorText = $"Строка {i + 1}: Дата записи не может быть в будущем.";
                    return false;
                }
            }

            // проверка уникальности кода
            var dup = list
                .Where(x => x != null)
                .GroupBy(x => x.Code?.Trim(), StringComparer.OrdinalIgnoreCase)
                .FirstOrDefault(g => !string.IsNullOrWhiteSpace(g.Key) && g.Count() > 1);

            if (dup != null)
            {
                errorText = $"Код клипа должен быть уникальным. Повтор: {dup.Key}";
                return false;
            }

            return true;
        }

        private void UpdateStatisticsAndChart_PAA()
        {
            var list = clips_PAA.ToList();
            var stats = Lib.StatsService.CalculateCostStats(list);

            if (stats.Count == 0)
            {
                // Обновляем ВСЕ label статистики
                labelStats_PAA.Text = "Нет данных";
                labelCount_PAA.Text = "Количество: 0";
                labelSum_PAA.Text = "Сумма: 0,00";
                labelAvg_PAA.Text = "Среднее: 0,00";
                labelMin_PAA.Text = "Минимум: 0,00";
                labelMax_PAA.Text = "Максимум: 0,00";

                // Очищаем текстовое поле статистики по темам
                textBoxStats_PAA.Text = "Нет данных для отображения статистики по темам.";

                // Очищаем диаграмму
                if (chartThemes_PAA.Series.Count > 0)
                {
                    var series = chartThemes_PAA.Series[0];
                    series.Points.Clear();
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;
                }
                return;
            }

            // Обновляем заголовок
            labelStats_PAA.Text = "Общая статистика:";

            // Обновляем ВСЕ label статистики
            labelCount_PAA.Text = $"Количество: {stats.Count}";
            labelSum_PAA.Text = $"Сумма: {stats.Sum:F2}";
            labelAvg_PAA.Text = $"Среднее: {stats.Avg:F2}";
            labelMin_PAA.Text = $"Минимум: {stats.Min:F2}";
            labelMax_PAA.Text = $"Максимум: {stats.Max:F2}";

            // Обновляем статистику по темам
            var map = Lib.StatsService.CountByTheme(list);
            UpdateThemeStats_PAA(map);

            // Обновляем диаграмму
            if (chartThemes_PAA.Series.Count > 0)
            {
                var series = chartThemes_PAA.Series[0];
                series.Points.Clear();
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                foreach (var kv in map)
                {
                    series.Points.AddXY(kv.Key, kv.Value);
                }
            }
        }

        private void UpdateThemeStats_PAA(Dictionary<string, int> map)
        {
            if (map == null || map.Count == 0)
            {
                textBoxStats_PAA.Text = "Нет данных по темам.";
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("СТАТИСТИКА ПО ТЕМАМ:");
            sb.AppendLine("════════════════════");

            foreach (var kv in map.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"{kv.Key}: {kv.Value} клипов");
            }

            textBoxStats_PAA.Text = sb.ToString();
        }

        private void InitializeDataTable_PAA()
        {
            dataTableClips_PAA.Columns.Add("Код", typeof(string));
            dataTableClips_PAA.Columns.Add("Дата записи", typeof(DateTime));
            dataTableClips_PAA.Columns.Add("Длительность (сек)", typeof(int));
            dataTableClips_PAA.Columns.Add("Тема", typeof(string));
            dataTableClips_PAA.Columns.Add("Стоимость", typeof(decimal));
            dataTableClips_PAA.Columns.Add("Актёр", typeof(string));
            dataTableClips_PAA.Columns.Add("ID актёра", typeof(int));

            dataGridViewClips_PAA.DataSource = dataTableClips_PAA;
            dataGridViewClips_PAA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewClips_PAA.ReadOnly = false;
            dataGridViewClips_PAA.AllowUserToAddRows = true;
            dataGridViewClips_PAA.AllowUserToDeleteRows = true;
        }

        private void SetupToolTips_PAA()
        {
            var toolTip_PAA = new ToolTip();
            toolTip_PAA.SetToolTip(buttonAddClip_PAA, "Добавить новый видео-клип");
            toolTip_PAA.SetToolTip(buttonSave_PAA, "Сохранить все изменения в файлы");
            toolTip_PAA.SetToolTip(buttonLoad_PAA, "Загрузить данные из файлов");
            toolTip_PAA.SetToolTip(buttonSearch_PAA, "Поиск клипов по теме");
            toolTip_PAA.SetToolTip(buttonSort_PAA, "Сортировка по стоимости (от большего к меньшему)");
            toolTip_PAA.SetToolTip(buttonFilter_PAA, "Фильтр по длительности (в секундах)");
            toolTip_PAA.SetToolTip(buttonStats_PAA, "Показать подробную статистику");
            toolTip_PAA.SetToolTip(buttonChart_PAA, "Показать график распределения по темам");
            toolTip_PAA.SetToolTip(buttonExportExcel_PAA, "Экспортировать данные в CSV файл");
            toolTip_PAA.SetToolTip(buttonAbout_PAA, "Показать информацию о программе");
            toolTip_PAA.SetToolTip(buttonHelp_PAA, "Показать справку по использованию программы");
            toolTip_PAA.SetToolTip(textBoxCode_PAA, "Введите уникальный код клипа");
            toolTip_PAA.SetToolTip(textBoxTheme_PAA, "Введите тему клипа");
            toolTip_PAA.SetToolTip(dateTimePicker_PAA, "Выберите дату записи клипа");
            toolTip_PAA.SetToolTip(numericUpDownDuration_PAA, "Введите длительность в секундах");
            toolTip_PAA.SetToolTip(numericUpDownCost_PAA, "Введите стоимость клипа");
            toolTip_PAA.SetToolTip(comboBoxActor_PAA, "Выберите актёра");
            toolTip_PAA.SetToolTip(textBoxSearch_PAA, "Введите тему для поиска");
            toolTip_PAA.SetToolTip(numericUpDownFilterMin_PAA, "Минимальная длительность в секундах");
            toolTip_PAA.SetToolTip(numericUpDownFilterMax_PAA, "Максимальная длительность в секундах");
            toolTip_PAA.SetToolTip(buttonClearSearch_PAA, "Сбросить поиск и показать все данные");
        }

        private void buttonAddClip_PAA_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxActor_PAA.SelectedIndex < 0)
                {
                    MessageBox.Show("Выберите актёра", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newClip = new Lib.VideoClip
                {
                    Code = textBoxCode_PAA.Text.Trim(),
                    RecordDate = dateTimePicker_PAA.Value,
                    DurationSec = (int)numericUpDownDuration_PAA.Value,
                    Theme = textBoxTheme_PAA.Text.Trim(),
                    Cost = numericUpDownCost_PAA.Value,
                    ActorId = (int)comboBoxActor_PAA.SelectedValue
                };

                // Валидация
                if (string.IsNullOrEmpty(newClip.Code))
                {
                    MessageBox.Show("Введите код клипа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newClip.DurationSec <= 0)
                {
                    MessageBox.Show("Длительность должна быть больше 0 секунд", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newClip.Cost < 0)
                {
                    MessageBox.Show("Стоимость не может быть отрицательной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newClip.RecordDate > DateTime.Now)
                {
                    MessageBox.Show("Дата записи не может быть в будущем", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка уникальности кода
                if (clips_PAA.Any(c => c.Code.Equals(newClip.Code, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show($"Код '{newClip.Code}' уже существует. Используйте уникальный код.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clips_PAA.Add(newClip);
                AddClipToTable_PAA(newClip);
                SaveToFile_PAA();
                OnDataChanged_PAA();

                // Сброс полей ввода
                textBoxCode_PAA.Clear();
                textBoxTheme_PAA.Clear();
                numericUpDownDuration_PAA.Value = 60;
                numericUpDownCost_PAA.Value = 0;

                MessageBox.Show("Клип успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления клипа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddClipToTable_PAA(Lib.VideoClip clip)
        {
            if (clip == null) return;

            var actorName = "Неизвестно";
            if (actors_PAA != null)
            {
                var actor = actors_PAA.FirstOrDefault(a => a.ActorId == clip.ActorId);
                actorName = actor?.LastName ?? "Неизвестно";
            }

            dataTableClips_PAA.Rows.Add(
                clip.Code ?? "",
                clip.RecordDate,
                clip.DurationSec,
                clip.Theme ?? "",
                clip.Cost,
                actorName,
                clip.ActorId
            );
        }

        private void UpdateActorComboBox_PAA()
        {
            if (actors_PAA != null && actors_PAA.Count > 0)
            {
                comboBoxActor_PAA.DataSource = actors_PAA;
                comboBoxActor_PAA.DisplayMember = "LastName";
                comboBoxActor_PAA.ValueMember = "ActorId";
            }
            else
            {
                comboBoxActor_PAA.DataSource = null;
                comboBoxActor_PAA.Items.Clear();
                comboBoxActor_PAA.Text = "Нет актёров";
            }
        }

        private void UpdateDisplay_PAA()
        {
            dataTableClips_PAA.Rows.Clear();

            foreach (var clip in clips_PAA)
            {
                AddClipToTable_PAA(clip);
            }
        }

        private void LoadFromFile_PAA()
        {
            try
            {
                actors_PAA = Lib.CsvDataService.LoadActors("actors.csv");
                clips_PAA = Lib.CsvDataService.LoadClips("clips.csv");

                UpdateDisplay_PAA();
                UpdateActorComboBox_PAA();
                OnDataChanged_PAA();
                MessageBox.Show("Данные успешно загружены из файлов", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToFile_PAA()
        {
            try
            {
                if (!ValidateClips_PAA(out string err))
                {
                    MessageBox.Show(err, "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Обновляем список клипов из DataGridView
                clips_PAA.Clear();
                foreach (DataRow row in dataTableClips_PAA.Rows)
                {
                    if (row[0] != DBNull.Value)
                    {
                        clips_PAA.Add(new Lib.VideoClip
                        {
                            Code = row[0].ToString(),
                            RecordDate = (DateTime)row[1],
                            DurationSec = (int)row[2],
                            Theme = row[3].ToString(),
                            Cost = (decimal)row[4],
                            ActorId = row[6] != DBNull.Value ? (int)row[6] : 0
                        });
                    }
                }

                Lib.CsvDataService.SaveActors("actors.csv", actors_PAA);
                Lib.CsvDataService.SaveClips("clips.csv", clips_PAA);

                OnDataChanged_PAA();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_PAA_Click(object sender, EventArgs e)
        {
            SaveToFile_PAA();
            MessageBox.Show("Данные успешно сохранены в файлы", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLoad_PAA_Click(object sender, EventArgs e)
        {
            LoadFromFile_PAA();
        }

        private void buttonSearch_PAA_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch_PAA.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Введите тему для поиска", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var filtered = clips_PAA.Where(c =>
                c.Theme.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

            dataTableClips_PAA.Rows.Clear();
            foreach (var clip in filtered)
            {
                AddClipToTable_PAA(clip);
            }
            OnDataChanged_PAA();

            MessageBox.Show($"Найдено {filtered.Count} клипов по теме '{searchTerm}'",
                "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonClearSearch_PAA_Click(object sender, EventArgs e)
        {
            textBoxSearch_PAA.Clear();
            UpdateDisplay_PAA();
            OnDataChanged_PAA();
            MessageBox.Show("Поиск сброшен. Отображаются все данные.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSort_PAA_Click(object sender, EventArgs e)
        {
            if (clips_PAA.Count == 0)
            {
                MessageBox.Show("Нет данных для сортировки", "Сортировка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sorted = clips_PAA.OrderByDescending(c => c.Cost).ToList();

            dataTableClips_PAA.Rows.Clear();
            foreach (var clip in sorted)
            {
                AddClipToTable_PAA(clip);
            }
            OnDataChanged_PAA();

            MessageBox.Show("Данные отсортированы по стоимости (от большей к меньшей)",
                "Сортировка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonFilter_PAA_Click(object sender, EventArgs e)
        {
            int minDuration = (int)numericUpDownFilterMin_PAA.Value;
            int maxDuration = (int)numericUpDownFilterMax_PAA.Value;

            if (minDuration > maxDuration)
            {
                MessageBox.Show("Минимальная длительность не может быть больше максимальной",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filtered = clips_PAA.Where(c =>
                c.DurationSec >= minDuration && c.DurationSec <= maxDuration).ToList();

            dataTableClips_PAA.Rows.Clear();
            foreach (var clip in filtered)
            {
                AddClipToTable_PAA(clip);
            }
            OnDataChanged_PAA();

            MessageBox.Show($"Найдено {filtered.Count} клипов с длительностью от {minDuration} до {maxDuration} секунд",
                "Результаты фильтрации", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonStats_PAA_Click(object sender, EventArgs e)
        {
            if (clips_PAA.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения статистики", "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string statsText = $"ПОДРОБНАЯ СТАТИСТИКА:\n";
            statsText += $"══════════════════════\n";
            statsText += $"Общее количество клипов: {clips_PAA.Count}\n";

            var stats = Lib.StatsService.CalculateCostStats(clips_PAA);
            statsText += $"Общая стоимость всех клипов: {stats.Sum:F2} руб.\n";
            statsText += $"Средняя стоимость клипа: {stats.Avg:F2} руб.\n";
            statsText += $"Самый дорогой клип: {stats.Max:F2} руб.\n";
            statsText += $"Самый дешёвый клип: {stats.Min:F2} руб.\n\n";

            var byTheme = Lib.StatsService.CountByTheme(clips_PAA);
            statsText += $"РАСПРЕДЕЛЕНИЕ ПО ТЕМАМ:\n";
            statsText += $"══════════════════════\n";

            foreach (var kv in byTheme.OrderByDescending(x => x.Value))
            {
                statsText += $"{kv.Key}: {kv.Value} клипов\n";
            }

            statsText += $"\nСАМАЯ ПОПУЛЯРНАЯ ТЕМА: {byTheme.OrderByDescending(x => x.Value).FirstOrDefault().Key}";

            MessageBox.Show(statsText, "Подробная статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonChart_PAA_Click(object sender, EventArgs e)
        {
            if (clips_PAA.Count == 0)
            {
                MessageBox.Show("Нет данных для построения графика", "График", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var byTheme = Lib.StatsService.CountByTheme(clips_PAA);

            string chartText = "ГРАФИК РАСПРЕДЕЛЕНИЯ КЛИПОВ ПО ТЕМАМ:\n";
            chartText += "═══════════════════════════════\n";

            foreach (var kv in byTheme.OrderByDescending(x => x.Value))
            {
                chartText += $"{kv.Key}: {new string('█', kv.Value)} ({kv.Value})\n";
            }

            MessageBox.Show(chartText, "График распределения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonExportExcel_PAA_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    saveDialog.Title = "Экспорт данных";
                    saveDialog.FileName = $"видеоклипы_экспорт_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                    saveDialog.DefaultExt = "csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                        {
                            // Заголовки
                            for (int i = 0; i < dataGridViewClips_PAA.Columns.Count - 1; i++)
                            {
                                writer.Write($"\"{dataGridViewClips_PAA.Columns[i].HeaderText}\"");
                                if (i < dataGridViewClips_PAA.Columns.Count - 2) writer.Write(";");
                            }
                            writer.WriteLine();

                            // Данные
                            for (int i = 0; i < dataGridViewClips_PAA.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < dataGridViewClips_PAA.Columns.Count - 1; j++)
                                {
                                    var value = dataGridViewClips_PAA.Rows[i].Cells[j].Value;
                                    writer.Write($"\"{value?.ToString() ?? ""}\"");
                                    if (j < dataGridViewClips_PAA.Columns.Count - 2) writer.Write(";");
                                }
                                writer.WriteLine();
                            }
                        }

                        MessageBox.Show($"Данные успешно экспортированы в файл:\n{saveDialog.FileName}\n\n" +
                                      $"Всего экспортировано: {dataGridViewClips_PAA.Rows.Count - 1} записей",
                            "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта данных:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAbout_PAA_Click(object sender, EventArgs e)
        {
            string aboutText = "КАТАЛОГ ВИДЕОКЛИПОВ\n" +
                             "═══════════════════\n\n" +
                             "Разработчик: Панькова Ангелина Алексеевна\n" +
                             "Группа: ПИНб-25-1\n\n" +
                             "Программа разработана в рамках изучения языка C#\n\n" +
                             "Тюменский индустриальный университет (с) 2025\n" +
                             "Высшая школа цифровых технологий (с) 2025";

            MessageBox.Show(aboutText, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHelp_PAA_Click(object sender, EventArgs e)
        {
            string helpText = "РУКОВОДСТВО ПОЛЬЗОВАТЕЛЯ\n" +
                            "══════════════════════\n\n" +
                            "1. ДОБАВЛЕНИЕ НОВОГО КЛИПА:\n" +
                            "   • Заполните все поля: Код, Тема, Дата, Длительность, Стоимость\n" +
                            "   • Выберите актёра из списка\n" +
                            "   • Нажмите кнопку 'Добавить клип'\n\n" +
                            "2. РЕДАКТИРОВАНИЕ ДАННЫХ:\n" +
                            "   • Кликните дважды на ячейке в таблице\n" +
                            "   • Внесите изменения\n" +
                            "   • Данные сохраняются автоматически\n\n" +
                            "3. ПОИСК КЛИПОВ:\n" +
                            "   • Введите тему в поле поиска\n" +
                            "   • Нажмите кнопку 'Найти'\n" +
                            "   • Для сброса поиска нажмите 'Сбросить'\n\n" +
                            "4. СОРТИРОВКА:\n" +
                            "   • Нажмите 'Сортировать' для сортировки по стоимости\n" +
                            "   • Отсортируется от самой высокой к самой низкой стоимости\n\n" +
                            "5. ФИЛЬТРАЦИЯ:\n" +
                            "   • Укажите минимальную и максимальную длительность\n" +
                            "   • Нажмите 'Применить'\n\n" +
                            "6. СТАТИСТИКА И ГРАФИКИ:\n" +
                            "   • Нажмите 'Статистика' для подробной статистики\n" +
                            "   • Нажмите 'График' для визуализации данных\n\n" +
                            "7. РАБОТА С ФАЙЛАМИ:\n" +
                            "   • 'Загрузить' - загрузить данные из CSV файлов\n" +
                            "   • 'Сохранить' - сохранить данные в CSV файлы\n" +
                            "   • 'Excel' - экспортировать данные в CSV файл\n\n" +
                            "8. ДОПОЛНИТЕЛЬНО:\n" +
                            "   • 'О программе' - информация о разработчике\n" +
                            "   • 'Справка' - это руководство пользователя\n" +
                            "   • 'Выход' - закрыть программу\n\n" +
                            "Все данные автоматически сохраняются при изменении!";

            MessageBox.Show(helpText, "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonExit_PAA_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из программы?\n" +
                                       "Все несохраненные изменения будут потеряны.",
                                       "Выход",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveToFile_PAA(); 
                Application.Exit();
            }
        }

        private void toolStripMenuItemAbout_PAA_Click(object sender, EventArgs e)
        {
            buttonAbout_PAA_Click(sender, e);
        }

        private void toolStripMenuItemGuide_PAA_Click(object sender, EventArgs e)
        {
            buttonHelp_PAA_Click(sender, e);
        }
    }
}