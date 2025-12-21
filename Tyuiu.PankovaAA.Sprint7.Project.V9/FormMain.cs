using Tyuiu.PankovaPAA.Sprint7.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tyuiu.PankovaPAA.Sprint7.Lib;

namespace Tyuiu.PankovaPAA.Sprint7.App
{
    public partial class FormMain : Form
    {
        // мастер-данные (вся база)
        private readonly List<Actor> actors_PAA = new List<Actor>();
        private readonly List<VideoClip> clipsMaster_PAA = new List<VideoClip>();

        // то, что показываем в таблице (после поиска/фильтра/сортировки)
        private readonly List<VideoClip> clipsView_PAA = new List<VideoClip>();

        private string dataFolder_PAA;
        private string actorsPath_PAA;
        private string clipsPath_PAA;

        public FormMain()
        {
            InitializeComponent();

            dataFolder_PAA = Path.Combine(AppContext.BaseDirectory, "Data");
            if (!Directory.Exists(dataFolder_PAA))
                Directory.CreateDirectory(dataFolder_PAA);

            actorsPath_PAA = Path.Combine(dataFolder_PAA, "Actors.csv");
            clipsPath_PAA = Path.Combine(dataFolder_PAA, "Clips.csv");

            SetupCombos_PAA();
            SetupGrid_PAA();

            UpdateStatus_PAA("Готово");
        }

        private void SetupGrid_PAA()
        {
            dataGridViewClips_PAA.AutoGenerateColumns = true;
            dataGridViewClips_PAA.ReadOnly = true;
            dataGridViewClips_PAA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClips_PAA.MultiSelect = false;

            RefreshGrid_PAA();
        }

        private void SetupCombos_PAA()
        {
            comboBoxSort_PAA.Items.Clear();
            comboBoxSort_PAA.Items.Add("Без сортировки");
            comboBoxSort_PAA.Items.Add("Код (A→Z)");
            comboBoxSort_PAA.Items.Add("Дата (новые→старые)");
            comboBoxSort_PAA.Items.Add("Длительность (по возрастанию)");
            comboBoxSort_PAA.Items.Add("Стоимость (по убыванию)");
            comboBoxSort_PAA.SelectedIndex = 0;

            comboBoxTheme_PAA.Items.Clear();
            comboBoxTheme_PAA.Items.Add("Все");
            comboBoxTheme_PAA.SelectedIndex = 0;
        }

        private void RebuildThemeFilter_PAA()
        {
            var themes = clipsMaster_PAA
                .Select(c => c.Theme)
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            comboBoxTheme_PAA.Items.Clear();
            comboBoxTheme_PAA.Items.Add("Все");
            foreach (var t in themes)
                comboBoxTheme_PAA.Items.Add(t);

            comboBoxTheme_PAA.SelectedIndex = 0;
        }

        private void RefreshGrid_PAA()
        {
            dataGridViewClips_PAA.DataSource = null;
            dataGridViewClips_PAA.DataSource = clipsView_PAA;
            UpdateStatus_PAA("Обновлено");
        }

        private void UpdateStatus_PAA(string message)
        {
            labelStatus_PAA.Text = $"{message}. Показано: {clipsView_PAA.Count} / Всего: {clipsMaster_PAA.Count}";
        }

        // ------------------ ДЕМО/CSV ------------------

        private void buttonDemo_PAA_Click(object sender, EventArgs e)
        {
            actors_PAA.Clear();
            clipsMaster_PAA.Clear();

            actors_PAA.Add(new Actor { ActorId = 1, LastName = "Иванова", FirstName = "Анна", MiddleName = "Сергеевна", RoleType = "Вокал" });
            actors_PAA.Add(new Actor { ActorId = 2, LastName = "Петров", FirstName = "Илья", MiddleName = "Олегович", RoleType = "Рэп" });

            clipsMaster_PAA.Add(new VideoClip { Code = "CL-001", RecordDate = new DateTime(2024, 01, 10), DurationSec = 210, Theme = "Поп", Cost = 199.99m, ActorId = 1 });
            clipsMaster_PAA.Add(new VideoClip { Code = "CL-002", RecordDate = new DateTime(2024, 02, 05), DurationSec = 180, Theme = "Хип-хоп", Cost = 149.50m, ActorId = 2 });
            clipsMaster_PAA.Add(new VideoClip
            {
                Code = "CL-003",
                RecordDate = new DateTime(2024, 03, 01),
                DurationSec = 240,
                Theme = "Поп",
                Cost = 249.00m,
                ActorId = 1
            });

            RebuildThemeFilter_PAA();
            ApplyView_PAA();
            UpdateStatus_PAA("Demo загружено");
        }

