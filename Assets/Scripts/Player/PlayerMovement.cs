using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject TelaVitoria;
    bool vitoria = false;
    public int Vida = 3;
    public float Speed = 3.5f;
    public bool SaveActive = false;

    void Start()
    {
        
        Save_do_mundo.save.Load();  // Usa o save global

        
        transform.position = Save_do_mundo.save.posicao;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Arena" && SaveActive == false)
        {
            SaveActive = true;

            transform.position = new Vector3(-4.47f, 0.25f, 0f);
            Save_do_mundo.save.posicao = transform.position;
        }

        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            SaveActive = false;
        }

        Vector2 movementVector = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow)) movementVector.x = -1;
        else if (Input.GetKey(KeyCode.RightArrow)) movementVector.x = 1;

        if (Input.GetKey(KeyCode.UpArrow)) movementVector.y = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) movementVector.y = -1;

        GetComponent<Rigidbody2D>().linearVelocity = movementVector * Speed;
        VerificarVitoria();
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
            TelaVitoria.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("npcMulti") ||
            collision.gameObject.CompareTag("npcMais") ||
            collision.gameObject.CompareTag("npcMenos"))
        {
            Multicos enemy = collision.gameObject.GetComponent<Multicos>();

            if (enemy != null)
            {
                Save_do_mundo.save.inimigoArenaID = enemy.id; // salva o id para trocar sprite
                Save_do_mundo.save.inimigo[enemy.id].inimigoActive = false; // marca inimigo como destruído
                Debug.Log("ID SALVO: " + enemy.id);
            }

            Save_do_mundo.save.posicao = transform.position; // salva posição do player
            Save_do_mundo.save.Save();

            SceneManager.LoadScene("Arena");
        }
    }
}