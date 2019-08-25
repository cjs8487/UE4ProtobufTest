// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.
using System.IO;
using System;
using UnrealBuildTool;

public class Experiments : ModuleRules
{

    private string ModulePath
    {
        get
        {
            return ModuleDirectory;
        }
    }

    private string ThirdPartyPath
    {
        get
        {
            return Path.GetFullPath(Path.Combine(ModulePath, "../ThirdParty"));
        }
    }
    public Experiments(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "HeadMountedDisplay" });

        //LoadProtobufTest(Target);

        LoadProtobuf(Target);

        //PrivateDependencyModuleNames.AddRange(new string[] { "ProtobufTest" });
        //PrivateDependencyModuleNames.AddRange(new string[] {"protobuf" });
        //PrivateDependencyModuleNames.AddRange(new string[] { "CoreUObject", "Engine", "libprotobuf" });
    }

    public bool LoadProtobufTest(ReadOnlyTargetRules target)
    {
        bool supported = false;
        if (target.Platform == UnrealTargetPlatform.Win64 || target.Platform == UnrealTargetPlatform.Win32)
        {
            supported = true;
            string platformString = target.Platform == UnrealTargetPlatform.Win64 ? "x64" : "x86";
            string librariesPath = Path.Combine(ThirdPartyPath, "ProtobufTest", "Libraries");

            PublicAdditionalLibraries.Add(Path.Combine(librariesPath, "ProtobufTest"  + ".lib"));
        }

        if (supported)
        {
            PublicIncludePaths.Add(Path.Combine(ThirdPartyPath, "ProtobufTest", "Includes"));
        }

        PublicDefinitions.Add(string.Format("WITH_PROTOBUF_TEST_BINDING={0}", supported ? 1 : 0));
        return supported;
    }

    public void LoadProtobuf(ReadOnlyTargetRules target)
    {
        PublicSystemIncludePaths.Add(Path.Combine(ThirdPartyPath, "protobuf", "include"));

        switch (Target.Platform)
        {
            case UnrealTargetPlatform.Win64:
                PublicLibraryPaths.Add(Path.Combine(ThirdPartyPath, "protobuf", "lib", "Win64"));
                PublicAdditionalLibraries.Add("libprotobuf.lib");
                break;
            default:
                throw new Exception("Unsupported platform " + Target.Platform.ToString());
        }

        PublicDefinitions.Add("GOOGLE_PROTOBUF_NO_RTTI=1");
    }
}
