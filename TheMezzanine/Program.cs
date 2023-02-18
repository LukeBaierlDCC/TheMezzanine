using System;
using System.Collections.Generic;
using System.Linq;
using TheMezzanine;

class Program
{
    static List<MezzanineItem> inventory = new List<MezzanineItem>();

    static void Main(string[] args)
    {
        Console.WriteLine("Hello. Welcome to the Mezzanine. \nPlease select enter to continue.");
        Console.ReadLine();
        MezzanineMenu();
        Console.Clear();
        return;
    }

    static void MezzanineMenu()
    {
        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add item to inventory");
            Console.WriteLine("2. Edit item in inventory");
            Console.WriteLine("3. Search for item in inventory");
            Console.WriteLine("4. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddItem();
                    break;

                case "2":
                    EditItem();
                    break;

                case "3":
                    SearchInventory();
                    break;

                case "4":
                    Console.WriteLine("Exiting program.");
                    return;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    static void AddItem()
    {
        Console.WriteLine("Enter the name of the item:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the location of the item:");
        string location = Console.ReadLine();

        Console.WriteLine("Enter the quantity of the item:");
        int quantity = int.Parse(Console.ReadLine());

        MezzanineItem item = new MezzanineItem(name, location, quantity);
        inventory.Add(item);

        Console.WriteLine($"Added {quantity} {name} to {location}.");
    }

    static void EditItem()
    {
        Console.WriteLine("Enter the name of the item to edit:");
        string name = Console.ReadLine();

        var matchingItems = inventory.Where(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (!matchingItems.Any())
        {
            Console.WriteLine($"No item found with name {name}.");
            MezzanineMenu();
            return;
        }
        
        if (matchingItems.Count() > 1)
        {
            Console.WriteLine($"Found {matchingItems.Count()} matching items:");
            int index = 1;
            foreach (var item in matchingItems)
            {
                Console.WriteLine($"{index}: Name: {item.Name}, Location: {item.Location}, Quantity: {item.Quantity}");
                index++;
            }

            Console.WriteLine("Enter the number of the item to edit:");
            int choice = int.Parse(Console.ReadLine());
            MezzanineItem itemToEdit = matchingItems.ElementAt(choice - 1);

            Console.WriteLine($"Enter the new quantity for {itemToEdit.Name}:");
            int newQuantity = int.Parse(Console.ReadLine());
            itemToEdit.Quantity = newQuantity;

            Console.WriteLine($"Item '{itemToEdit.Name}' updated with new quantity of {itemToEdit.Quantity}.");
        }
        else
        {
            MezzanineItem itemToEdit = matchingItems.First();

            Console.WriteLine($"Enter the new quantity for {itemToEdit.Name}:");
            int newQuantity = int.Parse(Console.ReadLine());
            itemToEdit.Quantity = newQuantity;

            Console.WriteLine($"Item '{itemToEdit.Name}' updated with new quantity of {itemToEdit.Quantity}.");
        }
    }

    static void SearchInventory()
    {
        Console.WriteLine("Enter the name of the item to search for:");
        string name = Console.ReadLine();

        var matchingItems = inventory.Where(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (!matchingItems.Any())
        {
            Console.WriteLine($"No item found with name {name}.");
            return;
        }

        Console.WriteLine($"Found {matchingItems.Count()} matching items:");
        foreach (var item in matchingItems)
        {
            Console.WriteLine($"Name: {item.Name}, Location: {item.Location}, Quantity: {item.Quantity}");
        }
    }
}
