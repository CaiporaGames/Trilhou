using System;

namespace GameBooster
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class ButtonAttribute : Attribute { 

		public enum ShowType { EditorAndRuntime, EditorOnly, RuntimeOnly }
		public ShowType showType = ShowType.RuntimeOnly;

		public ButtonAttribute(ShowType showType = ShowType.RuntimeOnly){
			this.showType = showType;
		}
	
	}
}
