using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Tyuiu.PankovaPAA.Sprint7.Lib;

namespace Tyuiu.PankovaPAA.Sprint7.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Csv_Save_And_Load_Works()
        {
            const string actorsFile = "test_actors.csv";
            const string clipsFile = "test_clips.csv";

            var actors = new List<Actor>
            {
                new Actor { ActorId = 1, LastName="Иванова", FirstName="Анна", MiddleName="Сергеевна", RoleType="Вокал" }
            };

            var clips = new List<VideoClip>
            {
                new VideoClip { Code="CL-01", RecordDate=new DateTime(2024,1,1), DurationSec=180, Theme="Поп", Cost=199.99m, ActorId=1 },
                new VideoClip { Code="CL-02", RecordDate=new DateTime(2024,2,1), DurationSec=200, Theme="Рок", Cost=100m, ActorId=1 }
            };

            CsvDataService.SaveActors(actorsFile, actors);
            CsvDataService.SaveClips(clipsFile, clips);

            var loadedActors = CsvDataService.LoadActors(actorsFile);
            var loadedClips = CsvDataService.LoadClips(clipsFile);

            Assert.AreEqual(1, loadedActors.Count);
            Assert.AreEqual(2, loadedClips.Count);
            Assert.AreEqual("CL-02", loadedClips[1].Code);

            File.Delete(actorsFile);
            File.Delete(clipsFile);
        }

        [TestMethod]
        public void Stats_Calculate_Works()
        {
            var clips = new List<VideoClip>
            {
                new VideoClip { Cost = 10m, Theme = "Поп" },
                new VideoClip { Cost = 30m, Theme = "Поп" },
                new VideoClip { Cost = 20m, Theme = "Рок" }
            };

            var stats = StatsService.CalculateCostStats(clips);
            Assert.AreEqual(3, stats.Count);
            Assert.AreEqual(60m, stats.Sum);
            Assert.AreEqual(20m, stats.Avg);
            Assert.AreEqual(10m, stats.Min);
            Assert.AreEqual(30m, stats.Max);

            var byTheme = StatsService.CountByTheme(clips);
            Assert.AreEqual(2, byTheme["Поп"]);
            Assert.AreEqual(1, byTheme["Рок"]);
        }
    }
}