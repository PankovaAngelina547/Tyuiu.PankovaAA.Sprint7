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
        private const string ActorsFile = "test_actors.csv";
        private const string ClipsFile = "test_clips.csv";

        [TestMethod]
        public void Csv_Save_And_Load_Works()
        {
            var actors = new List<Actor>
            {
                new Actor
                {
                    ActorId = 1,
                    LastName = "Иванова",
                    FirstName = "Анна",
                    MiddleName = "Сергеевна",
                    RoleType = "Вокал"
                }
            };

            var clips = new List<VideoClip>
            {
                new VideoClip
                {
                    Code = "CL-01",
                    RecordDate = new DateTime(2024, 1, 1),
                    DurationSec = 180,
                    Theme = "Поп",
                    Cost = 199.99m,
                    ActorId = 1
                }
            };

            CsvDataService.SaveActors(ActorsFile, actors);
            CsvDataService.SaveClips(ClipsFile, clips);

            var loadedActors = CsvDataService.LoadActors(ActorsFile);
            var loadedClips = CsvDataService.LoadClips(ClipsFile);

            Assert.AreEqual(1, loadedActors.Count);
            Assert.AreEqual("Иванова", loadedActors[0].LastName);

            Assert.AreEqual(1, loadedClips.Count);
            Assert.AreEqual("CL-01", loadedClips[0].Code);

            File.Delete(ActorsFile);
            File.Delete(ClipsFile);
        }
    }
}