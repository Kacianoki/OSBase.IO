namespace OSBase.IO;
public class File
{
    /// <summary>
    /// Will create a file and a .kfp file for it
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="rights">By default, all rights prameters will be equal to Permision.Programme</param>
    public static void Create(string path, Rights.RightsFileForFiles? rights = null)
    {
        if (rights is null) rights = new Rights.RightsFileForFiles(path, User.Permision.Program, User.Permision.Program, User.Permision.Program);
        System.IO.File.Create(path).Close();
        System.IO.File.WriteAllText(path + ".kfp", Newtonsoft.Json.JsonConvert.SerializeObject(rights));

    }
    /// <summary>
    /// Will create a file and a .kfp file for it
    /// </summary>
    /// <param name="path">File path</param>
    public static void Create(string path, User.Permision CanView = User.Permision.Program, User.Permision CanDelete = User.Permision.Program, User.Permision CanEdit = User.Permision.Program)
    {
        var rights = new Rights.RightsFileForFiles(path, CanView, CanDelete, CanEdit);
        System.IO.File.Create(path).Close();
        System.IO.File.WriteAllText(path + ".kfp", Newtonsoft.Json.JsonConvert.SerializeObject(rights));

    }
    public static bool Exists(string path) => System.IO.File.Exists(path) && System.IO.File.Exists(path + ".kfp");
    public static void Delete(string path)
    {
        if (!Exists(path)) throw new Exceptions.FileDoesNotExistException(path);
        System.IO.File.Delete(path);
        System.IO.File.Delete(path + ".kfp");
    }
    public static string ReadAllText(string path)
    {
        if (!Exists(path)) throw new Exceptions.FileDoesNotExistException(path);
        return System.IO.File.ReadAllText(path);
    }
    public static string ReadAllText(string path, System.Text.Encoding encoding)
    {
        if (!Exists(path)) throw new Exceptions.FileDoesNotExistException(path);
        return System.IO.File.ReadAllText(path, encoding);
    }
    public static string[] ReadAllLines(string path, System.Text.Encoding encoding)
    {
        if (!Exists(path)) throw new Exceptions.FileDoesNotExistException(path);
        return System.IO.File.ReadAllLines(path, encoding);
    }
    public static string[] ReadAllLines(string path)
    {
        if (!Exists(path)) throw new Exceptions.FileDoesNotExistException(path);
        return System.IO.File.ReadAllLines(path);
    }

}

