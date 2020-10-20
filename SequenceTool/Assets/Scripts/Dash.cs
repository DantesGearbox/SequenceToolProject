using UnityEngine;

public class Dash : MonoBehaviour
{
	public float distance = 3.0f;
	public float duration = 0.25f;

	private SequenceTool.InterpolationValue interpolationValue;
	private Rigidbody2D rb;
	private Vector3 nonZeroVelocity = Vector2.right;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		interpolationValue = GetComponent<SequenceTool.InterpolationValue>();
	}

	void Update()
	{
		Vector3 vel = rb.velocity;

		if(vel.magnitude > 0 && !interpolationValue.isExecuting)
		{
			nonZeroVelocity = vel.normalized;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!interpolationValue.isExecuting)
			{
				interpolationValue.Run(0, distance, duration);
			}
		}
	}

	private void FixedUpdate()
	{
		if (interpolationValue.isExecuting)
		{
			float moveVelo = interpolationValue.GetValueChangeOverASecond();
			rb.velocity = nonZeroVelocity * moveVelo;
		}
	}
}