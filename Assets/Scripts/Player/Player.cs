using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject painel;
    public int Vida = 3;
    public float speed;
    void Start()
    {
        speed = 3.5f;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;
        
        // Horizontal movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1;
        }
        
        // Vertical movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1;
        }
        
        // Apply velocity
        GetComponent<Rigidbody2D>().linearVelocity = movement * 5;

        // comparacao de vida do marcio
        if(Vida <= 0)
        {
            Destroy(gameObject);
            painel.SetActive(true);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("npcMulti"))
        {
            Destroy(collision.gameObject);
          //  GetComponent<Save_do_mundo>().Save();
            SceneManager.LoadScene("Arena");
        }
        if (collision.gameObject.CompareTag("npcMais"))
        {
            Destroy(collision.gameObject);
           // GetComponent<Save_do_mundo>().Save();
            SceneManager.LoadScene("Arena");
        }
        if (collision.gameObject.CompareTag("npcMenos"))
        {
            Destroy(collision.gameObject);
            //GetComponent<Save_do_mundo>().Save();
            SceneManager.LoadScene("Arena");
        }
    }

}
