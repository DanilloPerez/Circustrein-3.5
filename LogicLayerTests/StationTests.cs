using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Tests
{
    [TestClass()]
    public class StationTests
    {
        
        

        [TestMethod()]
        public void HandleHerbivoreTestRightAnimal()
        { //arrange
            Station station = new Station();
            Animal herb = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Medium);
            //act
            station.HandleHerbivore(herb);
            //assert
            Assert.AreEqual(1, station.trainlist.Count);
            Assert.AreEqual(herb, station.trainlist[0].AnimalsinWagon[0]);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
    "animal can't be null")]
        public void HandleNullHerbivoreTest()
        { //arrange
            Station station = new Station();
            Animal herb = null;
            //act                     
            station.HandleHerbivore(herb);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
   "animal can't be a carnivore")]
        public void HandleHerbivoreTestWrongAnimal()
        { //arrange
            Station station = new Station();
            Animal Carnivore = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Medium);
            //act
            station.HandleHerbivore(Carnivore);
        }

        [TestMethod()]
        public void StartLoadingTrainRightInput()
        {
            //arrange
            Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Large);
            Station station = new Station();
            List<Animal> animalList = new List<Animal>();
            animalList.Add(animal);
 
            //act
            station.StartLoadingTrain(animalList);
            //arrange
            Assert.AreEqual(1 , station.trainlist.Count);            
        }
        [TestMethod()]
        public void StartLoadingTrainWrongInput()
        {
            //arrange
            Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Large);
            Station station = new Station();
            List<Animal> animalList = new List<Animal>();          
            //act
            station.StartLoadingTrain(animalList);
            //arrange
            Assert.AreEqual(0, station.trainlist.Count);
        }       
        
    }
}