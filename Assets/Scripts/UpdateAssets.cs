using UnityEngine;
using System.Diagnostics;

public class UpdateAssets : MonoBehaviour
{
    public void Awake()
    {
        AddAndPushFiles();
        
    }
    public void AddAndPushFiles()
    {
        string gitPath = "git"; // Path to the git executable or 'git' if it's in the system PATH

        // Add the files to the staging area
        RunGitCommand(gitPath, "add -A");

        // Commit the changes
        RunGitCommand(gitPath, "commit -m \"Commit message\"");

        // Push the changes to the remote repository
        RunGitCommand(gitPath, "push origin main");
    }

    private void RunGitCommand(string gitPath, string command)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = gitPath;
        startInfo.Arguments = command;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.CreateNoWindow = true;

        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();

        // Read the output of the Git command, if needed
        string output = process.StandardOutput.ReadToEnd();
        UnityEngine.Debug.Log(output);

        process.WaitForExit();
    }
}
