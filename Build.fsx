// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile

// Properties
let buildDir = "./build/"
let packagingRoot = "./package/"
let packagingDir = packagingRoot @@ "lib"

let authors = ["Michael-Jorge Gómez Campos"]
let projectName = "WebForms.vNextinator"
let projectDescription= "The future of WebForms is here!!"
let projectVersion = "0.4.1"
let projectSummary = projectVersion

// Targets
Target "BuildClean" (fun _ -> 
    CleanDir buildDir
)

Target "CopyWebConfigTransform" (fun _ ->
    CopyFileIntoSubFolder buildDir "web.config.transform"
)

let generateAssemblyAttributes guid = 
    [Attribute.Title projectName
     Attribute.Description projectDescription
     Attribute.Guid guid
     Attribute.Product projectName
     Attribute.Version projectVersion
     Attribute.FileVersion projectVersion
     Attribute.CLSCompliant true
     Attribute.ComVisible false]

Target "BuildNet20Project" (fun _ ->
    generateAssemblyAttributes "ab47c848-139c-4120-ad73-9570ba612160" 
        |> CreateCSharpAssemblyInfo "Src/WebForms.vNextinator.Net20/Properties/AssemblyInfo.cs"

    !! "Src/WebForms.vNextinator.Net20/*.csproj"
        |> MSBuildRelease (buildDir + "Net20/") "Build"
        |> Log "AppBuild-Output: "
)

Target "BuildNet35Project" (fun _ ->
    generateAssemblyAttributes "16ab937c-58b7-41eb-806e-2101894d8bb3" 
        |> CreateCSharpAssemblyInfo "Src/WebForms.vNextinator.Net35/Properties/AssemblyInfo.cs"
                

    !! "Src/WebForms.vNextinator.Net35/*.csproj"
        |> MSBuildRelease (buildDir + "Net35/") "Build"
        |> Log "AppBuild-Output: "
)

Target "BuildNet40Project" (fun _ ->
    generateAssemblyAttributes "c92237ff-8875-47f9-86ed-9c0c6cf6cca2"
        |> CreateCSharpAssemblyInfo "Src/WebForms.vNextinator.Net40/Properties/AssemblyInfo.cs"
        
    !! "Src/WebForms.vNextinator.Net40/*.csproj"
        |> MSBuildRelease (buildDir + "Net40/") "Build"
        |> Log "AppBuild-Output: "
)

Target "BuildNet45Project" (fun _ ->
    generateAssemblyAttributes "1aa18ad4-ed25-4220-b504-e62104855800"
    |> CreateCSharpAssemblyInfo "Src/WebForms.vNextinator.Net45/Properties/AssemblyInfo.cs"

    !! "Src/WebForms.vNextinator.Net45/*.csproj"
        |> MSBuildRelease (buildDir + "Net45/") "Build"
        |> Log "AppBuild-Output: "
)

Target "CreatePackage" (fun _ ->
    NuGet (fun p -> 
        {p with
            Authors = authors
            Project = projectName
            Title = projectName
            Description = projectDescription                               
            OutputPath = buildDir
            Summary = projectSummary
            WorkingDir = buildDir
            Version = projectVersion
            AccessKey = getBuildParamOrDefault "nugetkey" ""
            Publish = hasBuildParam "nugetKey"
            DependenciesByFramework = 
                [ 
                    {Dependencies = [("TaskParallelLibrary","1.0.2856.0")]; FrameworkVersion = "net35"}
                    {Dependencies = []; FrameworkVersion = "net40"}
                ]
            FrameworkAssemblies = 
                [{FrameworkVersions = []; AssemblyName = "System.Web"}]
            Files = 
                [("Net20/WebForms.vNextinator.dll", Some "lib/net20/WebForms.vNextinator.dll", None)
                 ("Net20/WebForms.vNextinator.PDB", Some "lib/net20/WebForms.vNextinator.PDB", None)
                 ("Net35/WebForms.vNextinator.dll", Some "lib/net35/WebForms.vNextinator.dll", None)
                 ("Net35/WebForms.vNextinator.PDB", Some "lib/net35/WebForms.vNextinator.PDB", None)
                 ("Net40/WebForms.vNextinator.dll", Some "lib/net40/WebForms.vNextinator.dll", None)
                 ("Net40/WebForms.vNextinator.PDB", Some "lib/net40/WebForms.vNextinator.PDB", None)
                 ("Net45/WebForms.vNextinator.dll", Some "lib/net45/WebForms.vNextinator.dll", None)
                 ("Net45/WebForms.vNextinator.PDB", Some "lib/net45/WebForms.vNextinator.PDB", None)
                 ("web.config.transform", Some "content/web.config.transform", None)]
        })
            "WebForms.vNextinator.nuspec"
)

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

// Dependencies
"BuildClean"
  ==> "CopyWebConfigTransform"
  ==> "BuildNet20Project"
  ==> "BuildNet35Project"
  ==> "BuildNet40Project"
  ==> "BuildNet45Project"
  ==> "CreatePackage"
  ==> "Default"

// start build
RunTargetOrDefault "Default"