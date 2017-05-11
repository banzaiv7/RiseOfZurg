using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
- attached to the QuestManager
*/
public class ActivationQuest : MonoBehaviour 
{
	public GameObject redFuel;
	public GameObject greenFuel;
	public GameObject blueFuel;
    public GameObject yellowFuel;

	//Quest Indicators
	public GameObject exclamationMark;
	public GameObject grayQuestionMark;
	public GameObject yellowQuestionMark;
	public GameObject questCheckmark;

	//UI Variables
	public GameObject actSuccessPanel;
	public GameObject questBox;
	public GameObject questTrackerBox;
	public Text actQuestText;
	public Text actQuestTitleText;
	public Text actSuccessPanelText;
	public Text actQuestTrackerText;

	//minimap indicators
	public GameObject exPointMM;
	public GameObject qmPointMM;
	public GameObject cmPointMM;

	public GameObject items;

	public GameObject LaserDoor1;
	public GameObject lights;

	void Start()
	{
		items.SetActive(false);
	}

	public void Talk()
	{
        if (!QuestManager.activationIsActive && !QuestManager.activationComplete) //If quest isn't already active and not complete
        {
            QuestManager.activationIsActive = true; //Activate quest
			items.SetActive(true);
            Debug.Log("Activation Quest activated");

			//UI Stuff
			//Sets the quest box in the bottom left corner on
			questBox.SetActive(true);
			//Sets the text in the quest box
			actQuestText.text = "Aha, suh Gruz. Can you help me fix the generator? " +
				"There should be some stuff around here to help. Fixing isn’t in my protocol, " +
					"I usually just come down here to get lubed up without the General seeing me. " +
					"Let me know when the deed is done.";
			//Sets the title of the quest box
			actQuestTitleText.text = "Gener-hater Activated";
			//Sets the quest tracker on the right side on
			questTrackerBox.SetActive(true);
			//Sets the quest tracker text
			actQuestTrackerText.text = "- Generator Activated 0/1";

			//Quest Indicator markers
			exclamationMark.SetActive(false);
			grayQuestionMark.SetActive(true);
        }
		if (QuestManager.activationComplete == true)
		{
			//appreciation dialogue
			Debug.Log ("go do other stuff");
		}
		if(QuestManager.activationIsActive == true)
		{
			Debug.Log ("find a way to restore power to the generators");

			if (redFuel.activeSelf && greenFuel.activeSelf && blueFuel.activeSelf && yellowFuel.activeSelf) //if all these objects are active...
			{
				//completion dialogue here
				Debug.Log ("generator is working");
				QuestManager.activationComplete = true;
				QuestManager.activationIsActive = false;

				//UI Stuff
				questBox.SetActive(true);
				actQuestTitleText.text = "Gener-hater Activated";
				actQuestText.text = "Looks like you got the generator working. I’ll power on the station for you...right this last can of lube.";
				actQuestTrackerText.text = "";


				//More UI stuff
				//Turns on the QUest success panel at the top
				actSuccessPanel.SetActive(true);
				//Sets the text of that panel
				actSuccessPanelText.text = "Gener-hater Activation Complete \n" +
					"Reward: Station Power Online";
				//Turns off the quest tracker on the right
				questTrackerBox.SetActive(false);

				//Checkmark
				grayQuestionMark.SetActive(false);
				yellowQuestionMark.SetActive(false);
				questCheckmark.SetActive(true);
				cmPointMM.SetActive(true);
				qmPointMM.SetActive(false);
				exPointMM.SetActive(false);

				//Opens the laser door
				LaserDoor1.SetActive(false);

				//turns on the lights
				lights.SetActive(true);
			} 
			else 
			{
				Debug.Log ("generator won't start");
				return;
			}
		}
	}
}
