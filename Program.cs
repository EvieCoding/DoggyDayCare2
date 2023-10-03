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
    internal class Program
    {
        static void Main(string[] args)
        {
            int index;
            float pupAge,
                pupWeight;
            string pupName,
                clientName,
                pupBreed,
                pupColor,
                foodAns;
            bool pupFood = false;
            const int NUM_DOGS = 30;

            Console.WriteLine("Select one of the following:\n" +
                "1 to Check in Dog\n" +
                "2 to Check out Dog\n" +
                "3 to Exit\n");

            Dog[] dogs = new Dog[NUM_DOGS];

            Dog dog;

            Console.WriteLine();

            Console.Write("Enter an option: ");
            var input = Console.ReadLine();

            while (input != "3")
            {
                if (input == "1")
                {
                    Dog dogInstance = new Dog();
                    if(dogInstance.getInstanceCount() <= NUM_DOGS)
                    {
                        Console.Write("Client's name: ");
                        clientName = Console.ReadLine();

                        Console.Write("Dog's name: ");
                        pupName = Console.ReadLine();

                        Console.Write("Dog's breed: ");
                        pupBreed = Console.ReadLine();

                        Console.Write("Dog's color: ");
                        pupColor = Console.ReadLine();

                        Console.Write("Dog's age(in years): ");
                        pupAge = float.Parse(Console.ReadLine());

                        while (pupAge <= 0.0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Age must be greater than 0.");
                            Console.Write("Enter another age: ");
                            pupAge = float.Parse(Console.ReadLine());
                        }

                        Console.Write("Dog's weight(in pounds): ");
                        pupWeight = float.Parse(Console.ReadLine());

                        while (pupWeight <= 0.0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Weight must be greater than 0.");
                            Console.Write("Enter another weight: ");
                            pupWeight= float.Parse(Console.ReadLine());
                        }

                        Console.Write("Did client bring out dog food?(y/n): ");
                        foodAns = Console.ReadLine();

                        if (foodAns.Equals("y") || foodAns.Equals("Y"))
                        {
                            pupFood = true;
                        }
                        else
                        {
                            pupFood = false;
                        }

                        Console.WriteLine();

                        dog = new Dog(pupName, clientName, pupAge, pupBreed,
                            pupWeight, pupFood, pupColor);

                        Dog.priceForDay(dog.determineSize(), pupWeight);

                        Console.WriteLine(String.Format("Total: {0:C}", Dog.priceForDay(pupFood)));

                        index = dogInstance.getInstanceCount() - 1;

                        dogs[index] = dog;
                        dogs[index].setDogName(pupName);
                        dogs[index].setOwnerName(clientName);
                        dogs[index].setBreed(pupBreed);
                        dogs[index].setColor(pupColor);
                        dogs[index].setAge(pupAge);
                        dogs[index].setWeight(pupWeight);
                        dogs[index].setFood(pupFood);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, the Doggy Day Care is at capacity.");
                    }
                }

                if (input == "2")
                {
                    int count = 0;
                    Console.Write("Enter the client's name: ");
                    clientName = Console.ReadLine();

                    Console.WriteLine();

                    for (int Index = 0; Index <= dogs.Length - 1; Index++)
                    {
                        if (dogs[Index] != null && dogs[Index].getOwnerName() == clientName)
                        {
                            Console.WriteLine(dogs[Index].getDogName() + " is checked out.");
                            dogs[Index] = null;
                            Dog.checkOutDog();
                            count++;
                        }
                        else
                        {
                            dogs[Index - count] = dogs[Index];
                        }
                    }

                    for (int i = 1; i <= count; i++)
                    {
                        dogs[dogs.Length - i] = null;
                    }
                }

                Console.WriteLine();
                Console.Write("Enter another selection: ");
                input = Console.ReadLine();
            }

            if (input == "3")
            {
                DateTime date = DateTime.Now;
                FileStream file = new FileStream(date.ToString("yyyy-MM-dd") + "LatePickups" + ".txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(file);
                
                for (int INDEX = 0; INDEX < dogs.Length - 1; INDEX++)
                {
                    if (dogs[INDEX] != null)
                    {
                        writer.WriteLine("Client name: " + dogs[INDEX].getOwnerName());
                        writer.WriteLine("Dog name: " + dogs[INDEX].getDogName());
                        writer.WriteLine("Dog Breed: " + dogs[INDEX].getBreed());
                        writer.WriteLine("Dog Color: " + dogs[INDEX].getColor());
                        writer.WriteLine("Dog Age: " + dogs[INDEX].getAge());
                        writer.WriteLine("Dog Weight: " + dogs[INDEX].getWeight());

                        if (dogs[INDEX].getFood() == true)
                        {
                            writer.WriteLine("Food: Yes");
                        }
                        else
                        {
                            writer.WriteLine("Food: No");
                        }
                        writer.WriteLine("Lifestage: " + dogs[INDEX].determineLifeStage());
                        writer.WriteLine("Size: " + dogs[INDEX].getSize());
                        writer.WriteLine(String.Format("Total: {0:C}",  dogs[INDEX].getTotal()));
                        writer.WriteLine();
                    }
                } 

                writer.Close();
                Console.WriteLine();
                Console.WriteLine("The doggy daycare is closed.");
            }
        }
    }
}
