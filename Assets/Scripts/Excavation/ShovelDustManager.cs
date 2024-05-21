using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelDustManager : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _sandEmission;

    [SerializeField]
    private ParticleSystem _dustEmission;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private List<AudioClip> clips;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            Debug.Log("Hitting Terrain, sending dust");
            _audioSource.clip = clips[0];
            _audioSource.Play();
            _dustEmission.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Terrain"))
        {
            Debug.Log("Leaving Terrain, sending sand");
            _audioSource.clip = clips[1];
            _audioSource.Play();
            _sandEmission.Play();
        }
    }
}
