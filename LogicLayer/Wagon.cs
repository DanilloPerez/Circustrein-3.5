using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class Wagon
    {

        public int spaceAvailable { get; private set; }
        private List<Animal> animalsinWagon;

        public IReadOnlyList<Animal> AnimalsinWagon => animalsinWagon.AsReadOnly();
        public enum WagonSize
        {
            Regular = 10,
        }
        private WagonSize wagonSize;

        public Wagon(WagonSize size)
        {
            this.wagonSize = size;
            this.animalsinWagon = new List<Animal>();
            this.spaceAvailable = (int)size;
            
        }
        public Wagon(int wagonsize)
        {
            
            this.animalsinWagon = new List<Animal>();
            this.spaceAvailable = (int)wagonsize;

        }

        //place animal in wagon
        private void PlaceAnimal(Animal animal)
        {
            if (animal == null) { throw new Exception("You need animal, buddy");}
            
                this.animalsinWagon.Add(animal);
                this.spaceAvailable -= (int)animal.animalSize;
            
           
        }

        public void PlaceAnimalInNewWagon(Animal animal)
        {
            if (spaceAvailable.Equals(10))
            {
                this.PlaceAnimal(animal);
            }
            else
            {
                throw new Exception("Big oof");
            }                      
        }
        
        //try to place animal in existing wagon
        public bool TryPlaceAnimal(Animal animal)
        {
            if (this.spaceAvailable >= (int)animal.animalSize)
            {
                Animal tempAnimal = this.animalsinWagon.Find(temp => temp.animalType == Animal.AnimalType.Carnivore);
                if (tempAnimal != null)
                {
                    if (animal.animalSize > tempAnimal.animalSize)
                    {
                        PlaceAnimal(animal);
                        return true;
                    }
                }
                else
                {
                    PlaceAnimal(animal);
                    return true;
                }
            }
            return false;
        }


    }
}
