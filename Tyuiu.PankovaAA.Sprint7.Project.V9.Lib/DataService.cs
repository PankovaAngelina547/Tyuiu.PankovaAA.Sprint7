using System.Linq;
using System;

namespace Tyuiu.PankovaPAA.Sprint7.Lib
{
    // Актёр
    public sealed class Actor
    {
        public int ActorId { get; set; }

        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        // Амплуа
        public string RoleType { get; set; } = string.Empty;

        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    }

    // Видеоклип
    public sealed class VideoClip
    {
        // Код видеоленты/клипа
        public string Code { get; set; } = string.Empty;

        public DateTime RecordDate { get; set; } = DateTime.Today;

        // Длительность (сек)
        public int DurationSec { get; set; }

        public string Theme { get; set; } = string.Empty;

        public decimal Cost { get; set; }

        // Связь с актёромт
        public int ActorId { get; set; }
    }
}