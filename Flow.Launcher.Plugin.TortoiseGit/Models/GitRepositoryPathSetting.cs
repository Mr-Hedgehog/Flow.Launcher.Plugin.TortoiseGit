
namespace Flow.Launcher.Plugin.TortoiseGit.Models;

/// <summary>
/// Represents a Git repository path setting
/// </summary>
public class GitRepositoryPathSetting : BaseModel
{
    private string name;
    private string path;

    /// <summary>
    /// Gets or sets the name of the Git repository
    /// </summary>
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    /// <summary>
    /// Gets or sets the path to the Git repository.
    /// </summary>
    public string Path
    {
        get
        {
            return path;
        }

        set
        {
            path = value;
            OnPropertyChanged(nameof(Path));
        }
    }
}
