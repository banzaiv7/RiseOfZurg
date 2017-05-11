using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour 
{
	void Update () 
	{
		if(QuestManager.searchComplete == true && QuestManager.repairComplete == true && QuestManager.collectionComplete == true)
		{
			this.gameObject.SetActive(false);
		}
	}
}
