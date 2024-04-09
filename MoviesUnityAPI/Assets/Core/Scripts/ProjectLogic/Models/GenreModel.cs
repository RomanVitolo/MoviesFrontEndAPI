using System;
using SharedLibrary.Interfaces.Entities;

namespace Models
{
    [Serializable]
    internal class GenreModel : IGenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GenreModel(string name)
        {
            Name = name;
        }
    }
}