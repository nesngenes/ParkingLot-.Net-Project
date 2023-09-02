using System;

namespace ParkingLot
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string Type { get; set; } // Mobil atau Motor
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public int SlotNumber { get; set; } // Add SlotNumber property

        public Vehicle(string registrationNumber, string type, string color)
        {
            RegistrationNumber = registrationNumber;
            Type = type;
            Color = color;
            EntryTime = DateTime.Now;
        }
    }
}
