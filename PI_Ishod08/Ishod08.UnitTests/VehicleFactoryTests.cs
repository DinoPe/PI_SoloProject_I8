using Ishod08.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ishod08.UnitTests
{
    [TestClass]
    public class VehicleFactoryTests
    {
        [TestMethod]
        public void getRandomVehicle_Input0_ReturnsCar()
        {
            //Arrange
            var vehicleFactory = new VehicleFactory();

            //Act
            var result = VehicleFactory.getRandomVehicle(0);

            //Assert

            Assert.IsTrue(result is Car);

        }
        [TestMethod]
        public void getRandomVehicle_Input1_ReturnsVan()
        {
            //Arrange
            var vehicleFactory = new VehicleFactory();

            //Act
            var result = VehicleFactory.getRandomVehicle(1);

            //Assert

            Assert.IsTrue(result is Van);

        }
        [TestMethod]
        public void getRandomVehicle_Input2_ReturnsBus()
        {
            //Arrange
            var vehicleFactory = new VehicleFactory();

            //Act
            var result = VehicleFactory.getRandomVehicle(2);

            //Assert

            Assert.IsTrue(result is Bus);

        }
        [TestMethod]
        public void getRandomVehicle_Input3_ReturnsBus()
        {
            //Arrange
            var vehicleFactory = new VehicleFactory();

            //Act
            var result = VehicleFactory.getRandomVehicle(3);

            //Assert

            Assert.IsTrue(result is Truck);

        }
    }
}
