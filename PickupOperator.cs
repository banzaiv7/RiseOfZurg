using UnityEngine;
using System.Collections;
/*
 - attached to player
*/
public class PickupOperator : MonoBehaviour 
{
	public float radius = 1.5f;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
			foreach (Collider hitCollider in hitColliders)
			{
				Vector3 direction = hitCollider.transform.position - transform.position;
				if (Vector3.Dot(transform.forward, direction) > .5f)
				{
					hitCollider.SendMessage("PickUp", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
