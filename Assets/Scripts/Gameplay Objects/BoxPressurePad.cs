using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPressurePad : PressurePad
{
	[SerializeField] private AudioClip pressureAudio;

	private void OnTriggerEnter(Collider other)
	{
		SoundControl.audioPlayer.PlayOneShot(pressureAudio, 10f);
		base.OnTriggerEnter(other);
	}
}
