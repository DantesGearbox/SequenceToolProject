using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;

	[SerializeField] private float movespeed = 5;
	public SequenceTool.MovementAction dash;

	public SequenceTool.Sequence dashSeq;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		dash.rigidbody2DReference = rb;

		//The above thing is nice. It is a way to reference the specific action from a sequence that we want to influece.
		//However, it is a little annoying that you have to set up this kind of behavior both in the sequence for the
		//	settings of the jump, and also in here, to make it reference the right things. It is also annoying that this is
		//	used both to have references, but also to give data to sequence in the form of which direction to dash.
		//What we have here is basically THREE seperate systems. The sequence, which starts a lerp, which is controlled by
		//	the player script. The fact that the sequence and the lerp/action are seperate things is important to keep in mind.
		//The code and the project should make sure to reflect that. It is a sequence that activates actions. You first set up
		//	the sequence of events and then you set up multiple actions that get fired by those events.
		//It would be nice to have more seperation between those two. Don't have it all in one list. Make one list of events,
		//	that also says the name of their actions, and then a seperate list to specify those actions in more detail.
	}

	void Update()
	{
		float xInput = Input.GetAxisRaw("Horizontal");
		float yInput = Input.GetAxisRaw("Vertical");

		Vector3 inputVector = new Vector3(xInput, yInput);

		dash.direction = inputVector;

		rb.velocity = inputVector.normalized * movespeed;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			dashSeq.StartSequence();
		}
	}

	public void PostMessageOnEvent()
	{
		Debug.Log("This message was triggered by an event");
	}
}
