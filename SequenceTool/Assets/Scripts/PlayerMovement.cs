using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;

	[SerializeField] private float movespeed = 5;

	public SequenceTool.Sequence dashSequence;
	//public SequenceTool.InterpolationValue dashInterpolation;

	private Vector3 nonZeroDirection = Vector2.zero;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");

		Vector3 inputVector = new Vector3(xInput, yInput);

		if(inputVector != Vector3.zero)
		{
			nonZeroDirection = inputVector;
		}

		rb.velocity = inputVector.normalized * movespeed;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			dashSequence.StartSequence();
		}
	}

	public void DashMovement()
	{

	}

	public void PostMessage1()
	{
		Debug.Log("Message 1 was triggered by an event");
	}

	public void PostMessage2()
	{
		Debug.Log("Message 2 was triggered by an event");
	}
}
