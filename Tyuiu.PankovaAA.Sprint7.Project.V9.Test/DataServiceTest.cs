using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.PankovaAA.Sprint7.Lib;

namespace Tyuiu.PankovaPAA.Sprint7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestCSVandStats()
        {
            // 1. Создаем тестовый файл
            string testFile = "test.csv";
            File.WriteAllText(testFile,
                "ID;Тема;Название;Длительность ;Дата;Стоимость ;Страна\n" +
                "1;Фэнтези;Фильм1;2 ч 30 мин;2023;1000 руб.;Россия\n" +
                "2;Боевик;Фильм2;1 ч 45 мин;2024;2000 $;США\n" +
                "3;Фэнтези;Фильм3;3 ч 00 мин;2023;1500 руб.;Россия\n" +
                "4;Драма;Фильм4;1 ч 30 мин;2024;;Корея"); // без стоимости

            try
            {
                // 2. Читаем файл
                var clips = CsvParser_PAA.ParseClipsFromFile(testFile);

                // Проверяем
                Assert.AreEqual(4, clips.Count, "Должно быть 4 фильма");
                Assert.AreEqual("Фэнтези", clips[0].Theme);
                Assert.AreEqual("Боевик", clips[1].Theme);
                Assert.AreEqual(9000, clips[0].DurationSec); // 2ч 30мин = 9000 сек

                // 3. Проверяем статистику
                var stats = StatsService.CalculateCostStats(clips);
                Assert.AreEqual(3, stats.Count, "3 фильма со стоимостью");
                Assert.AreEqual(4500, stats.Sum); // 1000+2000+1500

                var themes = StatsService.CountByTheme(clips);
                Assert.AreEqual(2, themes["Фэнтези"]);
                Assert.AreEqual(1, themes["Боевик"]);
                Assert.AreEqual(1, themes["Драма"]);

                var countries = StatsService.CountByCountry(clips);
                Assert.AreEqual(2, countries["Россия"]);
                Assert.AreEqual(1, countries["США"]);
                Assert.AreEqual(1, countries["Корея"]);
            }
            finally
            {
                // 4. Удаляем тестовый файл
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }
    }
}