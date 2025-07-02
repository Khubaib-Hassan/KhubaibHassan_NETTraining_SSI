using Library_Manager_Training_App.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryManagementTests
{
    public class LibraryServiceTests
    {
        [Fact]
        public void BorrowBooks_ReturnsList()
        {
            var mockedRepo = new Mock<ILibraryService>();

            mockedRepo.Setup(m => m.BorrowBook("ABC123", 1)).Returns(true);

            Assert.Equal(mockedRepo.Object.BorrowBook("ABC123", 1), true);
        }
    }
}
