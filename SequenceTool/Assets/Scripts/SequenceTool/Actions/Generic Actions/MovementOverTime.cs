using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	/// <summary>
	/// MovementOverTime is imprecise. If you need very precise movement use MovementOverFixedTime
	/// </summary>
	public class MovementOverTime : OverTimeAction
	{
		[Header("A header")]
		public Rigidbody2D rigidbody2DReference;
		
		public Vector3 movementVectorInput;

		public bool useInputAsDirection = false;
		public bool useReverseVector = false;
		
		public Vector2 direction;
		public float distance;
		
		private Vector2 moveDirection;

		private Vector2 onEnterValue;

		private Vector2 startPosition;
		private Vector2 endPosition;

		public override void StartAction()
		{
			base.StartAction();

			moveDirection = direction.normalized;
			if (useInputAsDirection)
			{
				moveDirection = movementVectorInput.normalized;
			}
			if (useReverseVector)
			{
				moveDirection = (movementVectorInput * -1.0f).normalized;
			}

			startPosition = rigidbody2DReference.position;
			endPosition = startPosition + moveDirection * distance; //This position can't quite be expected since collision with other objects might stop it
		}

		public override void EndAction()
		{
			base.EndAction();
			UpdateValue();
		}

		protected override void UpdateValue()
		{
			float timeForwards = 0.05f;

			float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			float normalizedTimerForward = normalizedTimer + timeForwards;

			Vector2 currentPosition = rigidbody2DReference.position;
			Vector2 nextPosition = Vector2.Lerp(startPosition, endPosition, normalizedTimerForward);

			Vector2 diff = nextPosition - currentPosition;
			
			Debug.Log("NormalizedTimer: " + normalizedTimer + ", NewVelocity: " + (diff * (1 / timeForwards)).ToString("F4") + ", CurrentPos: " + currentPosition.ToString("F4") + ", NextPos: " + nextPosition.ToString("F4") + ", Diff:" + diff.ToString("F4"));

			rigidbody2DReference.velocity = diff * (1/timeForwards);
		}

		protected override void RestoreOriginalValue()
		{
			rigidbody2DReference.velocity = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			rigidbody2DReference.velocity = Vector2.zero;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = rigidbody2DReference.velocity;
		}
	}
}