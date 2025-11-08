using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>> // establishes the dictionary
        {
            { "Monkey", new List<string> { "Orangutan", "Mandrill" } },
            { "Lion", new List<string> { "Congo", "European" } },
            { "Bear", new List<string> { "Grizzly", "Polar" } }
        };

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nDictionary of Animals");
            Console.WriteLine("a. Populate the Dictionary"); // add keys and values to the group.
            Console.WriteLine("b. Display Dictionary Contents"); // displays the entirety of the dictionary
            Console.WriteLine("c. Remove a Key"); // removes a key, case-sensitive. if anyone knows how to change that please edit it
            Console.WriteLine("d. Add a New Key and Value"); // adds a new key and value to the group
            Console.WriteLine("e. Add a Value to an Existing Key"); // edits an already existing key by adding a new element to it
            Console.WriteLine("f. Sort the Keys"); // organizes the keys alphabetically 
            Console.WriteLine("x. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "a": // this should add to the dictionary these two new keys alongside their values: an elephant and wolf
                    Console.WriteLine("\nPopulating Dictionary.");
                    myDictionary["Wolf"] = new List<string> { "Arctic", "Gray" };
                    myDictionary["Elephant"] = new List<string> { "African", "Asian" };
                    Console.WriteLine("Dictionary populated!");
                    break;

                case "b": // displays the contents of the dictionary
                    Console.WriteLine("\nDisplaying dictionary contents:");
                    foreach (var kvp in myDictionary)
                        Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
                    break;

                case "c": // remove any of the animals from the dictionary.
                    Console.Write("\nEnter the key to remove: ");
                    string keyToRemove = Console.ReadLine();
                    if (myDictionary.Remove(keyToRemove))
                        Console.WriteLine($"{keyToRemove} was removed.");
                    else
                        Console.WriteLine($"{keyToRemove} not found.");
                    break;

                case "d": // adds a new key and value to the dictionary
                    Console.Write("\nEnter a new key to add: ");
                    string newKey = Console.ReadLine();
                    Console.Write("Enter a value for this key: ");
                    string newValue = Console.ReadLine();
                    myDictionary[newKey] = new List<string> { newValue };
                    Console.WriteLine($"{newKey} added with value {newValue}.");
                    break;

                case "e": // edits a new value to add to a group
                    Console.Write("\nEnter the key to add a value to: ");
                    string existingKey = Console.ReadLine();
                    if (myDictionary.ContainsKey(existingKey))
                    {
                        Console.Write("Enter the new value: ");
                        string addValue = Console.ReadLine();
                        myDictionary[existingKey].Add(addValue);
                        Console.WriteLine($"Added {addValue} to {existingKey}.");
                    }
                    else
                    {
                        Console.WriteLine("Key not found.");
                    }
                    break;

                case "f": 
                    Console.WriteLine("\nSorting dictionary alphabetically.");
                    var sorted = myDictionary.OrderBy(kvp => kvp.Key)
                                             .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    myDictionary = sorted;
                    Console.WriteLine("Dictionary sorted!");
                    foreach (var kvp in myDictionary)
                        Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
                    break;

                case "x":
                    Console.WriteLine("\nExiting program.");
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Try again.");
                    break;
            }
        }
    }
}
