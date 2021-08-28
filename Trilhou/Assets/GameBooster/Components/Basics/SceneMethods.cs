using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBooster{

	[Comment(
@"Extra scene methods

Methods to control timeScale, quit and load other scenes.

Methods:
	//load another scene
	void LoadScene(string sceneName)

	//reload current scene
	void ReloadCurrentScene()

	//quit application
	void ApplicationQuit()

	//set Time.timeScale = 0
	void Pause()

	//set Time.timeScale = 1
	void Resume()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#scenemethods")]
	[AddComponentMenu("GameBooster/Basics/SceneMethods")]
	public class SceneMethods : GameBoosterBehaviour {

		public void LoadScene(string sceneName){
			SceneManager.LoadScene (sceneName);
		}

		[Button]
		public void ReloadCurrentScene(){
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

		public void ApplicationQuit(){
			Application.Quit ();
		}

		[Button]
		public void Pause(){
			Time.timeScale = 0f;
		}

		[Button]
		public void Resume(){
			Time.timeScale = 1f;
		}

		[InspectorDebugger("TimeScale")]
		public float debugTimeScale { get { return Time.timeScale; } }

	}

}