using System.Collections;
using System.Collections.Generic;

namespace E08_PetClinics.Models
{
    public class RoomsRegister : IEnumerable<int>
    {
        private readonly List<Pet> rooms;
        private readonly int centralRoomIndex;

        public RoomsRegister(int numberOfRooms)
        {
            this.rooms = new List<Pet>(new Pet[numberOfRooms]); // null elements collection
            this.centralRoomIndex = numberOfRooms / 2;
        }

        public Pet this[int index]
        {
            get => this.rooms[index];
            set => this.rooms[index] = value;
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return this.centralRoomIndex;

            var step = 1;
            while (step <= this.centralRoomIndex)
            {
                yield return this.centralRoomIndex - step;
                yield return this.centralRoomIndex + step++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}