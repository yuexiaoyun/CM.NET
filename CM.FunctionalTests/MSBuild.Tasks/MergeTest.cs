using System.IO;
using CM.MSBuild.Tasks;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CM.FunctionalTests.MSBuild.Tasks
{
    [TestFixture]
    public class MergeTest
    {
        [SetUp]
        public void CreateDirectories()
        {
            Directory.CreateDirectory("old");
            Directory.CreateDirectory("new");
        }

        [TearDown]
        public void RemoveDirectories()
        {
            Directory.Delete("old", true);
            Directory.Delete("new", true);
        }
        
        [Test]
        public void MergingEmptyDirectoriesDoesNothing()
        {
            Merge.From("new").Into("old");
            Assert.That(Directory.GetFiles("old"), Is.EqualTo(new string[0]));
        }

        [Test]
        public void ShouldAddMissingTopLevelFile()
        {
            File.WriteAllText(@"new\test.txt", "");
            Merge.From("new").Into("old");

            Assert.That(Directory.GetFiles("old"), Is.EqualTo(new[] {@"old\test.txt"}));
        }

        [Test]
        public void ShouldUpdateExistingTopLevelFile()
        {
            File.WriteAllText(@"old\test.txt", "old");
            File.WriteAllText(@"new\test.txt", "new");
            Merge.From("new").Into("old");

            Assert.That(File.ReadAllText(@"old\test.txt"), Is.EqualTo("new"));
        }

        [Test]
        public void ShouldDeleteRemovedTopLevelFile()
        {
            File.WriteAllText(@"old\test.txt", "");
            Merge.From("new").Into("old");

            Assert.That(Directory.GetFiles("old"), Is.EqualTo(new string[0]));
        }

        [Test]
        public void ShouldAddNewSubdirectory()
        {
            Directory.CreateDirectory(@"new\subdir");
            Merge.From("new").Into("old");

            Assert.That(Directory.GetDirectories("old"), Is.EqualTo(new[] {@"old\subdir"}));
        }

        [Test]
        public void ShouldDeleteRemovedSubdirectory()
        {
            Directory.CreateDirectory(@"old\subdir");
            Merge.From("new").Into("old");

            Assert.That(Directory.GetDirectories("old"), Is.EqualTo(new string[0]));
        }

        [Test]
        public void ShouldAddMissingFileInExistingSubdirectory()
        {
            Directory.CreateDirectory(@"old\subdir");
            Directory.CreateDirectory(@"new\subdir");
            File.WriteAllText(@"new\subdir\test.txt", "");
            Merge.From("new").Into("old");

            Assert.That(Directory.GetFiles(@"old\subdir"), Is.EqualTo(new[] {@"old\subdir\test.txt"}));
        }

        [Test]
        public void ShouldAddMissingSubdirectoryWithContents()
        {
            Directory.CreateDirectory(@"new\subdir");
            File.WriteAllText(@"new\subdir\test.txt", "");
            Merge.From("new").Into("old");

            Assert.That(Directory.GetFiles(@"old\subdir"), Is.EqualTo(new[] { @"old\subdir\test.txt" }));
        }

        [Test]
        public void ShouldUpdateExistingFileInSubdirectory()
        {
            Directory.CreateDirectory(@"old\subdir");
            Directory.CreateDirectory(@"new\subdir");
            File.WriteAllText(@"old\subdir\test.txt", "old");
            File.WriteAllText(@"new\subdir\test.txt", "new");
            Merge.From("new").Into("old");

            Assert.That(File.ReadAllText(@"old\subdir\test.txt"), Is.EqualTo("new"));
        }

        [Test]
        public void ShouldDeleteRemovedFileInSubdirectory()
        {
            Directory.CreateDirectory(@"old\subdir");
            Directory.CreateDirectory(@"new\subdir");
            File.WriteAllText(@"old\subdir\test.txt", "");
            Merge.From("new").Into("old");

            Assert.That(Directory.GetFiles(@"old\subdir"), Is.EqualTo(new string[0]));
        }

        [Test]
        public void ShouldRecursivelyDeleteRemovedDirectory()
        {
            Directory.CreateDirectory(@"old\subdir");
            File.WriteAllText(@"old\subdir\test.txt", "");
            Merge.From("new").Into("old");

            Assert.That(Directory.GetDirectories("old"), Is.EqualTo(new string[0]));
        }

        [Test]
        public void ShouldBeAbleToExcludeDirectories()
        {
            Directory.CreateDirectory(@"old\.svn");
            Merge.From("new").ExcludingDirectories(".svn").Into("old");

            Assert.That(Directory.GetDirectories("old"), Is.EqualTo(new[] {@"old\.svn"}));
        }

        [Test]
        public void ShouldKeepExcludeDirectoriesWhenRecursing()
        {
            Directory.CreateDirectory(@"old\subdir");
            Directory.CreateDirectory(@"old\subdir\.svn");
            Directory.CreateDirectory(@"new\subdir");
            Merge.From("new").ExcludingDirectories(".svn").Into("old");

            Assert.That(Directory.GetDirectories(@"old\subdir"), Is.EqualTo(new[] { @"old\subdir\.svn" }));
        }
    }
}