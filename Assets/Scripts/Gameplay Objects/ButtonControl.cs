using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour, IInteractable
{
	[SerializeField] private Material highLightedMaterial;
	[SerializeField] private string collisionTag;

	public UnityEvent OnInteracted;
	private MeshRenderer meshRenderer;
	private Material originalMaterial;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		originalMaterial = meshRenderer.material;
	}

	public void OnHoverEnter()
	{
		meshRenderer.material = highLightedMaterial;
		Debug.Log("Aiming the button");
	}

	public void OnHoverExit()
	{	
		meshRenderer.material = originalMaterial;
		Debug.Log("Aiming out of the button");
	}

	public void OnInteract(InteractModule module)
	{
		OnInteracted.Invoke();
		Debug.Log("Pressing the button");
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag(collisionTag))
		{
			OnInteracted.Invoke();
			Debug.Log("Trigger the button");
		}
	}
}
