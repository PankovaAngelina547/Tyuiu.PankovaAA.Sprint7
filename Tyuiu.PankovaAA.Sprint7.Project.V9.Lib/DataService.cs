using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tyuiu.PankovaAA.Sprint7.Lib  
{

    public sealed class VideoClip
    {
        public int Id { get; set; }
        public string Theme { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string DurationText { get; set; } = string.Empty;
        public int DurationSec { get; set; }
        public string DateText { get; set; } = string.Empty;
        public string CostText { get; set; } = string.Empty;
        public decimal? Cost { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }

    public sealed class CostStats
    {
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public decimal Avg { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }


    public static class StatsService
    {
        public static CostStats CalculateCostStats(List<VideoClip> clips)
        {
            clips ??= new List<VideoClip>();

            var clipsWithCost = clips.Where(c => c.Cost.HasValue).ToList();

            if (clipsWithCost.Count == 0)
            {
                return new CostStats
                {
                    Count = 0,
                    Sum = 0,
                    Avg = 0,
                    Min = 0,
                    Max = 0
                };
            }

            var costs = clipsWithCost.Select(c => c.Cost.Value).ToList();

            return new CostStats
            {
                Count = clipsWithCost.Count,
                Sum = costs.Sum(),
                Avg = costs.Average(),
                Min = costs.Min(),
                Max = costs.Max()
            };
        }

        public static Dictionary<string, int> CountByTheme(List<VideoClip> clips)
        {
            clips ??= new List<VideoClip>();

            return clips
                .Where(c => !string.IsNullOrWhiteSpace(c.Theme))
                .GroupBy(c => c.Theme.Trim())
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public static Dictionary<string, int> CountByCountry(List<VideoClip> clips)
        {
            clips ??= new List<VideoClip>();

            return clips
                .Where(c => !string.IsNullOrWhiteSpace(c.Country))
                .GroupBy(c => c.Country.Trim())
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }


    public static class CsvParser_PAA
    {
        private const char Separator = ';';
        private static readonly CultureInfo CultureInvariant = CultureInfo.InvariantCulture;

        public static int ParseDuration(string durationText)
        {
            if (string.IsNullOrWhiteSpace(durationText))
                return 0;

            int totalSeconds = 0;

            durationText = durationText.ToLower();

            var hourMatch = Regex.Match(durationText, @"(\d+)\s*ч");
            if (hourMatch.Success && int.TryParse(hourMatch.Groups[1].Value, out int hours))
                totalSeconds += hours * 3600;

            var minMatch = Regex.Match(durationText, @"(\d+)\s*мин");
            if (minMatch.Success && int.TryParse(minMatch.Groups[1].Value, out int minutes))
                totalSeconds += minutes * 60;

            var secMatch = Regex.Match(durationText, @"(\d+)\s*сек");
            if (secMatch.Success && int.TryParse(secMatch.Groups[1].Value, out int seconds))
                totalSeconds += seconds;

            return totalSeconds > 0 ? totalSeconds : 0;
        }

        public static decimal? ParseCost(string costText, out string currency)
        {
            currency = "";

            if (string.IsNullOrWhiteSpace(costText))
                return null;

            costText = costText.Trim().ToLower();

            if (costText.Contains("руб") || costText.Contains("rub"))
                currency = "RUB";
            else if (costText.Contains("$") || costText.Contains("доллар"))
                currency = "USD";
            else if (costText.Contains("€") || costText.Contains("евро"))
                currency = "EUR";
            else if (costText.Contains("р") || costText.Contains("р."))
                currency = "RUB";
            else
                currency = "UNKNOWN";

            string numberText = Regex.Replace(costText, @"[^\d.,]", "");

            numberText = numberText.Replace(',', '.');

            int dotCount = numberText.Count(c => c == '.');
            if (dotCount > 1)
            {
                int lastDot = numberText.LastIndexOf('.');
                numberText = numberText.Replace(".", "");
                numberText = numberText.Insert(lastDot - (dotCount - 1), ".");
            }

            decimal multiplier = 1;
            if (costText.Contains("млрд") || costText.Contains("млрд"))
                multiplier = 1000000000;
            else if (costText.Contains("млн") || costText.Contains("млн"))
                multiplier = 1000000;
            else if (costText.Contains("тыс") || costText.Contains("тыс"))
                multiplier = 1000;

            if (decimal.TryParse(numberText, NumberStyles.Any, CultureInvariant, out decimal value))
            {
                return value * multiplier;
            }

            return null;
        }

        public static List<VideoClip> ParseClipsFromFile(string filePath)
        {
            var clips = new List<VideoClip>();

            if (!File.Exists(filePath))
            {
                CreateSampleCsvFile(filePath);
                return clips;
            }

            var lines = File.ReadAllLines(filePath);

            if (lines.Length < 2) 
                return clips;

            string header = lines[0];
            if (header.StartsWith("\uFEFF"))
                header = header.Substring(1);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = SplitCsvLine(line);

                if (parts.Length < 7)
                    continue;

                try
                {
                    decimal? cost = ParseCost(parts[5], out string currency);

                    var clip = new VideoClip
                    {
                        Id = ParseInt(parts[0]),
                        Theme = parts[1]?.Trim() ?? "",
                        Title = parts[2]?.Trim() ?? "",
                        DurationText = parts[3]?.Trim() ?? "",
                        DurationSec = ParseDuration(parts[3]),
                        DateText = parts[4]?.Trim() ?? "",
                        CostText = parts[5]?.Trim() ?? "",
                        Cost = cost,
                        Currency = currency,
                        Country = parts[6]?.Trim() ?? ""
                    };

                    clips.Add(clip);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка парсинга строки {i}: {ex.Message}");
                }
            }

            return clips;
        }

        public static void SaveClipsToFile(string filePath, List<VideoClip> clips)
        {
            using StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);

            writer.WriteLine("ID;Тема;Название;Длительность ;Дата;Стоимость ;Страна");

            foreach (var clip in clips)
            {
                writer.WriteLine(
                    $"{clip.Id}{Separator}" +
                    $"{EscapeCsvField(clip.Theme)}{Separator}" +
                    $"{EscapeCsvField(clip.Title)}{Separator}" +
                    $"{EscapeCsvField(clip.DurationText)}{Separator}" +
                    $"{EscapeCsvField(clip.DateText)}{Separator}" +
                    $"{EscapeCsvField(clip.CostText)}{Separator}" +
                    $"{EscapeCsvField(clip.Country)}"
                );
            }
        }

        private static void CreateSampleCsvFile(string filePath)
        {
            var sampleClips = new List<VideoClip>
            {
                new VideoClip { Id = 1, Theme = "Фэнтези", Title = "Властелин колец", DurationText = "12 ч 10 мин", DurationSec = 43800, DateText = "2001—2003 гг.", CostText = "$2,91 млрд", Cost = 2910000000m, Currency = "USD", Country = "США" },
                new VideoClip { Id = 2, Theme = "Боевик", Title = "Мстители: Финал", DurationText = "3 ч 1 мин", DurationSec = 10860, DateText = "25 апреля 2019 г.", CostText = "2,503 млрд", Cost = 2503000000m, Currency = "USD", Country = "США" },
                new VideoClip { Id = 3, Theme = "Драма", Title = "Огонь", DurationText = "2 ч 11 мин", DurationSec = 7860, DateText = "24 декабря 2020 г.", CostText = "927379370 руб.", Cost = 927379370m, Currency = "RUB", Country = "Россия" },
                new VideoClip { Id = 4, Theme = "Детское", Title = "Хранители снов", DurationText = "1 ч 37 мин", DurationSec = 5820, DateText = "22 ноября 2012 г.", CostText = "203528912 $", Cost = 203528912m, Currency = "USD", Country = "США" },
                new VideoClip { Id = 5, Theme = "Комедия", Title = "Правила съёма: Метод Хитча", DurationText = "1 ч 58 мин", DurationSec = 7080, DateText = "2005 г.", CostText = "371 594 210 долларов", Cost = 371594210m, Currency = "USD", Country = "США" }
            };

            SaveClipsToFile(filePath, sampleClips);
        }

        private static int ParseInt(string text)
        {
            if (int.TryParse(text, out int result))
                return result;
            return 0;
        }

        private static string EscapeCsvField(string field)
        {
            if (field == null) return "";

            if (field.Contains(Separator) || field.Contains('"') || field.Contains('\n'))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }
            return field;
        }

        private static string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;
            string currentField = "";

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        currentField += '"';
                        i++; 
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == Separator && !inQuotes)
                {
                    result.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += c;
                }
            }

            result.Add(currentField); 
            return result.ToArray();
        }
    }
}