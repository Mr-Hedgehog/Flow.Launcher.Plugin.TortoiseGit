using Flow.Launcher.Plugin.TortoiseGit.Models;
using System.Diagnostics;

namespace Flow.Launcher.Plugin.TortoiseGit.Commands.Windows;

/// <summary>
/// Executes the command to open a command prompt for a Git repository.
/// </summary>
internal class CmdCommand : ICommand
{
    public void Execute(GitRepositoryInfo gitRepositoryInfo)
    {
        Process.Start("wt", $"-w 1 -d \"{gitRepositoryInfo.FullPath}\" --title \"{gitRepositoryInfo.Title}\"");
    }
}
