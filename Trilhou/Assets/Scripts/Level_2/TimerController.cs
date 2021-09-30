using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


namespace Paulo
{
    public class TimerController : MonoBehaviour
    {
        public static TimerController instance;

        [SerializeField] private TMP_Text timeCounter;
        [SerializeField] private TMP_Text counter;
        [SerializeField] private TMP_Text visualFeedBack;
        [SerializeField] private GameObject miniatureBook;
        [SerializeField] private float initialTime;

        private TimeSpan timePlaying;
        private bool timerGoing;
        private float elapsedTime;
        private float beforeTimer;

        private float timeToAppear = 2f;
        private float timeWhenDisappear;
        private bool feedBackOnScreen;
        private TweenText tweenCounter;

        private void Awake()
        {
            instance = this;
            miniatureBook.SetActive(false);
        }

        private void Start()
        {
            tweenCounter = counter.gameObject.GetComponent<TweenText>();
            timerGoing = false;
        }

        private void Update()
        {
            if (feedBackOnScreen && (Time.time >= timeWhenDisappear))
            {
                feedBackOnScreen = false;
                visualFeedBack.gameObject.SetActive(false);
            }
        }
        public void BeginTimer()
        {
            timeCounter.text = "Tempo: 00:00:00";
            timerGoing = true;
            elapsedTime = initialTime;

            StartCoroutine(UpdateTimer());
        }

        public void BeginCounter()
        {
            counter.text = "0";
        }

        public void EndTimer()
        {
            timerGoing = false;
            timeCounter.gameObject.SetActive(false);
        }
        public void PauseTimer()
        {
            timerGoing = false;
            beforeTimer = elapsedTime;

        }
        public void ContinueTimer()
        {
            elapsedTime = Time.deltaTime + (initialTime - beforeTimer);
            timerGoing = true;
        }
        private IEnumerator UpdateTimer()
        {
            bool flag = true;
            bool flag2 = true;
            while (timerGoing && elapsedTime > 0)
            {
                elapsedTime = elapsedTime - Time.deltaTime;
                timePlaying = TimeSpan.FromSeconds(elapsedTime);
                string timePlayingStr = " " + timePlaying.ToString("mm':'ss'.'ff");
                timeCounter.text = timePlayingStr;
                if (flag && elapsedTime < 60 && elapsedTime > 30)
                {
                    flag = false;
                    //mudar a cor
                    //this.GetComponent<SpriteRenderer>().color = Color.white;
                }
                if (flag2 && elapsedTime < 30)
                {
                    flag2 = false;
                    //mudar a cor
                    //this.GetComponent<SpriteRenderer>().color = Color.white;
                }
                yield return null;
            }

        }

        public float GetTimer()
        {
            return elapsedTime;
        }
        public void SetScore(int score)
        {
            tweenCounter.SendMessage("Tween");
            counter.text = "" + score;
        }

        public void VisualFeedBack(string text)
        {
            visualFeedBack.gameObject.SetActive(true);
            visualFeedBack.text = text;
            feedBackOnScreen = true;
            timeWhenDisappear = Time.time + timeToAppear;
        }
        public void PopUpBook(bool active)
        {
            miniatureBook.gameObject.SetActive(active);
            TweenText tweenBook = miniatureBook.GetComponent<TweenText>();
            Debug.Log(tweenBook);
            tweenBook.SendMessage("Tween");
        }
    }
}