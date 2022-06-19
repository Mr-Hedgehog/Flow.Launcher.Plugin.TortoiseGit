using Flow.Launcher.Plugin.TortoiseGit.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Flow.Launcher.Plugin.TortoiseGit.Views
{
    public partial class GitRepositoryEditor : Window
    {
        private GitRepositoryPathSetting currentRepositoryPath;

        public GitRepositoryEditor(GitRepositoryPathSetting repositoryPath)
        {
            InitializeComponent();
            currentRepositoryPath = repositoryPath;
            DataContext = new GitRepositoryPathSetting
            {
                Name = repositoryPath.Name,
                Path = repositoryPath.Path
            };
        }

        private void ConfirmCancelEdit(object sender, RoutedEventArgs e)
        {
            if (DataContext is GitRepositoryPathSetting editBrowser && e.Source is Button button)
            {
                if (button.Name == "btnConfirm")
                {
                    currentRepositoryPath.Name = editBrowser.Name;
                    currentRepositoryPath.Path = editBrowser.Path;
                    Close();
                }
            }

            Close();
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmCancelEdit(sender, e);
            }
        }
    }
}
