using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonExplosion : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect;
    [SerializeField] SOBalloonOptions options;
    [SerializeField] float chance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") || collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Player"))
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
}
