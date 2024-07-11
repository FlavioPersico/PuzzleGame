using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleRoom : MonoBehaviour
{
	[SerializeField] private bool isCurrentPuzzle;
	[SerializeField] public bool isCompleted { get; private set; }
	[SerializeField] private UnityEvent OnPuzzleCompleted;
	[SerializeField] private GameObject puzzleRoomNumber;

	public void RoomCompleted()
	{
		isCompleted = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		isCurrentPuzzle = true; 
	}

	private void OnTriggerExit(Collider other)
	{
		if(isCompleted && isCurrentPuzzle)
		{
			ExitedAndFinishedPluzzle();
		}
		isCurrentPuzzle = false;
	}

	private void ExitedAndFinishedPluzzle()
	{
		OnPuzzleCompleted?.Invoke();
		Destroy(this);
	}
}
