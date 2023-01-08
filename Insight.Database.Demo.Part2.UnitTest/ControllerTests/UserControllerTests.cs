using FizzWare.NBuilder;
using Insight.Database.Demo.Part2.Controllers;
using Insight.Database.Demo.Part2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Database.Demo.Part2.UnitTest.ControllerTests
{
    internal class UserControllerTests
    {
        private UserController _userController { get; set; }

        private Mock<ILogger<UserController>> _logger { get; set; }

        private Mock<IUserRepository> _iUserRepository { get; set; }

        private List<User> Users { get; set; } = new List<User>();

        [SetUp]
        public void Setup()
        {
            Users = Builder<User>
                    .CreateListOfSize(5)
                    .All()
                    .With(c => c.FirstName = Faker.Name.First())
                    .With(c => c.LastName = Faker.Name.Last())
                    .With(c => c.EmailAddress = Faker.Internet.Email())
                    .With(c => c.Country = Faker.Address.Country())
                    .Build()
                    .ToList();

            this._iUserRepository = new Mock<IUserRepository>(MockBehavior.Strict);
            this._logger = new Mock<ILogger<UserController>>();
        }

        [Test]
        public async Task GetUserEmailAddressAsync_Positive()
        {
            //Arrange     
            this._iUserRepository
             .Setup(m => m.GetUserEmailAddressAsync(It.IsAny<long>()))
             .ReturnsAsync(Users.FirstOrDefault().EmailAddress);

            this._userController = new UserController(this._logger.Object, this._iUserRepository.Object);

            //Act
            var result = await this._userController.GetUserEmailAddressAsync(100);

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
            var jsonResult = ((OkObjectResult)result).Value.ToString();
            Assert.AreEqual(Users.FirstOrDefault().EmailAddress, jsonResult);
        }


        [Test]
        public async Task GetUserEmailAddressAsync_Negative()
        {
            //Arrange
           
            this._iUserRepository
             .Setup(m => m.GetUserEmailAddressAsync(It.IsAny<long>()))
             .ReturnsAsync(Users.FirstOrDefault().EmailAddress);

            this._userController = new UserController(this._logger.Object, this._iUserRepository.Object);

            //Act
            var result = await this._userController.GetUserEmailAddressAsync(100);

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
            var jsonResult = ((OkObjectResult)result).Value.ToString();
            Assert.AreNotEqual(Users.LastOrDefault().EmailAddress, jsonResult);
        }


        [Test]
        public async Task GetUserEmailAddressAsync_V1_Positive()
        {
            //Arrange           

            this._iUserRepository
             .Setup(m => m.GetUserEmailAddressAsync_V1(It.IsAny<long>()))
             .ReturnsAsync(Users.FirstOrDefault().EmailAddress);

            this._userController = new UserController(this._logger.Object, this._iUserRepository.Object);

            //Act
            var result = await this._userController.GetUserEmailAddressAsync_V1(100);

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
            var jsonResult = ((OkObjectResult)result).Value.ToString();
            Assert.AreEqual(Users.FirstOrDefault().EmailAddress, jsonResult);
        }


        [Test]
        public async Task GetUserEmailAddressAsync_V1_Negative()
        {
            //Arrange        

            this._iUserRepository
             .Setup(m => m.GetUserEmailAddressAsync_V1(It.IsAny<long>()))
             .ReturnsAsync(Users.FirstOrDefault().EmailAddress);

            this._userController = new UserController(this._logger.Object, this._iUserRepository.Object);

            //Act
            var result = await this._userController.GetUserEmailAddressAsync_V1(100);

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
            var jsonResult = ((OkObjectResult)result).Value.ToString();
            Assert.AreNotEqual(Users.LastOrDefault().EmailAddress, jsonResult);
        }

        [Test]
        public async Task GetAllUsersAsync_Positive()
        {
            //Arrange
            this._iUserRepository
             .Setup(m => m.GetAllUsersAsync())
             .ReturnsAsync(Users);

            this._userController = new UserController(this._logger.Object, this._iUserRepository.Object);

            //Act
            var result = await this._userController.GetAllUsersAsync() as OkObjectResult;

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
            Assert.AreEqual(Users, result.Value as List<User>);       
        }


        [Test]
        public async Task GetAllUsersAsync_Negative()
        {
            //Arrange
            this._iUserRepository
             .Setup(m => m.GetAllUsersAsync())
             .ReturnsAsync(Users);

            this._userController = new UserController(this._logger.Object, this._iUserRepository.Object);

            //Act
            var result = await this._userController.GetAllUsersAsync() as OkObjectResult;

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
            Assert.AreNotEqual(Users.OrderByDescending(x => x.UserId), result.Value as List<User>);
        }

        [Test]
        public async Task GetAllUsersAsync_V1_Positive()
        {
            //Arrange
            this._iUserRepository
             .Setup(m => m.GetAllUsersAsync_V1())
             .ReturnsAsync(Users);

            this._userController = new UserController(this._logger.Object, this._iUserRepository.Object);

            //Act
            var result = await this._userController.GetAllUsersAsync_V1() as OkObjectResult;

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
            Assert.AreEqual(Users, result.Value as List<User>);
        }


        [Test]
        public async Task GetAllUsersAsync_V1_Negative()
        {
            //Arrange
            this._iUserRepository
             .Setup(m => m.GetAllUsersAsync_V1())
             .ReturnsAsync(Users);

            this._userController = new UserController(this._logger.Object, this._iUserRepository.Object);

            //Act
            var result = await this._userController.GetAllUsersAsync_V1() as OkObjectResult;

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
            Assert.AreNotEqual(Users.OrderByDescending(x => x.UserId), result.Value as List<User>);
        }
    }
}
