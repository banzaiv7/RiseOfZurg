using UnityEngine;
using System.Collections;

public class RevengeOperator : MonoBehaviour 
{
	public RevengeQuest rev;
	public GameObject button;

	void OnTriggerStay(Collider other)
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(other.name == "ButtonCollider"  && rev.buttonPressed == false)
			{
				button.transform.Translate(0.0f, -0.25f, 0.0f);
				rev.buttonPressed = true;
			}
		}
	}
}
