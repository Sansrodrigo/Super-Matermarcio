using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager_Script : MonoBehaviour
{

    [SerializeField] Slider ImusicVolume; //Slider para controlar o volume da musica
    private AudioSource[] AudioSources; //0 = music, 1 = sfx


    public AudioResource[] Musics; //Armazena as musicas que serao tocadas
    public AudioResource[] SFX; //Armazena os SFX que serao tocados

    void Start()
    {
        AudioSources = GetComponents<AudioSource>(); //Pega os audiosources do objeto
        AudioSwitch(); //Chama a funcao que troca a musica dependendo da cena
    }

    void Update()
    {
        AudioSources[0].volume = ImusicVolume.value;
    }

    public void AudioSwitch() //Troca a musica dependendo da cena
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "World_1":
                AudioSources[0].resource = Musics[0];
                AudioSources[0].Play();
                break;
            case "Arena":
                AudioSources[0].resource = Musics[1];
                AudioSources[0].Play();
                break;
        }
    }
}
