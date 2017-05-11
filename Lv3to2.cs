using UnityEngine;
using System.Collections;

public class Lv3to2 : MonoBehaviour 
{
	public GameObject level2Music;
	public GameObject level3Music;
	
	
	void OnTriggerEnter()
	{
		if(level3Music.activeSelf == true)
		{
			level2Music.SetActive(true);
			level3Music.SetActive(false);
		}
	}
}
