using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLot
    {
        public int TotalSlots { get; private set;}
        public int OccupiedSlotsCount = 0; // Initialize the count to 0
        public List<Vehicle> Slots {get; private set;}
        public ParkingLot(int totalSlots)
        {
            TotalSlots = totalSlots;
            Slots = new List<Vehicle>(totalSlots);
        }
    }
}