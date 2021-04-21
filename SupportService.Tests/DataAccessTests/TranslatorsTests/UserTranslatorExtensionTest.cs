using FluentAssertions;
using SupportService.DataAccess.Entities;
using SupportService.DataAccess.Translators;
using SupportService.Models.Enums;
using SupportService.Models.Models;
using Xunit;

namespace SupportService.Tests.DataAccessTests.TranslatorsTests
{
    public class UserTranslatorExtensionTest
    {
        [Fact] //атрибут что это ТЕСТ
        public void ToModel_AllPropertySetted()  //что делаешь_что получаешь, пишутся в 3 действия
        {
            UserEntity entity = new UserEntity() // 1 - подготовка
            {
                Id = 123,
                Role = 1,
                Name = "stroka"
            };
           
            User user = entity.ToModel(); // 2 - основное действие
          
            // 3 - проверить результат
            user.Should().NotBeNull();
            user.Id.Should().Be(entity.Id);
            user.Role.Should().Be(entity.Role);
            user.Name.Should().Be(entity.Name);
            //Assert.NotNull(user);// check user not null
            //Assert.Equal(entity.Id, user.Id);// check id 
            //Assert.Equal(entity.Role,(int)user.Role);// check role
            //Assert.Equal(entity.Name, user.Name);//check Name
        }

        [Fact] //атрибут что это ТЕСТ
        public void ToEntity_AllPropertySetted()  //что делаешь_что получаешь, пишутся в 3 действия
        {
            User user = new User() // 1 - подготовка
            {
                Role = Roles.Admin,
                Name = "stroka"
            };

            UserEntity entity = user.ToEntity(); // 2 - основное действие

            // 3 - проверить результат
            Assert.NotNull(entity);// check user not null
            Assert.Equal((int)user.Role, entity.Role);// check role
            Assert.Equal(user.Name, entity.Name);//check Name
        }
    }

}
