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

            pattern = "hello_*MM*_World.jpeg";
            name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual("hello_"+DateTime.Now.ToString("MM") + "_World.jpeg", Path.GetFileName(name));

            
            pattern = "*yy*_*MMM*_*dd*_*HH*_*mm*_*ss*.jpeg";
            name = FileNaming.GenerateFileName(file, pattern, false, dir, "");

            string generated = DateTime.Now.ToString("yy") + "_" + DateTime.Now.ToString("MMM") +
                "_" + DateTime.Now.ToString("dd") + "_" + DateTime.Now.ToString("HH") +
                "_" + DateTime.Now.ToString("mm") + "_" + DateTime.Now.ToString("ss") + ".jpeg";
            Assert.AreEqual(generated, Path.GetFileName(name));

            //Fails because timing is too fine
            //pattern = "*fffffff*";
            //name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            //Assert.AreEqual(DateTime.Now.ToString("fffffff") + ".jpg", Path.GetFileName(name));

        }


        [Test]
        public void FileDateTimePatten()
        {
            String pattern = "*CFyyyy*_hello";
            DateTime fileDate = file.CreationTime;


            string name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual(fileDate.ToString("yyyy") + "_hello.jpg", Path.GetFileName(name));


            pattern = "*CFyy*_hi.tmp";
            name = FileNaming.GenerateFileName(png_file, pattern, false, dir, "");
            Assert.AreEqual(fileDate.ToString("yy") + "_hi.tmp.png", Path.GetFileName(name));

            pattern = "hello_*CFMM*_World.jpeg";
            name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual("hello_" + fileDate.ToString("MM") + "_World.jpeg", Path.GetFileName(name));


            pattern = "*CFyy*_*CFMMM*_*CFdd*_*CFHH*_*CFmm*_*CFss*.jpeg";
            name = FileNaming.GenerateFileName(file, pattern, false, dir, "");

            string generated = fileDate.ToString("yy") + "_" + fileDate.ToString("MMM") +
                "_" + fileDate.ToString("dd") + "_" + fileDate.ToString("HH") +
                "_" + fileDate.ToString("mm") + "_" + fileDate.ToString("ss") + ".jpeg";
            Assert.AreEqual(generated, Path.GetFileName(name));

            //fffffff
            pattern = "*CFff*";
            name = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            Assert.AreEqual(fileDate.ToString("ff") + ".jpg", Path.GetFileName(name));
        }


        [Test]
        public void RandomStringPattern()
        {
            String pattern = "*RAND4*.jpg";
            string name1 = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            string name2 = FileNaming.GenerateFileName(file, pattern, false, dir, "");
            name1 = Path.GetFileName(name1);
            name2 = Path.GetFileName(name2);


            Assert.AreEqual(name1.Length, 8);
            Assert.AreEqual(name2.Length, 8);
            Assert.AreNotEqual(name1, name2);

        }

    }
}
