using System;
using System.Linq;

namespace E08_PetClinics.Models
{
    public class Clinic
    {
        private int numberOfRooms;
        private RoomsRegister roomsRegister;

        public Clinic(string name, int numberOfRooms)
        {
            this.Name = name;
            this.NumberOfRooms = numberOfRooms;
            this.roomsRegister = new RoomsRegister(numberOfRooms);
        }

        private string Name { get; set; }

        private int NumberOfRooms
        {
            get => this.numberOfRooms;
            set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                this.numberOfRooms = value;
            }
        }

        public bool TryAddPet(Pet pet)
        {
            foreach (var roomIndex in this.roomsRegister)
            {
                if (this.roomsRegister[roomIndex] == null)
                {
                    this.roomsRegister[roomIndex] = pet;
                    return true;
                }
            }
            return false;
        }

        public bool TryReleasePet()
        {
            var centralRoomIndex = this.NumberOfRooms / 2;

            for (int i = 0; i < this.NumberOfRooms; i++)
            {
                var currentIndex = (centralRoomIndex + i) % this.NumberOfRooms;
                if (this.roomsRegister[currentIndex] != null)
                {
                    this.roomsRegister[currentIndex] = null;
                    return true;
                }
            }
            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.roomsRegister.Any(i => this.roomsRegister[i] == null);
        }

        internal void PrintRoom(int index)
        {
            var room = this.roomsRegister[index];
            Console.WriteLine(room == null ? "Room empty" : room.ToString());
        }

        internal void PrintAllRooms()
        {
            for (int i = 0; i < this.NumberOfRooms; i++)
            {
                this.PrintRoom(i);
            }
        }
    }
}