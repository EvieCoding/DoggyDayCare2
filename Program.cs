using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
                if (input == "1")
                {
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

                        while(!float.TryParse(input, out pupAge) || pupAge <= 0)
                        {
                            Console.WriteLine("Age must be a number and greater than 0.");
                            Console.Write("Enter the age again: ");
                            input = Console.ReadLine().Trim();
                        }

                        Console.Write("Dog's weight(in pounds): ");
                        input = Console.ReadLine().Trim();

                        while(!float.TryParse(input,out pupWeight) || pupWeight <= 0)
                        {
                            Console.WriteLine("Weight must be a number and greater than 0.");
                            Console.Write("Enter the weight again: ");
                            input = Console.ReadLine().Trim();
                        }

                        Console.Write("Did client bring dog food?(y/n): ");
                        input = Console.ReadLine().ToUpper().Trim();

                        while (!input.Equals("Y") && !input.Equals("N") || input.Equals(""))
                        {
                            Console.WriteLine("Enter y for yes or n for no.");
                            Console.Write("Did client bring dog food?(y/n): ");

                            input = Console.ReadLine().ToUpper().Trim();
                        }

                        if (input.Equals("Y"))
                        {
                            pupFood = true;
                        }
                        else
                        {
                            pupFood = false;
                        }

                        Console.WriteLine();

                        var dog = new Dog(pupName, clientName, pupAge, pupBreed,
                            pupWeight, pupFood, pupColor);
                        dogs.Add(dog);
                        dog.determineSize();

                        Console.WriteLine(String.Format("Total: {0:C}", dog.priceForDay()));
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, the Doggy Day Care is at capacity.");
                    }
                }

                if (input == "2")
                {
                    Console.Write("Enter the client's name: ");
                    clientName = Console.ReadLine().Trim();

                    Console.WriteLine();

                    for (int i = 0; i < dogs.Count; i++)
                    {
                        if (dogs[i].ownerName == clientName)
                        {
                            Console.WriteLine("{0} was checked out.", dogs[i].dogName);
                            dogs.RemoveAt(i);
                        }
                    }
                }

                Console.WriteLine();
                Console.Write("Enter another selection: ");
                input = Console.ReadLine().Trim();
            }

            DateTime date = DateTime.Now;
            FileStream file = new FileStream(date.ToString("yyyy-MM-dd") + "LatePickups" + ".txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(file);

            foreach (Dog left in dogs)
            {
                if (left != null)
                {
                    writer.WriteLine(
                        "Client name: {0}\n" +
                        "Dog name: {1}\n" +
                        "Dog Breed: {2}\n" +
                        "Dog Color: {3}\n" +
                        "Dog age: {4}\n" +
                        "Dog Weight: {5}", left.ownerName, left.dogName, left.dogBreed, left.dogColor, left.age, left.weight);

                    if (left.food == true)
                    {
                        writer.WriteLine("Food: Yes");
                    }
                    else
                    {
                        writer.WriteLine("Food: No");
                    }

                    writer.WriteLine(
                        "Lifestage: {0}\n" +
                        "Size: {1}\n" +
                        "Total: {2:C}\n", left.determineLifeStage(), left.size, left.total);
                }
            }

            writer.Close();
            Console.WriteLine();
            Console.WriteLine("The doggy daycare is closed.");
            
        }
    }
}
