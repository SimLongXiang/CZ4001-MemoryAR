using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Countdown : MonoBehaviour
{
  public int timeLeft; //Seconds Overall
  

  public void Counting (int sec) {
  	timeLeft = sec;
    StartCoroutine("LoseTime");
    Time.timeScale = 1; //Just making sure that the timeScale is right
   }


  //Simple Coroutine
  IEnumerator LoseTime()
  {
  	Debug.Log(timeLeft);
    while (true) {
      yield return new WaitForSeconds (1);
      timeLeft--;
      Debug.Log(timeLeft);

      if (timeLeft <= 0) break;
    }
  }
}
