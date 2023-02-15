using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSound : MonoBehaviour
{
    private AudioSource explosion;
    [SerializeField] private AudioClip[] sounds;
    private void Start()
    {
        explosion =GetComponent<AudioSource>();

        explosion.clip= sounds[Random.Range(0,sounds.Length)];
        explosion.Play();
        Destroy(gameObject,2);
    }


}
