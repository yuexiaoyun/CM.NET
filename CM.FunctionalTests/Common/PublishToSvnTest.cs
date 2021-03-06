using System;
using System.IO;
using CM.Common;
using NUnit.Framework;

namespace CM.FunctionalTests.Common
{
    [TestFixture]
    public class PublishToSvnTest
    {
        [Test]
        public void ShouldImportTrunkAndBranchIfTrunkDoesNotExist()
        {
            Using.Directory("publishSvn", () =>
            Using.SvnRepo(url => 
            {
                File.WriteAllText("test.txt", "");

                var log = new TestLogger();
                var sourceControl = new SvnProvider(log, TimeSpan.FromSeconds(30));
                var publish = new PublishToSourceControl(sourceControl);
                publish.FromWorkingDirectory(".")
                    .WithMainline(url + "/trunk")
                    .WithCommitMessage("test")
                    .To(url + "/tags/v1");

                Assert.That(sourceControl.Exists(url + "/trunk/test.txt"), "not imported into trunk\n" + log.Contents);
                Assert.That(sourceControl.Exists(url + "/tags/v1/test.txt"), "not branched\n" + log.Contents);
            }));
        }

        [Test]
        public void ShouldUpdateTrunkAndBranchWhenNewFileAdded()
        {
            Using.Directory("publishSvn", () =>
            Using.SvnRepo(url =>
            {
                var log = new TestLogger();
                var sourceControl = new SvnProvider(log, TimeSpan.FromSeconds(30));
                Directory.CreateDirectory("import");
                sourceControl.Import("import", url + "/trunk", "");

                Directory.CreateDirectory("new");
                File.WriteAllText(@"new\test.txt", "");

                var publish = new PublishToSourceControl(sourceControl);
                publish.FromWorkingDirectory("new")
                    .WithMainline(url + "/trunk")
                    .WithCommitMessage("test")
                    .To(url + "/tags/v1");

                Assert.That(sourceControl.Exists(url + "/trunk/test.txt"), "trunk not updated\n" + log.Contents);
                Assert.That(sourceControl.Exists(url + "/tags/v1/test.txt"), "not branched\n" + log.Contents);
            }));
        }

        [Test]
        public void ShouldUpdateTrunkAndBranchWhenFileDeleted()
        {
            Using.Directory("publishSvn", () =>
            Using.SvnRepo(url =>
            {
                var log = new TestLogger();
                var sourceControl = new SvnProvider(log, TimeSpan.FromSeconds(30));
                Directory.CreateDirectory("import");
                File.WriteAllText(@"import\test.txt", "");
                sourceControl.Import("import", url + "/trunk", "");

                Directory.CreateDirectory("new");

                var publish = new PublishToSourceControl(sourceControl);
                publish.FromWorkingDirectory("new")
                    .WithMainline(url + "/trunk")
                    .WithCommitMessage("test")
                    .To(url + "/tags/v1");

                Assert.That(!sourceControl.Exists(url + "/trunk/test.txt"), "file not deleted in trunk\n" + log.Contents);
                Assert.That(!sourceControl.Exists(url + "/tags/v1/test.txt"), "file not deleted in branch\n" + log.Contents);
            }));
        }
    }
}