using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomNumber4 : MonoBehaviour
{
    [SerializeField] private List<PressurePad> pressurePad = new List<PressurePad>();
	[SerializeField] private int amountOfCopiesPressed = 0;
	[SerializeField] private UnityEvent OnPuzzleCompleted;
	[SerializeField] private bool roomCompleted;
	[SerializeField] private AudioClip pressureAudio;

	private void Awake()
	{
		//var amountOfCopies = FindObjectsOfType<PressurePad>();
		var amountOfCopies = this.GetComponentsInChildren<PressurePad>();
		for (int i = 0; i < amountOfCopies.Length; i++)
		{
			pressurePad.Add(amountOfCopies[i]);
		}
	}

	private void Update()
	{
		if(CheckNumberPadOn() == pressurePad.Count && !roomCompleted)
		{
			Debug.Log("Open Door");
			SoundControl.audioPlayer.PlayOneShot(pressureAudio, 10f);
			OnPuzzleCompleted.Invoke();
			RoomCompleted();
		}
	}

	private void RoomCompleted()
	{
		for (int i = 0; i < pressurePad.Count; i++)
		{
			pressurePad[i].GetComponent<BoxCollider>().enabled = false;
			roomCompleted = true;
		}
	}

	private int CheckNumberPadOn()
	{
		for (int i = 0; i < pressurePad.Count; i++)
		{
			if (pressurePad[i].GetComponent<StepPressurePad>().GetNumberStepPadOn() && !pressurePad[i].GetComponent<StepPressurePad>().GetStepPadOffChecked())
			{
				amountOfCopiesPressed++;
				pressurePad[i].GetComponent<StepPressurePad>().SetStepPadOffChecked();
			}
		}
		return amountOfCopiesPressed;
	}
}
