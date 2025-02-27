using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using Flow.Launcher.Plugin.TortoiseGit.Models;

namespace Flow.Launcher.Plugin.TortoiseGit.Views;

public partial class SettingsControl : INotifyPropertyChanged
{
    public Settings Settings { get; }
    public GitRepositoryPathSetting SelectedRepository { get; set; }
    public SettingsControl(Settings settings)
    {
        this.Settings = settings;
        InitializeComponent();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NewGitPath(object sender, RoutedEventArgs e)
    {
        var gitSettings = new GitRepositoryPathSetting();
        var window = new GitRepositoryEditor(gitSettings);
        window.ShowDialog();
        if (gitSettings is not
            {
                Name: null,
                Path: null
            })
        {
            Settings.GitRepositoryPathSettings.Add(gitSettings);
        }
    }

    private void DeleteGitPath(object sender, RoutedEventArgs e)
    {
        if (GitPaths.SelectedItem is GitRepositoryPathSetting selectedItem)
        {
            Settings.GitRepositoryPathSettings.Remove(selectedItem);
        }
    }

    private void MouseDoubleClickOnSelectedGitPath(object sender, MouseButtonEventArgs e)
    {
        if (SelectedRepository is null)
            return;

        var window = new GitRepositoryEditor(SelectedRepository);
        window.ShowDialog();
    }
}
