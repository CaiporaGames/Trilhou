using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TimerController timerController;
    private bool playing;

    [SerializeField]
    private int maxBooks;

    void Awake(){
        timerController = this.gameObject.GetComponent<TimerController>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update(){

    }

    private void StartPlaying() {
        this.timerController.BeginTimer();
    }

    private void incrementCounter(int score) {
        this.timerController.incrementCounter(score);
    }
}