        private void buttonOpen_PAA_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(clipsPath_PAA))
                {
                    MessageBox.Show(
                        "Файл Clips.csv не найден в папке Data.\nНажми Demo → Сохранить, чтобы создать CSV.",
                        "Открыть",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                actors_PAA.Clear();
                clipsMaster_PAA.Clear();

                actors_PAA.AddRange(CsvDataService.LoadActors(actorsPath_PAA));
                clipsMaster_PAA.AddRange(CsvDataService.LoadClips(clipsPath_PAA));

                RebuildThemeFilter_PAA();
                ApplyView_PAA();
                UpdateStatus_PAA("Загружено из CSV");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка открытия CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_PAA_Click(object sender, EventArgs e)
        {
            try
            {
                CsvDataService.SaveActors(actorsPath_PAA, actors_PAA);
                CsvDataService.SaveClips(clipsPath_PAA, clipsMaster_PAA);

                UpdateStatus_PAA("Сохранено в CSV");
                MessageBox.Show($"Сохранено:\n{actorsPath_PAA}\n{clipsPath_PAA}", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------ ПОИСК / ФИЛЬТР / СОРТ ------------------

        private void buttonApply_PAA_Click(object sender, EventArgs e)
        {
            ApplyView_PAA();
        }

        private void buttonReset_PAA_Click(object sender, EventArgs e)
        {
            textBoxSearch_PAA.Text = "";
            comboBoxTheme_PAA.SelectedIndex = 0;
            comboBoxSort_PAA.SelectedIndex = 0;

            ApplyView_PAA();
        }

        private void ApplyView_PAA()
        {
            string search = (textBoxSearch_PAA.Text ?? "").Trim().ToLowerInvariant();
            string theme = comboBoxTheme_PAA.SelectedItem?.ToString() ?? "Все";
            string sort = comboBoxSort_PAA.SelectedItem?.ToString() ?? "Без сортировки";

            IEnumerable<VideoClip> q = clipsMaster_PAA;

            if (!string.IsNullOrWhiteSpace(search))
            {
                q = q.Where(c =>
                    (c.Code ?? "").ToLowerInvariant().Contains(search) ||
                    (c.Theme ?? "").ToLowerInvariant().Contains(search));
            }

            if (theme != "Все")
            {
                q = q.Where(c => string.Equals(c.Theme, theme, StringComparison.OrdinalIgnoreCase));
            }

            // сортировка
            q = sort switch
            {
                "Код (A→Z)" => q.OrderBy(c => c.Code),
                "Дата (новые→старые)" => q.OrderByDescending(c => c.RecordDate),
                "Длительность (по возрастанию)" => q.OrderBy(c => c.DurationSec),
                "Стоимость (по убыванию)" => q.OrderByDescending(c => c.Cost),
                _ => q
            };

            clipsView_PAA.Clear();
            clipsView_PAA.AddRange(q);

            RefreshGrid_PAA();
        }

        // ------------------ CRUD ------------------

        private void buttonAdd_PAA_Click(object sender, EventArgs e)
        {
            var clip = new VideoClip
            {
                Code = "",
                RecordDate = DateTime.Today,
                DurationSec = 180,
                Theme = "",
                Cost = 0m,
                ActorId = (actors_PAA.Count > 0 ? actors_PAA[0].ActorId : 1)
            };

if (ShowEditDialog_PAA(clip, isEdit: false))
            {
                if (clipsMaster_PAA.Any(x => string.Equals(x.Code, clip.Code, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Код клипа должен быть уникальным.", "Добавить", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clipsMaster_PAA.Add(clip);
                RebuildThemeFilter_PAA();
                ApplyView_PAA();
                UpdateStatus_PAA("Добавлено");
            }
        }

        private void buttonEdit_PAA_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedClip_PAA();
            if (selected == null)
            {
                MessageBox.Show("Выбери строку в таблице.", "Изменить", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ищем оригинал по коду
            var original = clipsMaster_PAA.FirstOrDefault(x => x.Code == selected.Code);
            if (original == null) return;

            // копия на редактирование
            var copy = new VideoClip
            {
                Code = original.Code,
                RecordDate = original.RecordDate,
                DurationSec = original.DurationSec,
                Theme = original.Theme,
                Cost = original.Cost,
                ActorId = original.ActorId
            };

            if (ShowEditDialog_PAA(copy, isEdit: true))
            {
                // если код поменяли — проверим уникальность
                if (!string.Equals(original.Code, copy.Code, StringComparison.OrdinalIgnoreCase) &&
                    clipsMaster_PAA.Any(x => string.Equals(x.Code, copy.Code, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Код клипа должен быть уникальным.", "Изменить", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                original.Code = copy.Code;
                original.RecordDate = copy.RecordDate;
                original.DurationSec = copy.DurationSec;
                original.Theme = copy.Theme;
                original.Cost = copy.Cost;
                original.ActorId = copy.ActorId;

                RebuildThemeFilter_PAA();
                ApplyView_PAA();
                UpdateStatus_PAA("Изменено");
            }
        }

        private void buttonDelete_PAA_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedClip_PAA();
            if (selected == null)
            {
                MessageBox.Show("Выбери строку в таблице.", "Удалить", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Удалить клип {selected.Code}?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            var original = clipsMaster_PAA.FirstOrDefault(x => x.Code == selected.Code);
            if (original != null)
            {
                clipsMaster_PAA.Remove(original);
                RebuildThemeFilter_PAA();
                ApplyView_PAA();
                UpdateStatus_PAA("Удалено");
            }
        }

        private VideoClip GetSelectedClip_PAA()
        {
            if (dataGridViewClips_PAA.CurrentRow == null) return null;
            return dataGridViewClips_PAA.CurrentRow.DataBoundItem as VideoClip;
        }

        // ------------------ Встроенное окно редактирования (без новых файлов) ------------------

        private bool ShowEditDialog_PAA(VideoClip clip, bool isEdit)
        {
            using var dlg = new ClipEditDialog_PAA(clip, isEdit);
            return dlg.ShowDialog(this) == DialogResult.OK;
        }

        private sealed class ClipEditDialog_PAA : Form
        {
            private readonly VideoClip clip_PAA;

            private TextBox textBoxCode_PAA;
            private DateTimePicker dateTimePickerRecord_PAA;

      
private NumericUpDown numericDuration_PAA;
            private TextBox textBoxTheme_PAA;
            private NumericUpDown numericCost_PAA;

            private Button buttonOk_PAA;
            private Button buttonCancel_PAA;

            public ClipEditDialog_PAA(VideoClip clip, bool isEdit)
            {
                clip_PAA = clip;

                Text = isEdit ? "Изменить клип" : "Добавить клип";
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                ClientSize = new System.Drawing.Size(420, 240);

                BuildUi_PAA();
                LoadValues_PAA();
            }

            private void BuildUi_PAA()
            {
                var labelCode = new Label { Left = 15, Top = 15, Width = 120, Text = "Код клипа" };
                textBoxCode_PAA = new TextBox { Left = 150, Top = 12, Width = 240 };

                var labelDate = new Label { Left = 15, Top = 45, Width = 120, Text = "Дата записи" };
                dateTimePickerRecord_PAA = new DateTimePicker { Left = 150, Top = 42, Width = 240 };

                var labelDur = new Label { Left = 15, Top = 75, Width = 120, Text = "Длительность (сек)" };
                numericDuration_PAA = new NumericUpDown { Left = 150, Top = 72, Width = 240, Minimum = 1, Maximum = 36000 };

                var labelTheme = new Label { Left = 15, Top = 105, Width = 120, Text = "Тема" };
                textBoxTheme_PAA = new TextBox { Left = 150, Top = 102, Width = 240 };

                var labelCost = new Label { Left = 15, Top = 135, Width = 120, Text = "Стоимость" };
                numericCost_PAA = new NumericUpDown { Left = 150, Top = 132, Width = 240, Minimum = 0, Maximum = 100000000, DecimalPlaces = 2, Increment = 10 };

                buttonOk_PAA = new Button { Left = 230, Top = 185, Width = 75, Text = "OK" };
                buttonCancel_PAA = new Button { Left = 315, Top = 185, Width = 75, Text = "Отмена" };

                buttonOk_PAA.Click += ButtonOk_PAA_Click;
                buttonCancel_PAA.Click += (s, e) => DialogResult = DialogResult.Cancel;

                Controls.AddRange(new Control[]
                {
                    labelCode, textBoxCode_PAA,
                    labelDate, dateTimePickerRecord_PAA,
                    labelDur, numericDuration_PAA,
                    labelTheme, textBoxTheme_PAA,
                    labelCost, numericCost_PAA,
                    buttonOk_PAA, buttonCancel_PAA
                });
            }

            private void LoadValues_PAA()
            {
                textBoxCode_PAA.Text = clip_PAA.Code ?? "";
                dateTimePickerRecord_PAA.Value = (clip_PAA.RecordDate == default ? DateTime.Today : clip_PAA.RecordDate);
                numericDuration_PAA.Value = clip_PAA.DurationSec <= 0 ? 1 : clip_PAA.DurationSec;
                textBoxTheme_PAA.Text = clip_PAA.Theme ?? "";
                numericCost_PAA.Value = clip_PAA.Cost < 0 ? 0 : clip_PAA.Cost;
            }

            private void ButtonOk_PAA_Click(object sender, EventArgs e)
            {
                string code = (textBoxCode_PAA.Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(code))
                {
                    MessageBox.Show("Код клипа не может быть пустым.");
                    return;
                }

                string theme = (textBoxTheme_PAA.Text ?? "").Trim();

                clip_PAA.Code = code;
                clip_PAA.RecordDate = dateTimePickerRecord_PAA.Value.Date;
                clip_PAA.DurationSec = (int)numericDuration_PAA.Value;
                clip_PAA.Theme = theme;
                clip_PAA.Cost = numericCost_PAA.Value;

                DialogResult = DialogResult.OK;
            }
        }

        // ------------------ Help ------------------

        private void toolStripMenuItemAbout_PAA_Click(object sender, EventArgs e)
        {
            MessageBox.Show(

"Каталог видеоклипов\n\nРазработчик: Панькова А.А. (ПАА)\nХранение данных: CSV",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void toolStripMenuItemGuide_PAA_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Руководство:\n" +
                "1) Demo — загрузить тестовые данные.\n" +
                "2) Добавить/Изменить — управление клипами.\n" +
                "3) Поиск/Тема/Сортировка — управление отображением.\n" +
                "4) Сохранить/Открыть — работа с CSV (папка Data).",
                "Руководство пользователя",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonExit_PAA_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}