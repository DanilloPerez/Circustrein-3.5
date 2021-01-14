using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Tests
{
    [TestClass()]
    public class WagonTests
    {

        [TestMethod()]
        public void TryPlaceAnimalRightInputCarnivore()
        {
            //arrange
            Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Medium);
            Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
            //act
            bool result = wagon.TryPlaceAnimal(animal);
            //assert
            Assert.IsTrue(result);
        }



        [TestMethod()]
        public void PlaceAnimalInNewWagonWrongWagonInput()
        {
            //arrange
            Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Medium);
            Wagon wagon = new Wagon(5);
            // act/assert
            Assert.ThrowsException<Exception>(() => wagon.PlaceAnimalInNewWagon(animal), "Big oof");
        }

        [TestMethod()]
        public void PlaceAnimalInNewWagonRightInput()
        {
            //arrange
            Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Medium);
            Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
            //act
            wagon.PlaceAnimalInNewWagon(animal);
            //assert
            Assert.AreEqual(7, wagon.spaceAvailable);
            Assert.AreEqual(1, wagon.AnimalsinWagon.Count);
            Assert.AreEqual(animal, wagon.AnimalsinWagon[0]);
        }

        [TestMethod()]
        public void PlaceAnimalInNewWagonNullTest()
        {
            //arrange
            Animal animal = null;
            Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
            //assert/act
            Assert.ThrowsException<Exception>(() => wagon.PlaceAnimalInNewWagon(animal), "You need animal, buddy");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Cannot put two carnivores together")]
        public void TryPlaceAnimalWrongInput()
        {
            //arrange
            Wagon wagon = new Wagon(Wagon.WagonSize.Regular);
            Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Small);
            wagon.PlaceAnimalInNewWagon(animal);
            //act
            wagon.TryPlaceAnimal(animal);
        }

        [TestMethod()]
        public void TryPlaceAnimalTestRightInput()
        {
            //arrange
            Wagon wagon = new Wagon(10);
            Animal animal = new Animal(Animal.AnimalType.Herbivore, Animal.AnimalSize.Large);
            //act
            bool result = wagon.TryPlaceAnimal(animal);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Animal cannot be null")]
        public void TryPlaceAnimalNullTest()
        {
            //arrange
            Wagon wagon = new Wagon(10);
            Animal animal = null;
            //act
            wagon.TryPlaceAnimal(animal);
          
        }
    }
}