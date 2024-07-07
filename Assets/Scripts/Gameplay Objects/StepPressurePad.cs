using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPressurePad : PressurePad
{
	[SerializeField] private Material highLightedMaterial;
	private MeshRenderer meshRenderer;
	private Material originalMaterial;
	private bool stepPadOn = false;
	private bool stepPadOffChecked = false;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		originalMaterial = meshRenderer.material;
	}

	private new void OnTriggerExit(Collider other) { } //null the trigger exit from PressurePad

	public bool GetNumberStepPadOn()
	{
		return stepPadOn;
	}

	public void SetStepPadOffChecked()
	{
		stepPadOffChecked = true;
	}
	public bool GetStepPadOffChecked()
	{
		return stepPadOffChecked;
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
