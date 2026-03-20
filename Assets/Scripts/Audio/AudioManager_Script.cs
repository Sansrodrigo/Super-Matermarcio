using System.ComponentModel;
using UnityEngine;

[DisplayName("Audio Manager")]
public class AudioManager_Script : MonoBehaviour
{
    public AudioSource[] AudioSources;
    //0 = music, 1 = sfx

    void Start()
    {
        AudioSources = GetComponents<AudioSource>();
    }

    void Update()
    {
        
    }
}
