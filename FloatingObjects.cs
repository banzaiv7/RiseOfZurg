using UnityEngine;
using System.Collections;

public class FloatingObjects : MonoBehaviour {

	public float initialY;
	private float _speed = 0.25f;
	Vector3 _direction = Vector3.up;
	
	void Start()
	{
		initialY = transform.position.y;
	}
	
	void Update()
	{
		transform.Translate (_direction * _speed * Time.deltaTime);
		
		if (transform.position.y >= (initialY + 0.3f)) 
		{
			_direction = -_direction; //inverse direction
		}
		
		if (transform.position.y <= (initialY)) 
		{
			_direction = -_direction;
		}
	}
}
