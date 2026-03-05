using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static Save_do_mundo save = new Save_do_mundo();
    public int Vida = 3;
    public float Speed = 3.5f;

    void Start()
    {
        //>>Player.save.Load();
        //>>transform.position =  Player.save.posicao;
    }
    void Update()
    {
        /*>>if (Input.GetKey(KeyCode.E))
        {
            Player.save.Save();
           
            Player.save.posicao = transform.position;
        }
        */

        Vector2 movementVector = Vector2.zero; //Zera o vetor de movimento para evitar acumulação de velocidade
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementVector.x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movementVector.x = 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementVector.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movementVector.y = -1;
        }
        
        // Apply velocity based on speed variable
        GetComponent<Rigidbody2D>().linearVelocity = movementVector * Speed;

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("npcMulti"))
        {
            Destroy(collision.gameObject);
            //>>Player.save.Save();
            SceneManager.LoadScene("Arena");
        }
        if (collision.gameObject.CompareTag("npcMais"))
        {
            Destroy(collision.gameObject);
            //>>Player.save.Save();
            SceneManager.LoadScene("Arena");
        }
        if (collision.gameObject.CompareTag("npcMenos"))
        {
            Destroy(collision.gameObject);
            //>>Player.save.Save();
            SceneManager.LoadScene("Arena");
        }
    }

}
