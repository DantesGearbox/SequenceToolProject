using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	[Header("Properties")]
	public float duration = 0;

	[Header("Not implemented yet")]
	public bool loop = false;
	public bool pingpong = false;
	public bool finishBeforeRestart = false;

	private float timer = 0;
	private bool isExecuting = false;

	private UnityEvent startEvent;
	private UnityEvent endEvent;

	private void FixedUpdate()
	{
		if (!isExecuting) { return; }
		timer += Time.deltaTime;
		if (timer > duration)
		{
			End();
		}
	}

	public void Run()
	{
		isExecuting = true;
		startEvent.Invoke();
	}

	public void End()
	{
		isExecuting = false;
		timer = 0;
		endEvent.Invoke();
	}
}
