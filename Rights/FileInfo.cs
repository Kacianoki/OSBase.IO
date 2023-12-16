namespace OSBase.IO.Rights;
public class FileInfo
{
    public RightsFileForFiles FileRight { get; }
    public System.IO.FileInfo File { get; }
    public FileInfo(RightsFileForFiles fileRight, System.IO.FileInfo file)
    {
        FileRight = fileRight;
        File = file;
    }
    /// <summary>
    /// Получение информации о файле по указанному пути.
    /// </summary>
    /// <param name="path">Путь к файлу.</param>
    /// <exception cref="Exceptions.WrongFile">Выбрасывается, если указанный путь к файлу будет вести к файлу сохранения.</exception>
    public static FileInfo Get(string path)
    {
        if (path.EndsWith(".kfp") || path.EndsWith(".kdp")) throw new Exceptions.WrongFile();
        var file = new System.IO.FileInfo(path);
        var right = Newtonsoft.Json.JsonConvert.DeserializeObject<RightsFileForFiles>(System.IO.File.ReadAllText(file.FullName + ".kfp"));
        return new FileInfo(right, file);
    }
    /// <summary>
    /// Попытка получить информацию о файле по указанному пути.
    /// </summary>
    /// <param name="path">Путь к файлу.</param>
    /// <returns>Значение true, если удалось получить информацию о файле; в противном случае - false.</returns>
    /// <remarks>
    /// Этот метод будет пытаться получить информацию о файле по указанному пути.
    /// Если метод сможет получить информацию о файле, информация о файле будет возвращена в параметре fileInfo.
    /// Если у метода не получится получить информацию о файле, параметр fileInfo будет содержать значение null.
    /// </remarks>
    public static bool TryGet(string path, out FileInfo? fileInfo)
    {
        try
        {
            if (path.EndsWith(".kfp") || path.EndsWith(".kdp")) throw new Exceptions.WrongFile();
            var file = new System.IO.FileInfo(path);
            var right = Newtonsoft.Json.JsonConvert.DeserializeObject<RightsFileForFiles>(System.IO.File.ReadAllText(file.FullName + ".kfp"));
            fileInfo = new FileInfo(right, file);
            return true;
        }
        catch
        {
            fileInfo = null;
            return false;
        }
    }
}

