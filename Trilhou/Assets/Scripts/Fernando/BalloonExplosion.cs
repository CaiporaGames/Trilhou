using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonExplosion : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect;
    [SerializeField] SOBalloonOptions options;
    [SerializeField] float chance;

    public delegate void BalloonOptionIsEmptyDelegate();
    public static BalloonOptionIsEmptyDelegate balloonOptionIsEmpty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") || collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Player") && options.ballonOptions.Count != 0)
            {
                OptionChooser();
            }
            GameObject instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            gameObject.SetActive(false);
            Destroy(instance, 2);
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
