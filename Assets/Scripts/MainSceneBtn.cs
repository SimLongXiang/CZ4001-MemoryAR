using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneBtn : MonoBehaviour
{

    public void toMainScene(string scenename){
    	Application.LoadLevel("SimonSays - PokerCards");
    }

    public void toQuit(string scenename){
    	Application.Quit();
    }
}
