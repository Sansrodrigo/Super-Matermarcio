using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static Save_do_mundo save = new Save_do_mundo();
    public int Vida = 3;
    public float Speed = 3.5f;
    public bool SaveActive = false;

    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name == "Arena" );
       
        //Player.save.Load();
        // transform.position =  save.posicao;
        transform.position = save.posicao;
        save.Load();
       
    }
    void Update()
    {
        if(SaveActive == false)
        {
            
        }
        if (SceneManager.GetActiveScene().name == "Arena" && SaveActive == false)
        {
            SaveActive = true;
            save.posicao = transform.position = new Vector3(-4.47f, 0.25f,0f);
        }
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            SaveActive = false;
        }
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
            save.posicao = transform.position;
            //collision.gameObject.GetComponent<Multicos>().id;
            save.inimigo[0].inimigoActive = false;
            save.Save();
            SceneManager.LoadScene("Arena");
        }
        if (collision.gameObject.CompareTag("npcMais"))
        {
            
            Destroy(collision.gameObject);
            save.posicao = transform.position;
            
            save.Save();
            SceneManager.LoadScene("Arena");
        }
        if (collision.gameObject.CompareTag("npcMenos"))
        { 
            Destroy(collision.gameObject);
            save.posicao = transform.position;
            
            save.Save();
            SceneManager.LoadScene("Arena");
        }
    }
  

}
