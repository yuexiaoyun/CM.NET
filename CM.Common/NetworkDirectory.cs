using System;
using System.IO;

namespace CM.Common
{
    public class NetworkDirectory
    {
        public NetworkDirectory(string machine, string localDirectory)
        {
            Machine = machine;
            LocalDirectory = localDirectory;
        }

        public virtual string Machine { get; private set; }
        public virtual string LocalDirectory { get; private set; }

        public virtual string NetworkPath
        {
            get
            {
                if (!LocalDirectory.Contains(":"))
                    return LocalDirectory;
                if (Machine.Equals("localhost", StringComparison.InvariantCultureIgnoreCase))
                    return LocalDirectory;

                return string.Format(@"\\{0}\{1}$\{2}", Machine, LocalDirectory.Substring(0, 1),
                    LocalDirectory.Substring(3));
            }
        }

        public virtual string BaseDirectoryName
        {
            get
            {
                var directories = NetworkPath.Split('\\');
                return directories[directories.Length - 1];
            }
        }
        
        public virtual string ParentDirectoryName
        {
            get { return new NetworkDirectory(Machine, new DirectoryInfo(LocalDirectory).Parent.FullName).NetworkPath; }
        }

        public virtual void EnsureExistsAndIsEmpty()
        {
            if (Directory.Exists(NetworkPath))
                Empty();
            else
                Directory.CreateDirectory(NetworkPath);
        }

        public virtual void MirrorFrom(string sourceDirectory)
        {
            EnsureExistsAndIsEmpty();
            MirrorFrom(sourceDirectory, NetworkPath);
        }

        private void Empty()
        {
            foreach (var subdirectory in Directory.GetDirectories(NetworkPath))
            {
                Directory.Delete(subdirectory, true);
            }
            foreach (var filename in Directory.GetFiles(NetworkPath))
            {
                File.Delete(filename);
            }
        }

        private static void MirrorFrom(string sourceDirectory, string destinationDirectory)
        {
            foreach (var file in Directory.GetFiles(sourceDirectory))
            {
                File.Copy(file, Path.Combine(destinationDirectory, Path.GetFileName(file)));
            }
            foreach (var directory in Directory.GetDirectories(sourceDirectory))
            {
                var subdirectoryName = new DirectoryInfo(directory).Name;
                var destination = Path.Combine(destinationDirectory, subdirectoryName);
                Directory.CreateDirectory(destination);
                MirrorFrom(Path.Combine(sourceDirectory, subdirectoryName), destination);
            }
        }
    }
}