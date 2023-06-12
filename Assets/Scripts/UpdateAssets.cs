using UnityEngine;
using System.Diagnostics;

public class UpdateAssets : MonoBehaviour
{
    //public void Awake()
    //{
    //    AddAndPushFiles();
        
    //}
    public void AddAndPushFiles()
    {
        string gitExecutable = "git"; //path to the git executable
        string repositoryPath = "/Users/beauchapman/Take2/"; //path to the gitRepo

        ProcessStartInfo processInfo = new ProcessStartInfo(gitExecutable);
        processInfo.WorkingDirectory = repositoryPath;
        processInfo.Arguments = "add ."; //add all files to the git repository

        Process addProcess = new Process();
        addProcess.StartInfo = processInfo;
        addProcess.Start();
        addProcess.WaitForExit();

        if (addProcess.ExitCode == 0)
        {
            UnityEngine.Debug.Log("Git add command executed successfully.");

            ProcessStartInfo commitProcessInfo = new ProcessStartInfo(gitExecutable);
            commitProcessInfo.WorkingDirectory = repositoryPath;
            commitProcessInfo.Arguments = "commit -m \"Your commit message\""; // Replace with your commit message

            Process commitProcess = new Process();
            commitProcess.StartInfo = commitProcessInfo;
            commitProcess.Start();
            commitProcess.WaitForExit();

            if (commitProcess.ExitCode == 0)
            {
                UnityEngine.Debug.Log("Git commit command executed successfully.");

                ProcessStartInfo pushProcessInfo = new ProcessStartInfo(gitExecutable);
                pushProcessInfo.WorkingDirectory = repositoryPath;
                pushProcessInfo.Arguments = "push -u origin main";

                Process pushProcess = new Process();
                pushProcess.StartInfo = pushProcessInfo;
                pushProcess.Start();
                pushProcess.WaitForExit();

                if (pushProcess.ExitCode == 0)
                {
                    UnityEngine.Debug.Log("Git push command executed successfully.");
                }
                else
                {
                    UnityEngine.Debug.LogError("Failed to execute git push command.");
                }
            }
            else
            {
                UnityEngine.Debug.LogError("Failed to execute git commit command.");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Failed to execute git add command.");
        }
    }
}

