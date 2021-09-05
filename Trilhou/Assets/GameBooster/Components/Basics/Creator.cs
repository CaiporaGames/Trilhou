using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameBooster{

	[Comment(
@"Creates copies of prefabs.

Methods:
	//instantiate a prefab using the options set
	void Create()"
)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#creator")]
	[AddComponentMenu("GameBooster/Basics/Creator")]
	public class Creator : GameBoosterBehaviour {

		[Tooltip("Prefabs to be instantiated (random choosen)")]
        [Reorderable]
		public List<GameObject> prefabs;

		[Tooltip("Use spawn point rotation as rotation of the instantiated object")]
		public bool useRotation;

		[Tooltip("Place the instantiated object inside other object's hierarchy")]
		public bool insideHierarchy;
		[Tooltip("Object to put the instantiated objects")]
		[ConditionalHideAttribute("insideHierarchy")]
		public Transform parent;

		[Tooltip("Use other spawn points instead of this object")]
		public bool useSpawnPoints;
		[System.Serializable]
		public class SpawnPoints{
            public List<Transform> elements;
        }
        [ConditionalHideAttribute("useSpawnPoints")]
        [Tooltip("Spawn points where the prefab will be instantiated (random choosen)")]
        public SpawnPoints spawnPoints;

		[Tooltip("Automatically instantiate.")]
		public bool autoCreate;
		[Tooltip("Time to start prefab instantiation.")]
		[ConditionalHideAttribute("autoCreate")]
		public float startTime;
		[Tooltip("Time between instantiations.")]
		[ConditionalHideAttribute("autoCreate")]
		public float repeatTime;

		void OnEnable () {
			if (autoCreate) {
				if (startTime == 0)
					CallTimed ();
				else
					Invoke ("CallTimed", startTime);
			}
		}

		void OnDisable(){
			CancelInvoke("CallTimed");
		}

		void CallTimed(){
			Create();
			if(repeatTime > 0)
				Invoke ("CallTimed", repeatTime);
		}

		[Button]
		public void Create(){

			var prefab = prefabs [Random.Range (0, prefabs.Count)];
			var target = useSpawnPoints ? spawnPoints.elements[Random.Range (0, spawnPoints.elements.Count)] : this.transform;
			var rotation = useRotation ? target.rotation : Quaternion.identity;

			if(prefab){
				GameObject obj = Instantiate(prefab, target.position, rotation) as GameObject;
				obj.name = prefab.name;

				if(insideHierarchy && parent)
					obj.transform.SetParent(parent);
				
			}
		}

	}

}