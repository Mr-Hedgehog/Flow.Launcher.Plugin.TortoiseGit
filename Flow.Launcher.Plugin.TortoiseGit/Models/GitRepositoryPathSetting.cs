
namespace Flow.Launcher.Plugin.TortoiseGit.Models
{
    public class GitRepositoryPathSetting : BaseModel
    {
        private string name;
        private string path;

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
}
