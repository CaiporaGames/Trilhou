using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameBooster{

	[Comment(
@"Select and activate an object of the list deactivating the other ones.

Methods:
	//select fist object in the list
	void SelectFirst()

	//select next object in the list
	void SelectNext()

	//select previous object in the list
	void SelectPrevious()

	//deselect all objects
	void SelectNone()

	//select the object passed as parameter
	void Select(GameObject object)

	//select the object with name passed as parameter
	void Select(string name)

	//select the object at the index of the list
	void Select(int index)"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#objectselector")]
	[AddComponentMenu("GameBooster/Basics/ObjectSelector")]
	public class ObjectSelector : GameBoosterBehaviour {

		[Tooltip("Selected object at start")]
		public GameObject startSelected;

		[Tooltip("Select the 'startSelected' object on OnEnable event occours")]
		public bool autoSelectOnEnable;

		[Tooltip("Selectable objects")]
        [Reorderable]
		public List<GameObject> objects;

		void Start(){
			Select (startSelected);
		}

		void OnEnable () {
			if (autoSelectOnEnable) {
				Select (startSelected);
			}
		}

		[Button(ButtonAttribute.ShowType.EditorAndRuntime)]
		public void SelectFirst(){
			Select (0);
		}
		[Button(ButtonAttribute.ShowType.EditorAndRuntime)]
		public void SelectNext(){
			Select ((FindSelected() + 1) % objects.Count);
		}
		[Button(ButtonAttribute.ShowType.EditorAndRuntime)]
		public void SelectPrevious(){
			Select ((FindSelected() + objects.Count - 1) % objects.Count);
		}
		[Button(ButtonAttribute.ShowType.EditorAndRuntime)]
		public void SelectNone(){
			Select (-1);
		}

		int FindSelected(){
			for (int i = 0; i < objects.Count; i++) {
				if (objects [i].activeSelf) {
					return i;
				}
			}
			return -1;
		}

		public void Select(GameObject obj){
			if (Application.isPlaying) {
				for (int i = 0; i < objects.Count; i++) {
					if (objects [i]) {
						objects [i].SetActive (objects [i] == obj);
					}
				}
			} else {
				EditorSelect (obj);
			}
		}
		private void EditorSelect(GameObject obj){
			#if UNITY_EDITOR
			for (int i = 0; i < objects.Count; i++) {
				if (objects [i]) {
					var so = new UnityEditor.SerializedObject(objects[i]);
					so.Update();
					so.FindProperty("m_IsActive").boolValue = objects [i] == obj;
					so.ApplyModifiedProperties();
				}
			}
			#endif
		}

		public void Select(string name){
			for (int i = 0; i < objects.Count; i++) {
				if (objects [i] && objects [i].name == name) {
					Select (objects [i]);
					break;
				}
			}
		}

		public void Select(int index){
			if (index >= 0 && index < objects.Count && objects [index] != null) {
				Select (objects [index]);
			} else {
				Select ((GameObject)null);
			}
		}

	}

}