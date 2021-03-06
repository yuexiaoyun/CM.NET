using System;

namespace CM.Common
{
    public class SvnProvider : ISourceControlProvider
    {
        private readonly ILogger log;
        private readonly TimeSpan commandTimeout;

        public SvnProvider(ILogger log, TimeSpan commandTimeout)
        {
            this.log = log;
            this.commandTimeout = commandTimeout;
        }

        public string[] MetadataDirectories
        {
            get { return new[] {".svn"}; }
        }

        public virtual bool Exists(string url)
        {
            var result = true;
            RunCommand(string.Format("ls \"{0}\"", url), ".", delegate { result = false; });
            return result;
        }

        public virtual void CreateWorkingDirectory(string url, string localPath)
        {
            RunCommand(string.Format("checkout \"{0}\" \"{1}\"", url, localPath), ".", LogFailure);
        }

        public virtual void Commit(string workingDirectory, string message)
        {
            RunCommand(string.Format("commit . --message \"{0}\"", message), workingDirectory, LogFailure);
        }

        public virtual void Import(string workingDirectory, string url, string message)
        {
            RunCommand(string.Format("import \"{0}\" \"{1}\" --message \"{2}\"", workingDirectory, url, message), ".", LogFailure);
        }

        public virtual void Branch(string sourceUrl, string destinationUrl, string message)
        {
            var parentsFlag = Exists(ParentPath(destinationUrl)) ? "" : "--parents";
            var command = string.Format("copy \"{0}\" \"{1}\" {2} --message \"{3}\"", sourceUrl, destinationUrl, parentsFlag, message);
            RunCommand(command, ".", LogFailure);
        }

        public virtual void AddFile(string file, string workingDirectory)
        {
            RunCommand(string.Format("add \"{0}\"", file), workingDirectory, LogFailure);
        }

        public virtual void AddDirectory(string directory, string workingDirectory)
        {
            RunCommand(string.Format("add \"{0}\"", directory), workingDirectory, LogFailure);
        }

        public virtual void UpdateFile(string file, string workingDirectory)
        {
        }

        public virtual void DeleteFile(string file, string workingDirectory)
        {
            RunCommand(string.Format("rm \"{0}\"", file), workingDirectory, LogFailure);
        }

        public virtual void DeleteDirectory(string directory, string workingDirectory)
        {
            RunCommand(string.Format("rm \"{0}\"", directory), workingDirectory, LogFailure);
        }

        private void RunCommand(string command, string workingDirectory, Action<SystemProcess> onFailure)
        {
            log.Info("svn {0}", command);
            var processRunner = new ProcessRunner(workingDirectory);
            var process = processRunner.Exec("svn " + command, commandTimeout);
            if (!process.WasSuccessful)
                onFailure(process);
        }

        private void LogFailure(SystemProcess process)
        {
            log.Error(process.ToString());
            throw new Exception("svn command failed");
        }

        private static string ParentPath(string url)
        {
            var uri = new Uri(url);
            if (uri.AbsolutePath == "/")
                return url;

            var directories = uri.AbsolutePath.Split('/');
            return url.Replace(directories[directories.Length - 1], "");
        }
    }
}