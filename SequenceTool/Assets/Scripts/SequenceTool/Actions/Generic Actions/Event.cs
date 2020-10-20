using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceTool
{
	[System.Serializable]
	public class Event
	{
		public float startingTime = 0;
		[HideInInspector] public bool hasInvoked = false;

		public UnityEvent unityEvent;
	}
}
