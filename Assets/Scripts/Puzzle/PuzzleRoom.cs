using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleRoom : MonoBehaviour
{
	[SerializeField] private bool isCurrentPuzzle;
	[SerializeField] private bool isCompleted;
	[SerializeField] private UnityEvent OnPuzzleCompleted;
	private void OnTriggerEnter(Collider other)
	{
		isCurrentPuzzle = true; 
	}

	private void OnTriggerExit(Collider other)
	{
		if(isCompleted && isCurrentPuzzle)
		{
			ExitedAndFinishedPluzze();
		}
		isCurrentPuzzle = false;
	}

	private void ExitedAndFinishedPluzze()
	{
		OnPuzzleCompleted?.Invoke();
		Destroy(gameObject);
	}
}
