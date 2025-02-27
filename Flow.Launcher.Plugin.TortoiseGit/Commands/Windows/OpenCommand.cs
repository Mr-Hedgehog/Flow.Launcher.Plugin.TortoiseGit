using Flow.Launcher.Plugin.TortoiseGit.Models;
using System.Diagnostics;

namespace Flow.Launcher.Plugin.TortoiseGit.Commands.Windows;

/// <summary>
/// Executes the command to open the file explorer window for a Git repository.
/// </summary>
internal class OpenCommand : ICommand
{
    public void Execute(GitRepositoryInfo gitRepositoryInfo)
    {
        Process.Start("explorer.exe", gitRepositoryInfo.FullPath);
    }
}
