#r "../src/Cake.ResourceHacker/bin/Debug/netstandard2.0/Cake.ResourceHacker.dll"

var target = Argument("target", "Default");

Task("Add")
    .Does(() => {
            ResourceHackerAdd(new ResourceHackerSettings{ Open = "open.exe", Save = "save.exe", Resource = "resource.ico", Mask = new Mask { Type = MaskType.IconGroup } });
    });

RunTarget(target);