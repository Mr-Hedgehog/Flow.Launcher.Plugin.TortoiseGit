using Flow.Launcher.Plugin.TortoiseGit.Models;
using System.Diagnostics;

namespace Flow.Launcher.Plugin.TortoiseGit.Commands.TortoiseGit;

/// <summary>
/// Executes the command to view the commit history of a Git repository.
/// </summary>
internal class LogCommand : ICommand
{
    public void Execute(GitRepositoryInfo gitRepositoryInfo)
    {
        Process.Start("TortoiseGitProc.exe", $"/command:log /path:{gitRepositoryInfo.FullPath}");
    }
}
