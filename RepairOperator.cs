using UnityEngine;
using System.Collections;

public class RepairOperator : MonoBehaviour 
{
	public GameObject battery;
	public GameObject sPump;

	public GameObject qmPointMM;
	public GameObject exPointMM;

	void OnTriggerStay(Collider other)
	{
		if(other.name == "BatteryCollider")
		{
			Inventory inv = GetComponent<Inventory>();
			if(Input.GetKeyDown(KeyCode.E) && inv.battery >= 1)
			{
				inv.battery = 0;
				sPump.GetComponent<MovingPlatform>().enabled = true;
				battery.SetActive(true);
				RepairQuest rep = GameObject.Find ("C-3PO").GetComponent<RepairQuest>();
				rep.tasksCompleted++;
				exPointMM.SetActive(false);
				qmPointMM.SetActive(true);
			}
		}
	}
}
