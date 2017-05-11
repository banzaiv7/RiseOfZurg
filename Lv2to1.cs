using UnityEngine;
using System.Collections;

public class Lv2to1 : MonoBehaviour 
{
	public GameObject basementMusic;
	public GameObject level2Music;

	void OnTriggerEnter()
	{
		if(level2Music.activeSelf == true)
		{
			basementMusic.SetActive(true);
			level2Music.SetActive(false);
		}
	}
}
