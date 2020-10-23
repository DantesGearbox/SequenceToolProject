using UnityEngine;
using UnityEngine.Events;

namespace SequenceTool
{
	public class InterpolationValue : MonoBehaviour
	{
		[Header("Properties")]
		public float fromValue = 0;
		public float toValue = 0;
		public float duration = 0;

		[Header("Events")]
		public UnityEvent startEvent;
		public UnityEvent endEvent;

		[Header("Not implemented yet")]
		public bool loop = false; 
		public bool pingpong = false;
		public bool finishBeforeRestart = false;
		public TweenType tweenType;
		//public TweenType.TweenTypes tweenType;
		//public AnimationCurve curve;

		[Header("Make private later")]
		public float interpolationValue = 0;
		public float timer = 0;
		public bool isExecuting = false;

		private float absoluteValueChange = 0;
		private float valueChangeOverASecond = 0;

		private void FixedUpdate()
		{
			if (!isExecuting) { return; }

			UpdateValue();
			UpdateTimer();
		}

		private void Start()
		{
			interpolationValue = fromValue;
		}

		private void UpdateValue()
		{
			float timeForwards = Time.deltaTime;

			float normalizedTimer = Utility.NormalizeTo01Scale(0, duration, timer);
			float normalizedTimerForward = Utility.NormalizeTo01Scale(0, duration, timer + timeForwards);

			float currentValue = Mathf.Lerp(fromValue, toValue, normalizedTimer);
			float nextValue = Mathf.Lerp(fromValue, toValue, normalizedTimerForward);

			absoluteValueChange = nextValue - currentValue;
			valueChangeOverASecond = absoluteValueChange * (1 / timeForwards);

			interpolationValue += absoluteValueChange;
		}

		private void UpdateTimer() 
		{
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

		public void Run(float from, float to, float time)
		{
			fromValue = from;
			toValue = to;
			duration = time;
			isExecuting = true;

			startEvent.Invoke();
		}

		public void End()
		{
			isExecuting = false;
			timer = 0;
			interpolationValue = fromValue;

			endEvent.Invoke();
		}

		public float GetInterplationValue()
		{
			return interpolationValue;
		}

		public float GetAbsoluteValueChange()
		{
			return absoluteValueChange;
		}

		public float GetValueChangeOverASecond()
		{
			return valueChangeOverASecond;
		}
	}
}
