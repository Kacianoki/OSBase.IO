namespace OSBase.IO.Rights;
public class RightsFileForFiles : RightFile
{
    public string path;
    public User.Permision CanView;
    public User.Permision CanDelete;
    public User.Permision CanEdit;
    public RightsFileForFiles(string path, User.Permision CanView, User.Permision CanDelete, User.Permision CanEdit)
    {
        this.path = path;
        this.CanView = CanView; 
        this.CanDelete = CanDelete;
        this.CanEdit = CanEdit;
    }
    protected RightsFileForFiles() { }
}
public class RightsFileForDirectories : RightFile
{
    public string path;
    public User.Permision CanView;
    public User.Permision CanDelete;
    public User.Permision CanEdit;
    public RightsFileForDirectories(string path, User.Permision CanView, User.Permision CanDelete, User.Permision CanEdit)
    {
        this.path = path;
        this.CanView = CanView;
        this.CanDelete = CanDelete;
        this.CanEdit = CanEdit;
    }
    protected RightsFileForDirectories() { }
}
public class RightFile
{
    public string path = string.Empty;
    public User.Permision CanView = User.Permision.None;
    public User.Permision CanDelete = User.Permision.None;
    public User.Permision CanEdit = User.Permision.None;
    public RightFile(string path, User.Permision CanView, User.Permision CanDelete, User.Permision CanEdit)
    {
        this.path = path;
        this.CanView = CanView;
        this.CanDelete = CanDelete;
        this.CanEdit = CanEdit;
    }
    protected RightFile() { }
}

