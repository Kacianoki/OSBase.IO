namespace OSBase.IO.Exceptions;

    public class FileDoesNotExistException : Exception
    {
    public FileDoesNotExistException(string path) : base($"The file \"{path}\" does not exist") { }
}

