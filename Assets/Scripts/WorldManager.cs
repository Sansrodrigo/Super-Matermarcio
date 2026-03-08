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

    void Start()
    {
        // Carrega dados do mundo (save) e inicializa o jogador a partir deles.
        Save_do_mundo.save.Load(); // gestão do mundo: carregar save

        _playerMovement = GetComponent<PlayerMovement>();
        _playerState = GetComponent<PlayerStateManager>();

        if (_playerMovement != null)
        {
            _playerMovement.SetPosition(Save_do_mundo.save.posicao);
        }
        else
        {
            transform.position = Save_do_mundo.save.posicao;
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

            Save_do_mundo.save.posicao = transform.position;
        }

        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            SaveActive = false;
        }

        VerificarVitoria();

        if (Input.GetKeyDown(KeyCode.F7))
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    void VerificarVitoria()
    {
        int inimigosMortos = 0;

        for (int i = 0; i < Save_do_mundo.save.inimigo.Length; i++)
        {
            if (Save_do_mundo.save.inimigo[i].inimigoActive == false)
            {
                inimigosMortos++;
            }
        }

        if (inimigosMortos == 3 && vitoria == false)
        {
            vitoria = true;
            Portal.SetActive(true);
        }
    }
}