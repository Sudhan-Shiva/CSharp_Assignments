using System.Text;
using NUnit.Framework;
using Task1.FileManager;
using Task2.FileManager;

namespace FilesAndStreamsUnitTesting
{
    public class AsynchronousFileHandlerTests
    {
        AsynchronousFileHandler asynchronousFileHandler = new AsynchronousFileHandler();

        [TestCase("asynchronousTestFile1")]
        [TestCase("asynchronousTestFile2")]
        [TestCase("asynchronousTestFile3")]
        [TestCase("asynchronousTestFile4")]
        [Test]
        public void CreateLargeTextFile_ShallCreateFileOfSize1GB_IfFileNameIsGiven(string fileName)
        {
            //Arrange
            asynchronousFileHandler.DeleteFileIfExists(fileName + ".txt");

            //Act
            asynchronousFileHandler.CreateLargeTextFile(fileName);

            //Assert
            Assert.IsTrue(new FileInfo(fileName + ".txt").Length > (long)1024 * 1024 * 1024);
        }

        [TestCase("asynchronousTestFile1")]
        [TestCase("asynchronousTestFile2")]
        [TestCase("asynchronousTestFile3")]
        [TestCase("asynchronousTestFile4")]
        [Test]
        public async Task ReadByFileStream_ShallReadTargetFileInChunksByFileStream_IfFileNameIsGiven(string fileName)
        {
            //Act
            int bytesReadByFileStream = await asynchronousFileHandler.ReadByFileStream(fileName, 1024 * 1024 * 10);

            //Assert
            Assert.AreEqual((int) new FileInfo(fileName + ".txt").Length, bytesReadByFileStream);
        }

        [TestCase("asynchronousTestFile1")]
        [TestCase("asynchronousTestFile2")]
        [TestCase("asynchronousTestFile3")]
        [TestCase("asynchronousTestFile4")]
        [Test]
        public async Task ReadByBufferedStream_ShallReadTargetFileInChunksByBufferedStream_IfFileNameIsGiven(string fileName)
        {
            //Act
            int bytesReadByBufferedStream = await asynchronousFileHandler.ReadByBufferedStream(fileName, 1024 * 1024 * 10);

            //Assert
            Assert.AreEqual((int)new FileInfo(fileName + ".txt").Length, bytesReadByBufferedStream);
        }


        [TestCase("asynchronousTestFile1", "asynchronousProcessedTestFileByMemoryStream1")]
        [TestCase("asynchronousTestFile2", "asynchronousProcessedTestFileByMemoryStream2")]
        [TestCase("asynchronousTestFile3", "asynchronousProcessedTestFileByMemoryStream3")]
        [TestCase("asynchronousTestFile4", "asynchronousProcessedTestFileByMemoryStream4")]
        [Test]
        public async Task WriteByMemoryStream_ShallWriteProcessedDataFromAFileToNewFile_WhenInputFileNameAndProcessedFileNameIsGiven(string fileName, string processedFileName)
        {
            //Arrange
            asynchronousFileHandler.DeleteFileIfExists(processedFileName + ".txt");

            //Act
            await asynchronousFileHandler.WriteByMemoryStream(fileName, processedFileName, 1024 * 1024 * 10);
            byte[] fileData = File.ReadAllBytes(processedFileName + ".txt");

            //Assert
            Assert.IsTrue(Encoding.UTF8.GetString(fileData.Chunk(1024 * 1024).First()).Where(char.IsLetter).All(char.IsUpper));
        }

        [TestCase("asynchronousTestFile1", "asynchronousProcessedTestFileByFileStream1")]
        [TestCase("asynchronousTestFile2", "asynchronousProcessedTestFileByFileStream2")]
        [TestCase("asynchronousTestFile3", "asynchronousProcessedTestFileByFileStream3")]
        [TestCase("asynchronousTestFile4", "asynchronousProcessedTestFileByFileStream4")]
        [Test]
        public async Task WriteByFileStream_ShallWriteProcessedDataFromAFileToNewFile_WhenInputFileNameAndProcessedFileNameIsGiven(string fileName, string processedFileName)
        {
            //Arrange
            asynchronousFileHandler.DeleteFileIfExists(processedFileName + ".txt");

            //Act
            await asynchronousFileHandler.WriteByFileStream(fileName, processedFileName, 1024 * 1024 * 10);
            byte[] fileData = File.ReadAllBytes(processedFileName + ".txt");

            //Assert
            Assert.IsTrue(Encoding.UTF8.GetString(fileData.Chunk(1024 * 1024).First()).Where(char.IsLetter).All(char.IsLower));
        }

        [TestCase($"asynchronousDeletingFile1.txt")]
        [TestCase($"asynchronousDeletingFile2.txt")]
        [TestCase($"asynchronousDeletingFile3.txt")]
        [TestCase($"asynchronousDeletingFile4.txt")]
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
            asynchronousFileHandler.DeleteFileIfExists(fileName);

            //Assert
            Assert.IsFalse(File.Exists(fileName));
        }
    }
}
