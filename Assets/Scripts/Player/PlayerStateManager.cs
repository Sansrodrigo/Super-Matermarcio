using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    [Tooltip("Vida atual do jogador")]
    public int Vida = 3;
    public GameObject TelaGameOver;
    [SerializeField] GameObject interact;
    public AudioSource audioDano;
    void Awake()
    {
        // Apenas inicializações relacionadas ao status do jogador.
        if (SceneManager.GetActiveScene().name == "Arena")// nao mexer serio da bug !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            transform.position = new Vector3(-8.49f, -0.3f, 0f);
        }
        else
        {
            transform.position = Save_do_mundo.save.posicao_Mundo;//atualiza a posicao do player a cada cena nao apagar !!!!!!!!!

        }
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
        if (collision.gameObject.CompareTag("EstanteDeLivros"))
        {
            interact.SetActive(true);

        }
            if (collision.gameObject.CompareTag("casa"))
        {
            Save_do_mundo.save.posicao_Mundo = new Vector3(-1.47f, -2.49f, 0f);
            Save_do_mundo.save.Save();
            SceneManager.LoadScene("House0_F0"); // voltando do mundo pra casa
        }
        if (collision.gameObject.CompareTag("terreo"))
        {
           
            Save_do_mundo.save.posicao_Mundo = new Vector3(-4.4f, 2.52f, 0f);
            Save_do_mundo.save.Save();
            SceneManager.LoadScene("House0_F0");// deceu pro terreo
        }
        if (collision.gameObject.CompareTag("primeiroAndar"))
        {
           
            Save_do_mundo.save.posicao_Mundo = new Vector3(-4.17f, -0.48f, 0f);
            Save_do_mundo.save.Save();
            SceneManager.LoadScene("House0_F1"); //subindo pro primeiro andar
        }
        if (collision.gameObject.CompareTag("mundo"))
        {
            Save_do_mundo.save.posicao_Mundo = new Vector3(-0.53f, -7.82f, 0f); // sai pra gameplay
            Save_do_mundo.save.Save();
            SceneManager.LoadScene("Gameplay");
        }
      
        if (collision.gameObject.CompareTag("npcMulti") ||  // Lógica de colisão relacionada ao estado do jogador / mundo transferida aqui.
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
            Save_do_mundo.save.posicao_Mundo = transform.position;
            
            SyncToSaveMemory();// sincroniza status do jogador (HP) em memória antes de persistir
            Save_do_mundo.save.Save(); // persiste o save em disco (gestão do mundo)
            SceneManager.LoadScene("Arena");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EstanteDeLivros"))
        
        {
            interact.SetActive(false); }
          
    }
    
     
    




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boss"))
        {
            Vida--;
            audioDano.Play();
        }
    }
}