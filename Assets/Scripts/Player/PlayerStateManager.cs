using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateManager : MonoBehaviour
{
    public static Scene localizacao;
    [Tooltip("Vida atual do jogador")]
    public int Vida = 3;
    public GameObject TelaGameOver;
    void Awake()
    {
        // Apenas inicializações relacionadas ao status do jogador.
    }
    public void Update()
    {
        if (Vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void Start()
    {
        
    }


    public void InitializeFromSave()
    {
        Vida = Save_do_mundo.save.HP;
    }

    public void SetVida(int novoValor)
    {
        Vida = novoValor;
    }

    public void ApplyDamage(int dano)
    {
        Vida = Mathf.Max(0, Vida - dano);
    }

    /// <summary>
    /// Atualiza o objeto de save em memória com o status atual do jogador.
    /// Não grava em disco — a persistência é responsabilidade do WorldManager.
    /// </summary>
    public void SyncToSaveMemory()
    {
        Save_do_mundo.save.HP = Vida;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("casa"))
        {
            //localizacao = 2;// voltando do mundo pra casa
            SceneManager.LoadScene("House0_F0");
        }
        if (collision.gameObject.CompareTag("terreo"))
        {
           // localizacao = 1;// deceu pro terreo
            SceneManager.LoadScene("House0_F0");
        }
        if (collision.gameObject.CompareTag("primeiroAndar"))
        {
            localizacao = SceneManager.GetActiveScene();
            Save_do_mundo.save.posicao = transform.position = new Vector3(-4.11f, -0.33f,0f);
            Save_do_mundo.save.Save();
            //localizacao = 0; subindo pro primeiro andar
            SceneManager.LoadScene("House0_F1");
        }
        if (collision.gameObject.CompareTag("mundo"))
        {
            //localizacao = 3; sai pra gameplay
            SceneManager.LoadScene("Gameplay");
        }
        // Lógica de colisão relacionada ao estado do jogador / mundo transferida aqui.
        if (collision.gameObject.CompareTag("npcMulti") ||
            collision.gameObject.CompareTag("npcMais") ||
            collision.gameObject.CompareTag("npcMenos"))
        {
            Movement_Enemy enemy = collision.gameObject.GetComponent<Movement_Enemy>();

            if (enemy != null)
            {
                Save_do_mundo.save.inimigoArenaID = enemy.id; // salva o id para trocar sprite
                Save_do_mundo.save.inimigo[enemy.id].inimigoActive = false; // marca inimigo como destruído
                Debug.Log("ID SALVO: " + enemy.id);
            }

            // salva posição do player no save em memória
            Save_do_mundo.save.posicao = transform.position;
            Save_do_mundo.save.Save();

            // sincroniza status do jogador (HP) em memória antes de persistir
            SyncToSaveMemory();

            // persiste o save em disco (gestão do mundo)
            Save_do_mundo.save.Save();

            SceneManager.LoadScene("Arena");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boss"))
        {
            Vida--;

        }
    }


}