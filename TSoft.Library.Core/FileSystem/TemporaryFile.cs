// <copyright file="TemporaryFile.cs" company="Tavares Software Developement">
// Copyright (c) 2019 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>04.03.2019</date>
// <summary>Implements the temporary file class</summary>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TSoft.Library.Core.FileSystem
{
    /// <summary> A temporary file. </summary>
    public class TemporaryFile
    {
        #region [Constructors]
        /// <summary> Initializes a new instance of the TSoft.Library.Core.FileSystem.TemporaryFile class. </summary>
        public TemporaryFile()
            : this(Path.GetTempPath())
        {
        }

        /// <summary> Initializes a new instance of the TSoft.Library.Core.FileSystem.TemporaryFile class. </summary>
        /// <param name="directory"> Pathname of the directory. </param>
        public TemporaryFile(string directory)
        {
            Create(Path.Combine(directory, Path.GetRandomFileName()));
        }

        /// <summary> Initializes a new instance of the TSoft.Library.Core.FileSystem.TemporaryFile class. </summary>
        /// <param name="directory"> Pathname of the directory. </param>
        /// <param name="filename">  Filename of the file. </param>
        public TemporaryFile(string directory, string filename)
        {
            Create(Path.Combine(directory, filename));
        }
        #endregion

        #region [Destructors]
        /// <summary> Finalizes an instance of the TSoft.Library.Core.FileSystem.TemporaryFile class. </summary>
        ~TemporaryFile()
        {
            Delete();
        }
        #endregion

        #region [Public properties]
        /// <summary> Gets the full pathname of the file. </summary>
        /// <value> The full pathname of the file. </value>
        public string FilePath { get; private set; }
        #endregion

        #region [Public methods]
        /// <summary> Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. </summary>
        public void Dispose()
        {
            Delete();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region [Private methods]
        /// <summary> Creates this TemporaryFile. </summary>
        /// <param name="path"> Full pathname of the file. </param>
        private void Create(string path)
        {
            FilePath = path;
            using (File.Create(FilePath)) { }
        }

        /// <summary> Deletes this TemporaryFile. </summary>
        private void Delete()
        {
            File.Delete(FilePath);
            FilePath = null;
        }
        #endregion
    }
}