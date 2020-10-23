using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public float timer = 0;
	public bool counting = false;

	private void FixedUpdate()
	{
		if(!counting) { return; }
		timer += Time.deltaTime;
	}

	public void Run()
	{
		counting = true;
	}

	public void End()
	{
		counting = false;
	}
}
