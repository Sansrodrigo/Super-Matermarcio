using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Save_do_mundo save = new Save_do_mundo();
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
        save.Load();
    }
    public void Sair() // Sai do jogo
    {
        Application.Quit();
    }
    public void Volta_Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
