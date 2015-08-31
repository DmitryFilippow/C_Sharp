using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheatsDBSQL
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public enum GenrEnum
    {
        Action,
        RPG,
        Strategy,
        Race,
        Sport,
        Fly,
        Puzzle,
        Arcade,
        Card
    }

    public class Cheat:Entity
    {
        public string FileName { get; set; }
        public string GameName { get; set; }
        public int Genre { get; set; }
    }
}
