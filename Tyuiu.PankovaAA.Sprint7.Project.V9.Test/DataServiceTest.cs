using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.PankovaAA.Sprint7.Lib;
using System.Collections.Generic;

namespace Tyuiu.PankovaAA.Sprint7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestParseDuration_PAA()
        {
            Assert.AreEqual(9000, CsvParser_PAA.ParseDuration("2 ч 30 мин"));
            Assert.AreEqual(7380, CsvParser_PAA.ParseDuration("2 ч 3 мин"));
            Assert.AreEqual(180, CsvParser_PAA.ParseDuration("3 мин"));
            Assert.AreEqual(7200, CsvParser_PAA.ParseDuration("2 ч"));
            Assert.AreEqual(0, CsvParser_PAA.ParseDuration(""));
        }

        [TestMethod]
        public void TestParseCost_PAA()
        {
            decimal? cost1 = CsvParser_PAA.ParseCost("$1.5 млн", out string currency1);
            Assert.AreEqual(1500000m, cost1);
            Assert.AreEqual("USD", currency1);

            decimal? cost2 = CsvParser_PAA.ParseCost("1000 руб.", out string currency2);
            Assert.AreEqual(1000m, cost2);
            Assert.AreEqual("RUB", currency2);

            decimal? cost3 = CsvParser_PAA.ParseCost("500 €", out string currency3);
            Assert.AreEqual(500m, cost3);
            Assert.AreEqual("EUR", currency3);
        }

        [TestMethod]
        public void TestCalculateCostStats_PAA()
        {
            var clips = new List<VideoClip>
            {
                new VideoClip { Cost = 100m },
                new VideoClip { Cost = 200m },
                new VideoClip { Cost = 300m },
                new VideoClip { Cost = null }
            };

            var stats = StatsService.CalculateCostStats(clips);
            Assert.AreEqual(3, stats.Count);
            Assert.AreEqual(600m, stats.Sum);
            Assert.AreEqual(200m, stats.Avg);
            Assert.AreEqual(100m, stats.Min);
            Assert.AreEqual(300m, stats.Max);
        }

        [TestMethod]
        public void TestCountByTheme_PAA()
        {
            var clips = new List<VideoClip>
            {
                new VideoClip { Theme = "Фэнтези" },
                new VideoClip { Theme = "Фэнтези" },
                new VideoClip { Theme = "Боевик" },
                new VideoClip { Theme = "" }
            };

            var result = StatsService.CountByTheme(clips);
            Assert.AreEqual(2, result["Фэнтези"]);
            Assert.AreEqual(1, result["Боевик"]);
        }

        [TestMethod]
        public void TestCountByCountry_PAA()
        {
            var clips = new List<VideoClip>
            {
                new VideoClip { Country = "США" },
                new VideoClip { Country = "США" },
                new VideoClip { Country = "Россия" },
                new VideoClip { Country = "" }
            };

            var result = StatsService.CountByCountry(clips);
            Assert.AreEqual(2, result["США"]);
            Assert.AreEqual(1, result["Россия"]);
        }

        [TestMethod]
        public void TestEmptyData_PAA()
        {
            var emptyList = new List<VideoClip>();

            var stats = StatsService.CalculateCostStats(emptyList);
            Assert.AreEqual(0, stats.Count);
            Assert.AreEqual(0m, stats.Sum);

            var themes = StatsService.CountByTheme(emptyList);
            Assert.AreEqual(0, themes.Count);

            var countries = StatsService.CountByCountry(emptyList);
            Assert.AreEqual(0, countries.Count);
        }
    }
}