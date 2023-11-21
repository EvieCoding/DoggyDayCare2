using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace DoggyDayCare2
{
    public class Dog
    {
        private string _ownerName,
            _dogName,
            _dogBreed,
            _dogColor,
            _size,
            _lifeStage;
        private float _age,
            _weight;
        private double _total;
        private bool _food;
        private float value;
        
        public string OwnerName 
        {
            get {  return _ownerName; }
        }
        public string DogName 
        {
            get { return _dogName; }
        }
        public string DogBreed 
        { 
            get { return _dogBreed; }
        }
        public string DogColor 
        {
            get { return _dogColor; }
        }
        public string Size 
        { 
            get { return _size; } 
        }
        public string LifeStage 
        {
            get { return _lifeStage; } 
        }
        public float Age 
        { 
            get { return _age; }
        }
        public float Weight 
        { 
            get { return _weight; }
        }
        public double Total 
        { 
            get { return _total; }
        }
        public bool Food 
        { 
            get { return _food; } 
        }
        
        public Dog() { }

        public Dog(string pupName, string clientName, float pupAge, string pupBreed,
            float pupWeight, bool pupFood, string pupColor)
        {
            _dogName = pupName;
            _ownerName = clientName;
            _age = pupAge;
            _dogBreed = pupBreed;
            _weight = pupWeight;
            _food = pupFood;
            _dogColor = pupColor;
            _total = 0.0;
            _lifeStage = "";
            _size = "";
        }

        public string DetermineLifeStage()
        {
            if (_age < 1)
            {
                _lifeStage = "puppy";
            }
            else if (_age >= 1 && _age <= 3)
            {
                _lifeStage = "adolescent";
            }
            else if (_age >= 4 && _age <= 8)
            {
                _lifeStage = "adult";
            }
            else if (_age > 8)
            {
                _lifeStage = "senior";
            }
            return _lifeStage;
        }

        public string DetermineSize()
        {
            if (_weight > 0 && _weight <= 10)
            {
                _size = "small";
            }
            else if (_weight >= 11 && _weight <= 30)
            {
                _size = "medium";
            }
            else if (_weight >= 31 && _weight <= 100)
            {
                _size = "large";
            }
            else if (_weight > 100)
            {
                _size = "xLarge";
            }

            return _size;
        }

        public double PriceForDay()
        {
            if (_size.Equals("small") || _size.Equals("medium"))
            {
                _total = 45;
            }
            else
            {
                _total = 45 + (0.1 * _weight);
            }

            if (_food == false)
            {
                _total += 5;
            }
                return _total;
        }

        public float InvalidInput(string input)
        {
            while (!float.TryParse(input, out value) || value <= 0)
            {
                Console.WriteLine("Must be a number and greater than 0.");
                Console.Write("Enter again: ");
                input = Console.ReadLine().Trim();
            }

            return float.Parse(input);
        }

        public string YesNoInputValidation(string input)
        {
            while (!input.Equals("Y") && !input.Equals("N") || input.Equals(""))
            {
                Console.WriteLine("Enter y for yes or n for no.");
                Console.Write("Did client bring dog food?(y/n): ");

                input = Console.ReadLine().ToUpper().Trim();
            }

            return input;
        }
    }
}
