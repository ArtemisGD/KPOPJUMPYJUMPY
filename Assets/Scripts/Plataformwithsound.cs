using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlatformer : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            _audio.Play();

        }
    }
}


