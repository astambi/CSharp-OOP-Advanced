using E08_PetClinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_PetClinics
{
    public class Startup
    {
        private static Dictionary<string, Pet> pets = new Dictionary<string, Pet>();
        private static Dictionary<string, Clinic> clinics = new Dictionary<string, Clinic>();

        public static void Main()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandTokens = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();
                var command = commandTokens[0];
                commandTokens = commandTokens.Skip(1).ToList();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            CreateEntity(commandTokens);
                            break;
                        case "Add":
                            Console.WriteLine(AddPetToClinic(commandTokens));
                            break;
                        case "Release":
                            Console.WriteLine(ReleasePetFromClinic(commandTokens[0]));
                            break;
                        case "HasEmptyRooms":
                            Console.WriteLine(FindEmptyRoomsInClinic(commandTokens[0]));
                            break;
                        case "Print":
                            PrintClinicRooms(commandTokens);
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Operation!");
                }
            }
        }

        private static void PrintClinicRooms(List<string> commandTokens)
        {
            var clinicName = commandTokens[0];
            var clinic = clinics[clinicName];

            switch (commandTokens.Count)
            {
                case 1:
                    clinic.PrintAllRooms();
                    break;
                case 2:
                    clinic.PrintRoom(int.Parse(commandTokens[1]) - 1);
                    break;
                default: break;
            }
        }

        private static bool FindEmptyRoomsInClinic(string clinicName)
        {
            return clinics[clinicName].HasEmptyRooms();
        }

        private static bool ReleasePetFromClinic(string clinicName)
        {
            return clinics[clinicName].TryReleasePet();
        }

        private static bool AddPetToClinic(List<string> commandTokens)
        {
            var petName = commandTokens[0];
            var clinicName = commandTokens[1];
            var pet = pets[petName];
            var clinic = clinics[clinicName];

            if (clinic.TryAddPet(pet))
            {
                pets.Remove(petName);
                return true;
            }
            return false;
        }

        private static void CreateEntity(List<string> commandTokens)
        {
            var entityType = commandTokens[0];
            var name = commandTokens[1];

            switch (entityType)
            {
                case "Pet":
                    int age = int.Parse(commandTokens[2]);
                    string type = commandTokens[3];
                    pets[name] = new Pet(name, age, type);
                    break;
                case "Clinic":
                    int numberOfRooms = int.Parse(commandTokens[2]);
                    clinics[name] = new Clinic(name, numberOfRooms);
                    break;
                default: break;
            }
        }
    }
}