# CoilBoing
Replaces the coil-head spring sound with a cartoon boing.

## Steps to build just in case I forgor 💀

- Create a .csproj.user file with this content

```xml
<?xml version="1.0" encoding="utf-8"?>
<!-- Shamelessly copied from the LethalLib build instructions. Sorry not sorry -->
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
        <LethalCompanyDir>/home/mew/.local/share/Steam/steamapps/common/</LethalCompanyDir>
        <TestProfileDir>/home/mew/.config/r2modmanPlus-local/LethalCompany/profiles/DevProfile/</TestProfileDir>
    </PropertyGroup>

    <!-- Enable by setting the Condition attribute to "true". *nix users should switch out `copy` for `cp`. -->
    <Target Name="CopyToTestProfile" AfterTargets="PostBuildEvent" Condition="true">
        <MakeDir
                Directories="$(TestProfileDir)BepInEx/plugins/Raoul1808-CoilBoing"
                Condition="!Exists('$(TestProfileDir)BepInEx/plugins/Raoul1808-CoilBoing')"
        />
        <Copy
                SourceFiles="$(TargetPath)"
                DestinationFolder="$(TestProfileDir)BepInEx/plugins/Raoul1808-CoilBoing"
                SkipUnchangedFiles="false"
                OverwriteReadOnlyFiles="true"
        />
    </Target>
</Project>
```

- Build
- Copy the asset bundle to the destination

## License

This project is licensed under the [MIT License](LICENSE)
