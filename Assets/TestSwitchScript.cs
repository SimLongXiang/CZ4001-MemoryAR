using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TestSwitchScript : MonoBehaviour
{

	public int switchvalue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(switchvalue == 0){
        	ARSwitchScript.PauseVuforia(true);
        }
        if(switchvalue == 1){
        	ARSwitchScript.PauseVuforia(false);
        }

        Debug.Log(DefaultTrackableEventHandler.targetname);

    }
}
