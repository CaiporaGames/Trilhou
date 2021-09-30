using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameBooster{

	[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	public sealed class InspectorDebuggerAttribute : Attribute {

		public string label;

		public InspectorDebuggerAttribute(){
			
		}

		public InspectorDebuggerAttribute(string label){
			this.label = label;
		}

	}

}
