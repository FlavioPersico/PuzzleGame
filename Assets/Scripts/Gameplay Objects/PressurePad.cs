using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PressurePad : MonoBehaviour
{
	[SerializeField] protected Rigidbody correctRigibody;
	[SerializeField] protected UnityEvent OnInteracted;
	public void OnTriggerEnter(Collider other)
	{
		if(other.attachedRigidbody == correctRigibody)
		{
			OnInteracted.Invoke();
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.attachedRigidbody == correctRigibody)
		{
			OnInteracted.Invoke();
		}
	}
}
