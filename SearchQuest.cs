using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
- attached to the QuestManager
 */
public class SearchQuest : MonoBehaviour 
{
	int neededAlien = 1;

	public GameObject player;
	public GameObject items;
	public GameObject laserMiddle;

	//ui
	public GameObject exclamationMark;
	public GameObject grayQuestionMark;
	public GameObject yellowQuestionMark;
	public GameObject questCheckmark;
	
	//UI Variables
	public GameObject serSuccessPanel;
	public GameObject questBox;
	public GameObject questTrackerBox;
	public Text serQuestText;
	public Text serQuestTitleText;
	public Text serSuccessPanelText;
	public Text serQuestTrackerText;

	//minimap indicators
	//public GameObject exPointMM;
	public GameObject qmPointMM;
	public GameObject cmPointMM;

	void Start()
	{
		items.SetActive(false);
	}

	public void Talk()
	{
		if (!QuestManager.searchIsActive && !QuestManager.searchComplete) //If quest isn't already active and not complete
		{
			//Show quest prompt in UI
			QuestManager.searchIsActive = true; //Activate quest
			items.SetActive(true);
			Debug.Log("Search Quest activated");

			//ui
			//************************************************
			questBox.SetActive(true);
			serQuestText.text = "Aha, suh Gruz. I need you to find my brother before the claw ceremony. " +
				"The claw will choose who will go and who will stay tonight and I need to dilute the pool a little bit. " +
				"His name is Jim, and he looks exactly like me. Bring him back here when you find that idiot.";
			serQuestTitleText.text = "Idiot Abroad";
			questTrackerBox.SetActive(true);
			//serQuestTrackerText.text = "- Idiot found 0/1";
			
			exclamationMark.SetActive(false);
			grayQuestionMark.SetActive(true);
			//**************************************************
		}
		if (QuestManager.searchComplete == true)
		{
			//appreciation dialogue
			Debug.Log ("go do other stuff");
		}
		if(QuestManager.searchIsActive == true)
		{
			Inventory inv = player.GetComponent<Inventory> (); //grabs player inventory
			if (inv.alien == neededAlien) //checks if the number of aliens in player inventory matches the required number of aliens to complete quest
			{
				//success
				Debug.Log ("Yay you found the lost idiot!");
				inv.alien = 0; //clears the player inventory of aliens
				QuestManager.searchComplete = true; //sets searchComplete in the static class QuestManager to true,
				QuestManager.searchIsActive = false;

				//********************************************
				//UI Stuff
				questBox.SetActive(true);
				serQuestTitleText.text = "Idiot Abroad";
				serQuestText.text = "Jim! You idiot the claw ceremony is in 15 minutes. " +
					"Go put on your good suit. As for you Gruz, a job well done. I heard Star Command has made you a little salty, here is a Laser Component, I’m sure you’ll find some use for it, if you know what I mean.";
				serQuestTrackerText.text = "";
				
				
				//More UI stuff
				serSuccessPanel.SetActive(true);
				serSuccessPanelText.text = "Idiot Abroad Complete \n" +
					"Reward: Laser Component";
				questTrackerBox.SetActive(false);
				
				//Checkmark
				grayQuestionMark.SetActive(false);
				yellowQuestionMark.SetActive(false);
				questCheckmark.SetActive(true);
				qmPointMM.SetActive(false);
				cmPointMM.SetActive(true);
				//********************************************

				laserMiddle.SetActive(false);
			} 
			else 
			{
				Debug.Log ("Go find him please.");
				return;
			}
		}
	}
}
