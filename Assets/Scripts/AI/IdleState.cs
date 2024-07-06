using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIState
{
	public IdleState(AIController contr) : base(contr)
	{
	}

	public override void OnStateEnter()
	{
		Debug.Log("Idle Mode! - ON");
	}

	public override void OnStateExit()
	{
		Debug.Log("Idle Mode! - OFF");
	}

	public override void OnStateRun()
	{
	
	}
}
