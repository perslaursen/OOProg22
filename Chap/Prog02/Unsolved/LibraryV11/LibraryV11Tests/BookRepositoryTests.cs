using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class BookRepositoryTests
    {
        private BookRepository _repository = new BookRepository();

        public void TestSetup()
        {
            Book b1 = new Book("AD1337", "C# for All", "John Potter", 352);
            Book b2 = new Book("XS3220", "Gardening", "Alex Sohn", 220);
            Book b3 = new Book("DD0095", "Cars in the USA", "Susan Dreyer", 528);
            Book b4 = new Book("PT1295", "The World Narrators", "Dan Mygind", 256);

            _repository = new BookRepository();
            _repository.AddBook(b1);
            _repository.AddBook(b2);
            _repository.AddBook(b3);
            _repository.AddBook(b4);
        }

        [TestMethod()]
        public void AddBookTest()
        {
            // Arrange
            TestSetup();

            // Act
            int beforeCount = _repository.Count;
            _repository.AddBook(new Book("KS2007", "Dogs and Cats", "Jim Scott", 217));
            int afterCount = _repository.Count;

            // Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [TestMethod()]
        public void LookupBookTest_ExistingBook()
        {
            // Arrange
            TestSetup();

            // Act
            Book? result = _repository.LookupBook("AD1337");

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(result?.ISBN, "AD1337");
        }

        [TestMethod()]
        public void LookupBookTest_NonExistingBook_Case1()
        {
            // Arrange
            TestSetup();

            // Act
            Book? result = _repository.LookupBook("AD1338");

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void LookupBookTest_NonExistingBook_Case2()
        {
            // Arrange
            TestSetup();

            // Act
            Book? result = _repository.LookupBook("...");

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void LookupBookTest_NonExistingBook_Case3()
        {
            // Arrange
            TestSetup();

            // Act
            Book? result = _repository.LookupBook("ad1337");

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void DeleteBookTest_ExistingBook()
        {
            // Arrange
            TestSetup();

            // Act
            int beforeCount = _repository.Count;
            _repository.DeleteBook("XS3220");
            int afterCount = _repository.Count;

            // Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount - 1, afterCount);
        }

        [TestMethod()]
        public void DeleteBookTest_NonExistingBook()
        {
            // Arrange
            TestSetup();

            // Act
            int beforeCount = _repository.Count;
            _repository.DeleteBook("SX2320");
            int afterCount = _repository.Count;

            // Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount, afterCount);
        }
    }
}