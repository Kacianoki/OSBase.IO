namespace OSBase.IO.Rights.Exceptions;

    public class WrongFile : Exception
    {
    public WrongFile() : base("Files like \".kfp\" and \".kdp\" cannot be used in the game.") { }
    }

