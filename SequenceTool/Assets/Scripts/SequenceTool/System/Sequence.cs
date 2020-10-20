using UnityEngine;

namespace SequenceTool
{
	public class Sequence : MonoBehaviour
	{
		[Header("Properties")]
		public bool invokeAllBeforeNextExecution = true;

		[HideInInspector]
		public bool sequenceIsExecuting = false;

		[Header("Timed events")]
		public Event[] events;

		private float timer = 0;

		private void Update()
		{
			//Invoke relevant events
			foreach (Event e in events)
			{
				if (timer > e.startingTime && !e.hasInvoked)
				{
					e.unityEvent.Invoke();
					e.hasInvoked = true;
				}
			}

			//Stop sequence if all events have been invoked
			if (HasAllEventsInvoked())
			{
				StopSequence();
			}

			//Update timer
			if (sequenceIsExecuting)
			{
				timer += Time.deltaTime;
			}
		}

		private bool HasAllEventsInvoked()
		{
			bool hasInvoked = true;
			foreach (Event e in events)
			{
				if (!e.hasInvoked)
				{
					hasInvoked = false;
				}
			}
			return hasInvoked;
		}

		public void StopSequence()
		{
			sequenceIsExecuting = false;
			timer = 0;
		}

		public void StartSequence()
		{
			if(invokeAllBeforeNextExecution && sequenceIsExecuting) { return; }
			ResetAllEvents();
			sequenceIsExecuting = true;
			timer = 0;
		}

		private void ResetAllEvents()
		{
			foreach (Event e in events)
			{
				e.hasInvoked = false;
			}
		}
	}
}
