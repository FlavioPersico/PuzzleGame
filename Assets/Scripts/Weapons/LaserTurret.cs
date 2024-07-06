using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
	[SerializeField] private LaserLine laserLine;
	[SerializeField] private AIController myController;
	private bool attacking;
	private bool turretOn;

	private void Start()
	{
		turretOn = true;
		//laserLine = FindObjectOfType<LaserLine>();
		//myController = FindObjectOfType<AIController>();
	}
	void Update()
	{
		if (laserLine.objectCollision == true && laserLine.playerCollision == true)
		{
			if (attacking == false)
			{
				myController.ChangeState(new AttackState(myController));
			}
			attacking = true;
		}
		else
		{
			myController.ChangeState(new IdleState(myController));
			attacking = false;
		}
	}

	public void TurretOnOff()
	{
		if (turretOn == true)
		{
			turretOn = false;
			laserLine.LaserOnOff(turretOn);
			laserLine.enabled = false;
		}
		else
		{
			turretOn = true;
			laserLine.gameObject.SetActive(turretOn);
			laserLine.LaserOnOff(turretOn);
			laserLine.enabled = true;
		}
	}
}
