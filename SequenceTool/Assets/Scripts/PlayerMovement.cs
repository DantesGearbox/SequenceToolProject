using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;

	[SerializeField] private float movespeed = 5;
	public SequenceTool.MovementAction dash;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		dash.rigidbody2DReference = rb;
	}

	void Update()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");

		Vector3 inputVector = new Vector3(xInput, yInput);

		dash.direction = inputVector;

		rb.velocity = inputVector.normalized * movespeed;
	}
}
