using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static SaveManager save = new SaveManager();
    [SerializeField] GameObject creditsBanner;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject Tutorial_panel;
    [SerializeField] GameObject Botao_Ativo;


    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (SaveManager.save.TemSave() == true)
            {
                Botao_Ativo.SetActive(true);
            }
            else
            {
                Botao_Ativo.SetActive(false);
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Arena")
        {
           Pause();
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
    public void NovoJogo() //Ativa o Tutorial
    {
        
        SceneManager.LoadScene("Tutorial");
    }
    public void SkipTutorial() //sai do tutorial e vai pro Word_1
    {
        SaveManager.save.DeleteSave();
        SceneManager.LoadScene("House0_F1");
        SaveManager.save.posicao_Mundo = new Vector3(1.516f, 2.05f, 0f);
        SaveManager.save.Save();
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
        SaveManager.save.posicao_Mundo = player.transform.position;
        SaveManager.save.Save();
    }
    public void Continue()
    {
        Time.timeScale = 1;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("World_1");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) // faz parte do continue pra achar o player na nova cena
    {
       
        PlayerStateManager player = FindObjectOfType<PlayerStateManager>();    // Procura o player na nova cena
        if (player != null)
        {
            player.transform.position = SaveManager.save.posicao_Mundo;
        }

       
        SceneManager.sceneLoaded -= OnSceneLoaded;   // Remove o listener para não repetir
    }
    public void Morte_menu()
    {
        SaveManager.save.DeleteSave();
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}


