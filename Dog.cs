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
        private string _dogName,
            _ownerName,
            _dogBreed,
            _dogColor,
            _size,
            _lifeStage;
        private static float _age,
            _weight;
        private static double _total;
        private bool _food;
        private static int _instanceCount;

        public Dog()
        {
            _instanceCount++;
        }

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
            _age = 0;
            _lifeStage = "";
            _size = "";
        }

        public int getInstanceCount()
        {
            return _instanceCount;
        }

        public string getDogName()
        {
            return _dogName;
        }

        public string getOwnerName()
        {
            return _ownerName;
        }

        public string getBreed()
        {
            return _dogBreed;
        }

        public string getColor()
        {
            return _dogColor;
        }

        public string getSize()
        {
            return _size;
        }

        public string getLifeStage()
        {
            return _lifeStage;
        }

        public float getAge()
        {
            return _age;
        }

        public float getWeight()
        {
            return _weight;
        }

        public double getTotal()
        {
            return _total;
        }

        public bool getFood()
        {
            return _food;
        }

        public void setDogName(string pupName)
        {
            _dogName = pupName;
        }

        public void setOwnerName(string clientName)
        {
            _ownerName = clientName;
        }

        public void setBreed(string pupBreed)
        {
            _dogBreed = pupBreed;
        }

        public void setColor(string pupColor)
        {
            _dogColor = pupColor;
        }

        public void setAge(float pupAge)
        {
            _age = pupAge;
        }

        public void setWeight(float pupWeight)
        {
            _weight = pupWeight;
        }

        public void setFood(bool pupFood)
        {
            _food = pupFood;
        }

        public string determineLifeStage()
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

        public string determineSize()
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

        public static void checkOutDog()
        {
            _instanceCount--;
        }

        public static double priceForDay(string size, float pupWeight)
        {
            if (size.Equals("small") || size.Equals("medium"))
            {
                _total = 45;
                return _total;
            }
            else
            {
                _total = 45 + (0.1 * pupWeight);
                return _total;
            }
        }

        public static double priceForDay(bool food)
        {
            if (food)
            {
                _total += 5;
            }

            return _total;
        }
    }
}
