using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] private Vector3 moveDirection;
	[SerializeField] private Vector2 aimDirection;
	[SerializeField] private Camera camera;
	[SerializeField] private CharacterController characterController;
	[SerializeField] private float speed;
	[SerializeField] private float sprintingMultiplier;
	[SerializeField] private float mouseSensitivity;
	[SerializeField] private Vector3 velocity;
	[SerializeField] private LayerMask floorLayer;

	public const float gravityAccelaration = -9.81f;
	private bool canLookWithMouse;

	// Start is called before the first frame update
	void Awake()
    {
		Cursor.lockState = CursorLockMode.Confined;
	}

	private void Start()
	{
		camera.transform.localEulerAngles = transform.localEulerAngles;
		aimDirection.y = 0;
		Invoke("EnableMouseInput", 1f);
	}
	private void EnableMouseInput()
	{
		canLookWithMouse = true;
	}

	void Update()
	{
		MovePlayer();

		if (canLookWithMouse)
		{
			RotatePlayer();
		}

		Jump();
		ApplyGravity();
	}

	private void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			velocity.y = 5f;
		}
	}

	private void ApplyGravity()
	{
		if(!IsGrounded()) //Check for collision on an imaginary sphere that we created
		{
			velocity.y += gravityAccelaration * Time.deltaTime;

			if (velocity.y < -9f)
			{
				velocity.y = -9f;
			}
		}
		else if(velocity.y < 0)
		{
			velocity.y = 0;
		}
		
		characterController.Move(velocity * Time.deltaTime);
	}

	private void RotatePlayer()
	{
		aimDirection.x = Input.GetAxisRaw("Mouse X");
		aimDirection.y += -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensitivity;

		//camera.transform.Rotate(Vector3.right, -aimDirection.y * Time.deltaTime * mouseSensitivity);

		aimDirection.y = Mathf.Clamp(aimDirection.y, -85f, 85f);
		camera.transform.localEulerAngles = new Vector3(aimDirection.y, 0, 0);
		transform.Rotate(Vector3.up, aimDirection.x * Time.deltaTime * mouseSensitivity);
	}

	private void MovePlayer()
	{
		moveDirection.x = Input.GetAxisRaw("Horizontal");
		moveDirection.z = Input.GetAxisRaw("Vertical");

		float tempMultiplier = 1;
		if (Input.GetKey(KeyCode.LeftShift))
		{
			tempMultiplier = sprintingMultiplier;
		}

		characterController.Move(((transform.right * moveDirection.x) + (transform.forward * moveDirection.z)) * Time.deltaTime * speed * tempMultiplier);
	}

	private bool IsGrounded()
	{
		return Physics.CheckSphere(transform.position, 0.25f, floorLayer);
	}
}
