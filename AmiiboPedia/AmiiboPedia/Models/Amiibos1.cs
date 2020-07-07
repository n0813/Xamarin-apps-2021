using System;
namespace AmiiboPedia.Models
{
    public partial class Amiiboss
    {
        public Amiibo[] Amiibo { get; set; }
    }

    public partial class Amiibo
    {
        public string AmiiboSeries { get; set; }
        public string Character { get; set; }
        public string GameSeries { get; set; }
        public string Head { get; set; }
        public Uri Image { get; set; }
        public string Name { get; set; }
        public Release Release { get; set; }
        public string Tail { get; set; }
        public string Type { get; set; }
    }

    public partial class Release
    {
        public DateTimeOffset Au { get; set; }
        public DateTimeOffset Eu { get; set; }
        public DateTimeOffset Jp { get; set; }
        public DateTimeOffset Na { get; set; }
    }
}
