using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MiMFa_Framework.General
{
    public class MiMFa_Path
    {
        public static bool IsUsingByProccess(string fileName)
        {
            try { File.ReadAllBytes(fileName); return false; } catch { return true; }
        }
        public static string ReturnExistAddress(ref string CheckAddress, string ReplaceAddress = null)
        {
            if (File.Exists(CheckAddress)) return CheckAddress;
            else return CheckAddress = ReplaceAddress;
        }
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs=true)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public static void DeleteAllFilesInAllDirectoriesInPath(string DirectoryAddress)
        {
            if (Directory.Exists(DirectoryAddress))
            {
                string[] sa = Directory.GetFiles(DirectoryAddress);
                foreach (var item in sa)
                    try { File.Delete(item); } catch { }
                string[] sda = Directory.GetDirectories(DirectoryAddress);
                foreach (var item in sda)
                    DeleteAllFilesInAllDirectoriesInPath(item);
            }
        }
        public static void DeleteAllFilesInDirectory(string DirectoryAddress)
        {
            if (Directory.Exists(DirectoryAddress))
            {
                string[] sa = Directory.GetFiles(DirectoryAddress);
                foreach (var item in sa)
                    File.Delete(item);
            }
        }
        public static void DeleteAllDirectoriesInPath(string DirectoryAddress, bool deleteFiles = true)
        {
            if (Directory.Exists(DirectoryAddress))
            {
                string[] sa = Directory.GetDirectories(DirectoryAddress);
                foreach (var item in sa)
                    Directory.Delete(item, deleteFiles);
            }
        }
        public static void DeleteAllDirectories(bool deleteFiles = true,params string[] DirectoryAddresses)
        {
            foreach (var item in DirectoryAddresses)
                DeleteDirectory(item, deleteFiles);
        }
        public static void DeleteDirectory(string DirectoryAddress, bool deleteFiles = true)
        {
                    Directory.Delete(DirectoryAddress, deleteFiles);
        }
        public static void DeleteAllFilesInAllDirectories(params string[] DirectoryAddresses)
        {
            foreach (var item in DirectoryAddresses)
                 DeleteFiles(Directory.GetFiles(item));
        }
        public static void DeleteFile(string FileAddress)
        {
            if (File.Exists(FileAddress))
                File.Delete(FileAddress);
        }
        public static void DeleteFiles(params string[] FileAddress)
        {
            foreach (var item in FileAddress)
                DeleteFile(item);
        }
        public static void CreateDirectories(params string[] DirectoryAddresses)
        {
            foreach (var item in DirectoryAddresses)
                CreateDirectory(item);
        }
        public static void CreateFiles(params string[] FileAddress)
        {
            foreach (var item in FileAddress)
                CreateFile(item);
        }
        public static List<string> GetAllDirectories(string DirectoryAddress, bool reclcive = true)
        {
            List<string> result = new List<string>();
            if (Directory.Exists(DirectoryAddress))
            {
                var ll = Directory.GetDirectories(DirectoryAddress);
                if (!reclcive && ll.Length > 0) result.AddRange(ll);
                else if (ll.Length > 0)
                {
                    result.AddRange(ll);
                    if (ll.Length > 0)
                        foreach (var item in ll)
                            result.AddRange(GetAllDirectories(item, reclcive));
                }
            }
            return result;
        }
        public static List<string> GetAllFilesInAllDirectoriesInPath(string DirectoryAddress)
        {
           return GetAllFiles(DirectoryAddress,true);
        }
        public static List<string> GetAllFiles(string DirectoryAddress, bool reclcive = true, string extention = null)
        {
            List<string> result = new List<string>();
            if (Directory.Exists(DirectoryAddress))
            {
                if (!reclcive) result.AddRange(Directory.GetFiles(DirectoryAddress));
                else
                {
                    List<string> sa;
                    if (!string.IsNullOrEmpty(extention))
                        result.AddRange(from v in Directory.GetFiles(DirectoryAddress) where Path.GetExtension(v) == extention select v);
                    else
                        result.AddRange(Directory.GetFiles(DirectoryAddress));
                    sa = GetAllDirectories(DirectoryAddress,true).ToList();
                    if (sa != null && sa.Count > 0)
                        foreach (var item in sa)
                            result.AddRange(GetAllFiles(item,false,extention));
                }
            }
            return result;
        }
        public static List<string> GetAllFiles(string DirectoryAddress,Func<string,bool> func, bool reclcive = true)
        {
            List<string> result = new List<string>();
            if (Directory.Exists(DirectoryAddress))
            {
                if (!reclcive) result.AddRange(Directory.GetFiles(DirectoryAddress));
                else
                {
                    List<string> sa;
                    result.AddRange(from v in Directory.GetFiles(DirectoryAddress) where func(v) select v);
                    sa = GetAllDirectories(DirectoryAddress).ToList();
                    if (sa != null && sa.Count > 0)
                        foreach (var item in sa)
                            result.AddRange(GetAllFiles(item, func,reclcive));
                }
            }
            return result;
        }
        public static void CreateFile(string FileAddress)
        {
            if (!File.Exists(FileAddress))
            {
                File.Create(FileAddress);
            }
        }
        public static void CreateDirectory(string DirectoryAddress)
        {
            if (!Directory.Exists(DirectoryAddress))
            {
                Directory.CreateDirectory(DirectoryAddress);
            }
        }
        public static void CreateAllDirectories(string DirectoryAddress)
        {
            string[] stra = DirectoryAddress.Split('\\', '/');
            string str = "";
            if (stra.Length > 1) str += stra[0];
            for (int i = 1; i < stra.Length; i++)
                CreateDirectory(str += "\\" + stra[i]);
        }
        public static string CreateValidDirectoryName(string DirectoryAddress, string DirectoryName, bool withparentsis = false)
        {
            foreach (var item in Path.GetInvalidPathChars())
            DirectoryName = DirectoryName.Replace(item + "", "");
            string fn = DirectoryName;
            string address = DirectoryAddress + fn + "\\";
            int i = 1;
           if(withparentsis)
                while (Directory.Exists(address))
                {
                    fn = DirectoryName + "(" + i++ + ")";
                    address = DirectoryAddress + fn + "\\";
                }
           else
                while (Directory.Exists(address))
                {
                    fn = DirectoryName +  i++ ;
                    address = DirectoryAddress + fn + "\\";
                }
            return address;
        }
        public static string NormalizeForFileAndFolderName(string oldFileAndFolderName)
        {
            string[] signs = { "?","=","~", "!", "@", "#", "$", "%", "^", "&", "*", ":", ";", "'", "\"", "<", ">", "|" ,"/","\\"};
            foreach (var item in signs)
                oldFileAndFolderName = oldFileAndFolderName.Replace(item, "_");
            return oldFileAndFolderName;
        }
        public static string NormalizeForAddressPath(string oldAddress)
        {
            string[] signs = { "~", "!", "@", "#", "$", "%", "^", "&", "*", "-", ":", ";", "'", "\"", "<", ">", "|"};
            foreach (var item in signs)
               oldAddress=  oldAddress.Replace(item, "_");
            return oldAddress;
        }
        public static string PathCreator(string DirectoryAddress, string VariableFileName, string extension)
        {

            foreach (var item in Path.GetInvalidFileNameChars())
                VariableFileName = VariableFileName.Replace(item + "", "");
            string address = DirectoryAddress + VariableFileName + extension;
            int i = 1;
            while (File.Exists(address))
                address = DirectoryAddress + VariableFileName + "(" + i++ + ")" + extension;
            return address;
        }
        public static string CreateValidPathName(string DirectoryAddress, string VariableFileName, string extension, bool withparentsis = false)
        {
            string fn = VariableFileName;
            string address = DirectoryAddress + fn + extension;
            int i = 1;
            if (withparentsis)
                while (File.Exists(address))
                {
                    fn = VariableFileName + "(" + i++ + ")";
                    address = DirectoryAddress + fn + extension;
                }
            else
                while (File.Exists(address))
                {
                    fn = VariableFileName + i++;
                    address = DirectoryAddress + fn + extension;
                }
            return address;
        }
        public static Dictionary<string, string> GetPathRestoreList(string pathFileAddress, string defaultPathDirectory)
        {
            FileStream fs = new FileStream(pathFileAddress, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Dictionary<string, string> list = new Dictionary<string, string>();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                Dictionary<string, string> ls = new Dictionary<string, string>();
                try { ls = (Dictionary<string, string>)bf.Deserialize(fs); }
                catch { }
                fs.Close();
                foreach (var item in ls)
                    if (File.Exists(item.Key)) list.Add(item.Key, Path.GetFileNameWithoutExtension(item.Key));
                fs = new FileStream(pathFileAddress, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                bf = new BinaryFormatter();
                bf.Serialize(fs, list);
                fs.Close();
                string[] dpFiles = Directory.GetFiles(defaultPathDirectory);
                foreach (var item in dpFiles)
                    try { list.Add(item, Path.GetFileNameWithoutExtension(item)); }
                    catch { }

            }
            catch { return null; }
            finally { fs.Close(); }
            return list;
        }
        public static Dictionary<string, string> GetPathRestoreList(string pathFileAddress)
        {
            FileStream fs = new FileStream(pathFileAddress, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Dictionary<string, string> list = new Dictionary<string, string>();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                Dictionary<string, string> ls = new Dictionary<string, string>();
                try { ls = (Dictionary<string, string>)bf.Deserialize(fs); }
                catch { }
                fs.Close();
                foreach (var item in ls)
                    if (File.Exists(item.Key)) list.Add(item.Key, Path.GetFileNameWithoutExtension(item.Key));
                fs = new FileStream(pathFileAddress, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                bf = new BinaryFormatter();
                bf.Serialize(fs, list);
                fs.Close();
            }
            catch { return null; }
            finally { fs.Close(); }
            return list;
        }
        public static Dictionary<string, string> AddPathRestoreToList(string pathFileAddress, string newpath)
        {
            FileStream fs = new FileStream(pathFileAddress, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Dictionary<string, string> list = new Dictionary<string, string>();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                Dictionary<string, string> ls = new Dictionary<string, string>();
                try { ls = (Dictionary<string, string>)bf.Deserialize(fs); }
                catch { }
                fs.Close();
                try { list.Add(newpath, Path.GetFileNameWithoutExtension(newpath)); }
                catch { }
                foreach (var item in ls)
                    if (File.Exists(item.Key)) try { list.Add(item.Key, Path.GetFileNameWithoutExtension(item.Key)); }
                        catch { continue; }
                fs = new FileStream(pathFileAddress, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                bf = new BinaryFormatter();
                bf.Serialize(fs, list);
                fs.Close();
            }
            catch { return null; }
            finally { fs.Close(); }
            return list;
        }
        public static string GetFullPath(string path)
        {
           return Path.GetFullPath(path);
        }
        public static string GetDirectoryName(string path)
        {
           return Path.GetDirectoryName(path);
        }
        public static string GetFileName(string path)
        {
           return Path.GetFileName(path);
        }
        public static string GetFileNameWithoutExtension(string path)
        {
           return Path.GetFileNameWithoutExtension(path);
        }
    }
}
