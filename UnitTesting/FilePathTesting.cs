using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting;
using System;

namespace UnitTesting
{
    [TestClass]
    public class FilePathTesting
    {
        [TestMethod]
        public void NotFilePathTest()
        {
            // Arrange test
            TextFileReader reader = new TextFileReader();
            reader.FilePath = "NotAPath";
            string result = "";

            //Act test
            reader.ControlledAccess(ref result);

            //Assert test
            Assert.AreEqual("Text file reading exception: This survice only supports text files (*.txt), you entered: \"NotAPath\"", result);
        }

        [TestMethod]
        public void EmptyPathTest()
        {
            // Arrange test
            TextFileReader reader = new TextFileReader();
            reader.FilePath = "";
            string result = "";

            //Act test
            reader.ControlledAccess(ref result);

            //Assert test
            Assert.AreEqual("Text file reading exception: No path was entered", result);
        }

        [TestMethod]
        public void WrongFormatPathTest()
        {
            // Arrange test
            TextFileReader reader = new TextFileReader();
            reader.FilePath = "C:\\omega\\example\\NotAText.docx";
            string result = "";

            //Act test
            reader.ControlledAccess(ref result);

            //Assert test
            Assert.AreEqual("Text file reading exception: This survice only supports text files (*.txt), you entered: \"C:\\omega\\example\\NotAText.docx\"", result);
        }

        [TestMethod]
        public void NoSuchDirectoryPathTest()
        {
            // Arrange test
            TextFileReader reader = new TextFileReader();
            reader.FilePath = "No\\Such\\Directoty.txt";
            string result = "";

            //Act test
            reader.ControlledAccess(ref result);

            //Assert test
            Assert.AreEqual("Text file reading exception: Directory for: \"No\\Such\\Directoty.txt\" not found", result);
        }

        [TestMethod]
        public void NoSuchFilePathTest()
        {
            // Arrange test
            TextFileReader reader = new TextFileReader();
            reader.FilePath = "NoSuchDirectoty.txt";
            string result = "";

            //Act test
            reader.ControlledAccess(ref result);

            //Assert test
            Assert.AreEqual("Text file reading exception: File: \"NoSuchDirectoty.txt\" not found", result);
        }
    }
}
