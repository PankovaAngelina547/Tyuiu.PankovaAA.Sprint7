using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Tyuiu.PankovaPAA.Sprint7.Lib
{
    // МОДЕЛИ

    public sealed class Actor
    {
        public int ActorId { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string RoleType { get; set; } = string.Empty;
    }

    public sealed class VideoClip
    {
        public string Code { get; set; } = string.Empty;
        public DateTime RecordDate { get; set; }
        public int DurationSec { get; set; }
        public string Theme { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int ActorId { get; set; }
    }

    public sealed class CostStats
    {
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public decimal Avg { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }

    // СЕРВИСЫ

    public static class StatsService
    {
        public static CostStats CalculateCostStats(List<VideoClip> clips)
        {
            clips ??= new List<VideoClip>();

            if (clips.Count == 0)
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

            return new CostStats
            {
                Count = clips.Count,
                Sum = clips.Sum(c => c.Cost),
                Avg = clips.Average(c => c.Cost),
                Min = clips.Min(c => c.Cost),
                Max = clips.Max(c => c.Cost)
            };
        }

        public static Dictionary<string, int> CountByTheme(List<VideoClip> clips)
        {
            clips ??= new List<VideoClip>();

            return clips
                .GroupBy(c => string.IsNullOrWhiteSpace(c.Theme) ? "Без темы" : c.Theme.Trim())
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }

    // РАБОТА С CSV

    public static class CsvDataService
    {
        private const char Separator = ';';

        //Сохранение

        public static void SaveActors(string filePath, List<Actor> actors)
        {
            using StreamWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine("ActorId;LastName;FirstName;MiddleName;RoleType");

            foreach (var a in actors)
            {
                writer.WriteLine(
                    $"{a.ActorId}{Separator}{a.LastName}{Separator}{a.FirstName}{Separator}{a.MiddleName}{Separator}{a.RoleType}"
                );
            }
        }

        public static void SaveClips(string filePath, List<VideoClip> clips)
        {
            using StreamWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine("Code;RecordDate;DurationSec;Theme;Cost;ActorId");

            foreach (var c in clips)
            {
                writer.WriteLine(
                    $"{c.Code}{Separator}" +
                    $"{c.RecordDate:yyyy-MM-dd}{Separator}" +
                    $"{c.DurationSec}{Separator}" +
                    $"{c.Theme}{Separator}" +
                    $"{c.Cost.ToString(CultureInfo.InvariantCulture)}{Separator}" +
                    $"{c.ActorId}"
                );
            }
        }

        //Чтение

        public static List<Actor> LoadActors(string filePath)
        {
            List<Actor> result = new List<Actor>();

            if (!File.Exists(filePath))
                return result;

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(Separator);

                result.Add(new Actor
                {
                    ActorId = int.Parse(parts[0]),
                    LastName = parts[1],
                    FirstName = parts[2],
                    MiddleName = parts[3],
                    RoleType = parts[4]
                });
            }

            return result;
        }

        public static List<VideoClip> LoadClips(string filePath)
        {
            List<VideoClip> result = new List<VideoClip>();

            if (!File.Exists(filePath))
                return result;

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(Separator);

                result.Add(new VideoClip
                {
                    Code = parts[0],
                    RecordDate = DateTime.Parse(parts[1]),
                    DurationSec = int.Parse(parts[2]),
                    Theme = parts[3],
                    Cost = decimal.Parse(parts[4], CultureInfo.InvariantCulture),
                    ActorId = int.Parse(parts[5])
                });
            }

            return result;
        }
    }
}