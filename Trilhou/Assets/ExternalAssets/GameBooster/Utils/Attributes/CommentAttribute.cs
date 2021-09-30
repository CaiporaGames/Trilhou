using System;
using System.Collections.Generic;

namespace GameBooster
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class CommentAttribute : Attribute { 
		

		private static Dictionary<System.Type,bool> showCommentsDict = new Dictionary<System.Type, bool>();

		public static bool CanShowComments(System.Type type){
			return showCommentsDict.ContainsKey (type) && showCommentsDict [type];
		}
		public static void SwitchShowComments(System.Type type){
			if(showCommentsDict.ContainsKey(type)){
				showCommentsDict [type] = !showCommentsDict [type];
			}else{
				showCommentsDict[type] = true;
			}
		}


		public string text;

		public CommentAttribute(string text){
			this.text = text;
		}
	
	}
}
