using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : AIState
{
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
		controller.GetPlayer().ReceiveDamage(1);
	}
}
