using Cake.Core;
using Cake.Core.IO;
using System;

namespace Cake.ResourceHacker
{
    /// <summary>
    /// ResourceHacker tool resolver.
    /// </summary>
    public class ResourceHackerResolver
    {
        /// <summary>
        /// Returns the path of the ResourceHacker.exe.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <returns>The path of the latest ResourceHacker.exe</returns>
        /// <remarks>Throws if ResourceHacker isn't found.</remarks>
        public static FilePath GetResourceHackerPath(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException(nameof(fileSystem));
            }
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }
            var exe = new DirectoryPath(Environment.GetEnvironmentVariable("ProgramFiles(x86)"))
                .Combine("Resource Hacker")
                .CombineWithFilePath("ResourceHacker.exe");
            Console.WriteLine($"program files: {exe}");
            return exe;
        }
    }
}
