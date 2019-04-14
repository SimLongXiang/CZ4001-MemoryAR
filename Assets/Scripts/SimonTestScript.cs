using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class SimonTestScript : MonoBehaviour
{
	
	public GameObject [] ColorImage;
	public Button RestartBtn;
	string s;
	int checkcounter = 0; // 0 - card found, 1 - card lost, 2 - game over 
	int status = 0;
	int cardcounter = 0;
	string [] startwords = new string[]{"Colors will be shown in order.", "Remember the colors !", "Scan the correct color.", "Ready?"};
	string [] flash = new string[]{"Red", "Black"};
	List<string> storedinfo = new List<string>();
	public Text [] allText;
	int [] countvalues = new int[]{0,0,1,1,4};
	//0 = startword, 1 = score, 2 = level, 3 = speed, 4 =no.ofcard

    // Start is called before the first frame update
    void Start(){
    	
      	ARSwitchScript.PauseVuforia(true);
      	foreach(GameObject C in ColorImage){
      		C.SetActive(false);}
      	Debug.Log("All Active Set to False");
      	InvokeRepeating("ChangeText",0.5f,1.0f);
      	Invoke("StartGame", 4.5f);
      	RestartBtn.onClick.AddListener(RestartOnClick);
    }

    void RestartOnClick(){
    	countvalues[0] = 0;
    	countvalues[1] = 0;
    	countvalues[2] = 1;
    	countvalues[3] = 1;
    	countvalues[4] = 4;
    	storedinfo.Clear();
    	StartGame();
    }

	void StartGame(){
		ARSwitchScript.PauseVuforia(true);
		cardcounter = countvalues[4];
		status = 1;
		Invoke("ChangeText", 1.0f);
		InvokeRepeating("FlashColors", 2.0f, 1.0f);
	}

	void ChangeText(){
		if(status == 0) //To print front instruction
		{
			allText[0].text = startwords[countvalues[0]];
			allText[0].color = new Color(97, 120,231,255);
			countvalues[0]++;
			Checks(0);
		}

		if(status == 1) //To print Level
		{
			allText[0].text = "Level " + countvalues[2];
			allText[0].color = new Color(97, 120,231,255);
		}

		if(status == 2) // To print scan instruction
		{
			allText[0].text = "Scan the Next Card in Color Order.";
			allText[0].color = new Color(97, 120,231,255);
		}

		if(status == 3) // print when correct
		{
			allText[0].text = "Correct ! Please clear the cards.";
			allText[0].color = new Color(0, 255,0);
		}

		if(status == 4) // print when wrong
		{
			allText[0].text = "Wrong ! Press the Restart Button to Play Again !";
			allText[0].color = new Color(255, 0,0);
		}
	}

	void FlashColors(){
		Debug.Log("Card Count = " + cardcounter);
		storedinfo.Add(flash[Random.Range(0,2)]);
		
		//Flash Actual Sprite
		FlashObject(storedinfo[storedinfo.Count-1].ToString());

		cardcounter--;
		Checks(4);
		Debug.Log(storedinfo[storedinfo.Count-1]);
	}

	void FlashObject(string color){
		if(color == "Red"){
			ColorImage[0].SetActive(true);
			Debug.Log("Red Block Appeared");
			Invoke("Hide", 0.5f);
		}
		if(color == "Black"){
			ColorImage[1].SetActive(true);
			Debug.Log("Black Block Appeared");
			Invoke("Hide", 0.5f);
		}
	}

	void Hide(){
		foreach(GameObject C in ColorImage){
      	C.SetActive(false);}
	}

	void ScanCards(){
		Invoke("ChangeText", 1.0f);
		ARSwitchScript.PauseVuforia(false);
		checkcounter = 0;
	}

	void RemoveCards(){
		Debug.Log("Removing Cards");
	}
		
	
	void Update(){
		for(int x = 1; x < 5; x++){
			allText[x].text = countvalues[x].ToString();
		}

		if(DefaultTrackableEventHandler.targetname != null && checkcounter == 0){
			s = DefaultTrackableEventHandler.targetname;
			Checks(1);
		}

		if(DefaultTrackableEventHandler.targetname == null && checkcounter == 1){ //check for removal of cards
			s = null;

			if(storedinfo.Count == 0){
				countvalues[2] ++;
				countvalues[4] ++;
				Debug.Log("Values changed: " + "Level - " + countvalues[2] + "Level - " + countvalues[4]);
				checkcounter = 0;
				Invoke("StartGame", 1.0f);
			}
			else{
				status = 2;
				ScanCards();
			}
		}
	}

	void Checks(int index){

		switch(index){
			case 0: 
				if(countvalues[0] > 3 || status != 0){
	    			CancelInvoke("ChangeText");
	    			Debug.Log("ChangeText Stopped");
	    		}
	    		break;

			case 1:
				Debug.Log("Checking Card......");
				if((s == "8heart" && storedinfo[0] == "Red") || (s == "8spades" && storedinfo[0] == "Black")){
					Debug.Log("Correct !");
					status = 3;
					countvalues[1] ++;
					checkcounter = 1;
					Invoke("ChangeText", 0.5f);
					storedinfo.RemoveAt(0);
					RemoveCards();
					foreach(string T in storedinfo){
	    				Debug.Log("Card Left " + T);}
				}
				else{
					Debug.Log("Wrong !!!!");
					status = 4;
					checkcounter = 2;
					Invoke("ChangeText", 0.5f);
				}
				break;

			case 2:
			case 3:
			case 4:
				if(cardcounter == 0){
	    			CancelInvoke("FlashColors");
	    			Debug.Log("FlashColors Stopped");
	    			cardcounter = 0;
	    			status = 2;
	    			ScanCards();
	    			foreach(string T in storedinfo){
	    				Debug.Log("Card " + T);}
	    		} break;
		} //switch ending
	}//checks() ending
}



// timer =  GameObject.Find("CountDown");
// StartCoroutine("LoseTime");
// timer.GetComponent<Countdown>().Counting(4); //accessing countdown methods
// timer.GetComponent<Countdown>().timeLeft = 7;  //accessing countdown variable