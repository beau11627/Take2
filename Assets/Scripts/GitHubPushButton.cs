using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GitHubPushButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PushToGitHub()
    {
        // Run the git command to push the changes
        Process.Start("git", "add .");
        Process.Start("git", "push -u origin main");
    }

}
