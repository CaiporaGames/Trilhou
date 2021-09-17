using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip wonGame;
    [SerializeField] private AudioClip wrongShelf;
    [SerializeField] private AudioClip rightShelf;
    [SerializeField] private AudioSource manager;

    public static SoundManager instance;

    public void Awake()
    {
        instance = this;
        manager = GetComponent<AudioSource>();
    }

    public void PlayWonGame() 
    {
        manager.PlayOneShot(wonGame);
    }
    public void PlayWrongShelf()
    {
        manager.PlayOneShot(wrongShelf);
    }
    public void PlayRightShelf()
    {
        manager.PlayOneShot(rightShelf);
    }
}
