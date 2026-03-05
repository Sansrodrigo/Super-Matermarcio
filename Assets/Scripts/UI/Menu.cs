using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject creditsBanner;

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

    public void teste()
    {
        Player.save.Load();
    }

    public void Sair() // Sai do jogo
    {
        Application.Quit();
    }

}
