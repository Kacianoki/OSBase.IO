namespace OSBase.IO;
public class Directory
{
    public static string[] GetFiles(string path) => (from file in System.IO.Directory.GetFiles(path) where !file.EndsWith(".kfp") select file).ToArray();
    public static string[] GetFiles(string path, string searchPattern) => (from file in System.IO.Directory.GetFiles(path, searchPattern) where !file.EndsWith(".kfp") where !file.EndsWith(".kdp") select file).ToArray();
    public static string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions) => (from file in System.IO.Directory.GetFiles(path, searchPattern, enumerationOptions) where !file.EndsWith(".kfp") where !file.EndsWith(".kdp") select file).ToArray();
    public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption) => (from file in System.IO.Directory.GetFiles(path, searchPattern, searchOption) where !file.EndsWith(".kfp") where !file.EndsWith(".kdp") select file).ToArray();
    /// <summary>
    /// Creates a directory and a .kdp file
    /// </summary>
    /// <param name="path">Path to the new directory</param>
    /// <param name="rights">By default, all rights prameters will be equal to Permision.Programme</param>
    public static void CreateDirectory(string path, Rights.RightsFileForDirectories? rights = null)
    {
        if (rights is null) rights = new Rights.RightsFileForDirectories(path, User.Permision.Program, User.Permision.Program, User.Permision.Program);
        if(new DirectoryInfo(path).Parent is not null) if(!new DirectoryInfo(path).Parent.Exists)
        {
                List<DirectoryInfo> tocreate = new List<DirectoryInfo>();
                DirectoryInfo info = new DirectoryInfo(path);
                while (true)
                {
                    if (info.Parent is not null) if (!info.Parent.Exists)
                        {
                            tocreate.Add(info);
                            info = info.Parent;
                        }
                        else break;
                }
                foreach (var s in tocreate)
                {
                    System.IO.Directory.CreateDirectory(s.FullName);
                    System.IO.File.WriteAllText(s.FullName + ".kdp", Newtonsoft.Json.JsonConvert.SerializeObject(rights));
                }
            }
        System.IO.Directory.CreateDirectory(path);
        System.IO.File.WriteAllText(path + ".kdp", Newtonsoft.Json.JsonConvert.SerializeObject(rights));
    }
    public static void CreateDirectory(string path, User.Permision CanView = User.Permision.Program, User.Permision CanDelete = User.Permision.Program, User.Permision CanEdit = User.Permision.Program)
    {
        var rights = new Rights.RightsFileForDirectories(path, CanView, CanDelete, CanEdit);
        if (new DirectoryInfo(path).Parent is not null) if (!new DirectoryInfo(path).Parent.Exists)
            {
                List<DirectoryInfo> tocreate = new List<DirectoryInfo>();
                DirectoryInfo info = new DirectoryInfo(path);
                while (true)
                {
                    if (info.Parent is not null) if (!info.Parent.Exists)
                        {
                            tocreate.Add(info);
                            info = info.Parent;
                        }
                        else break;
                }
                foreach (var s in tocreate)
                {
                    System.IO.Directory.CreateDirectory(s.FullName);
                    System.IO.File.WriteAllText(s.FullName + ".kdp", Newtonsoft.Json.JsonConvert.SerializeObject(rights));
                }
            }
        System.IO.Directory.CreateDirectory(path);
        System.IO.File.WriteAllText(path + ".kdp", Newtonsoft.Json.JsonConvert.SerializeObject(rights));
    }
    public static bool Exists(string path) => System.IO.File.Exists(path + ".kdp") && System.IO.Directory.Exists(path);
    public static void Delete(string path, bool recursive)
    {
        if (!Exists(path)) throw new Exceptions.DirectoryDoesNotExistException(path);
        System.IO.Directory.Delete(path, recursive);
        System.IO.File.Delete(path + ".kdp");
    }
    public static void Delete(string path)
    {
        if (!Exists(path)) throw new Exceptions.DirectoryDoesNotExistException(path);
        System.IO.Directory.Delete(path);
        System.IO.File.Delete(path + ".kdp");
    }
}

