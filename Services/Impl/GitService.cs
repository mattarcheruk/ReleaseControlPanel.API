using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Services.Impl
{
    class GitService : IGitService
    {
        private string GitRoot
        {
            get
            {
                if (string.IsNullOrEmpty(_settings.GitRepositoriesPath))
                {
                    _logger.LogCritical("Config error: 'App.GitRepositoriesPath' must be set to correct name of directory!");
                }
                return Path.Combine(Directory.GetCurrentDirectory(), _settings.GitRepositoriesPath);
            }
        }

        private readonly ILogger _logger;
        private readonly AppSettings _settings;

        public GitService(ILogger<GitService> logger, IOptions<AppSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        private void CloneProject(ProjectSettings project)
        {
            var projectPath = GetProjectPath(project);

            _logger.LogTrace($"Cloning project '{project.Name}' into '{projectPath}'.");

            var gitCloneStartInfo = new ProcessStartInfo("git", $"clone {project.GitUrl} {project.Name}")
            {
                WorkingDirectory = GitRoot
            };

            var gitCloneProcess = Process.Start(gitCloneStartInfo);
            gitCloneProcess.WaitForExit();
        }

        public void EnsureProjectsCloned()
        {
            if (_settings.Projects == null || _settings.Projects.Length == 0)
            {
                _logger.LogWarning("Config: 'App.Projects' is empty. The tool requies some projects to be defined!");
                return;
            }

            if (!Directory.Exists(GitRoot))
            {
                _logger.LogTrace($"'GitRoot' directory doesn't exist. Creating it: {GitRoot}");
                Directory.CreateDirectory(GitRoot);
            }

            _logger.LogTrace("Checking if projects are pulled from git");
            
            foreach (var project in _settings.Projects)
            {
                if (Directory.Exists(GetProjectPath(project)))
                {
                    _logger.LogTrace($"Project '{project.Name}' is already cloned.");
                    continue;
                }

                CloneProject(project);
            }
        }

        private string GetProjectPath(ProjectSettings project)
        {
            return Path.Combine(GitRoot, project.Name);
        }
    }
}
