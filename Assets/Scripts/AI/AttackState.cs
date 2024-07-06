using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : AIState
{
	private float time;
	private float timer;
	private float delayTime = 0.5f;
	public void Start()
	{
		timer = delayTime;
	}
	public AttackState(AIController contr) : base(contr)
	{
	}
	public override void OnStateEnter()
	{
		Debug.Log("Attack Mode! - ON");
	}

	public override void OnStateExit()
	{
		Debug.Log("Attack Mode! - OFF");

	}

	public override void OnStateRun()
	{
		time = Time.time;
		if (time > timer)
		{
			controller.GetPlayer().ReceiveDamage(1);
			timer = time + delayTime;
		}
	}
}
