using System;
using System.Collections.Generic;

namespace Demo
{
    public class Player
    {
        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }

        public static IList<Player> Parse(string playerAsString)
        {
            var data = playerAsString
                .Trim()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var list = new List<Player>();

            for (int i = 0; i < data.Length; i += 2)
            {
                var player = new Player(data[i], int.Parse(data[i + 1]));
                list.Add(player);
            }
            return list;
        }
    }
}