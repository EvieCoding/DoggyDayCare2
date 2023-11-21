using System;
using System.Collections.Generic;
using System.IO;

namespace DoggyDayCare2
{
    public class Program
    {
        static void Main(string[] args)
        {
            float pupAge,
                pupWeight;
            string pupName,
                clientName,
                pupBreed,
                pupColor;
            bool pupFood;
            const int MAX_DOGS = 30;

            Console.WriteLine("Select one of the following:\n" +
                "1 to Check in Dog\n" +
                "2 to Check out Dog\n" +
                "3 to Exit\n");

            List<Dog> dogs = new List<Dog>();

            Console.WriteLine();

            Console.Write("Enter an option: ");
            var input = Console.ReadLine().Trim();

            while (input != "3")
            {
                switch (input)
                {
                    case "1":
                        if (dogs.Count < MAX_DOGS)
                        {
                            Console.Write("Client's name: ");
                            clientName = Console.ReadLine().Trim();

                            Console.Write("Dog's name: ");
                            pupName = Console.ReadLine().Trim();

                            Console.Write("Dog's breed: ");
                            pupBreed = Console.ReadLine().Trim();

                            Console.Write("Dog's color: ");
                            pupColor = Console.ReadLine().Trim();

                            Console.Write("Dog's age(in years): ");
                            input = Console.ReadLine().Trim();

                            var inputDog = new Dog();
                            pupAge = inputDog.InvalidInput(input);

                            Console.Write("Dog's weight(in pounds): ");
                            input = Console.ReadLine().Trim();

                            pupWeight = inputDog.InvalidInput(input);

                            Console.Write("Did client bring dog food?(y/n): ");
                            input = Console.ReadLine().ToUpper().Trim();

                            input = inputDog.YesNoInputValidation(input);

                            if (input.Equals("Y"))
                            {
                                pupFood = true;
                            }

                            Console.WriteLine();

                            var dog = new Dog(pupName, clientName, pupAge, pupBreed,
                                pupWeight, pupFood, pupColor);
                            dogs.Add(dog);
                            dog.DetermineSize();

                            Console.WriteLine(String.Format("Total: {0:C}", dog.Priceforday()));
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Sorry, the Doggy Day Care is at capacity.");
                        }

                        break;

                    case "2":
                        Console.Write("Enter the client's name: ");
                        clientName = Console.ReadLine().Trim();

                        Console.WriteLine();

                        for (int i = 0; i < dogs.Count; i++)
                        {
                            if (dogs[i].OwnerName == clientName)
                            {
                                Console.WriteLine("{0} was checked out.", dogs[i].DogName);
                                dogs.RemoveAt(i);
                            }
                        }

                        break;
                }

                Console.WriteLine();
                Console.Write("Enter another selection: ");
                input = Console.ReadLine().Trim();
            }

            Dog.WriteToAFile(dogs);
            }
        }
    }
}
