using UnityEngine;
using System.Collections;

public static class QuestManager
{
	public static bool activationComplete = false;
	
	public static bool searchComplete = false;
	public static bool repairComplete = false;
	public static bool collectionComplete = false;
	public static bool revengeComplete = false;
	
	//for UI purposes
		//if [quest]IsActive = true, show in Quest Tracker
	public static bool activationIsActive = false; 
	public static bool searchIsActive = false;			//set to true once player accepts quests
	public static bool repairIsActive = false;
	public static bool collectionIsActive = false;
	public static bool revengeIsActive = false;
}
