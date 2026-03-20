using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    [Header("UI / Mundo")]
    public GameObject Portal;
    private bool vitoria = false;
    public bool SaveActive = false;
    public PlayerMovement _playerMovement;
    public PlayerStateManager _playerState;
    public float timer = 0f;
    public GameObject PortalActive;
   
    void Start()
    {
        // Carrega dados do mundo (save) e inicializa o jogador a partir deles.
        Save_do_mundo.save.Load(); // gestão do mundo: carregar save

        _playerMovement = GetComponent<PlayerMovement>();
        _playerState = GetComponent<PlayerStateManager>();

        if (_playerMovement != null)
        {
            _playerMovement.SetPosition(Save_do_mundo.save.posicao_Mundo);
        }
        else
        {
            transform.position = Save_do_mundo.save.posicao_Mundo;
        }

        if (_playerState != null)
        {
            _playerState.InitializeFromSave();
        }
    }

    void Update()
    {
        // Controle de posições iniciais específicas de cena (mundo)
        if (SceneManager.GetActiveScene().name == "Arena" && SaveActive == false)
        {
            SaveActive = true;

            Vector3 arenaPos = new Vector3(-4.47f, 0.25f, 0f);

            if (_playerMovement != null)
                _playerMovement.SetPosition(arenaPos);
            else
                transform.position = arenaPos;

            Save_do_mundo.save.posicao_Mundo = transform.position;
        }

        if (SceneManager.GetActiveScene().name == "World_1")
        {
            SaveActive = false;
        }

        VerificarVitoria();

        if (Input.GetKeyDown(KeyCode.F7))
        {
            GetComponent<PlayerStateManager>().transform.position = Save_do_mundo.save.posicao_Mundo;
            Save_do_mundo.save.Save();
            SceneManager.LoadScene("World_1");
        }
    }

    void VerificarVitoria()
    {
        int inimigosMortos = 0;
       //inimigosVivos = list.count;



        for (int i = 0; i < Save_do_mundo.save.inimigo.Length; i++)
        {
            if (Save_do_mundo.save.inimigo[i].inimigoActive == false)
            {
                inimigosMortos++;
            }
        }

        // if inimigosVivos == 0 
        if (inimigosMortos == 3 && vitoria == false)
        {
            timer += Time.deltaTime;

            if (timer >= 2f )
             {
                PortalActive.SetActive(true);
                vitoria = true;

                Portal.SetActive(true);
            }
           

        }
    }
}