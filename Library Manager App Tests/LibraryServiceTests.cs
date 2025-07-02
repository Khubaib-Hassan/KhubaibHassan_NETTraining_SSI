using Library_Manager_Training_App;
using Library_Manager_Training_App.Models;
using Library_Manager_Training_App.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace Library_Manager_Training_App.Tests
{
    public class LibraryServiceTests
    {
        private LibraryDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "LibraryTestDb")
                .Options;

            return new LibraryDbContext(options);
        }

        [Fact]
        public async Task DeleteBookAsync_BookExistsAndAvailable_ShouldDeleteBook()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Books.Add(new Book
            {
                ISBN = "123",
                Title = "Test Book"
            });
            await dbContext.SaveChangesAsync();

            var service = new LibraryService(dbContext);

            // Act
            var result = service.deleteBook("123");

            // Assert
            Assert.True(result);
            Assert.Empty(dbContext.Books);
        }

        [Fact]
        public async Task DeleteBookAsync_BookDoesNotExist_ShouldReturnFalse()
        {
            var dbContext = GetInMemoryDbContext();
            var service = new LibraryService(dbContext);

            var result = service.deleteBook("999");

            await Assert.False(result);
        }

        [Fact]
        public async Task DeleteBookAsync_BookBorrowed_ShouldReturnFalse()
        {
            var dbContext = GetInMemoryDbContext();
            dbContext.Books.Add(new Book
            {
                ISBN = "456",
                Title = "Borrowed Book",
                Status = BookStatus.Borrowed
            });
            await dbContext.SaveChangesAsync();

            var service = new LibraryService(dbContext);

            var result = await service.DeleteBookAsync("456");

            Assert.False(result);
        }
    }
}
