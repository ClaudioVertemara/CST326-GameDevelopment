using UnityEngine;
using System.Collections;

public class MusicBg : MonoBehaviour {
	public AudioClip[] soundtrack;
	
	void Start ()
	{
		if (!GetComponent<AudioSource>().playOnAwake)
		{
			GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)];
			GetComponent<AudioSource>().Play();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)];
			GetComponent<AudioSource>().GetComponent<AudioSource>().Play();
		}
	}
}
//By Ethan Herndon
