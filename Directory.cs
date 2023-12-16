namespace OSBase.IO;
public class Directory
{
    public static string[] GetFiles(string path) => (from file in System.IO.Directory.GetFiles(path) where !file.EndsWith(".kfp") select file).ToArray();
    public static string[] GetFiles(string path, string searchPattern) => (from file in System.IO.Directory.GetFiles(path, searchPattern) where !file.EndsWith(".kfp") where !file.EndsWith(".kdp") select file).ToArray();
    public static string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions) => (from file in System.IO.Directory.GetFiles(path, searchPattern, enumerationOptions) where !file.EndsWith(".kfp") where !file.EndsWith(".kdp") select file).ToArray();
    public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption) => (from file in System.IO.Directory.GetFiles(path, searchPattern, searchOption) where !file.EndsWith(".kfp") where !file.EndsWith(".kdp") select file).ToArray();
    /// <summary>
    /// Создаст директорию и файл .kdp
    /// </summary>
    /// <param name="path">Путь к новой директории</param>
    /// <param name="rights">По умолчанию все праметры прав будут равны Permision.Program</param>
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

}

