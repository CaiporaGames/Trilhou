using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    [SerializeField]
    private TMP_Text timeCounter;

    [SerializeField]
    private TMP_Text counter;

    [SerializeField]
    private TMP_Text feedBackCollision;

    [SerializeField]
    private float initialTime;

    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private float timeToAppear = 2f;
    private float timeWhenDisappear;
    private bool feedBackOnScreen;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timerGoing = false;
    }

    private void Update()
    {
        if (feedBackOnScreen  && (Time.time >= timeWhenDisappear))
        {
            this.feedBackOnScreen = false;
            this.feedBackCollision.gameObject.SetActive(false);
        }
    }
    public void BeginTimer() {
        timeCounter.text = "Tempo: 00:00:00";
        counter.text = "0";
        timerGoing = true;
        elapsedTime = initialTime;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer() {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer(){
        while (timerGoing) {
            elapsedTime = elapsedTime - Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Tempo:  " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public void IncrementCounter(int score) {
        counter.text = "" + score;
    }

    public void Collision(string text)
    {
        this.feedBackCollision.gameObject.SetActive(true);  
        this.feedBackCollision.text = text;
        this.feedBackOnScreen = true;
        timeWhenDisappear = Time.time + timeToAppear;
    }

}
