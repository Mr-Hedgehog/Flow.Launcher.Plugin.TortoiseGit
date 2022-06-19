using System.Collections.ObjectModel;

namespace Flow.Launcher.Plugin.TortoiseGit.Models
{
    public class Settings : BaseModel
    {
        public ObservableCollection<GitRepositoryPathSetting> GitRepositoryPathSettings { get; set; }
    }
}
