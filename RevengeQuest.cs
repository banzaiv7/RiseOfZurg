using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
- attached to quest giver
*/
public class RevengeQuest : MonoBehaviour 
{
	public GameObject player;

	//ui
	public GameObject exclamationMark;
	public GameObject grayQuestionMark;
	public GameObject yellowQuestionMark;
	public GameObject questCheckmark;
	
	//UI Variables
	public GameObject revSuccessPanel;
	public GameObject questBox;
	public GameObject questTrackerBox;
	public Text revQuestText;
	public Text revQuestTitleText;
	public Text revSuccessPanelText;
	//public Text revQuestTrackerText;

	//minimap indicators
	//public GameObject exPointMM;
	public GameObject qmPointMM;
	public GameObject cmPointMM;

	public bool buttonPressed;
	public GameObject buttonCollider;


	public void Talk()
	{
		if (!QuestManager.revengeIsActive) //If quest isn't already active
		{
			//Show quest prompt in UI
			QuestManager.revengeIsActive = true; //Activate quest
			Debug.Log("Revenge Quest activated");

			//ui
			//************************************************
			questBox.SetActive(true);
			revQuestText.text = "Aha, suh Gruz. I hear you have been collecting some parts to make a weapon. " +
				"Give them to me and I’ll install them on the photon cannon for you. " +
				"All you need to do then is head up to the command chamber and press the very ominous looking button.";
			revQuestTitleText.text = "The Zurgiac Killer";
			questTrackerBox.SetActive(true);
			//revQuestTrackerText.text = "- Generator Activated 0/1";
			
			exclamationMark.SetActive(false);
			grayQuestionMark.SetActive(true);
			//**************************************************
		}
		if (QuestManager.revengeComplete == true)
		{
			//appreciation dialogue
			Debug.Log ("I need a drink");
		}
		if(QuestManager.revengeIsActive == true)
		{
			Inventory inv = player.GetComponent<Inventory>();
			if(QuestManager.activationComplete == true && inv.targetComponent >= 1 && inv.laserComponent >= 1 && inv.prismComponent >= 1)
			{
				inv.targetComponent = 0;
				inv.laserComponent = 0;
				inv.prismComponent = 0;
				buttonCollider.SetActive(true);
				if(buttonPressed == true)
				{
					//success
					QuestManager.revengeComplete = true;
					Debug.Log ("revenge complete-ish");
					//********************************************
					//UI Stuff
					questBox.SetActive(true);
					revQuestTitleText.text = "The Zurgiac Killer";
					revQuestText.text = "What do you mean it didn’t fire?! Did you try turning it off and back on again? Ugh, I’ll have a look at it later, I need a drink. Come back to me tomorrow and we can figure this out.";
					//actQuestTrackerText.text = "- Generator Activated 1/1 \n\t\t\t- Return to R2D2.";
					
					
					//More UI stuff
					revSuccessPanel.SetActive(true);
					revSuccessPanelText.text = "The Zurgiac Killer Complete \n" +
						"Reward: A less broken space station than before";
					questTrackerBox.SetActive(false);
					
					//Checkmark
					yellowQuestionMark.SetActive(false);
					questCheckmark.SetActive(true);
					qmPointMM.SetActive(false);
					cmPointMM.SetActive(true);
					//********************************************
				}
			}
			else
			{
				return;
			}
		}
	}
}
