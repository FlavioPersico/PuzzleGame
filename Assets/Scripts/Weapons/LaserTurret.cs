using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
	[SerializeField] private LaserLine laserLine;
	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private AIController myController;
	private bool attacking;
	private bool turretOn = false;

	void Update()
	{
		if (turretOn)
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
				if (attacking == true)
				{
					myController.ChangeState(new IdleState(myController));
				}
				attacking = false;
			}
		}
	}

	public void TurretOnOff()
	{
		if (turretOn == true)
		{
			turretOn = false;
			laserLine.LaserOnOff(turretOn);
			laserLine.enabled = false;
			particleSystem.Stop();
		}
		else
		{
			turretOn = true;
			laserLine.gameObject.SetActive(turretOn);
			laserLine.LaserOnOff(turretOn);
			laserLine.enabled = true;
			particleSystem.Play();
		}
	}
}
