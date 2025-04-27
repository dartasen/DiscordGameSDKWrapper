## DiscordGameSDKWrapper
[![NuGet](https://img.shields.io/nuget/v/DiscordGameSDKWrapper.svg?style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/DiscordGameSDKWrapper/) [![NuGet](https://img.shields.io/nuget/dt/DiscordGameSDKWrapper.svg?style=for-the-badge)](https://www.nuget.org/stats/packages/DiscordGameSDKWrapper?groupby=Version)

Nuget package of the provided Discord Game SDK C# Wrapper contained in the zip linked on https://discord.com/developers/docs/game-sdk/sdk-starter-guide

> Supports net472 netstandard2.0 netstandard2.1 net8.0 net9.0

## Default Native Libraries Embedding

By default, for .NET Framework the native libraries are embedded and are extracted to runtimes folder. If you want to disable this behavior
You can Set `<ShouldIncludeNativeDiscordGameSDK>False</ShouldIncludeNativeDiscordGameSDK>` in your csproj, and provide manually your dlls in the runtimes folder or at the root of the executable.

Available for specific RID `linux-x64`, `osx-x64`, `osx-arm64`, `win-x64`, `win-x86`.