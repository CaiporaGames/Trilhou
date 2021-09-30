using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace GameBooster {

	[Comment(@"Detects 2D collisions")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#collisiondetector2d")]
	[AddComponentMenu("GameBooster/Collision Detection/CollisionDetector2D")]
	public class CollisionDetector2D : GameBoosterBehaviour {

		public enum CollisionEvent { Enter, Exit, Stay }
		public enum CollisionType { Any, Collision, Trigger }

		[Tooltip("Collision event")]
		public CollisionEvent collisionEvent;

		[Tooltip("Collider type")]
		public CollisionType collisionType;

		[Tooltip("Tags to filter collision.\nUse ';' to separate many tags")]
		public string tags;

		public GameObjectUnityEvent actions;

		bool CheckTags(GameObject go){
			if (string.IsNullOrEmpty (tags.Trim()))
				return true;

			var tagsArray = tags.Trim ().Split (';');
			foreach (var tag in tagsArray) {
				if (go.CompareTag (tag))
					return true;
			}
			return false;
		}

		void OnCollisionEnter2D(Collision2D col){
			if (collisionEvent == CollisionEvent.Enter && (collisionType == CollisionType.Any || collisionType == CollisionType.Collision)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnCollisionExit2D(Collision2D col){
			if (collisionEvent == CollisionEvent.Exit && (collisionType == CollisionType.Any || collisionType == CollisionType.Collision)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnCollisionStay2D(Collision2D col){
			if (collisionEvent == CollisionEvent.Stay && (collisionType == CollisionType.Any || collisionType == CollisionType.Collision)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnTriggerEnter2D(Collider2D col){
			if (collisionEvent == CollisionEvent.Enter && (collisionType == CollisionType.Any || collisionType == CollisionType.Trigger)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnTriggerExit2D(Collider2D col){
			if (collisionEvent == CollisionEvent.Exit && (collisionType == CollisionType.Any || collisionType == CollisionType.Trigger)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnTriggerStay2D(Collider2D col){
			if (collisionEvent == CollisionEvent.Stay && (collisionType == CollisionType.Any || collisionType == CollisionType.Trigger)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}


	}

}