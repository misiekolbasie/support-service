using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SupportService.ApiDto;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;
using SupportService.Services;
using Xunit;

namespace SupportService.Tests.ServiceTests
{
    public class UserServiceTests
    {
        [Fact]
        public void CreateUser_Success()
        {
            int expectedId = 123;
            Mock<IUserRepository> mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repository => repository.CreateUser(It.IsAny<User>())).Returns(expectedId); 
            // говорим моку, если у репозитория вызвать крейт юзер с любым объектом юзер, то пусть он возвращает всегда експектедИд
            UserService userService = new UserService(mockRepo.Object, null); //из сформированного мока сделай объект типа IUserRepository
            CreateUserRequest createUserRequest = new CreateUserRequest();

            int id = userService.CreateUser(createUserRequest);

            Assert.Equal(expectedId, id);
        }

    }
}
