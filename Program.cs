using System;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parking System");

            ParkingManager parkingManager = null;

            while (true)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine().Trim();;

                string[] parts = command.Split(' ');

                if (parts.Length == 0)
                {
                    Console.WriteLine("Invalid command.");
                    continue;
                }

                string action = parts[0].ToLower();

                switch (action)
                {
                    case "create_parking_lot":
                        if (parts.Length == 2)
                        {
                            int newTotalSlots = int.Parse(parts[1]);
                            parkingManager = new ParkingManager(newTotalSlots);
                            Console.WriteLine($"Created a parking lot with {newTotalSlots} slots");
                        }
                        else
                        {
                            Console.WriteLine("Invalid create_parking_lot command. Usage: create_parking_lot [TotalSlots]");
                        }
                        break;

                    case "park":
                    if (parts.Length == 4)
                    {
                        if (parkingManager == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                        }
                        else
                        {
                            string registrationNumber = parts[1];
                            string color = parts[2];
                            string type = parts[3];
                            parkingManager.ParkVehicle(registrationNumber, type, color);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid park command. Usage: park [RegistrationNumber] [Color] [Type]");
                    }
                    break;
                    
                    case "leave":
                        if (parts.Length == 2)
                        {
                            int slotNumber = int.Parse(parts[1]);
                            parkingManager.Leave(slotNumber);
                        }
                        else 
                        {
                            Console.WriteLine("Invalid leave command. Usage: leave [SlotNumber]");
                        }
                        break;
                    case "status":
                        parkingManager.PrintStatus();
                        break;
                    case "type_of_vehicles":
                        if (parts.Length == 2)
                        {
                            string type = parts[1];
                            int count = parkingManager.GetVehicleCountByType(type);
                            Console.WriteLine(count);
                        }
                        else
                        {
                            Console.WriteLine("Invalid type_of_vehicles command. Usage: type_of_vehicles [Type]");
                        }
                        break;
                    case "registration_numbers_for_vehicles_with_ood_plate":
                if (parkingManager == null)
                {
                    Console.WriteLine("Please create a parking lot first.");
                }
                else
                {
                    var oddPlateNumbers = parkingManager.GetOddPlateRegistrationNumbers();
                    Console.WriteLine("registration_numbers_for_vehicles_with_ood_plate");
                    Console.WriteLine(string.Join(", ", oddPlateNumbers));
                }
                break;

            case "registration_numbers_for_vehicles_with_event_plate":
                if (parkingManager == null)
                {
                    Console.WriteLine("Please create a parking lot first.");
                }
                else
                {
                    var evenPlateNumbers = parkingManager.GetEvenPlateRegistrationNumbers();
                    Console.WriteLine("registration_numbers_for_vehicles_with_even_plate");
                    Console.WriteLine(string.Join(", ", evenPlateNumbers));
                }
                break;
                    case "registration_numbers_for_vehicles_with_colour":
                        if (parts.Length == 2)
                        {
                            string color = parts[1];
                            var registrationNumbers = parkingManager.GetRegistrationNumbersByColor(color);
                            Console.WriteLine(string.Join(", ", registrationNumbers));
                        }
                        else 
                        {
                            Console.WriteLine("Invalid registration_numbers_for_vehicles_with_colour command. Usage: registration_numbers_for_vehicles_with_colour [Color]");
                        }
                        break;
    
                    case "slot_numbers_for_vehicles_with_colour":
                        if (parts.Length == 2)
                        {
                            string color = parts[1];
                            var slotNumbers = parkingManager.GetSlotNumbersByColor(color);
                            Console.WriteLine(string.Join(", ", slotNumbers));
                        }
                        else
                        {
                            Console.WriteLine("Invalid slot_numbers_for_vehicles_with_colour command. Usage: slot_numbers_for_vehicles_with_colour [Color]");
                        }
                        break;

                    case "slot_number_for_registration_number":
                        if (parts.Length == 2)
                        {
                            string registrationNumber = parts[1];
                            int slotNumber = parkingManager.GetSlotNumberByRegistrationNumber(registrationNumber);

                            if (slotNumber != -1)
                            {
                                Console.WriteLine(slotNumber);
                            }
                            else
                            {
                                Console.WriteLine("Not found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid slot_number_for_registration_number command. Usage: slot_number_for_registration_number [RegistrationNumber]");
                        }
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }

            }
        }
    }
}
