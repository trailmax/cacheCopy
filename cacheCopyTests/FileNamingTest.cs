using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using cacheCopy;
using NUnit.Framework;

namespace cacheCopyTests
{
    [TestFixture]
    public class FileNamingTest
    {

        public FileInfo file;
        public String dir;
        public FileInfo png_file;
        [SetUp]
        public void SetUp()
        {
            file = new FileInfo("files/example.jpg");
            dir = file.DirectoryName;

            png_file = new FileInfo("files/example.png");
        }


//GenerateFileName(FileInfo file, String pattern, bool allowOverwrite, string targetPath, string Number = "" )

        [Test]
        public void FileExists()
        {
            bool exists = File.Exists(file.FullName);
            Assert.IsTrue(exists);
            Assert.IsTrue(File.Exists(png_file.FullName));

            Assert.AreEqual(file.Name, "example.jpg");
            Assert.AreEqual(png_file.Name, "example.png");
        }


        [Test]
        public void NoPatternNoOverwrite()
        {
            String newName = FileNaming.GenerateFileName(file, "", true, dir, "");
            Assert.AreEqual(file.FullName, newName);
        }


        /// <summary>
        /// Check if we generate name for overwriting ok
        /// </summary>
        [Test]
        public void NoPatterDoOverwrite()
        {
            string newName = FileNaming.GenerateFileName(file, "", false, dir, "");
            Assert.AreNotEqual(file.FullName, newName);

            string newNameOnly = Path.GetFileName(newName);
            Assert.AreEqual("example(1).jpg", newNameOnly);
        }


        [Test]
        public void SimplePatternNoOverwrite() 
        {
            String pattern ="hello.jpg";
            Assert.IsFalse(File.Exists("files/" + pattern));

            string name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual(pattern, Path.GetFileName(name));
        }

        [Test]
        public void SimplePatternDoOverwrite()
        {
            String pattern = "example.jpg";
            Assert.IsTrue(File.Exists("files/" + pattern));

            string name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual("example(1).jpg", Path.GetFileName(name));
        }


        [Test]
        public void SimplePatternNoExtension()
        {
            String pattern = "simple";

            string name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual("simple.jpg", Path.GetFileName(name));

            name = FileNaming.GenerateFileName(png_file, pattern, false, dir, "");
            Assert.AreEqual("simple.png", Path.GetFileName(name));
        }



        [Test]
        public void SimplePatternNoExtensionDoOverwrite()
        {
            String pattern = "example";

            string name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual("example(1).jpg", Path.GetFileName(name));

            name = FileNaming.GenerateFileName(png_file, pattern, false, dir, "");
            Assert.AreEqual("example(1).png", Path.GetFileName(name));

        }

        [Test]
        public void DatePattern()
        {
            String pattern = "*yyyy*_hello";

            string name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual(DateTime.Now.ToString("yyyy")+"_hello.jpg", Path.GetFileName(name));


            pattern = "*yy*_hi.tmp";
            name = FileNaming.GenerateFileName(png_file, pattern, false, dir, "");
            Assert.AreEqual(DateTime.Now.ToString("yy")+"_hi.tmp.png", Path.GetFileName(name));
        }


    }
}
