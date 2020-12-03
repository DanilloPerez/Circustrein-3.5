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
        public void TryPlaceAnimalTest()
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
        public void PlaceAnimalInNewWagonTest()
        {
            //arrange
            Animal animal = new Animal(Animal.AnimalType.Carnivore, Animal.AnimalSize.Medium);
            Wagon wagon = new Wagon(5);
            // act/assert
            Assert.ThrowsException<Exception>(() => wagon.PlaceAnimalInNewWagon(animal), "Big oof");
        }

        [TestMethod()]
        public void PlaceAnimalInNewWagonTest1()
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
        public void PlaceAnimalInNewWagonTest2()
        {
            //arrange
            Animal animal = null;
            Wagon wagon = new Wagon(Wagon.WagonSize.Regular); 
            //assert/act
            Assert.ThrowsException<Exception>(() => wagon.PlaceAnimalInNewWagon(animal), "You need animal, buddy");
        }
    }
}