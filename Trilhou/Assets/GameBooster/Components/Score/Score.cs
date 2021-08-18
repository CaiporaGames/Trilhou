using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[Comment(
@"Stores player score and record.

Related components:
	ScoreMaker

Methods:
	void IncScore()
	void AddScore(int scoreChange)
	void ResetScore()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#score")]
	[AddComponentMenu("GameBooster/Score/Score")]
	public class Score : GameBoosterBehaviour {

		[Tooltip("Score id\nUse to differentiate multiple scores")]
		public string id;

		[Tooltip("Current score")]
		[SerializeField]
		protected int m_value;
		public int value { get { return this.m_value; } }

		[Tooltip("Current score record")]
		[SerializeField]
		protected int m_recordValue;
		public int recordValue { get { return this.m_recordValue; } }

		[Tooltip("If the score should be automatically saved")]
		public bool saveScore;
		[Tooltip("Score PlayerPrefs's key")]
		[ConditionalHideAttribute("saveScore")]
		public string valuePlayerPrefsKey = "ScoreValue";

		[Tooltip("If the record should be automatically saved")]
		public bool saveRecord;
		[Tooltip("Record PlayerPrefs's key")]
		[ConditionalHideAttribute("saveRecord")]
		public string recordPlayerPrefsKey = "RecordValue";

		[System.Serializable]
		public class ScoreEvents {
			public IntUnityEvent onScoreChange;
			public IntUnityEvent onRecordChange;
			public IntUnityEvent onNewRecord;
			public StringUnityEvent onScoreChangeText;
			public StringUnityEvent onRecordChangeText;
		}
		public ScoreEvents events;

		void Start () {
			
			this.m_value = 0;
			this.m_recordValue = 0;

			if (saveScore && PlayerPrefs.HasKey(valuePlayerPrefsKey)) {
				this.m_value = PlayerPrefs.GetInt (valuePlayerPrefsKey);
			}
			if (saveRecord && PlayerPrefs.HasKey(recordPlayerPrefsKey)) {
				this.m_recordValue = PlayerPrefs.GetInt (recordPlayerPrefsKey);
			}

			ValueUpdated ();
			RecordUpdated ();
		}

		[Button]
		public void IncScore(){
			AddScore (1);
		}

		public void AddScore(int scoreChange){
			if (scoreChange != 0) {

				m_value = Mathf.Max (0, m_value + scoreChange);
				ValueUpdated ();
				SaveValue ();

				if (m_value > m_recordValue) {
					m_recordValue = m_value;
					RecordUpdated ();
					NewRecord ();
					SaveRecord ();
				}
			}
		}

		[Button]
		public void ResetScore(){
			m_value = 0;
			ValueUpdated ();
			SaveValue ();
		}

		void ValueUpdated(){
			events.onScoreChange.Invoke (m_value);
			events.onScoreChangeText.Invoke (m_value.ToString ());
		}

		void RecordUpdated(){
			events.onRecordChange.Invoke (m_recordValue);
			events.onRecordChangeText.Invoke (m_recordValue.ToString ());
		}

		void NewRecord(){
			events.onNewRecord.Invoke (m_recordValue);
		}

		void SaveValue(){
			if(saveScore)
				PlayerPrefs.SetInt (valuePlayerPrefsKey, m_value);
		}
		void SaveRecord(){
			if(saveRecord)
				PlayerPrefs.SetInt (recordPlayerPrefsKey, m_recordValue);
		}

	}

}