using Flow.Launcher.Plugin.TortoiseGit.Models;
using Flow.Launcher.Plugin.TortoiseGit.Views;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Flow.Launcher.Plugin.TortoiseGit
{
    public class TortoiseGit : ISettingProvider, IPlugin, IPluginI18n
    {
        private PluginInitContext context;
        private Settings settings;

        public void Init(PluginInitContext context)
        {
            this.context = context;
            this.settings = context.API.LoadSettingJsonStorage<Settings>();
        }

        public List<Result> Query(Query query)
        {
            var results =
                from repository in GetReposNames()
                where repository.Title.ToLower().Contains(query.SecondSearch.ToLower()) || repository.Title.ToLower().Contains(query.Search)
                select new Result
                {
                    Title = repository.Title,
                    SubTitle = $"Query: {query.Search}",
                    IcoPath = Path.Combine("Images", "icon.png"),
                    Action = (context) => GetAction(repository, query),
                };

            return results.ToList();
        }

        public Control CreateSettingPanel()
        {
            return new SettingsControl(settings);
        }

        private IEnumerable<GitRepoInfo> GetReposNames()
        {
            var directories = settings.GitRepositoryPathSettings
                ?.Where(x => Directory.Exists(x.Path))
                .SelectMany(x => Directory.GetDirectories(x.Path, "*", SearchOption.TopDirectoryOnly));
            return directories
                .Select(x => new GitRepoInfo
                {
                    Title = new DirectoryInfo(x).Name,
                    FullPath = new DirectoryInfo(x).FullName,
                })
                .Where(x => !x.Title.StartsWith("."))
                .ToArray();
        }

        private static bool GetAction(GitRepoInfo repository, Query query)
        {
            switch (query.Search.Split(' ').FirstOrDefault()?.ToLowerInvariant())
            {
                case "log":
                    Process.Start("TortoiseGitProc.exe", $"/command:log /path:{repository.FullPath}");
                    return true;

                case "cmd":
                    Process.Start("wt", $"-w 1 -d \"{repository.FullPath}\" --title \"{repository.Title}\"");
                    return true;

                case "open":
                default:
                    Process.Start("explorer.exe", repository.FullPath);
                    return true;
            }
        }

        public string GetTranslatedPluginTitle()
        {
            return context.API.GetTranslation("flowlauncher_plugin_tortoisegit_plugin_name");
        }

        public string GetTranslatedPluginDescription()
        {
            return context.API.GetTranslation("flowlauncher_plugin_tortoisegit_plugin_description");
        }

        private class GitRepoInfo
        {
            public string Title { get; set; }
            public string FullPath { get; set; }
        }
    }
}