namespace OSBase.IO.Rights;

public class DirectoryInfo
{
    public RightsFileForDirectories DirectoryRight { get; }
    public System.IO.DirectoryInfo Directory { get; }

    public DirectoryInfo(RightsFileForDirectories directoryRight, System.IO.DirectoryInfo directory)
    {
        DirectoryRight = directoryRight;
        Directory = directory;
    }
    /// <summary>
    ///  информацию о директории по указанному пути.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    public static DirectoryInfo Get(string path)
    {
        var directory = new System.IO.DirectoryInfo(path);
        var right = Newtonsoft.Json.JsonConvert.DeserializeObject<RightsFileForDirectories>(System.IO.File.ReadAllText(directory.Parent.FullName + ".kdp"));
        return new DirectoryInfo(right, directory);
    }
    /// <summary>
    /// Попытка получить информацию о директории по указанному пути.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    /// <returns>Значение true, если удалось получить информацию о директории; в противном случае - false.</returns>
    /// <remarks>
    /// Этот метод будет пытаться получить информацию о директории по указанному пути.
    /// Если метод сможет получить информацию о директории, информация о директории будет возвращена в параметре directoryInfo.
    /// Если у метода не получится получить информацию о директории, параметр directoryInfo будет содержать значение null.
    /// </remarks>
    public static bool TryGet(string path, out DirectoryInfo? directoryInfo)
    {
        try
        {
            var directory = new System.IO.DirectoryInfo(path);
            var right = Newtonsoft.Json.JsonConvert.DeserializeObject<RightsFileForDirectories>(System.IO.File.ReadAllText(directory.Parent.FullName + ".kdp"));
            directoryInfo = new DirectoryInfo(right, directory);
            return true;
        }
        catch
        {
            directoryInfo = null;
            return false;
        }
    }
}

