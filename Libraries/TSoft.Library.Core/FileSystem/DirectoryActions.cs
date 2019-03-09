// <copyright file="DirectoryActions.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the directory actions class</summary>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.Library.Core.FileSystem
{
    /// <summary> A directory actions. </summary>
    public static class DirectoryActions
    {
        #region [Public methods]

        /// <summary> Creates a directory. </summary>
        /// <param name="pName"> The name. </param>
        public static void CreateDirectory(string pName)
        {
            if (string.IsNullOrEmpty(pName))
                return;
            try
            {
                string dir = Path.GetDirectoryName(pName);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Directory not found: {e.Message}");
            }
        }

        /// <summary> Directory copy. </summary>
        /// <exception cref="DirectoryNotFoundException"> Thrown when the requested directory is not present. </exception>
        /// <param name="sourceDirName"> Pathname of the source directory. </param>
        /// <param name="destDirName">   Pathname of the destination directory. </param>
        /// <param name="copySubDirs">   true to copy sub dirs. </param>
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDirName}");
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            foreach (FileInfo file in dir.GetFiles())
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        /// <summary> Directory move. </summary>
        /// <exception cref="DirectoryNotFoundException"> Thrown when the requested directory is not present. </exception>
        /// <param name="sourceDirName"> Pathname of the source directory. </param>
        /// <param name="destDirName">   Pathname of the destination directory. </param>
        /// <param name="copySubDirs">   true to copy sub dirs. </param>
        public static void DirectoryMove(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDirName}");
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.MoveTo(temppath);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryMove(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        /// <summary> Gets directory information. </summary>
        /// <param name="directory"> Pathname of the directory. </param>
        /// <returns> The directory information. </returns>
        public static DirectoryInfo GetDirectoryInfo(string @directory)
        {
            return new DirectoryInfo(Path.GetDirectoryName(@directory));
        }

        /// <summary> Query if 'name' is directory. </summary>
        /// <param name="name"> The name. </param>
        /// <returns> true if directory, false if not. </returns>
        public static bool IsDirectory(string name)
        {
            return (File.GetAttributes(name) & FileAttributes.Directory) != 0;
        }

        /// <summary> Enumerates process dir in this collection. </summary>
        /// <param name="sourceDirectory"> Pathname of the source directory. </param>
        /// <param name="fileExtension">   The file extension. </param>
        /// <param name="isRecursive">     (Optional) true if this object is recursive. </param>
        /// <returns> An enumerator that allows foreach to be used to process process dir in this collection. </returns>
        public static IEnumerable<string> ProcessDir(string sourceDirectory, string fileExtension, bool isRecursive = true)
        {
            new FileIOPermission(FileIOPermissionAccess.AllAccess, sourceDirectory).Demand();
            DirectoryInfo rootDirectory;
            FileInfo[] fileEntries;
            bool asError = false;

            //try
            {
                rootDirectory = new DirectoryInfo(sourceDirectory);
                fileEntries = rootDirectory.GetFiles(fileExtension);
            }

            //catch (Exception e)
            //{
            //   asError = true ;
            //}

            if (asError)
                yield break;

            foreach (FileInfo F in fileEntries)
            {
                yield return F.FullName;
            }

            if (isRecursive)
            {
                foreach (DirectoryInfo subdir in rootDirectory.GetDirectories())
                {
                    foreach (string item in ProcessDir(subdir.FullName, fileExtension, isRecursive))
                    {
                        yield return item;
                    }
                }
            }

            //return fileList;
        }

        /// <summary> Process the directory. </summary>
        /// <param name="sourceDirectory"> Pathname of the source directory. </param>
        /// <param name="fileExtension">   The file extension. </param>
        /// <returns> A Collection&lt;string&gt; </returns>
        public static Collection<string> ProcessDirectory(string sourceDirectory, string fileExtension)
        {
            Collection<string> fileList = new Collection<string>();

            ProcessRecurDir(ref fileList, sourceDirectory, fileExtension, false);
            return fileList;
        }

        /// <summary> Process the directory recursive. </summary>
        /// <param name="sourceDirectory"> Pathname of the source directory. </param>
        /// <param name="fileExtension">   The file extension. </param>
        /// <returns> A Collection&lt;string&gt; </returns>
        public static Collection<string> ProcessDirectoryRecursive(string sourceDirectory, string fileExtension)
        {
            Collection<string> fileList = new Collection<string>();

            ProcessRecurDir(ref fileList, sourceDirectory, fileExtension, true);
            return fileList;
        }

        /// <summary> Scans the directories in this collection. </summary>
        /// <param name="path">   Full pathname of the file. </param>
        /// <param name="filter"> Specifies the filter. </param>
        /// <returns> An enumerator that allows foreach to be used to process the directories in this collection. </returns>
        public static IEnumerable<string> ScanDirectory(string path, string filter)
        {
            foreach (string file in Directory.EnumerateFiles(path, filter, SearchOption.AllDirectories).AsParallel())
            {
                yield return file;
            }
        }

        /// <summary> Scans the files in this collection. </summary>
        /// <param name="path">   Full pathname of the file. </param>
        /// <param name="filter"> Specifies the filter. </param>
        /// <returns> An enumerator that allows foreach to be used to process the files in this collection. </returns>
        public static IEnumerable<string> ScanFiles(string path, string filter)
        {
            var pending = new Queue<string>();
            pending.Enqueue(path);
            string[] tmp;
            while (pending.Count > 0)
            {
                path = pending.Dequeue();
                try
                {
                    tmp = Directory.GetFiles(path, filter);
                }
                catch (Exception)
                {
                    continue;
                }

                for (int i = 0; i < tmp.Length; i++)
                {
                    yield return tmp[i];
                }

                tmp = Directory.GetDirectories(path);
                for (int i = 0; i < tmp.Length; i++)
                {
                    pending.Enqueue(tmp[i]);
                }
            }
        }
        #endregion

        #region [Private methods]

        /// <summary> Process the recur dir. </summary>
        /// <param name="fileList">        [in,out] List of files. </param>
        /// <param name="sourceDirectory"> Pathname of the source directory. </param>
        /// <param name="fileExtension">   The file extension. </param>
        /// <param name="isRecursive">     true if this object is recursive. </param>
        /// <returns> A Collection&lt;string&gt; </returns>
        private static Collection<string> ProcessRecurDir(ref Collection<string> fileList, string sourceDirectory, string fileExtension, bool isRecursive)
        {
            DirectoryInfo rootDirectory = new DirectoryInfo(sourceDirectory);
            foreach (string filter in fileExtension.Split(';'))
            {
                foreach (FileInfo file in rootDirectory.GetFiles(filter))
                {
                    fileList.Add(file.FullName);
                }
            }

            if (isRecursive)
            {
                foreach (DirectoryInfo subdir in rootDirectory.GetDirectories())
                {
                    if ((subdir.Attributes & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                        ProcessRecurDir(ref fileList, subdir.FullName, fileExtension, isRecursive);
                }
            }

            return fileList;
        }
        #endregion
    }
}
