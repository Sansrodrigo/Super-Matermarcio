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
        transform.position = Save_do_mundo.save.posicao;
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
            SceneManager.LoadScene("House0_F0"); // voltando do mundo pra casa
            Save_do_mundo.save.posicao = new Vector3(-1.47f, -2.49f, 0f);
            Save_do_mundo.save.Save();
        }
        if (collision.gameObject.CompareTag("terreo"))
        {
           
            Save_do_mundo.save.posicao = new Vector3(-4.4f, 2.52f, 0f);
            Save_do_mundo.save.Save();
            SceneManager.LoadScene("House0_F0");// deceu pro terreo
        }
        if (collision.gameObject.CompareTag("primeiroAndar"))
        {
           
            Save_do_mundo.save.posicao = new Vector3(-4.17f, -0.48f, 0f);
            Save_do_mundo.save.Save();
            SceneManager.LoadScene("House0_F1"); //subindo pro primeiro andar
        }
        if (collision.gameObject.CompareTag("mundo"))
        {
            SceneManager.LoadScene("Gameplay");
            Save_do_mundo.save.posicao = new Vector3(-0.53f, -7.82f, 0f); // sai pra gameplay
            Save_do_mundo.save.Save();
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