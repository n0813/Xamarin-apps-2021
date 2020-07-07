using System;
namespace AmiiboPedia.Models
{
    public class Characters
    {
        public Character[] Amiibo { get; set; }
    }

    public  class Character
    {
        public string Key { get; set; }
        public string Name { get; set; }
    }
}
