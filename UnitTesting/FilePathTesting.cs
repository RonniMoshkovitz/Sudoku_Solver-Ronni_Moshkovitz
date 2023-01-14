using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting;
using System;
using System.IO;

namespace UnitTesting
{
    // This class, FilePathTesting, preforms unit testing for different text file access situations.
    [TestClass]
    public class FilePathTesting
    {

        // Test for something that is not a path.
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
            Assert.AreEqual("Text file reading exception: This program only supports text files (*.txt), you entered: \"NotAPath\"", result);
        }

        // Test for an empty path.
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

        // Test for path that leads to a file that is not in the right format (not a *.txt).
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
            Assert.AreEqual("Text file reading exception: This program only supports text files (*.txt), you entered: \"C:\\omega\\example\\NotAText.docx\"", result);
        }

        // Test for a path that leads to a directory that does not exist.
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

        // Test for a path that leads to a file that does not exist.
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

        // Test for a path that leads to a valid path.
        [TestMethod]
        public void ValidFilePathTest()
        {
            // Arrange test
            TextFileReader reader = new TextFileReader();
            // Get the path dinamically to make the testing possible on different mechines.
            reader.FilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\", "ValidTextPath.txt");
            string result = "";

            //Act test
            reader.ControlledAccess(ref result);

            //Assert test
            Assert.AreEqual("This is a valid txt file!", result);
        }
    }
}
