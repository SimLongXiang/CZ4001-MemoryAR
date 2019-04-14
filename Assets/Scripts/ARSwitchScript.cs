using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class ARSwitchScript : MonoBehaviour
{
    private void Start()
    {
        PauseVuforia(false); // So to be sure when app starts, recognition will work.
    }

    static public void PauseVuforia(bool what)
    {
        Tracker imageTracker = TrackerManager.Instance.GetTracker<ObjectTracker>() as ObjectTracker;
        if (imageTracker != null)
        {
            if (what)
            {
                imageTracker.Stop();
                Debug.Log("Recognition Stopped");
            }
            else
            {
                imageTracker.Start();
                Debug.Log("Recognition Started");
            }
     	}  
     }     
    
}
