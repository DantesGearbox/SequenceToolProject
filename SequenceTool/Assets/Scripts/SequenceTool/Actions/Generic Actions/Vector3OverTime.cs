﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class Vector3OverTime : OverTimeAction
	{
		public Vector3 vectorReference;
		public Vector3 startValue;
		public Vector3 endValue;

		private Vector3 onEnterValue;

		protected override void RestoreOriginalValue()
		{
			vectorReference = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			vectorReference = endValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = vectorReference;
		}

		protected override void UpdateValue()
		{
			float normalizedTimer = Utility.NormalizeTo01Scale(0, actionDuration, actionTimer);
			vectorReference = Vector3.Lerp(startValue, endValue, normalizedTimer);
		}
	}
}