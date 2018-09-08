using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.ResourceHacker
{
    /// <summary>
    /// Contains functionality for working with Resource Hacker commands.
    /// </summary>
    [CakeAliasCategory("File Manipulation")]
    public static partial class ResourceHackerAliases
    {
        /// <summary>
        /// Add command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void ResourceHackerAdd(this ICakeContext context, ResourceHackerSettings settings)
        {
            InvokeCommand(context, "add", settings);
        }
        /// <summary>
        /// AddOverwrite command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void ResourceHackerAddOverwrite(this ICakeContext context, ResourceHackerSettings settings)
        {
            InvokeCommand(context, "addoverwrite", settings);
        }
        /// <summary>
        /// AddSkip command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void ResourceHackerAddSkip(this ICakeContext context, ResourceHackerSettings settings)
        {
            InvokeCommand(context, "addskip", settings);
        }
        /// <summary>
        /// Compile command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void ResourceHackerCompile(this ICakeContext context, ResourceHackerSettings settings)
        {
            InvokeCommand(context, "compile", settings);
        }
        /// <summary>
        /// Delete command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void ResourceHackerDelete(this ICakeContext context, ResourceHackerSettings settings)
        {
            InvokeCommand(context, "delete", settings);
        }
        /// <summary>
        /// Extract command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void ResourceHackerExtract(this ICakeContext context, ResourceHackerSettings settings)
        {
            InvokeCommand(context, "extract", settings);
        }
        /// <summary>
        /// Modify command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void ResourceHackerModify(this ICakeContext context, ResourceHackerSettings settings)
        {
            InvokeCommand(context, "modify", settings);
        }
        /// <summary>
        /// ChangeLanguage command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="languageId">LangId argument.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void ResourceHackerChangeLanguage(this ICakeContext context, string languageId, ResourceHackerSettings settings)
        {
            if (string.IsNullOrEmpty(languageId))
            {
                throw new ArgumentNullException(nameof(languageId));
            }
            InvokeCommand(context, $"changelanguage({languageId})", settings);
        }
        static void InvokeCommand(ICakeContext context, string command, ResourceHackerSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var runner = new ResourceHackerTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(command, settings);
        }
    }
}
