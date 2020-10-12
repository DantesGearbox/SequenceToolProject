using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SequenceTool
{
	public class BoolEnabledSwitch : SwitchAction
	{
		//Let's try making events that you can register GOs and functions to. Seems nice. Keeps the sequence about timing.


		[Header(" ")]
		public BoolWrapper boolRef;

		public bool startValue;
		public bool endValue;

		private bool onEnterValue;

		protected override void RestoreOriginalValue()
		{
			boolRef.boolValue = onEnterValue;
		}

		protected override void SetToEndValue()
		{
			boolRef.boolValue = endValue;
		}

		protected override void SetToStartValue()
		{
			boolRef.boolValue = startValue;
		}

		protected override void StoreOriginalValue()
		{
			onEnterValue = boolRef.boolValue;
		}
	}
}