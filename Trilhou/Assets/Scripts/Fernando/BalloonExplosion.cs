using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo
{
    public class BalloonExplosion : MonoBehaviour
    {
        [SerializeField] GameObject explosionEffect;
        [SerializeField] SOBalloonOptions options;
        [SerializeField] SOGeneralVariables variables;
        [SerializeField] float chance;

        public delegate void BalloonOptionIsEmptyDelegate();
        public static BalloonOptionIsEmptyDelegate balloonOptionIsEmpty;
        AudioSource audioSource;
        Collider2D _collider;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("ground") || collision.CompareTag("Player"))
            {
                audioSource.Play();
                _collider.enabled = false;
                if (collision.CompareTag("Player") && options.ballonOptions.Count != 0)
                {
                    OptionChooser();
                }
                GameObject instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);

                transform.GetChild(0).gameObject.SetActive(false);
                Destroy(instance, 2);
                Destroy(gameObject,3);
            }
        }

        void OptionChooser()
        {
             float i = Random.value;

            if (i < chance)
            {
                int j = Random.Range(0, options.ballonOptions.Count);
                options._name = options.ballonOptions[j];
                PanelManager.Instance.PutNameOnChoosedCard(options._name);
                variables.gamePaused = true;
                LeanTween.pauseAll();
            }
        }

        void BalloonOptionsAreEmpty()
        {
            if (options.ballonOptions.Count == 0)
            {
                balloonOptionIsEmpty?.Invoke();
            }
        }
    }
}