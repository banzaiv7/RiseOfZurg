using UnityEngine;
using System.Collections;

public class Lvl1to2 : MonoBehaviour 
{
    //public AudioClip level1;
    //public AudioClip level2;
    public GameObject basementMusic;
	public GameObject level2Music;
    //bool playSound;

    void OnTriggerEnter()
    {
		if(basementMusic.activeSelf == true)
		{
			basementMusic.SetActive(false);
			level2Music.SetActive(true);
		}
        //AudioSource.PlayClipAtPoint(level2, transform.position);
    }


    //void Start()
    //{
    //    playSound = true;
    //    AudioSource.PlayClipAtPoint(level1, transform.position);
    //}

    //void Update()
    //{
    //    if (playSound == true)
    //    {
    //        AudioSource.PlayClipAtPoint(level1, transform.position);
    //    }
    //    else
    //    {
    //        AudioSource.PlayClipAtPoint(level2, transform.position);
    //    }
    //}
    //void OnTriggerEnter()
    //{
    //    playSound = false;
    //}

}
