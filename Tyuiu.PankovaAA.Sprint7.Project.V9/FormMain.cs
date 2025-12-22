using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tyuiu.PankovaPAA.Sprint7.Lib;

namespace Tyuiu.PankovaPAA.Sprint7.App
{
    public partial class FormMain : Form
    {
        private readonly List<Actor> actors_PAA = new();
        private readonly List<VideoClip> clips_PAA = new();

        private readonly string dataFolder_PAA;
        private readonly string actorsPath_PAA;
        private readonly string clipsPath_PAA;

        public FormMain()
        {
            InitializeComponent();

            dataFolder_PAA = Path.Combine(AppContext.BaseDirectory, "Data");
            Directory.CreateDirectory(dataFolder_PAA);

            actorsPath_PAA = Path.Combine(dataFolder_PAA, "Actors.csv");
            clipsPath_PAA = Path.Combine(dataFolder_PAA, "Clips.csv");

            dataGridViewClips_PAA.DataSource = clips_PAA;
        }

        private void buttonDemo_PAA_Click(object sender, EventArgs e)
        {
            actors_PAA.Clear();
            clips_PAA.Clear();

            actors_PAA.Add(new Actor { ActorId = 1, LastName = "Иванова", FirstName = "Анна", RoleType = "Вокал" });

            clips_PAA.Add(new VideoClip { Code = "CL-001", RecordDate = DateTime.Today, DurationSec = 200, Theme = "Поп", Cost = 100 });
            clips_PAA.Add(new VideoClip { Code = "CL-002", RecordDate = DateTime.Today, DurationSec = 180, Theme = "Рок", Cost = 150 });
            clips_PAA.Add(new VideoClip { Code = "CL-003", RecordDate = DateTime.Today, DurationSec = 220, Theme = "Поп", Cost = 120 });

            RefreshAll_PAA();
        }

        private void buttonOpen_PAA_Click(object sender, EventArgs e)
        {
            clips_PAA.Clear();
            clips_PAA.AddRange(CsvDataService.LoadClips(clipsPath_PAA));
            RefreshAll_PAA();
        }

        private void buttonSave_PAA_Click(object sender, EventArgs e)
        {
            CsvDataService.SaveActors(actorsPath_PAA, actors_PAA);
            CsvDataService.SaveClips(clipsPath_PAA, clips_PAA);
        }

        private void RefreshAll_PAA()
        {
            dataGridViewClips_PAA.DataSource = null;
            dataGridViewClips_PAA.DataSource = clips_PAA;
            UpdateStatistics_PAA();
        }

        private void UpdateStatistics_PAA()
        {
            if (clips_PAA.Count == 0)
            {
                labelStats_PAA.Text = "Нет данных";
                chartThemes_PAA.Series[0].Points.Clear();
                return;
            }

            labelStats_PAA.Text =
                $"Количество: {clips_PAA.Count}\n" +
                $"Сумма: {clips_PAA.Sum(c => c.Cost).ToString("F2", CultureInfo.InvariantCulture)}\n" +
                $"Среднее: {clips_PAA.Average(c => c.Cost).ToString("F2", CultureInfo.InvariantCulture)}\n" +
                $"Min: {clips_PAA.Min(c => c.Cost).ToString("F2", CultureInfo.InvariantCulture)}\n" +
                $"Max: {clips_PAA.Max(c => c.Cost).ToString("F2", CultureInfo.InvariantCulture)}";

            var series = chartThemes_PAA.Series[0];
            series.Points.Clear();

            foreach (var g in clips_PAA.GroupBy(c => c.Theme))
                series.Points.AddXY(g.Key, g.Count());
        }

        private void toolStripMenuItemAbout_PAA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Каталог видеоклипов\nПанькова А.А.", "О программе");
        }

        private void toolStripMenuItemGuide_PAA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Demo → данные\nСохранить/Открыть → CSV\nСтатистика и диаграмма считаются автоматически", "Руководство");
        }
    }
}