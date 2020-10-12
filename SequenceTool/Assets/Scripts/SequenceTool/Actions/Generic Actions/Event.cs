using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceTool
{
	public class Event : Action
	{
		[Header("Event settings")]
		public UnityEvent unityEvent;

		public override void StartAction()
		{
			isExecuting = true;
			unityEvent.Invoke();
			EndAction();
		}

		public override void EndAction()
		{
			isExecuting = false;
			hasExecuted = true;
		}
	}
}
