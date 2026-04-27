using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip obsticklHitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Obstickl.OnPlayerHit += PlayObsticklHitSound;
    }

    private void PlayObsticklHitSound()
    {
        audioSource.PlayOneShot(obsticklHitSound);
    }

    
}
