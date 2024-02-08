using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;

namespace Cake.ResourceHacker
{
    /// <summary>
    /// Resource Hacker tool.
    /// </summary>
    public class ResourceHackerTool : Tool<ResourceHackerSettings>
    {
        readonly ICakeEnvironment environment;
        readonly IFileSystem fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceHackerTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        public ResourceHackerTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            this.fileSystem = fileSystem;
            this.environment = environment;
        }

        /// <summary>
        /// Runs given <paramref name="command"/> using given <paramref name="settings"/>.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="settings">The settings.</param>
        public void Run(string command, ResourceHackerSettings settings)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            Run(settings, GetArguments(command, settings ?? new ResourceHackerSettings()));
        }
        ProcessArgumentBuilder GetArguments(string command, ResourceHackerSettings settings)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(environment, command, settings);
            return builder;
        }
        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "Resource Hacker";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "ResourceHacker.exe", "ResourceHacker" };
        }
        /// <summary>
        /// Finds the proper Resource Hacker executable path.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>A single path to Resource Hacker executable.</returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(ResourceHackerSettings settings)
        {
            var path = ResourceHackerResolver.GetResourceHackerPath(fileSystem, environment);
            if (path != null)
            {
                return new FilePath[] { path };
            }
            else
            {
                return new FilePath[0];
            }
        }
    }
}
