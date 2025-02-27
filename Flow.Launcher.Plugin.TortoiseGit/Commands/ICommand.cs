using Flow.Launcher.Plugin.TortoiseGit.Models;

namespace Flow.Launcher.Plugin.TortoiseGit.Commands;

internal interface ICommand
{
    void Execute(GitRepositoryInfo gitRepositoryInfo);
}
