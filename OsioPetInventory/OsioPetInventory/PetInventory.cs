using System;
using System.Collections.Generic;

namespace OsioPetInventory
{
    // Enum Kind
    public enum Kind
    {
        Dog,
        Cat,
        Lizard,
        Bird
    }

    // Enum Gender
    public enum Gender
    {
        Male,
        Female
    }
    interface IAnimal
    {
        Kind Kind { get; set; }
        string Name { get; set; }
        Gender Gender { get; set; }
        string Owner { get; set; }
        string ClearRep();

    }
    class Dog : IAnimal
    {
        public Kind Kind { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Breed { get; set; }
        public string Owner { get; set; }
        public string ClearRep()
        {
            return ($"Dog -  {Name} ({Gender}), Owner: {Owner}, Breed: {Breed}");

        }
    }
    class Cat : IAnimal
    {
        public Kind Kind { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool LongHair { get; set; }
        public string Owner { get; set; }
        public string ClearRep()
        {
            string hairType;

            if (LongHair)
            {
                hairType = "Longhaired";
            }
            else
            {
                hairType = "Shorthaired";
            }

            return $"Cat - {Name} ({Gender}), Owner: {Owner}, Hair Type: {hairType}";
        }

    }
    class Lizard : IAnimal
    {
        public Kind Kind { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool ColdBlood { get; set; }
        public string Owner { get; set; }
        public string ClearRep()
        {
            string ColdBlooded;

            if (ColdBlood)
            {
                ColdBlooded = "Is cold-blooded";
            }
            else
            {
                ColdBlooded = "Is warm-blooded";
            }

            return $"Lizard - {Name} ({Gender}), Owner: {Owner}, {ColdBlooded}";
        }

    }
    class Bird : IAnimal
    {
        public Kind Kind { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Flight { get; set; }
        public string Owner { get; set; }
        public string ClearRep()
        {
            string Fly;

            if (Flight)
            {
                Fly = "Can Fly";
            }
            else
            {
                Fly = "Cannot Fly"; //aww :(
            }

            return $"Bird - {Name} ({Gender}), Owner: {Owner}, {Fly}";
        }
    }
    class Program
    {
        static List<IAnimal> pets = new List<IAnimal>(); //wag mo na galawain brave

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pet Inventory!");
            while (true)
            {
                Console.WriteLine();
                AddingPets();
                Console.Write("Add another pet? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    break;
                }
            }
            Console.Write("Which type of animals would you like to list? (Dog, Cat, Lizard, Bird, or 'All'): ");
            string choice = Console.ReadLine();
            Console.WriteLine("");
            ListingPets(choice);
        }

        static void AddingPets()
        {
            Console.Write("Kind (Dog, Cat, Lizard, Bird): ");
            Kind kind;
            while (!Enum.TryParse(Console.ReadLine(), true, out kind))
            {
                Console.Write("Invalid input! Please enter a valid kind (Dog, Cat, Lizard, Bird): ");
            }
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Gender (M/F): ");
            // Gender gender = Console.ReadLine().ToLower() == "m" ? Gender.Male : Gender.Female; //? = parang if else lang wag mo overthink <3
            string gendr = Console.ReadLine().ToLower();
            Gender gender;
            if (gendr == "m")
            {
                gender = Gender.Male;
            }
            else if (gendr == "f")
            {
                gender = Gender.Female;
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return; 
            }

            IAnimal animal = null;

            switch (kind)
            {
                case Kind.Dog:
                    Console.Write("Breed: ");
                    string breed = Console.ReadLine();
                    animal = new Dog { Kind = kind, Name = name, Gender = gender, Breed = breed};
                    break;
                case Kind.Cat:
                    Console.Write("Is Longhaired? (y/n): ");
                    //bool hair = Console.ReadLine().ToLower() == "y";
                    bool hair;
                    string hir = Console.ReadLine().ToLower();
                    if (hir == "y")
                    {
                        hair = true;
                    }
                    else if (hir == "n")
                    {
                        hair = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    animal = new Cat { Kind = kind, Name = name, Gender = gender, LongHair = hair };
                    break;
                case Kind.Lizard:
                    Console.Write("Cold-blooded? (y/n): ");
                    //bool coldblood = Console.ReadLine().ToLower()== "y";
                    bool coldblood;
                    string coldb = Console.ReadLine().ToLower();
                    if (coldb == "y")
                    {
                        coldblood = true;
                    }
                    else if (coldb == "n")
                    {
                        coldblood = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    animal = new Lizard { Kind = kind, Name = name, Gender = gender, ColdBlood = coldblood };
                    break;
                case Kind.Bird:
                    Console.Write("Can Fly? (y/n): ");
                    //bool fly = Console.ReadLine().ToLower() == "y";
                    bool fly;
                    string fy = Console.ReadLine().ToLower();
                    if (fy == "y")
                    {
                        fly = true;
                    }
                    else if (fy == "n")
                    {
                        fly = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    animal = new Bird { Kind = kind, Name = name, Gender = gender, Flight = fly };
                    break;
                default:
                    Console.WriteLine("Invalid Kind of Pet!");
                    break;
            }
            Console.Write("Owner: ");
            string owner = Console.ReadLine();

            if (animal != null)
            {
                animal.Owner = owner;
                pets.Add(animal);
                Console.WriteLine("");
            }
        }

        static void ListingPets(string choice)
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("No pets in inventory.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("All pets in the inventory: ");
            Console.WriteLine("");

            foreach (var animal in pets)
            {

                if (choice.ToLower() == "all" || animal.GetType().Name.ToLower() == choice.ToLower())
                {
                    Console.WriteLine($"* {animal.ClearRep()}");
                }

            }
            Console.ReadKey();
        }
    }
}
