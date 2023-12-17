namespace OSBase.IO.Exceptions;

    public class DirectoryDoesNotExistException : Exception
    {
    public DirectoryDoesNotExistException(string path) : base($"The directory \"{path}\" does not exist") { }
    }

