using System;
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
        /// Finds the registry key in a registry folder
        /// </summary>
        /// <param name="folder">The folder to search in</param>
        /// <param name="StartsWith">The search criteria - key must start with this value</param>
        /// <returns> Full key name if found, empty string if nothing found</returns>
        public static string FindRegistryKey(RegistryKey regFolder, String StartsWith)
        {
            if (null == regFolder)
                return "";

            var subKeys = regFolder.GetSubKeyNames();
            String key = subKeys.Where(k => k.StartsWith(StartsWith)).FirstOrDefault();

            if (null != key && key != string.Empty)
            {
                return regFolder.Name + @"\" + key;
            }
            else
            {
                return "";
            }
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


        /// <summary>
        /// Writes exception information to log file.
        /// </summary>
        /// <param name="e">The e.</param>
        public static void WriteToLogFile(Exception e)
        {
            StreamWriter sw = new StreamWriter("Errors.txt", true);
            sw.WriteLine("################################################");
            sw.WriteLine();
            sw.WriteLine("Error occurred at #{0}", DateTime.Now.ToString());
            sw.WriteLine(e.ToString());
            sw.WriteLine();
            sw.Dispose();                
        }


        public delegate String StringProfileFinder(String s);


        /// <summary>
        /// With list of possible paths, we need to find first one that is not empty
        /// 
        /// Go through array of possible values, apply passed in function and check if the 
        /// result of the function is not empty - return it.
        /// 
        /// If no result returned by any possible values, return empty string
        /// </summary>
        /// <param name="possiblePaths">The possible paths.</param>
        /// <param name="function">The function to apply to the possible path</param>
        /// <returns>first non-empty result or empty string if no value found</returns>
        public static string GetExistingPathByString(String[] possiblePaths, StringProfileFinder function)
        {
            foreach (string path in possiblePaths)
            {
                if (function(path) != null)
                    return path;
            }
            return String.Empty;
        }

        
        public delegate Boolean BooleanProfileFinder(String s);


        /// <summary>
        /// With list of possible paths, we need to find first one that is not empty
        /// 
        /// Go through array of possible values, apply passed in function and check if the 
        /// result of the function is not empty - return it.
        /// 
        /// If no result returned by any possible values, return empty string
        /// </summary>
        /// <param name="possiblePaths">The possible paths.</param>
        /// <param name="function">The function to apply to the possible path</param>
        /// <returns>first non-empty result or empty string if no value found</returns>
        public static string GetExistingPathByBoolean(String[] possiblePaths, BooleanProfileFinder function)
        {
            foreach (string path in possiblePaths)
            {
                if (function(path))
                    return path;
            }
            return String.Empty;
        }
    }


}
