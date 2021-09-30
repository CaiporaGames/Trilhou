using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fernando
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager levelManager;

        private int countBalloon = 0;
        private bool gameOver = false;

        private float seconds;
        private int secondsToInt;
        private int minutes;


        public Text minutesText;
        public Text secondsText;
        public Text balloonText;

        void Awake()
        {
            if (levelManager == null)
            {
                levelManager = this;
            }
            else if (levelManager != this)
            {
                Destroy(gameObject);
            }

        }


        // Update is called once per frame
        void Update()
        {
            if (!gameOver)
            {
                seconds += Time.deltaTime;
                if (seconds >= 60)
                {
                    seconds = 0;
                    minutes++;
                    minutesText.text = minutes.ToString();
                }
                secondsToInt = (int)seconds;
                secondsText.text = secondsToInt.ToString();
            }

        }

        public void SetBaloes()
        {
            countBalloon++;
            balloonText.text = countBalloon.ToString();
        }

        public int GetBaloes()
        {
            return countBalloon;
        }
    }
}