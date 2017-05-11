using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
Function
 - player will complete 3 small tasks for the quest giver
 - if all tasks are completed
 	+ reward player
 - otherwise
 	+ remind player to complete quest
============================================================
Required
 - an int to keep track of how many tasks are completed
 - a way for tasks to switch once another task is complete
 	+ switch statement
 - a check for the player's inventory
============================================================
- attached to quest giver
*/

public class RepairQuest : MonoBehaviour 
{
	public int tasksCompleted = 0; //tracks number of completed tasks

	public GameObject player; //needed to grab inventory component from player object
	public GameObject canister;
	public GameObject pump;
	public GameObject battery; //used for task 3, check for active
	public GameObject sCanister;
	public GameObject sPump;


	//ui
	public GameObject exclamationMark;
	public GameObject grayQuestionMark;
	public GameObject yellowQuestionMark;
	public GameObject questCheckmark;
	
	//UI Variables
	public GameObject repSuccessPanel;
	public GameObject questBox;
	public GameObject questTrackerBox;
	public Text repQuestText;
	public Text repQuestTitleText;
	public Text repSuccessPanelText;
	public Text repQuestTrackerText;

	//minimap indicators
	//public GameObject exPointMM;
	public GameObject qmPointMM;
	public GameObject cmPointMM;

	public GameObject laserBottom;

	void Start()
	{
		//items.SetActive(false);
		canister.SetActive(false);
		pump.SetActive(false);
	}

	public void Talk()
	{
		Inventory inv = player.GetComponent<Inventory>();

        if (!QuestManager.repairIsActive && !QuestManager.repairComplete) //If quest isn't already active and not complete
        {
            //Show quest prompt in UI
            QuestManager.repairIsActive = true; //Activate quest
			//items.SetActive(true);
            Debug.Log("Repair Quest activated");

			//ui
			//************************************************
			questBox.SetActive(true);
			repQuestText.text = "Aha, suh Gruz. I heard you got a chance to help out R2 downstairs. " +
				"Would you mind giving me a hand too? The oil dispensaries in the cantina are all jacked up since the power has been off for so long. " +
				"The other droids are pissed because they haven’t been able to get lubed up for a while.";
			repQuestTitleText.text = "Giffy Lube";
			questTrackerBox.SetActive(true);
			//repQuestTrackerText.text = "- Hit the Big Red Button";
			
			exclamationMark.SetActive(false);
			grayQuestionMark.SetActive(true);
			//**************************************************
        }

		if(QuestManager.repairComplete == true)
		{
			//appreciation dialogue
			Debug.Log ("go do other stuff");
		}

		if(QuestManager.repairIsActive == true)
		{
			switch (tasksCompleted) 
			{
			case 0:
				//start first task, give item1 to quest giver
				questBox.SetActive(true);
				repQuestText.text += "I need the oil canister. It looks like a giant piece of glass.";
				if(canister != null)
				{
					canister.SetActive(true);
				}
				if(inv.item1 == 1)
				{
					inv.item1 = 0;
					tasksCompleted++;
					sCanister.SetActive(true);
					pump.SetActive(true);
					goto case 1;
				}
				break;
			case 1:
				//start second task, give item2 to quest giver
				questBox.SetActive(true);
				repQuestText.text = "Now I need the internal pump. It looks like a donut.";
				if(pump != null)
				{
					pump.SetActive(true);
				}
				if(inv.item2 == 1)
				{
					inv.item2 = 0;
					tasksCompleted++;
					sPump.SetActive(true);
					goto case 2;
				}
				break;
			case 2:
				//start third task, put item3 in marked location
				questBox.SetActive(true);
				repQuestText.text = "Now suhlide this battery into the slot next to the machine. It looks like a tilted picture frame";
				inv.battery = 1;
				/*
				if(battery.activeSelf == true)
				{
					tasksCompleted++;
				}
				*/
				break;
			default:
				break;
			}

			if(tasksCompleted == 3)
			{
				//success dialogue
				QuestManager.repairComplete = true;
				QuestManager.repairIsActive = false;
				laserBottom.SetActive(false);
	            Debug.Log("Repair Quest completed");

				//********************************************
				//UI Stuff
				questBox.SetActive(true);
				repQuestTitleText.text = "Giffy Lube";
				repQuestText.text = "Looks like you got the dispensary pump working again. Really puzzling why Star Command marooned you on this station. " +
					"Anyway, I’m going to grab a few drinks. " +
					"I found this Target Interface System Component while you were running around, maybe you have some use for it.";
				repQuestTrackerText.text = "";
				
				
				//More UI stuff
				repSuccessPanel.SetActive(true);
				repSuccessPanelText.text = "Giffy Lube Complete \n" +
					"Reward: Target Interface System Component";
				questTrackerBox.SetActive(false);
				
				//Checkmark
				grayQuestionMark.SetActive(false);
				yellowQuestionMark.SetActive(false);
				qmPointMM.SetActive(false);
				questCheckmark.SetActive(true);
				cmPointMM.SetActive(true);
				//********************************************
			}
			else
			{
				return;
			}
		}
	}
}
