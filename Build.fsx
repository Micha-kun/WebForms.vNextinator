// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake

// Properties
let buildDir = "./build/"
let packagingRoot = "./package/"
let packagingDir = packagingRoot @@ "lib"

let authors = ["Michael-Jorge Gómez Campos"]
let projectName = "WebForms.vNextinator"
let projectDescription= "The future of WebForms is here!!"
let projectSummary = "0.1.0"

// Targets
Target "BuildClean" (fun _ -> 
    CleanDir buildDir
)

Target "BuildNet20Project" (fun _ ->
    !! "Src/WebForms.vNextinator.Net20/*.csproj"
        |> MSBuildRelease (buildDir + "Net20/") "Build"
        |> Log "AppBuild-Output: "
)

Target "BuildNet35Project" (fun _ ->
    !! "Src/WebForms.vNextinator.Net35/*.csproj"
        |> MSBuildRelease (buildDir + "Net35/") "Build"
        |> Log "AppBuild-Output: "
)

Target "BuildNet40Project" (fun _ ->
    !! "Src/WebForms.vNextinator.Net40/*.csproj"
        |> MSBuildRelease (buildDir + "Net40/") "Build"
        |> Log "AppBuild-Output: "
)

Target "BuildNet45Project" (fun _ ->
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
            Version = "0.1.0"
            AccessKey = getBuildParamOrDefault "nugetkey" ""
            Publish = hasBuildParam "nugetKey"
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
                 ("Net45/WebForms.vNextinator.PDB", Some "lib/net45/WebForms.vNextinator.PDB", None)]})
            "WebForms.vNextinator.nuspec"
)

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

// Dependencies
"BuildClean"
  ==> "BuildNet20Project"
  ==> "BuildNet35Project"
  ==> "BuildNet40Project"
  ==> "BuildNet45Project"
  ==> "CreatePackage"
  ==> "Default"

// start build
RunTargetOrDefault "Default"