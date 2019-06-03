using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSVFileComparsion;
using System;
using System.IO;
using System.Text;

namespace CSVFileComparisionTests
{
    [TestClass]
    public class UnitTest1
    {

        public static string _ResultPath = Directory.GetParent(@"../../../../../").FullName+ "\\ErrorResult\\";

        [DataTestMethod]
        [DataRow(new string[] {"a,b,","c,d"},  new string[] {"e,F","g,h"},true)]
        [DataRow(new string[] {"a,b,","c,d" }, new string[] { "e,F"}, false)]
        public void Compare_File_Lenght_Test(string[] stringArray1, string[] stringArray2, bool expected)
        {
            FileComparision _fc = new FileComparision();
            bool actual = _fc.CompareFileLength(stringArray1, stringArray2);
            Assert.AreEqual(expected, actual);
        }
        

        [DataTestMethod]
        [DataRow(new string[] { "a,b", "c,d" }, new string[] { "e,F", "g,h" }, true)]
        [DataRow(new string[] { "a,b,", "c,d" }, new string[] { "e,F", "a" }, false)]
        public void Compare_File_Column_Lenght_Test(string[] stringArray1, string[] stringArray2, bool expected)
        {
            FileComparision _fc = new FileComparision();
            bool actual = _fc.CompareCSVFileColumnLength(stringArray1, stringArray2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Test1.csv", "Test2.csv","ReportPath")]
        public void Provide_NoPath_ThrowsFileNotFoundException(string FilePath1, string FilePath2, string reportPath)
        {
            FileComparision _fc = new FileComparision();
            Assert.ThrowsException<FileNotFoundException>(() => _fc.CompareCsvFiles(FilePath1, FilePath2, reportPath));
        }

        [TestMethod]
        [DataRow(new string[] { "a,b", "c,d"}, new string[] { "a,b", "c,d" },true)]
        public void Provide_SameFileContent_CompareCsvFileContents_Test(string[] FileConentPath1, string[] FileConentPath2,bool expected)
        {
            FileComparision _fc = new FileComparision();
            bool actual = _fc.CompareCsvFileContents(FileConentPath1, FileConentPath2, new StringBuilder(), _ResultPath);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [DataRow(new string[] { "a,b", "c,d" }, new string[] { "a,b", "c,f" },true)]
        public void Provide_DifferentFileContent_CompareCsvFileContents_Test(string[] FileConentPath1, string[] FileConentPath2, bool expected)
        {
            FileComparision _fc = new FileComparision();
            bool actual = _fc.CompareCsvFileContents(FileConentPath1, FileConentPath2, new StringBuilder(), _ResultPath);
            Assert.AreEqual(expected, actual);
        }
    }
}
