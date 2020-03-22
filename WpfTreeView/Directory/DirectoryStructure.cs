
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfTreeView
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Get all logical Drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        { 
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive,
                Type = DirectoryItemType.Drive }).ToList();
            
        }

        /// <summary>
        /// Gets the directories top-level contents
        /// </summary>
        /// <param name="fullPath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            //Creae empty list
            var items = new List<DirectoryItem>();


            #region Get Folders

            //try and get directories from the folder
            //ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder}));
                }
            }
            catch { }


            #endregion

            #region Get Files

            //try and get directories from the folder
            //ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File}));
                }
            }
            catch { }

            #endregion

            return items;
        }


        #region Helpers
        /// <summary>
        /// Finds the file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            //make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');
            //finds the last back slash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');
            //if we dont find a back slash re turn the path itself
            if (lastIndex <= 0)
            {
                return path;
            }
            //return the name after the last back slash
            return path.Substring(lastIndex + 1);
        }

        #endregion
    }
}
