using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GameBooster{

	[Comment(
@"Adds score to 'Score' component.

Methods:
	void ApplyScore()
	void AddScore(int scoreChange)"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#scoremaker")]
	[AddComponentMenu("GameBooster/Score/ScoreMaker")]
	public class ScoreMaker : GameBoosterBehaviour {
		
		[Tooltip("Score component id.")]
		public string scoreId;

		[Tooltip("Amount of score to be added")]
		public int scoreChange = 1;

		Score score;

		void OnEnable () {
			score = GameObject.FindObjectsOfType<Score> ().Where (e => e.id == scoreId).FirstOrDefault ();
		}

		[Button]
		public void ApplyScore(){
			AddScore (this.scoreChange);
		}

		public void AddScore(int scoreChange){
			if (score) {
				score.AddScore (scoreChange);
			}
		}

	}

}