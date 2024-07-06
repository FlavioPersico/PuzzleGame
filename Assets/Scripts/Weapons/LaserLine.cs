using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserLine : MonoBehaviour
{
    [SerializeField] private LineRenderer lineLaser;
	[SerializeField] private Transform startPosition;
	[SerializeField] private Vector3 startPositionParam;
	[SerializeField] private Transform finalPosition;
	[SerializeField] private Vector3 originalFinalPosition;
	[SerializeField] private float laserSize = 2f;
	[SerializeField] private float laserDistance = 2f;
	[SerializeField] private LayerMask maskPlayer;
	public bool objectCollision { get; private set; }
	public bool playerCollision { get; private set; }
	private Color c1 = Color.yellow;
	private Color c2 = Color.red;
	private RaycastHit hit;


	private void Start()
	{
		laserSize = laserSize > startPosition.position.z ? laserSize : (startPosition.position.z + 0.1f);

		startPositionParam = startPosition.position;
		originalFinalPosition = finalPosition.position;
		lineLaser.material = new Material(Shader.Find("Sprites/Default"));

		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
			);
		lineLaser.colorGradient = gradient;
	}
	private void FixedUpdate()
	{
		if (lineLaser != null)
		{
			lineLaser.SetPosition(0, startPosition.position);
			lineLaser.SetPosition(1, finalPosition.position);
			laserDistance = Vector3.Distance(startPosition.position, finalPosition.position);
			objectCollision = LaserCollision();
		}
	}

	private bool LaserCollision()
	{
		if (Physics.Raycast(startPosition.position, startPosition.TransformDirection(Vector3.forward), out hit, laserDistance, maskPlayer))
		{
			Debug.DrawRay(startPosition.position, startPosition.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
			finalPosition.position = new Vector3(startPosition.position.x, startPosition.position.y, hit.transform.position.z); //(startPosition.TransformDirection(Vector3.forward) * hit.distance);
			playerCollision = PlayerCollision(hit.distance);
			return true;
		}
		else
		{
			Debug.DrawRay(startPosition.position, startPosition.TransformDirection(Vector3.forward) * laserDistance, Color.white);
			finalPosition.position = originalFinalPosition;
			lineLaser.SetPosition(1, finalPosition.position);
			return false;
		}
	}

	private bool PlayerCollision(float collisionDistance)
	{
		if (Physics.Raycast(startPosition.position, startPosition.TransformDirection(Vector3.forward), collisionDistance, maskPlayer))
		{
			return true;
		}
		return false;
	}

	public void LaserOnOff(bool OnParam)
	{
		lineLaser.SetPosition(1, startPosition.position);
	}
}
