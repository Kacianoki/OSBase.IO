namespace OSBase.IO;
public class File
{
    /// <summary>
    /// Создаст файл и файл .kfp для него
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <param name="rights">По умолчанию все праметры прав будут равны Permision.Program</param>
    public static void Create(string path, Rights.RightsFileForFiles? rights = null)
    {
        if (rights is null) rights = new Rights.RightsFileForFiles(path, User.Permision.Program, User.Permision.Program, User.Permision.Program);
        System.IO.File.Create(path);
        System.IO.File.WriteAllText(path + ".kfp", Newtonsoft.Json.JsonConvert.SerializeObject(rights));

    }
}

