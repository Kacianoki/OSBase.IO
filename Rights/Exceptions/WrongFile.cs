namespace OSBase.IO.Rights.Exceptions;

    public class WrongFileException : Exception
    {
    public WrongFileException() : base("Files like \".kfp\" and \".kdp\" cannot be used in the game.") { }
    }

