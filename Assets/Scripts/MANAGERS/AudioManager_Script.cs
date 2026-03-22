using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AudioManager_Script : MonoBehaviour
{
    private static float musicVolume = 0.5f; //Variavel para armazenar o volume da musica
    private static float SFXVolume = 0.5f; //Variavel para armazenar o volume da musica

    [Header("UI CONTROLLERS")]
    [SerializeField] Slider Music_Volume_Slider; //Slider para controlar o volume da musica
    [SerializeField] Slider SFX_Volume_Slider; //Slider para controlar o volume dos SFX

    [Space(20)]

    public AudioSource[] AudioSources; //0 = music, 1 = sfx
    
    public AudioResource[] Musics; //Armazena as musicas que serao tocadas
    public AudioResource[] SFX; //Armazena os SFX que serao tocados

    void Start()
    {
        Music_Volume_Slider.value = musicVolume; //Seta o valor do slider de musica para o valor armazenado
        SFX_Volume_Slider.value = SFXVolume; //Seta o valor do slider de SFX para o valor armazenado

        AudioSources = GetComponents<AudioSource>(); //Pega os audiosources do objeto
        AudioSwitch(); //Chama a funcao que troca a musica dependendo da cena
    }

    void Update()
    {
        AudioSources[0].volume = musicVolume; //Controla o volume da musica com o slider 
        AudioSources[1].volume = SFXVolume; //Controla o volume dos SFX com o slider
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
            case "Menu":
                AudioSources[0].resource = Musics[2];
                AudioSources[0].Play();
                break;
        }
    }

    //Volume Controls - Its called everytime the slider value changes
    public void MusicVolumeControl() //Eh chamado toda vez que o slider de musica muda de valor
    {
        musicVolume = Music_Volume_Slider.value; //Armazena o valor do slider de musica na variavel
    }
    public void SFXVolumeControl() //Eh chamado toda vez que o slider de SFX muda de valor
    {
        SFXVolume = SFX_Volume_Slider.value; //Armazena o valor do slider de SFX na variavel
    }
}
