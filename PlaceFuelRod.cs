using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
- attached to player
- checks the name of the collider the player enters
- sets the corresponding object active
 */
public class PlaceFuelRod : MonoBehaviour 
{
	public GameObject redFuel;
	public GameObject greenFuel;
	public GameObject blueFuel;
	public GameObject yellowFuel;

	public GameObject yellowQuestion;
	public GameObject grayQuestion;
	public Text actQuestTrackerText;

	public GameObject qmPointMM;
	public GameObject exPointMM;

	//bool readyTurnIn = false;

	void Start()
	{
		redFuel.SetActive(false);
		greenFuel.SetActive(false);
		blueFuel.SetActive(false);
		yellowFuel.SetActive(false);
	}
	void Update()
	{
		if (QuestManager.activationIsActive == true) 
		{
			if (redFuel.activeSelf == true && greenFuel.activeSelf == true && blueFuel.activeSelf == true && yellowFuel.activeSelf == true) 
			{
				//readyTurnIn = true;
				yellowQuestion.SetActive (true);
				grayQuestion.SetActive (false);
				exPointMM.SetActive(false);
				qmPointMM.SetActive(true);
				actQuestTrackerText.text = "- Generator Activated 1/1 \n\t\t\t- Return to R2D2.";
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			Inventory inv = GetComponent<Inventory> ();
			if (other.name == "Red Power Collider") 
			{
				if (inv.redFuelRod >= 1) 
				{
					redFuel.SetActive (true);
					inv.redFuelRod = 0;
                    Debug.Log("Red fuel rod placed");

				}
				else
				{
					Debug.Log ("Don't have red fuel");
				}
			} 
			else if (other.name == "Green Power Collider") 
			{
				if (inv.greenFuelRod >= 1) 
				{
					greenFuel.SetActive (true);
					inv.greenFuelRod = 0;
                    Debug.Log("Green fuel rod placed");

				} 
				else 
				{
					Debug.Log ("Don't have green fuel");
				}
			} 
			else if (other.name == "Blue Power Collider") 
			{
				if (inv.blueFuelRod >= 1) 
				{
					blueFuel.SetActive (true);
					inv.blueFuelRod = 0;
                    Debug.Log("Blue fuel rod placed");
				} 
				else
				{
					Debug.Log ("Don't have blue fuel");
				}
			}
			else if(other.name == "Yellow Power Collider")
			{
				if(inv.yellowFuelRod >= 1)
				{
					yellowFuel.SetActive(true);
					inv.yellowFuelRod = 0;
                    Debug.Log("Yellow fuel rod placed");

				}
				else
				{
					Debug.Log ("Don't have yellow fuel");
				}
			}
			else 
			{
				return;
			}
		}
	}
}
