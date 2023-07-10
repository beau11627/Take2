using UnityEngine;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using UnityEditor;


public class UpdateAssets : MonoBehaviour
{
    //private string gitExecutable = "git"; //path to the git executable
    //private string repositoryPath = Application.dataPath; //path to the gitRepo

    [SerializeField] private string commitComment; //string that will hold our inputted comment
    [SerializeField] private string branch;

    //General function for calling GitCommands
    private void ExecuteGitCommand(string command)
    {
        string gitExecutable = "git";
        string repositoryPath = Application.dataPath;
        ProcessStartInfo processInfo = new ProcessStartInfo(gitExecutable);
        processInfo.WorkingDirectory = repositoryPath;
        processInfo.Arguments = command;

        Process process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        if (process.ExitCode == 0)
        {
            LogGitOutput(process);
        }
        else
        {
            LogGitOutput(process);
        }
    }

    //function that will help return the terminal output to the log
    private void LogGitOutput(Process process)
    {
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;  // Set UseShellExecute to false for IO stream redirection
        process.Start();  // Start the process after configuring the properties

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
        ExecuteGitCommand("add .");
    }

    //function that will push all added files to the server with a comment
    public void ExecuteGitPush(string commitComment)
    {
        ExecuteGitCommand("commit -m \"" + commitComment + "\"");
        ExecuteGitCommand("push");
    }

    //pull command that will restore deleted things
    public void ExecuteGitPullRestoreDeleted()
    {
        ExecuteGitCommand("fetch");
        ExecuteGitCommand("reset --hard HEAD");
        ExecuteGitCommand("merge '@{u}'");
    }

    public void ExecuteGitPullOverwriteExisting()
    {
        ExecuteGitCommand("stash");
        ExecuteGitCommand("pull");
        ExecuteGitCommand("stash apply");
    }

    public void Stash()
    {
        ExecuteGitCommand("stash");
    }
    }

