using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class Station
    {
        private List<Wagon> trainList;

        public IReadOnlyList<Wagon> trainlist => trainList.AsReadOnly();

        public Station()
        {            
           trainList = new List<Wagon>();            
        }

        private List<Animal> SortAnimals(List<Animal> animalList)
        {
            
            animalList = SortBySize(animalList);
            animalList = SortByType(animalList);
            return animalList;
        }
        private List<Animal> SortByType(List<Animal> oldAnimals)
        {
            
            List<Animal> carnivoreList = new List<Animal>();
            List<Animal> herbivoreList = new List<Animal>();
            foreach (Animal animal in oldAnimals)
            {
                if (animal.animalType == Animal.AnimalType.Carnivore)
                    carnivoreList.Add(animal);
                else if (animal.animalType == Animal.AnimalType.Herbivore)
                    herbivoreList.Add(animal);
            }
            carnivoreList.AddRange(herbivoreList);
            return carnivoreList;
        }
        private List<Animal> SortBySize(List<Animal> oldAnimals)
        {
            Animal[] oldAnimalsArray = oldAnimals.ToArray();
            List<Animal> returnList = new List<Animal>();
            for (int j = 0; j < oldAnimalsArray.Length; j++)
            {
                Animal tempAnimal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Large);
                int index = 0;
                for (int i = 0; i < oldAnimalsArray.Length; i++)
                {
                    if (oldAnimalsArray[i] != null)
                    {
                        if ((int)oldAnimalsArray[i].animalSize <= (int)tempAnimal.animalSize)
                        {
                            tempAnimal = oldAnimalsArray[i];
                            index = i;
                        }
                    }
                }
                oldAnimalsArray[index] = null;
                returnList.Add(tempAnimal);
            }
            return returnList;
        }

        public List<Wagon> StartLoadingTrain(List<Animal> animalList)
        {
            animalList = SortAnimals(animalList);
            foreach (Animal animal in animalList)
            {
                // check for animaltype and make new wagon if carnivore
                if (animal.animalType == Animal.AnimalType.Carnivore)
                {
                    Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
                   
                    wagon.PlaceAnimalInNewWagon(animal);
                    trainList.Add(wagon);

                }
                //check for animaltype and try to place in used wagon, else make new wagon
                else if (animal.animalType == Animal.AnimalType.Herbivore)
                {
                    HandleHerbivore(animal);
                }
            }
            return trainList;
        }
        public List<Wagon> HandleHerbivore(Animal animal)
        {
            bool isAnimalPlaced = false;
            foreach (Wagon wagon in trainList)
            {

                if (!isAnimalPlaced)
                {
                    isAnimalPlaced = wagon.TryPlaceAnimal(animal);
                }
            }

            if (!isAnimalPlaced)
            {
                Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
                wagon.PlaceAnimalInNewWagon(animal);
                trainList.Add(wagon);
            }
            return trainList;
        }
    }
}
