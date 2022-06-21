using Flow.Launcher.Plugin.TortoiseGit.Models;
using System.Diagnostics;

namespace Flow.Launcher.Plugin.TortoiseGit.Commands
{
    internal class CmdCommand : ICommand
    {
        public void Execute(GitRepositoryInfo gitRepositoryInfo)
        {
            Process.Start("wt", $"-w 1 -d \"{gitRepositoryInfo.FullPath}\" --title \"{gitRepositoryInfo.Title}\"");
        }
    }
}
