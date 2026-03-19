using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Save_do_mundo save = new Save_do_mundo();
    [SerializeField] GameObject creditsBanner;
    [SerializeField] GameObject PausePanel;
    

    public void Update()
    {
        string SceneActive = SceneManager.GetActiveScene().name;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneActive != "Arena")
            {
                Pause();
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
        Save_do_mundo.save.DeleteSave();
        SceneManager.LoadScene("House0_F1");
        Save_do_mundo.save.posicao_Mundo = new Vector3(1.516f, 2.05f, 0f);
        Save_do_mundo.save.Save();
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
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Pause()
    {
        if (PausePanel.activeSelf == true)
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
    }
    public void Save_Pause(GameObject player)
    {
        Save_do_mundo.save.posicao_Mundo = player.transform.position;
        Save_do_mundo.save.Save();
    }
    public void Continue()
    {
     
        Time.timeScale = 1;
        SceneManager.LoadScene("World_1");
    }
}


