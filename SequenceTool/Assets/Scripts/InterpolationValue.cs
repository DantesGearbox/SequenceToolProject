using UnityEngine;

namespace SequenceTool
{
	public class InterpolationValue : MonoBehaviour
	{
		[Header("Properties")]
		public float valueStart = 0;
		public float valueEnd = 0;
		public float duration = 0;

		[Header("Not implemented yet")]
		public bool loop = false; 
		public bool pingpong = false;
		public bool finishBeforeRestart = false;
		public TweenType.TweenTypes tweenType;

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
			interpolationValue = valueStart;
		}

		private void UpdateValue()
		{
			float timeForwards = Time.deltaTime;

			float normalizedTimer = Utility.NormalizeTo01Scale(0, duration, timer);
			float normalizedTimerForward = Utility.NormalizeTo01Scale(0, duration, timer + timeForwards);

			float currentValue = Mathf.Lerp(valueStart, valueEnd, normalizedTimer);
			float nextValue = Mathf.Lerp(valueStart, valueEnd, normalizedTimerForward);

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
		}

		public void Run(float startVal, float endVal, float dur)
		{
			valueStart = startVal;
			valueEnd = endVal;
			duration = dur;
			isExecuting = true;
		}

		public void End()
		{
			isExecuting = false;
			timer = 0;
			interpolationValue = 0;
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
