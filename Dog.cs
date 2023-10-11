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
        public string ownerName 
        {
            get {  return _ownerName; }
            set {  _ownerName = value; } 
        }
        public string dogName 
        {
            get { return _dogName; }
            set { _dogName = value; }
        }
        public string dogBreed 
        { 
            get { return _dogBreed; }
            set { _dogBreed = value; }
        }
        public string dogColor 
        {
            get { return _dogColor; }
            set { _dogColor = value; }
        }
        public string size 
        { 
            get { return _size; } 
            set { _size = value; }
        }
        public string lifeStage 
        {
            get { return _lifeStage; } 
            set { _lifeStage = lifeStage; }
        }
        public float age 
        { 
            get { return _age; }
            set { _age = value; }
        }
        public float weight 
        { 
            get { return _weight; }
            set { _weight = value; } 
        }
        public double total 
        { 
            get { return _total; }
            set { _total = total; }
        }
        public bool food 
        { 
            get { return _food; } 
            set { _food = value; }
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
            _lifeStage = "";
            _size = "";
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

        public double priceForDay()
        {
            if (_size.Equals("small") || _size.Equals("medium"))
            {
                _total = 45;
                return _total;
            }
            else
            {
                _total = 45 + (0.1 * _weight);
                return _total;
            }
        }

        public double priceForDay(bool food)
        {
            if (food)
            {
                _total += 5;
            }

            return _total;
        }
    }
}
