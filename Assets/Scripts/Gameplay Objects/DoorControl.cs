using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class DoorControl : MonoBehaviour
{
	[SerializeField] private Transform doorOpenPosition;
	[SerializeField] private Transform doorClosedPosition;
	[SerializeField] private float moveSpeed = 0.1f;

	private bool doorOpen = false;
	

	private void Start()
	{
		
	}

	public void ControlDoor()
	{
		if (doorOpen == false) OpenDoor(); else CloseDoor();
	}

	IEnumerator MoveDoor(Vector3 goalPos)
	{
		float distance = Vector3.Distance(transform.position, goalPos); ;
		while(distance > 0.1f)
		{
			transform.position = Vector3.Lerp(transform.position, goalPos, moveSpeed * Time.deltaTime);
			distance = Vector3.Distance(transform.position, goalPos);
			yield return new WaitForSeconds(.5f);
		}
	}

	public void OpenDoor()
	{
		StartCoroutine(MoveDoor(doorOpenPosition.position));
		doorOpen = true;
	}

	public void CloseDoor()
	{
		StartCoroutine(MoveDoor(doorClosedPosition.position));
		doorOpen = false;
	}
}
