using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
	[SerializeField] private Rigidbody correctRigibody;
	[SerializeField] private UnityEvent OnInteracted;
	private void OnTriggerEnter(Collider other)
	{
		if(other.attachedRigidbody == correctRigibody)
		{
			OnInteracted.Invoke();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.attachedRigidbody == correctRigibody)
		{
			OnInteracted.Invoke();
		}
	}
}
