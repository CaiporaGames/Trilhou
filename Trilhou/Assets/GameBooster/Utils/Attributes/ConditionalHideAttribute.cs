using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[System.AttributeUsage (System.AttributeTargets.Field | System.AttributeTargets.Property , Inherited = true)]
	public sealed class ConditionalHideAttribute : PropertyAttribute
	{
		public string[] conditionalSourceFields;

		public bool inverseConditional;

		public int identation;

		public ConditionalHideAttribute(params string[] conditionalSourceFields) : this(false,1,conditionalSourceFields){
		}

		public ConditionalHideAttribute(bool inverseCondition = false, int identation = 1, params string[] conditionalSourceFields){
			this.conditionalSourceFields = conditionalSourceFields;
			this.inverseConditional = inverseCondition;
			this.identation = identation;
		}


	}
}