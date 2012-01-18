﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using Microsoft.Win32;

namespace cacheCopy
{
    static class Util
    {

        /// <summary>
        /// Get list of all the files in the directory. 
        /// This scans all the files inside of the sub-dirs
        /// </summary>
        /// <param name="directory">string with directory path</param>
        /// <returns>List with FileInfo</returns>
        public static List<FileInfo> WalkDirectory(string directory)
        {
            return WalkDirectory(new DirectoryInfo(directory));
        }



        /// <summary>
        /// Get list of all the files in the directory. 
        /// This scans all the files inside of the subdirs
        /// </summary>
        /// <param name="directory">DirectoryInfo to scan</param>
        /// <returns>List with FileInfo</returns>
        public static List<FileInfo> WalkDirectory(DirectoryInfo directory)
        {
            if (!Directory.Exists(directory.FullName))
            {
                return new List<FileInfo>();   
            }
            List<FileInfo> files = new List<FileInfo>();
            // Scan all files in the current path
            foreach (FileInfo file in directory.GetFiles())
            {
                files.Add(file);
            }

            DirectoryInfo[] subDirectories = directory.GetDirectories();

            // Scan the directories in the current directory and call this method 
            // again to go one level into the directory tree
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                files.AddRange(WalkDirectory(subDirectory));
            }

            return files;
        }


        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }


        /// <summary>
        /// Reads the key from win registry
        /// </summary>
        /// <param name="KeyName">Name of the key.</param>
        /// <param name="valueName">Name of the value.</param>
        /// <returns></returns>
        public static string ReadRegistryKey(string KeyName, string valueName)
        {
            string value;
            try
            {
                value = (String)Registry.GetValue(KeyName, valueName, "");
            }
            catch (Exception)
            {
                return "";
            }
            return value;
        }




        /// <summary>
        /// Determines whether a value is present at the specified key name
        /// </summary>
        /// <param name="KeyName">Name of the key.</param>
        /// <param name="valueName">Name of the value.</param>
        /// <returns>
        ///   <c>true</c> if value is present at the specified key name; otherwise, <c>false</c>.
        /// </returns>
        public static bool isRegistryValuePresent(string KeyName, string valueName)
        {
            string value = "";
            try
            {
                value = (String)Registry.GetValue(KeyName, valueName, "");
            }
            catch (Exception)
            {
                // if exception thrown, there is no value there
                return false;
            }

            if (value != "")
            {
                return true;
            }

            return false;
        }

    }


}
