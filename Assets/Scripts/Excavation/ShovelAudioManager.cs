using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelAudioManager : MonoBehaviour
{
    public static AudioSource audioSource;

    [SerializeField] 
    private List<AudioClip> clips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
