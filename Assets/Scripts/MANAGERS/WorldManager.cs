using NUnit.Framework;
using System.Collections;
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
    public int gameLevel = 0;

    void Start()
    {
        // Carrega dados do mundo (save) e inicializa o jogador a partir deles.
        SaveManager.save.Load(); // gestão do mundo: carregar save

        _playerMovement = GetComponent<PlayerMovement>();
        _playerState = GetComponent<PlayerStateManager>();

        if (_playerMovement != null)
        {
            _playerMovement.SetPosition(SaveManager.save.posicao_Mundo);
        }
        else
        {
            transform.position = SaveManager.save.posicao_Mundo;
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

            SaveManager.save.posicao_Mundo = transform.position;
        }

        if (SceneManager.GetActiveScene().name == "World_1")
        {
            SaveActive = false;
        }

        VerificarVitoria();
        //GameLevel();
    }

    void VerificarVitoria()
    {
        int inimigosMortos = 0;
       //inimigosVivos = list.count;



        for (int i = 0; i < SaveManager.save.inimigo.Length; i++)
        {
            if (SaveManager.save.inimigo[i].isActive == false)
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
                //StartCoroutine(PortalOpeningSequence());
                vitoria = true;
                Portal.SetActive(true);
                PortalActive.SetActive(true);
                
            }

        }

    }
  
    IEnumerator PortalOpeningSequence()
    {
        yield return new WaitForSeconds(2f);
        Camera.main.GetComponent<CameraBehaviour>().customCameraPosition = new Vector3(36f, 8f, -10f); // Exemplo de posição personalizada
        Camera.main.GetComponent<CameraBehaviour>().camTarget = null;
        Camera.main.GetComponent<CameraBehaviour>().useCustomPosition = true;
        yield return new WaitForSeconds(3f);
        //PortalActive.SetActive(true);
        //Portal.SetActive(true);
    }
}
