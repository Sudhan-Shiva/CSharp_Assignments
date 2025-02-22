using NUnit.Framework;
using Task4.SubTask4;

namespace FilesAndStreamsUnitTesting
{
    public class MultipleFileLogTests
    {
        MultipleFileLog multipleFileLog = new MultipleFileLog();

        [Test]
        public void ExecuteMultipleUserLoggingWithMultipleFiles_WillLogErrorsOfMultipleUsersIntoUniqueFiles_IfExecuted()
        {
            //Act
            multipleFileLog.ExecuteMultipleUserLoggingWithMultipleFiles();

            //Assert
            for (int userCount = 0; userCount < 10;  userCount++)
            {
                Assert.IsTrue(File.ReadAllText("User" + userCount + ".txt").Contains("Error Logged : " + userCount));
            }
        }
    }
}
