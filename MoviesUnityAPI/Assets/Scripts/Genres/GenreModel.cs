using System;

namespace Genres
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