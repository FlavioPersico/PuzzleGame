using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPressurePad : MonoBehaviour
{
	[SerializeField] private Material highLightedMaterial;
	private MeshRenderer meshRenderer;
	private Material originalMaterial;
	private bool stepPadOn = false;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		originalMaterial = meshRenderer.material;
	}

	public void ControlOnOffStepPad()
	{
		if (stepPadOn == false) OnStepPad(); else OffStepPad();
	}

	public void OnStepPad()
	{
		meshRenderer.material = highLightedMaterial;
		stepPadOn = true;
	}
	public void OffStepPad()
	{
		meshRenderer.material = originalMaterial;
		stepPadOn = false;
	}
}
