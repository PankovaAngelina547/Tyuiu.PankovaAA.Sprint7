
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
        private readonly List<Actor> actors_PAA = new List<Actor>();
        private readonly List<VideoClip> clips_PAA = new List<VideoClip>();

        private string dataFolder_PAA;
        private string actorsPath_PAA;
        private string clipsPath_PAA;

        public FormMain()
        {
            InitializeComponent();

            // Папка Data рядом с exe (под CSV)
            dataFolder_PAA = Path.Combine(AppContext.BaseDirectory, "Data");
            if (!Directory.Exists(dataFolder_PAA))
                Directory.CreateDirectory(dataFolder_PAA);

            actorsPath_PAA = Path.Combine(dataFolder_PAA, "Actors.csv");
            clipsPath_PAA = Path.Combine(dataFolder_PAA, "Clips.csv");

            SetupGrid_PAA();
            UpdateStatus_PAA("Готово");
        }

        private void SetupGrid_PAA()
        {
            dataGridViewClips_PAA.AutoGenerateColumns = true;
            dataGridViewClips_PAA.DataSource = null;
            dataGridViewClips_PAA.DataSource = clips_PAA;
        }

        private void RefreshGrid_PAA()
        {
            // Перепривязка, чтобы DataGridView обновился гарантированно
            dataGridViewClips_PAA.DataSource = null;
            dataGridViewClips_PAA.DataSource = clips_PAA;
            UpdateStatus_PAA("Обновлено");
        }

        private void UpdateStatus_PAA(string message)
        {
            labelStatus_PAA.Text = $"{message}. Клип(ов): {clips_PAA.Count}";
        }

        // ----------------- КНОПКИ -----------------

        private void buttonDemo_PAA_Click(object sender, EventArgs e)
        {
            actors_PAA.Clear();
            clips_PAA.Clear();

            // демо-актёры
            actors_PAA.Add(new Actor { ActorId = 1, LastName = "Иванова", FirstName = "Анна", MiddleName = "Сергеевна", RoleType = "Вокал" });
            actors_PAA.Add(new Actor { ActorId = 2, LastName = "Петров", FirstName = "Илья", MiddleName = "Олегович", RoleType = "Рэп" });

            // демо-клипы
            clips_PAA.Add(new VideoClip { Code = "CL-001", RecordDate = new DateTime(2024, 01, 10), DurationSec = 210, Theme = "Поп", Cost = 199.99m, ActorId = 1 });
            clips_PAA.Add(new VideoClip { Code = "CL-002", RecordDate = new DateTime(2024, 02, 05), DurationSec = 180, Theme = "Хип-хоп", Cost = 149.50m, ActorId = 2 });
            clips_PAA.Add(new VideoClip { Code = "CL-003", RecordDate = new DateTime(2024, 03, 01), DurationSec = 240, Theme = "Поп", Cost = 249.00m, ActorId = 1 });

            RefreshGrid_PAA();
            UpdateStatus_PAA("Demo загружено");
        }

        private void buttonOpen_PAA_Click(object sender, EventArgs e)
        {
            // Открываем клипы (Clips.csv) — актёров читаем “параллельно” из Actors.csv
            try
            {
                // если файлов ещё нет — объясняем нормально
                if (!File.Exists(clipsPath_PAA))
                {
                    MessageBox.Show(
                        "Файл Clips.csv не найден в папке Data.\n" +
                        "Нажми Demo и потом Сохранить — тогда появятся CSV.",
                        "Открыть",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                actors_PAA.Clear();
                clips_PAA.Clear();

                actors_PAA.AddRange(CsvDataService.LoadActors(actorsPath_PAA));
                clips_PAA.AddRange(CsvDataService.LoadClips(clipsPath_PAA));

                RefreshGrid_PAA();
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
                // Если актёров пусто — сделаем минимум, чтобы CSV был консистентный
                if (actors_PAA.Count == 0 && clips_PAA.Count > 0)
                {
                    // создаём “неизвестного” актёра для всех
                    actors_PAA.Add(new Actor { ActorId = 1, LastName = "Неизвестно", FirstName = "", MiddleName = "", RoleType = "" });

                    foreach (var c in clips_PAA.Where(x => x.ActorId == 0))
                        c.ActorId = 1;
                }

                CsvDataService.SaveActors(actorsPath_PAA, actors_PAA);
                CsvDataService.SaveClips(clipsPath_PAA, clips_PAA);

                UpdateStatus_PAA("Сохранено в CSV");
                MessageBox.Show(
                    $"Сохранено:\n{actorsPath_PAA}\n{clipsPath_PAA}",
                    "Сохранить",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_PAA_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}