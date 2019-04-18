# Cake.ResourceHacker

A Cake AddIn that extends Cake with [ResourceHacker](http://angusj.com/resourcehacker/) command tools.

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)
[![NuGet](https://img.shields.io/nuget/v/Cake.ResourceHacker.svg)](https://www.nuget.org/packages/Cake.ResourceHacker)
[![Build status](https://ci.appveyor.com/api/projects/status/vi07dth3d1gek7ak?svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-resourcehacker)

## Important

1.1.0 Supports Cake 0.33

1.0.0 Supports Cake 0.30 and .NET Standard 2.0.

## Including addin
Including addin in cake script is easy.
```
#addin "Cake.ResourceHacker"
```
## Usage

Resource Hacker has to be installed and it's ResourceHacker.exe in path.

To use the addin add it to Cake call the aliases and configure any settings you want.

```csharp
#addin "Cake.ResourceHacker"

...

// How to login using a token
Task("Add")
	.Does(() => {
		// or more containers at once
		ResourceHackerAdd(new ResourceHackerSettings{ Open = "file path" });
	)};
```
Other commands follow same convention.

This version is built against ResourceHacker 5.1.6.

## Credits

Brought to you by [Miha Markic](https://github.com/MihaMarkic) ([@MihaMarkic](https://twitter.com/MihaMarkic/)) and contributors.