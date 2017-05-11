using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 6.0f;
	public float gravity = 9.8f;
	public float jumpSpeed = 8.0f;

	Vector3 direction = Vector3.zero;

	void Update()
	{
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) 
		{
			direction = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			direction = transform.TransformDirection (direction);
			direction *= speed;
			if(Input.GetButton ("Jump"))
			{
				direction.y = jumpSpeed;
			}
		}
		direction.y -= gravity * Time.deltaTime;
		controller.Move (direction * Time.deltaTime);
	}
}
