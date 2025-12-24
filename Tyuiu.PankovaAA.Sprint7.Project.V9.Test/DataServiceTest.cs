using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.PankovaAA.Sprint7.Lib;

namespace Tyuiu.PankovaAA.Sprint7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestParseDuration_PAA()
        {
            int result = CsvParser_PAA.ParseDuration("2 ч 30 мин");
            Assert.AreEqual(9000, result);
        }

        [TestMethod]
        public void TestCalculateCostStats_PAA()
        {
            var clips = new List<VideoClip>
            {
                new VideoClip { Cost = 100 },
                new VideoClip { Cost = 200 }
            };

            var stats = StatsService.CalculateCostStats(clips);
            Assert.AreEqual(300, stats.Sum);
        }
    }
}