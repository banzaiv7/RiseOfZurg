using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
- attached to QuestManager
 */
public class CollectionQuest : MonoBehaviour 
{
	int neededCrystals = 10;

	public GameObject player;
	public GameObject items;
	public GameObject laserDoorTop;

	//ui
	public GameObject exclamationMark;
	public GameObject grayQuestionMark;
	public GameObject yellowQuestionMark;
	public GameObject questCheckmark;
	
	//UI Variables
	public GameObject colSuccessPanel;
	public GameObject questBox;
	public GameObject questTrackerBox;
	public Text colQuestText;
	public Text coQuestTitleText;
	public Text colSuccessPanelText;
	public Text colQuestTrackerText;

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
		Inventory inv = player.GetComponent<Inventory> ();
		if (!QuestManager.collectionIsActive && !QuestManager.collectionComplete) //If quest isn't already active and not complete
		{
			//Show quest prompt in UI
			QuestManager.collectionIsActive = true; //Activate quest
			items.SetActive(true);
			Debug.Log("Collection Quest activated");

			//ui
			//************************************************
			questBox.SetActive(true);
			colQuestText.text = "Aha, suh Gruz. A lot of the droids around here are getting annoyed because they have been stuck on this floor for a while. " +
				"Can you find the power cells needed to get these elevators back up and running? " +
				"There is something nice in it for you if you do.";
			coQuestTitleText.text = "Power Overwhelming!";
			questTrackerBox.SetActive(true);
			//colQuestTrackerText.text = "- Crystals Collected " +  inv.crystals + "/10"; 
			
			exclamationMark.SetActive(false);
			grayQuestionMark.SetActive(true);
			//**************************************************
		}
		if (QuestManager.collectionComplete == true)
		{
			//appreciation dialogue
			Debug.Log ("go do other stuff");
		}
		if(QuestManager.collectionIsActive == true)
		{
			Debug.Log ("go find crystals");
			//Inventory inv = player.GetComponent<Inventory> ();
			if (inv.crystals == neededCrystals) 
			{
				//success dialogue here
				Debug.Log ("yay you found them");
				inv.crystals = 0;
				inv.prismComponent++;
				QuestManager.collectionComplete = true;
				QuestManager.collectionIsActive = false;
				//********************************************
				//UI Stuff
				questBox.SetActive(true);
				coQuestTitleText.text = "Power Overwhelming!";
				colQuestText.text = "You did it! I’ve been holding onto this Prism Encasement for a while now, " +
					"I think you might be able to find some use for it. See you around, and thanks.";
				colQuestTrackerText.text = "";
				
				
				//More UI stuff
				colSuccessPanel.SetActive(true);
				colSuccessPanelText.text = "Power Overwhelming! Complete \n" +
					"Reward: Prism Encasement";
				questTrackerBox.SetActive(false);
				
				//Checkmark
				grayQuestionMark.SetActive(false);
				yellowQuestionMark.SetActive(false);
				questCheckmark.SetActive(true);
				qmPointMM.SetActive(false);
				cmPointMM.SetActive(true);
				//********************************************
				laserDoorTop.SetActive(false);
			} 
			else 
			{
				Debug.Log ("you need more");
				return;
			}
		}
	}
}
