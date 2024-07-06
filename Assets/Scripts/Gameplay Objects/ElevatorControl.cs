using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : MonoBehaviour
{
	[SerializeField] private Animator animator;

	public void ElevatorController()
	{
		if (animator != null)
		{
			if (animator.GetBool("ElevatorUp") == false) ElevatorUp(); else ElevatorDown();
		}
	}

	public void ElevatorUp()
	{
		animator.SetBool("ElevatorUp", true);
	}

	public void ElevatorDown()
	{
		animator.SetBool("ElevatorUp", false);
	}
}
