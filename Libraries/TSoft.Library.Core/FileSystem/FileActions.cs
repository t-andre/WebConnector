// <copyright file="FileActions.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the file actions class</summary>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace TSoft.Library.Core.FileSystem
{
    /// <summary> File actions. </summary>
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class FileActions
    {
        #region [Constructors]

        /// <summary> Initializes a new instance of the FileActions class. </summary>
        internal FileActions()
        {
        }

        #endregion

        #region [Public Methods]

        /// <summary> Queries if a given file or directory exists. </summary>
        /// <param name="name"> The name. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public static bool FileOrDirectoryExists(string name)
        {
            return Directory.Exists(name) || File.Exists(name);
        }

        /// <summary> Gets filey information. </summary>
        /// <param name="file"> The file. </param>
        /// <returns> The filey information. </returns>
        public static FileInfo GetFileyInfo(string @file)
        {
            return new FileInfo(Path.GetFullPath(@file));
        }

        /// <summary> Gets random file name. </summary>
        /// <param name="fileExtension"> The file extension. </param>
        /// <returns> The random file name. </returns>
        public static string GetRandomFileName(string fileExtension)
        {
            return !string.IsNullOrEmpty(fileExtension)
                ? Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + fileExtension
                : Path.GetRandomFileName();
        }

        /// <summary> Gets random file name. </summary>
        /// <returns> The random file name. </returns>
        public static string GetRandomFileName()
        {
            return Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        }

        /// <summary> Makes valid file name. </summary>
        /// <param name="name">        The name. </param>
        /// <param name="replaceChar"> The replace character. </param>
        /// <returns> A string. </returns>
        public static string MakeValidFileName(string name, string replaceChar)
        {
            if (Path.GetInvalidPathChars().Length > 0)
            {
                string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
                string invalidReStr = string.Format(CultureInfo.CurrentCulture, @"[{0}]", invalidChars);
                return Regex.Replace(name, invalidReStr, replaceChar);
            }
            else
            {
                return name;
            }
        }

        /// <summary> Sanitize path. </summary>
        /// <param name="path">         Full pathname of the file. </param>
        /// <param name="replaceValue"> The replace value. </param>
        /// <returns> A string. </returns>
        public static string SanitizePath(string path, char replaceValue)
        {
            int filenamePos = path.LastIndexOf(Path.DirectorySeparatorChar) + 1;
            var sb = new System.Text.StringBuilder();
            sb.Append(path, 0, filenamePos);
            for (int i = filenamePos; i < path.Length; i++)
            {
                char filenameChar = path[i];
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    if (filenameChar.Equals(c))
                    {
                        filenameChar = replaceValue;
                        break;
                    }
                }
                sb.Append(filenameChar);
            }
            return sb.ToString();
        }

        /// <summary> Sanitize path. </summary>
        /// <param name="name"> The name. </param>
        /// <returns> A string. </returns>
        public static string SanitizePath(string name)
        {
            return SanitizePath(name, '_');
        }

        /// <summary> Query if 'file' is file locked. </summary>
        /// <param name="file"> The file. </param>
        /// <returns> true if file locked, false if not. </returns>
        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                stream?.Close();
            }

            //file is not locked
            return false;
        }

        #endregion

    }
}
