using UnityEngine;
using System.Collections;

public class Lvl2to3 : MonoBehaviour 
{

	public GameObject level2Music;
	public GameObject level3Music;


	void OnTriggerEnter()
	{
		if(level2Music.activeSelf == true)
		{
			level2Music.SetActive(false);
			level3Music.SetActive(true);
		}
	}
}
