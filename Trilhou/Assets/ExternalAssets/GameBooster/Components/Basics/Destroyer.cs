using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(
@"Object destroyer.

Methods:
	//destroy this object including all options set
	void DestroyThis()

	//destroy this object ignoring timeToDestroy option
	void DestroyThisNow()

	//destroy this object ignoring explosion
	void DestroyThisWithoutExplosion()

	//destroy this object ignoring all options
	void JustDestroyThis()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#destroyer")]
	[AddComponentMenu("GameBooster/Basics/Destroyer")]
	public class Destroyer : GameBoosterBehaviour {

		[Tooltip("Time to self destruction.\n0(zero) to disable")]
		public float selfDestructionTime;

		[Tooltip("Time to destroy when 'DestroyThis' method is called")]
		public float timeToDestroy;

		[Tooltip("Prefab to replace the destroyed object.")]
		public GameObject explosionPrefab;

		void Start(){
			if (selfDestructionTime > 0)
				Invoke ("DestroyThis", selfDestructionTime);
		}

		[Button]
		public void DestroyThis(){
			if(explosionPrefab)
				Instantiate (explosionPrefab, this.transform.position, Quaternion.identity);

			if (timeToDestroy > 0)
				Destroy (this.gameObject, timeToDestroy);
			else
				Destroy (this.gameObject);
		}

		[Button]
		public void DestroyThisNow(){
			if(explosionPrefab)
				Instantiate (explosionPrefab, this.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}

		[Button]
		public void DestroyThisWithoutExplosion(){
			if (timeToDestroy > 0)
				Destroy (this.gameObject, timeToDestroy);
			else
				Destroy (this.gameObject);
		}

		[Button]
		public void JustDestroyThis(){
			Destroy (this.gameObject);
		}


	}

}