using System.Collections.ObjectModel;

namespace Flow.Launcher.Plugin.TortoiseGit.Models;

/// <summary>
/// Represents the plugin settings
/// </summary>
public class Settings : BaseModel
{
    public ObservableCollection<GitRepositoryPathSetting> GitRepositoryPathSettings { get; set; }
}
