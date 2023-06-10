using UnityEngine;
using System.Diagnostics;
public class GitUpdater : MonoBehaviour {[SerializeField] private string gitPath = "git";
    [SerializeField] private string repositoryPath = "/path/to/repository";
    public void UpdateAssets() {
        // Create a new process for the git pull command
        Process process = new Process();
        // Set the process start info
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = gitPath;
        // The name or path to the git executable
        startInfo.Arguments = "pull";
        // The Git command to update the repository
        startInfo.WorkingDirectory = repositoryPath;
        // The path to the Git repository
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        // Start the process
        process.StartInfo = startInfo;
        process.Start(); // Read the output from the process
        string output = process.StandardOutput.ReadToEnd();
        UnityEngine.Debug.Log(output);
        // Wait for the process to exit
        process.WaitForExit(); } }