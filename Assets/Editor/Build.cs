using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.IO;
using System.Linq;

public class MultiPlatformBuild
{
    // 빌드 출력을 저장할 폴더 경로
    private static readonly string buildPath = "Builds";

    // 빌드 대상 플랫폼 설정
    private static readonly BuildTarget[] buildTargets = {
        BuildTarget.StandaloneWindows64,
        BuildTarget.StandaloneOSX,
        BuildTarget.StandaloneLinux64
    };

    [MenuItem("Build/Build All Platforms")]
    public static void BuildAllPlatforms()
    {
        // 출력 디렉토리 생성
        if (!Directory.Exists(buildPath))
        {
            Directory.CreateDirectory(buildPath);
        }

        foreach (var target in buildTargets)
        {
            BuildForTarget(target);
        }
    }

    private static void BuildForTarget(BuildTarget target)
    {
        // 플랫폼별 출력 경로 설정
        string targetPath = Path.Combine(buildPath, target.ToString());

        // 빌드 옵션 설정
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = GetBuildLocation(targetPath, target),
            target = target,
            options = BuildOptions.None
        };

        // 빌드 실행
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);

        // 빌드 결과 확인
        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"Build succeeded for {target}: {targetPath}");
        }
        else
        {
            Debug.LogError($"Build failed for {target}: {report.summary.result}");
        }
    }

    private static string[] GetEnabledScenes()
    {
        // 빌드 설정에서 활성화된 씬 가져오기
        return EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
    }

    private static string GetBuildLocation(string targetPath, BuildTarget target)
    {
        // 플랫폼별 출력 파일 이름 설정
        switch (target)
        {
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                return Path.Combine(targetPath, "MKLK.exe");
            case BuildTarget.StandaloneOSX:
                return Path.Combine(targetPath, "MKLK.app");
            case BuildTarget.StandaloneLinux64:
                return Path.Combine(targetPath, "MKLK");
            default:
                throw new System.Exception($"Unsupported build target: {target}");
        }
    }
}
