using NUnit.Framework;
using Task1.FileManager;

namespace FilesAndStreamsUnitTesting
{
    public class SynchronousFileHandlerTests
    {
        SynchronousFileHandler synchronousFileHandler = new SynchronousFileHandler();

        [TestCase("synchronousTestFile1")]
        [TestCase("synchronousTestFile2")]
        [TestCase("synchronousTestFile3")]
        [TestCase("synchronousTestFile4")]
        [Test]
        public void CreateLargeTextFile_ShallCreateFileOfSize1GB_IfFileNameIsGiven(string fileName)
        {
            //Arrange
            synchronousFileHandler.DeleteFileIfExists(fileName+".txt");

            //Act
            synchronousFileHandler.CreateLargeTextFile(fileName);

            //Assert
            Assert.IsTrue(new FileInfo(fileName + ".txt").Length > (long) 1024* 1024* 1024);
        }

        [TestCase("synchronousTestFile1")]
        [TestCase("synchronousTestFile2")]
        [TestCase("synchronousTestFile3")]
        [TestCase("synchronousTestFile4")]
        [Test]
        public void ReadByBufferedStream_ShallReadTargetFileInChunksByBufferedStream_IfFileNameIsGiven(string fileName)
        {
            //Act
            int bytesReadByBufferedStream = synchronousFileHandler.ReadByBufferedStream(fileName);

            //Assert
            Assert.AreEqual((int) new FileInfo(fileName + ".txt").Length, bytesReadByBufferedStream);
        }

        [TestCase("synchronousTestFile1")]
        [TestCase("synchronousTestFile2")]
        [TestCase("synchronousTestFile3")]
        [TestCase("synchronousTestFile4")]
        [Test]
        public void ReadByFileStream_ShallReadTargetFileInChunksByFileStream_IfFileNameIsGiven(string fileName)
        {
            //Act
            int bytesReadByFileStream = synchronousFileHandler.ReadByFileStream(fileName);

            //Assert
            Assert.AreEqual((int) new FileInfo(fileName + ".txt").Length, bytesReadByFileStream);
        }

        [TestCase("synchronousTestFile1", "synchronousProcessedTestFileByMemoryStream1")]
        [TestCase("synchronousTestFile2", "synchronousProcessedTestFileByMemoryStream2")]
        [TestCase("synchronousTestFile3", "synchronousProcessedTestFileByMemoryStream3")]
        [TestCase("synchronousTestFile4", "synchronousProcessedTestFileByMemoryStream4")]
        [Test]
        public void WriteByMemoryStream_ShallWriteProcessedDataFromAFileToNewFile_WhenInputFileNameAndProcessedFileNameIsGiven(string fileName, string processedFileName)
        {
            //Arrange
            synchronousFileHandler.DeleteFileIfExists(processedFileName+".txt");

            //Act
            synchronousFileHandler.WriteByMemoryStream(fileName, processedFileName);
            string fileData = File.ReadAllText(processedFileName + ".txt");

            //Assert
            Assert.IsTrue(fileData.Where(char.IsLetter).All(char.IsUpper));
        }

        [TestCase($"synchronousDeletingFile1.txt")]
        [TestCase($"synchronousDeletingFile2.txt")]
        [TestCase($"synchronousDeletingFile3.txt")]
        [TestCase($"synchronousDeletingFile4.txt")]
        [Test]
        public void DeleteFileIfExists_ShallDeleteIfItExists_IfFileNameIsGiven(string fileName)
        {
            //Arrange
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                fileStream.WriteByte(0);
            }

            //Assert
            Assert.IsTrue(File.Exists(fileName));

            //Act
            synchronousFileHandler.DeleteFileIfExists(fileName);

            //Assert
            Assert.IsFalse(File.Exists(fileName));
        }
    }
}
