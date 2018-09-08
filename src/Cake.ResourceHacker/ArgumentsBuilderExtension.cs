using Cake.Core.IO;
using System;
using Cake.Core;

namespace Cake.ResourceHacker
{
    /// <summary>
    /// Arguments builder
    /// </summary>
    public static class ArgumentsBuilderExtension
    {
        /// <summary>
        /// Appends all arguments from <paramref name="settings"/> and <paramref name="arguments"/>.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="command"></param>
        /// <param name="settings">The settings.</param>
        /// <param name="arguments"></param>
        public static void AppendAll(this ProcessArgumentBuilder builder, ICakeEnvironment cakeEnvironment, string command, ResourceHackerSettings settings)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }
            if (settings == null)
            {
                settings = new ResourceHackerSettings();
            }
            builder.Append($"-{command}");
            AppendArguments(builder, cakeEnvironment, settings);
        }
        /// <summary>
        /// Appends pre or post command arguments.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="builder"></param>
        /// <param name="settings"></param>
        /// <param name="preCommand"></param>
        public static void AppendArguments(ProcessArgumentBuilder builder, ICakeEnvironment cakeEnvironment, ResourceHackerSettings settings)
        {
            AppendFilePathIfNotNull(builder, cakeEnvironment, "open", settings.Open);
            AppendFilePathIfNotNull(builder, cakeEnvironment, "save", settings.Save);
            AppendFilePathIfNotNull(builder, cakeEnvironment, "log", settings.Log);
            AppendFilePathIfNotNull(builder, cakeEnvironment, "resource", settings.Resource);
            AppendFilePathIfNotNull(builder, cakeEnvironment, "script", settings.Script);
            if (settings.Mask.HasValue)
            {
                var mask = settings.Mask.Value;
                builder.Append($"-mask {mask.Type},{mask.Name},{mask.Language}");
            }
        }

        static void AppendFilePathIfNotNull(ProcessArgumentBuilder builder, ICakeEnvironment cakeEnvironment, string name, FilePath path)
        {
            if (path != null)
            {
                builder.Append($"-{name} \"{path.MakeAbsolute(cakeEnvironment)}\"");
            }
        }
    }
}
