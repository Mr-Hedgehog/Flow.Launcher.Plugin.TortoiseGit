using Flow.Launcher.Plugin.TortoiseGit.Models;
using System.Diagnostics;

namespace Flow.Launcher.Plugin.TortoiseGit.Commands
{
    internal class OpenCommand : ICommand
    {
        public void Execute(GitRepositoryInfo gitRepositoryInfo)
        {
            Process.Start("explorer.exe", gitRepositoryInfo.FullPath);
        }
    }
}
