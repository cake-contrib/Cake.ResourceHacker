using Cake.Core.IO;
using Cake.ResourceHacker.Tests.Apps.Create;
using NUnit.Framework;

namespace Cake.ResourceHacker.Tests
{
    [TestFixture]
    public class ResourceHacker
    {
        [TestFixture]
        public class ResourceHackerAdd: ResourceHacker
        {
            [Test]
            public void WhenSettingsAreEmpty_OnlyCommandIsUsed()
            {
                var fixture = new ResourceHackerFixture
                {
                    Settings = new ResourceHackerSettings()
                };

                var actual = fixture.Run();
                Assert.That(actual.Args, Is.EqualTo("-add"));
            }
            [Test]
            public void WhenOpenIsSet_CommandAndOpenIsUsed()
            {
                var fixture = new ResourceHackerFixture
                {
                    Settings = new ResourceHackerSettings { Open = "somewhere.exe" }
                };

                var actual = fixture.Run();
                Assert.That(actual.Args, Is.EqualTo($"-add -open \"{GetAbsolutePath(fixture.Settings.Open)}\"").IgnoreCase);
            }
        }

        static string GetAbsolutePath(FilePath file) => $"/Working/{file.FullPath}";
    }
}
