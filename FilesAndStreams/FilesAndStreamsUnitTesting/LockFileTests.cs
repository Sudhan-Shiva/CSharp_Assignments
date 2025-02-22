using Task4.SubTask3;
using NUnit.Framework;

namespace FilesAndStreamsUnitTesting
{
    public class LockFileTests
    {
        LockFile lockFile = new LockFile();

        [Test]
        public void ExecuteMultipleUserLoggingWithLock_WillLogErrorsOfMultipleUsersIntoTheSameFile_IfExecuted()
        {
            //Arrange
            int numberOfErrorsLogged = 0;

            //Act
            lockFile.ExecuteMultipleUserLoggingWithLock();
            for (int loopCount = 0; loopCount < 10; loopCount++)
            {
                string fileData = File.ReadAllText("log.txt");
                if (fileData.Contains("Error Logged : " + loopCount))
                    numberOfErrorsLogged++;
            }

            //Assert
            Assert.AreEqual(10, numberOfErrorsLogged);
        }
    }
}
