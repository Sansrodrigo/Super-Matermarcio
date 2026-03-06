using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject creditsBanner;
    [SerializeField] GameObject PauseCanvas;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseCanvas.activeSelf)
            {
                Resume();
            }
            else
            {
                PauseCanvas.SetActive(true);
                Time.timeScale = 0; // Pausa o jogo
            }
                
        }
    }

    public void Creditos() // Ativa e Desativa o painel creditos
    {
        if (creditsBanner.activeSelf)
        {
            creditsBanner.SetActive(false);
        }
        else
        {
            creditsBanner.SetActive(true);
        }
    }

    public void NovoJogo() // Começa o jogo
    {
        SceneManager.LoadScene("Gameplay");

    }

    public void Sair() // Sai do jogo
    {
        Application.Quit();
    }

    public void SaveAndExit()
    {
        Time.timeScale = 1; // Retoma o jogo
        SceneManager.LoadScene("Menu");
        
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false); // Esconde o menu de pausa
        Time.timeScale = 1; // Retoma o jogo
    }

}
