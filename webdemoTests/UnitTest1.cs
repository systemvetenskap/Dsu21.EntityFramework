using System;
using Xunit;
using webdemo2.Data;
using Moq;
using webdemo2;
using System.Threading.Tasks;
using webdemo2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace webdemoTests
{
    public class UnitTest1
    {
       [Fact]
        public void Test1()
        {
            // Arrange
            int expected = 2;
            var mock = new Mock<IRepository>();
            //mock.Setup(x => x.CountAllPeople()).Returns(expected);
            mock.Setup(x => x.CountAllPeople()).Returns(23);
            var sut = new Repository(mock.Object);

            // Act
            int actual = sut.CountAllPeople();

            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test2()
        {
            // Arrange
            int expected = 2;
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.CountAllPeople()).Returns(expected);
            var sut = new Repository(mock.Object);
            // Act
            int actual = sut.CountAllPeople();
            mock.Verify(x => x.CountAllPeople(), Times.Exactly(1));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ShouldReturnPersonFromDatabase()
        {
            // https://stackoverflow.com/questions/20859639/using-moq-to-mock-an-asynchronous-method-for-a-unit-test
            var person = new Person
            {
                Firstname = "Erik"
            };

            var mock = new Mock<IRepository>();
            var sut = new Repository(mock.Object);
            // async
            mock.Setup(x => x.GetPersonAsync(It.IsAny<int>())).Returns(Task.FromResult<Person>(person));
            var actual = await sut.GetPersonAsync(2);
            //Assert.Same(actual, person); //jämför samma referens
            Assert.Equal(actual.Firstname, person.Firstname);
        }

        [Fact]
        public void ShouldAddPersonToDatabase()
        {
            // virtual!
            // https://docs.microsoft.com/sv-se/ef/ef6/fundamentals/testing/mocking?redirectedfrom=MSDN
            var mockSet = new Mock<DbSet<Person>>();
            var mockContext = new Mock<CarContext>();
            mockContext.Setup(x => x.Persons).Returns(mockSet.Object);

            var sut = new DbOperations(mockContext.Object);
            sut.AddPerson("Erik", "Persson");
            mockSet.Verify(x => x.Add(It.IsAny<Person>()), Times.Once());
            mockContext.Verify(x => x.SaveChanges(), Times.Once());

        }

        
    }
}
