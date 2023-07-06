using UnityEngine;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using UnityEditor;


public class UpdateAssets : MonoBehaviour
{

    
    [SerializeField] private string commitComment; //string that will hold our inputted comment
   
   
    //function that will help return the terminal output to the log
    private void LogGitOutput(Process process)
    {
        StringBuilder output = new StringBuilder();

        while (!process.StandardOutput.EndOfStream)
        {
            string line = process.StandardOutput.ReadLine();
            output.AppendLine(line);
        }

        if (output.Length > 0)
        {
            UnityEngine.Debug.Log(output.ToString());
        }
    }

    //function that will add changed files
    public void ExecuteGitAdd()
    {
    string gitExecutable = "git"; //path to the git executable
    string repositoryPath = Application.dataPath; //path to the gitRepo

    ProcessStartInfo processInfo = new ProcessStartInfo(gitExecutable);
        processInfo.WorkingDirectory = repositoryPath;
        processInfo.Arguments = "add ."; // Add all files to the Git repository
        processInfo.RedirectStandardOutput = true;
        processInfo.UseShellExecute = false;

        Process process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        LogGitOutput(process);
    }

    //function that will push all added files to the server with a comment
    public void ExecuteGitPush(string commitComment)
    {
        string gitExecutable = "git"; //path to the git executable
        string repositoryPath = Application.dataPath; //path to the gitRepo

        //ProcessStartInfo addProcessInfo = new ProcessStartInfo(gitExecutable);
        //addProcessInfo.WorkingDirectory = repositoryPath;
        //addProcessInfo.Arguments = "add ."; // Add all files to the Git repository
        //addProcessInfo.RedirectStandardOutput = true;
        //addProcessInfo.UseShellExecute = false;

        //Process addProcess = new Process();
        //addProcess.StartInfo = addProcessInfo;
        //addProcess.Start();
        //addProcess.WaitForExit();

        //LogGitOutput(addProcess);

        ProcessStartInfo commitProcessInfo = new ProcessStartInfo(gitExecutable);
        commitProcessInfo.WorkingDirectory = repositoryPath;
        commitProcessInfo.Arguments = "commit -m \"" + commitComment + "\""; // Use the comment as the commit message
        commitProcessInfo.RedirectStandardOutput = true;
        commitProcessInfo.UseShellExecute = false;

        Process commitProcess = new Process();
        commitProcess.StartInfo = commitProcessInfo;
        commitProcess.Start();
        commitProcess.WaitForExit();

        LogGitOutput(commitProcess);

        ProcessStartInfo pushProcessInfo = new ProcessStartInfo(gitExecutable);
        pushProcessInfo.WorkingDirectory = repositoryPath;
        pushProcessInfo.Arguments = "push";
        pushProcessInfo.RedirectStandardOutput = true;
        pushProcessInfo.UseShellExecute = false;

        Process pushProcess = new Process();
        pushProcess.StartInfo = pushProcessInfo;
        pushProcess.Start();
        pushProcess.WaitForExit();

        LogGitOutput(pushProcess);
    }

    //public void Push(string commitComment)
    //{



    //        ProcessStartInfo processInfo = new ProcessStartInfo(gitExecutable);
    //        processInfo.WorkingDirectory = repositoryPath;
    //        processInfo.Arguments = "add ."; //add all files to the git repository

    //        Process addProcess = new Process();
    //        addProcess.StartInfo = processInfo;
    //        addProcess.Start();
    //        addProcess.WaitForExit();

    //        if (addProcess.ExitCode == 0)
    //        {
    //            UnityEngine.Debug.Log("Git add command executed successfully.");

    //            ProcessStartInfo commitProcessInfo = new ProcessStartInfo(gitExecutable);
    //            commitProcessInfo.WorkingDirectory = repositoryPath;
    //            commitProcessInfo.Arguments = "commit -m \"" + commitComment + "\""; // Replace with your commit message

    //            Process commitProcess = new Process();
    //            commitProcess.StartInfo = commitProcessInfo;
    //            commitProcess.Start();
    //            commitProcess.WaitForExit();

    //            if (commitProcess.ExitCode == 0)
    //            {
    //                UnityEngine.Debug.Log("Git commit command executed successfully.");

    //                ProcessStartInfo pushProcessInfo = new ProcessStartInfo(gitExecutable);
    //                pushProcessInfo.WorkingDirectory = repositoryPath;
    //                pushProcessInfo.Arguments = "push -u origin main";

    //                Process pushProcess = new Process();
    //                pushProcess.StartInfo = pushProcessInfo;
    //                pushProcess.Start();
    //                pushProcess.WaitForExit();

    //                if (pushProcess.ExitCode == 0)
    //                {
    //                    UnityEngine.Debug.Log("Git push command executed successfully.");
    //                }
    //                else
    //                {
    //                    UnityEngine.Debug.LogError("Failed to execute git push command.");
    //                }
    //            }
    //            else
    //            {
    //                UnityEngine.Debug.LogError("Failed to execute git commit command.");
    //            }
    //        }
    //        else
    //        {
    //            UnityEngine.Debug.LogError("Failed to execute git add command.");
    //        }
    //    }
    public void PerformGitPull()
    {
        string gitExecutable = "git"; // Path to the git executable if not in system PATH
        string repositoryPath = "/Users/beauchapman/Take2/"; // Path to your Git repository

        ProcessStartInfo processInfo = new ProcessStartInfo(gitExecutable);
        processInfo.WorkingDirectory = repositoryPath;
        processInfo.Arguments = "pull";

        Process process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        if (process.ExitCode == 0)
        {
            UnityEngine.Debug.Log("Git pull operation completed successfully.");
        }
        else
        {
            UnityEngine.Debug.LogError("Failed to perform Git pull operation.");
        }
    }
}

