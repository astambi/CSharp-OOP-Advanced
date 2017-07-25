using E08_MilitaryElite.Interfaces;
using E08_MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_MilitaryElite
{
    public class Startup
    {
        public static void Main()
        {
            List<ISoldier> soldiers = GetSoldiers();
            PrintSoldiers(soldiers);
        }

        private static List<ISoldier> GetSoldiers()
        {
            var soldiers = new List<ISoldier>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                var soldierTokens = ParseInput(input);
                var type = soldierTokens[0];
                var id = soldierTokens[1];
                var firstName = soldierTokens[2];
                var lastName = soldierTokens[3];
                double salary = 0;

                switch (type)
                {
                    case "Private":
                        salary = double.Parse(soldierTokens[4]);
                        var privateSoldier = new Private(id, firstName, lastName, salary);
                        soldiers.Add(privateSoldier);
                        break;
                    case "LeutenantGeneral":
                        salary = double.Parse(soldierTokens[4]);
                        var leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);
                        var privatesIds = soldierTokens.Skip(5);
                        foreach (var privateId in privatesIds)
                        {
                            var priv = (Private)soldiers.FirstOrDefault(s => s.Id == privateId);
                            leutenantGeneral.Privates.Add(priv);
                        }
                        soldiers.Add(leutenantGeneral);
                        break;
                    case "Engineer":
                        salary = double.Parse(soldierTokens[4]);
                        var corps = soldierTokens[5];
                        try
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);
                            var repairs = soldierTokens.Skip(6).ToList();
                            for (int i = 0; i < repairs.Count; i += 2)
                            {
                                var repair = new Repair(repairs[i], int.Parse(repairs[i + 1]));
                                engineer.Repairs.Add(repair);
                            }
                            soldiers.Add(engineer);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        break;
                    case "Commando":
                        salary = double.Parse(soldierTokens[4]);
                        corps = soldierTokens[5];
                        try
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corps);
                            var missions = soldierTokens.Skip(6).ToList();
                            for (int i = 0; i < missions.Count; i += 2)
                            {
                                try
                                {
                                    var mission = new Mission(missions[i], missions[i + 1]);
                                    commando.Missions.Add(mission);
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                            soldiers.Add(commando);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        break;
                    case "Spy":
                        var codeNumber = int.Parse(soldierTokens[4]);
                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(spy);
                        break;
                    default: break;
                }
            }

            return soldiers;
        }

        private static void PrintSoldiers(List<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }

        private static string[] ParseInput(string input)
        {
            return input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
