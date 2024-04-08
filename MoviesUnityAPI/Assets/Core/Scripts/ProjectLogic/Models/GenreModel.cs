using System;

namespace Models
{
    [Serializable]
    internal class GenreModel
    {
        public string Name { get; set; }

        public GenreModel(string name)
        {
            Name = name;
        }
    }
}