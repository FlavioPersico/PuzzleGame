using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private Transform point;
	[SerializeField] private Joint joint;
	public void OnHoverEnter()
	{
		
	}

	public void OnHoverExit()
	{
		
	}

	public void OnInteract(InteractModule module)
	{
		Debug.Log("Grab!");
		if(joint == null) 
		{
			transform.position = module.GetHoldTransform().position;
			transform.rotation = Quaternion.identity;

			joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = module.GetComponent<Rigidbody>();
		}
		else
		{
			Destroy(joint);
		}

		/*if(transform.parent == null)
		{
			rb.useGravity = false;
			rb.isKinematic = false;
			
			point = module.GetHoldTransform();
			transform.position = point.position;
			transform.rotation = point.rotation;
			transform.SetParent(point);
		}
		else
		{
			rb.useGravity = true;
			rb.isKinematic = true;
			transform.SetParent(null);
		}*/
	}

	private void Pick()
	{

	}

	private void Drop()
	{

	}
}
