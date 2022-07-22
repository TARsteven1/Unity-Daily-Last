using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio  {


	private AudioSource audioSource;

	public Player_Audio(AudioSource audioSource)
    {
		this.audioSource = audioSource;
    }

	//播放指定额音效
	public void PlayAudio(AudioClip audioClip)
    {
		audioSource.PlayOneShot(audioClip);
    }
	
}
