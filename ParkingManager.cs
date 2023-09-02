using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingManager
    {
        private ParkingLot parkingLot;
        private int nextAvailableSlot = 1; // Initialize the next available slot number to 1

        public ParkingManager(int totalSlots)
        {
            parkingLot = new ParkingLot(totalSlots);
        }

        public bool ParkVehicle(string registrationNumber, string type, string color)
        {
            if (parkingLot.Slots.Count >= parkingLot.TotalSlots)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return false;
            }

            // Check if the vehicle type is Mobil or Motor
            if (type != "Mobil" && type != "Motor")
            {
                Console.WriteLine("Invalid vehicle type. Only 'Mobil' or 'Motor' allowed.");
                return false;
            }

            // Check for duplicate registration numbers
            if (parkingLot.Slots.Any(v => v.RegistrationNumber == registrationNumber))
            {
                Console.WriteLine("Vehicle with the same registration number already parked.");
                return false;
            }

            Vehicle vehicle = new Vehicle(registrationNumber, type, color);

            // Find the first available slot
            int availableSlot = 0;
            for (int i = 0; i < parkingLot.TotalSlots; i++)
            {
                if (parkingLot.Slots.All(v => v.SlotNumber != i + 1))
                {
                    availableSlot = i + 1;
                    break;
                }
            }

            vehicle.SlotNumber = availableSlot;
            parkingLot.Slots.Add(vehicle);
            Console.WriteLine($"Allocated slot number: {vehicle.SlotNumber}");

            return true;
        }

        public bool Leave(int slotNumber)
        {
            if (slotNumber < 1 || slotNumber > parkingLot.Slots.Count)
            {
                Console.WriteLine("Invalid slot number.");
                return false;
            }

            parkingLot.Slots.RemoveAt(slotNumber - 1);
            Console.WriteLine($"Slot number {slotNumber} is free");

            // Decrement the count of occupied slots
            parkingLot.OccupiedSlotsCount--;

            // Decrement the next available slot number
            nextAvailableSlot--;

            return true;
        }

        public void PrintStatus()
        {
            Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColour");

            var orderedSlots = parkingLot.Slots.OrderBy(v => v.SlotNumber);

            foreach (var vehicle in orderedSlots)
            {
                Console.WriteLine($"{vehicle.SlotNumber}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.Color}");
            }
        }

        public int GetOccupiedSlotsCount()
        {
            return parkingLot.Slots.Count;
        }

        public int GetVehicleCountByType(string type)
        {
            return parkingLot.Slots.Count(v => v.Type == type);
        }

        public List<string> GetRegistrationNumbersByColor(string color)
        {
            return parkingLot.Slots
                .Where(v => v.Color == color)
                .Select(v => v.RegistrationNumber)
                .ToList();
        }

        public List<int> GetSlotNumbersByColor(string color)
        {
            return parkingLot.Slots
                .Where(v => v.Color == color)
                .Select(v => v.SlotNumber)
                .ToList();
        }

        public int GetSlotNumberByRegistrationNumber(string registrationNumber)
        {
            var vehicle = parkingLot.Slots
                .FirstOrDefault(v => v.RegistrationNumber == registrationNumber);

            if (vehicle != null)
            {
                return vehicle.SlotNumber;
            }
            else
            {
                return -1; // Not found
            }
        }

public List<string> GetOddPlateRegistrationNumbers()
{
    return parkingLot.Slots
        .Where(v => IsOddPlate(v.RegistrationNumber))
        .Select(v => v.RegistrationNumber)
        .ToList();
}

public List<string> GetEvenPlateRegistrationNumbers()
{
    return parkingLot.Slots
        .Where(v => !IsOddPlate(v.RegistrationNumber))
        .Select(v => v.RegistrationNumber)
        .ToList();
}

// Helper method to check if a registration plate is odd or even
// Helper method to check if a registration plate is odd or even
// Helper method to check if a registration plate is odd or even
private bool IsOddPlate(string registrationNumber)
{
    // Implement your logic here to determine if the plate is odd or even.
    // You should define a pattern or rule that distinguishes odd and even plates.
    // For example, you can check the format or specific characters in the registration number.
    // Modify the following logic to match your registration number format.

    // Example: Check if the last digit (considering only numeric part) is odd.
    string numericPart = new string(registrationNumber.Where(char.IsDigit).ToArray());
    int lastDigit = int.Parse(numericPart[numericPart.Length - 1].ToString());

    return lastDigit % 2 != 0; // Returns true for odd, false for even
}


    }
}
