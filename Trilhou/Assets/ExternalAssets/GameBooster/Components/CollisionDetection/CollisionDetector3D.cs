using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace GameBooster {

	[Comment(@"Detects 3D collisions")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#collisiondetector3d")]
	[AddComponentMenu("GameBooster/Collision Detection/CollisionDetector3D")]
	public class CollisionDetector3D : GameBoosterBehaviour {

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

		void OnCollisionEnter(Collision col){
			if (collisionEvent == CollisionEvent.Enter && (collisionType == CollisionType.Any || collisionType == CollisionType.Collision)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnCollisionExit(Collision col){
			if (collisionEvent == CollisionEvent.Exit && (collisionType == CollisionType.Any || collisionType == CollisionType.Collision)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnCollisionStay(Collision col){
			if (collisionEvent == CollisionEvent.Stay && (collisionType == CollisionType.Any || collisionType == CollisionType.Collision)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnTriggerEnter(Collider col){
			if (collisionEvent == CollisionEvent.Enter && (collisionType == CollisionType.Any || collisionType == CollisionType.Trigger)) {
				if (CheckTags (col.gameObject)) {
					actions.Invoke (col.gameObject);
				}
			}
		}
		void OnTriggerExit(Collider col){
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