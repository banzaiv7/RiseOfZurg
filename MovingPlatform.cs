using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
	public float initialY;
	public float _speed = 1.5f;
	public float maxHeight = 12.0f;
	public float minHeight = 0.0f;

	Vector3 _direction = Vector3.up;

	void Start()
	{
		initialY = transform.position.y;
	}

	void Update()
	{
		transform.Translate (_direction * _speed * Time.deltaTime);

		if (transform.position.y > (initialY + maxHeight)) 
		{
			//Wait();
			_direction = -_direction; //inverse direction
		}

		if (transform.position.y < (initialY - minHeight)) 
		{
			//Wait ();
			_direction = -_direction;
		}
	}
	/*
	void Wait()
	{
		float secondsToWait = 3.0f;
		secondsToWait -= Time.deltaTime;
		if(secondsToWait > 0)
		{
			_speed = 0;
		}
		else
		{
			_speed = 1.5f;
		}
	}
	*/
}
