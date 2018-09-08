using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.ResourceHacker
{
    /// <summary>
    /// Resource hacker settings.
    /// </summary>
    public class ResourceHackerSettings : ToolSettings
    {
        /// <summary>
        /// filename - the name of the file that is to be modified. It should be a Windows PE file (*.exe, *.dll etc) or a compiled or uncompiled resouce file (*.res or *.rc)
        /// </summary>
        public FilePath Open { get; set; }
        /// <summary>
        /// usually a filename for the new or modified file, but can also be a folder when extracting multiple resources
        /// </summary>
        public FilePath Save { get; set; }
        /// <summary>
        /// Filename or CONSOLE or NUL
        /// CONSOLE can be abbreviated to CON
        /// Logs the details of the operation performed
        /// If this switch is omitted, the log will be written to resourcehacker.log
        /// </summary>
        public FilePath Log { get; set; }
        /// <summary>
        /// filename - contains a resource being added to the opened file.
        /// </summary>
        public FilePath Resource { get; set; }
        /// <summary>
        /// filename - contains a multi-command script, NOT a resource script for more info: -help script
        /// </summary>
        public FilePath Script { get; set; }
        /// <summary>
        /// resource mask - Type,Name,Language
        /// commas are mandatory but each of Type, Name & Language are optional
        /// </summary>
        public Mask? Mask { get; set; }
    }
}
