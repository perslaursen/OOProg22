namespace UnitTestProject
{
    [TestClass]
    public class WarriorUnitTest
    {
        [TestMethod]
        public void TestWarrior_Constructor_NameTooShort_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("A", 100); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_HitPointsMinimal_NoException()
        {
            // Act
            Warrior actualResult = new Warrior("Rolf", 1);

            // Assert
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void TestWarrior_Name_GetOnce()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            string expectedResult = "Rolf";

            // Act
            string actualResult = testSubject.Name;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetInitial()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            bool expectedResult = false;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}