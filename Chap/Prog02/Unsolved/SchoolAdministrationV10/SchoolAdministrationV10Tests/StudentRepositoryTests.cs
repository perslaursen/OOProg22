using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        private StudentRepository _students = new StudentRepository();

        public void TestSetup()
        {
            _students = new StudentRepository();

            Student anna = new Student(12, "Anna");
            Student betty = new Student(338, "Betty");
            Student carl = new Student(92, "Carl");
            Student diana = new Student(295, "Diana");

            anna.AddTestResult("English", 85);
            anna.AddTestResult("Math", 70);
            anna.AddTestResult("Biology", 90);
            anna.AddTestResult("French", 52);
            // Average for Anna is 74

            betty.AddTestResult("English", 77);
            betty.AddTestResult("Math", 82);
            betty.AddTestResult("Chemistry", 65);
            betty.AddTestResult("French", 41);
            // Average for Betty is 66

            carl.AddTestResult("English", 55);
            carl.AddTestResult("Math", 48);
            carl.AddTestResult("Biology", 70);
            carl.AddTestResult("French", 38);
            // Average for Betty is 52

            _students.AddStudent(anna);
            _students.AddStudent(betty);
            _students.AddStudent(carl);
            _students.AddStudent(diana);
        }

        [TestMethod()]
        public void AddStudentTest()
        {
            // Arrange
            TestSetup();

            // Act
            int beforeCount = _students.Count;
            _students.AddStudent(new Student(987, "Eric"));
            int afterCount = _students.Count;

            // Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [TestMethod()]
        public void GetStudentTest_ExistingStudent()
        {
            // Arrange
            TestSetup();

            // Act
            Student? result = _students.GetStudent(338);

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(result?.ID, 338);
        }

        [TestMethod()]
        public void GetStudentTest_NonExistingStudent()
        {
            // Arrange
            TestSetup();

            // Act
            Student? result = _students.GetStudent(833);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod()]
        public void GetAverageForStudentTest_ExistingStudent()
        {
            // Arrange
            TestSetup();

            // Act
            int? result = _students.GetAverageForStudent(12);
            int? expectedResult = (85 + 70 + 90 + 52) / 4;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetAverageForStudentTest_NonExistingStudent()
        {
            // Arrange
            TestSetup();

            // Act
            int? result = _students.GetAverageForStudent(21);
            int? expectedResult = null;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetTotalAverageTest()
        {
            // Arrange
            TestSetup();

            // Act
            int? result = _students.GetTotalAverage();
            int expectedResult = (74 + 66 + 52) / 3;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}