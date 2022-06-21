using Flow.Launcher.Plugin.TortoiseGit.Commands;
using Flow.Launcher.Plugin.TortoiseGit.Commands.TortoiseGit;
using Flow.Launcher.Plugin.TortoiseGit.Models;
using Flow.Launcher.Plugin.TortoiseGit.Views;
using System.Collections.Generic;
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
                    IcoPath = Path.Combine("Images", "icon.png"),
                    Action = (context) => GetAction(repository, query),
                };

            return results.ToList();
        }

        public Control CreateSettingPanel()
        {
            return new SettingsControl(settings);
        }

        private IEnumerable<GitRepositoryInfo> GetReposNames()
        {
            var directories = settings.GitRepositoryPathSettings
                ?.Where(x => Directory.Exists(x.Path))
                .SelectMany(x => Directory.GetDirectories(x.Path, "*", SearchOption.TopDirectoryOnly));
            return directories
                .Select(x => new GitRepositoryInfo
                {
                    Title = new DirectoryInfo(x).Name,
                    FullPath = new DirectoryInfo(x).FullName,
                })
                .Where(x => !x.Title.StartsWith("."))
                .ToArray();
        }

        private static bool GetAction(GitRepositoryInfo repository, Query query)
        {
            var command = GetCommand(query.Search.Split(' ').FirstOrDefault()?.ToLowerInvariant());

            if(command == null)
            {
                return false;
            }

            command.Execute(repository);
            return true;
        }

        private static ICommand GetCommand(string commandName)
        {
            switch (commandName)
            {
                case "log":
                    return new LogCommand();

                case "cmd":
                    return new CmdCommand();

                case "open":
                default:
                    return new OpenCommand();
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
    }
}