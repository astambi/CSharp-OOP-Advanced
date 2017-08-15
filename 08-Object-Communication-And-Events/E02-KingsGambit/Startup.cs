using E02_KingsGambit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_KingsGambit
{
    public class Startup
    {
        public static void Main()
        {
            var king = new King(Console.ReadLine());
            var soldiers = new List<Soldier>();

            var guardsNames = ParseInput(Console.ReadLine());
            var footmenNames = ParseInput(Console.ReadLine());

            foreach (var name in guardsNames)
            {
                var royalGuard = new RoyalGuard(name);
                soldiers.Add(royalGuard);
                king.UnderAttack += royalGuard.KingUnderAttack;
            }
            foreach (var name in footmenNames)
            {
                var footman = new Footman(name);
                soldiers.Add(footman);
                king.UnderAttack += footman.KingUnderAttack;
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                var commandArgs = ParseInput(input);
                var command = commandArgs[0];

                switch (command)
                {
                    case "Kill":
                        var soldierName = commandArgs[1];
                        var soldier = soldiers.FirstOrDefault(s => s.Name == soldierName);
                        king.UnderAttack -= soldier.KingUnderAttack;
                        soldiers.Remove(soldier);
                        break;
                    case "Attack":
                        king.OnAttack();
                        break;
                    default: break;
                }
            }
        }

        private static string[] ParseInput(string input)
        {
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
