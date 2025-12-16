using System.Globalization;

namespace Tyuiu.PankovaAA.Sprint7.Project.V9.Lib
{
    public class VideoClip
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public string Theme { get; set; }
        public decimal Price { get; set; }

        public string ActorLastName { get; set; }
        public string ActorFirstName { get; set; }
        public string ActorMiddleName { get; set; }
        public string ActorRole { get; set; }
    }

    public class CatalogManager
    {
        private List<VideoClip> clips = new List<VideoClip>();
        public void Add(VideoClip clip) => clips.Add(clip);

        public bool Remove(int id)
        {
            var clip = clips.FirstOrDefault(c => c.Id == id);
            return clip != null && clips.Remove(clip);
        }

        public VideoClip GetById(int id) => clips.FirstOrDefault(c => c.Id == id);

        public void Update(int id, VideoClip newData)
        {
            var clip = GetById(id);
            if (clip != null)
            {
                clip.Date = newData.Date;
                clip.Duration = newData.Duration;
                clip.Theme = newData.Theme;
                clip.Price = newData.Price;
                clip.ActorLastName = newData.ActorLastName;
                clip.ActorFirstName = newData.ActorFirstName;
                clip.ActorMiddleName = newData.ActorMiddleName;
                clip.ActorRole = newData.ActorRole;
            }
        }
        public List<VideoClip> Search(string keyword)
        {
            return clips.Where(c =>
                c.Theme.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.ActorLastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.ActorFirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.ActorRole.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public List<VideoClip> Sort(string by, bool ascending = true)
        {
            switch (by.ToLower())
            {
                case "date":
                    return ascending ?
                        clips.OrderBy(c => c.Date).ToList() :
                        clips.OrderByDescending(c => c.Date).ToList();

                case "price":
                    return ascending ?
                        clips.OrderBy(c => c.Price).ToList() :
                        clips.OrderByDescending(c => c.Price).ToList();

                case "duration":
                    return ascending ?
                        clips.OrderBy(c => c.Duration).ToList() :
                        clips.OrderByDescending(c => c.Duration).ToList();

                case "theme":
                    return ascending ?
                        clips.OrderBy(c => c.Theme).ToList() :
                        clips.OrderByDescending(c => c.Theme).ToList();

                default:
                    return clips;
            }
        }
        public List<VideoClip> FilterByDate(DateTime from, DateTime to)
        {
            return clips.Where(c => c.Date >= from && c.Date <= to).ToList();
        }

        public List<VideoClip> FilterByPrice(decimal min, decimal max)
        {
            return clips.Where(c => c.Price >= min && c.Price <= max).ToList();
        }

        public class Stats
        {
            public int Count { get; set; }
            public decimal TotalPrice { get; set; }
            public decimal AvgPrice { get; set; }
            public decimal MinPrice { get; set; }
            public decimal MaxPrice { get; set; }
            public TimeSpan TotalTime { get; set; }
            public TimeSpan AvgTime { get; set; }
            public int ThemesCount { get; set; }
        }

        public Stats GetStats()
        {
            if (!clips.Any()) return new Stats();

            return new Stats
            {
                Count = clips.Count,
                TotalPrice = clips.Sum(c => c.Price),
                AvgPrice = clips.Average(c => c.Price),
                MinPrice = clips.Min(c => c.Price),
                MaxPrice = clips.Max(c => c.Price),
                TotalTime = TimeSpan.FromMinutes(clips.Sum(c => c.Duration.TotalMinutes)),
                AvgTime = TimeSpan.FromMinutes(clips.Average(c => c.Duration.TotalMinutes)),
                ThemesCount = clips.Select(c => c.Theme).Distinct().Count()
            };
        }
        public void SaveToFile(string path)
        {
            var lines = new List<string> { "ID,Date,Duration,Theme,Price,LastName,FirstName,MiddleName,Role" };

            foreach (var clip in clips)
            {
                lines.Add($"{clip.Id},{clip.Date:yyyy-MM-dd},{clip.Duration},{clip.Theme}," +
                         $"{clip.Price},{clip.ActorLastName},{clip.ActorFirstName}," +
                         $"{clip.ActorMiddleName},{clip.ActorRole}");
            }

            File.WriteAllLines(path, lines);
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;

            var lines = File.ReadAllLines(path);
            clips.Clear();

            for (int i = 1; i < lines.Length; i++) 
            {
                var parts = lines[i].Split(',');
                if (parts.Length >= 9)
                {
                    clips.Add(new VideoClip
                    {
                        Id = int.Parse(parts[0]),
                        Date = DateTime.ParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Duration = TimeSpan.Parse(parts[2]),
                        Theme = parts[3],
                        Price = decimal.Parse(parts[4], CultureInfo.InvariantCulture),
                        ActorLastName = parts[5],
                        ActorFirstName = parts[6],
                        ActorMiddleName = parts[7],
                        ActorRole = parts[8]
                    });
                }
            }
        }

        public Dictionary<string, int> GetChartData(string type)
        {
            if (type == "themes")
            {
                return clips
                    .GroupBy(c => c.Theme)
                    .ToDictionary(g => g.Key, g => g.Count());
            }
            else if (type == "prices")
            {
                return clips
                    .GroupBy(c => c.Theme)
                    .ToDictionary(g => g.Key, g => (int)g.Sum(c => c.Price));
            }

            return new Dictionary<string, int>();
        }

        public List<VideoClip> GetAll() => clips;

        public void Clear() => clips.Clear();

        public string Validate(VideoClip clip)
        {
            if (clip.Id <= 0) return "ID должен быть больше 0";
            if (clip.Date > DateTime.Now) return "Дата не может быть в будущем";
            if (clip.Duration <= TimeSpan.Zero) return "Длительность должна быть больше 0";
            if (clip.Price < 0) return "Цена не может быть отрицательной";
            if (string.IsNullOrEmpty(clip.Theme)) return "Введите тему";
            if (string.IsNullOrEmpty(clip.ActorLastName)) return "Введите фамилию актера";

            return null;
        }
    }
}

