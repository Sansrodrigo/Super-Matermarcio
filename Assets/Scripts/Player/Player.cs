using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    void Start()
    {
        velocidade = 3.5f;
    }
    [SerializeField] GameObject painel;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(velocidade * Time.deltaTime, 0, 0);
        }
        else
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(velocidade * Time.deltaTime, 0, 0);
        }
        else
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, velocidade * Time.deltaTime, 0);
        }
        else
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, velocidade * Time.deltaTime, 0);

        }
      
        if (canvas.GetComponent<teste>().correto == true)
        {
            Debug.Log("entrou no teste");

            painel.SetActive(false);
        }
    }
  /*  public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "npcMulti")
        {
             
            painel.SetActive(true);
            Debug.Log("entrou");
        }
        else
 if (collision.gameObject.tag == "npcdivisao")
        {
           
            painel.SetActive(true);
            Debug.Log("entrou");
        }
        else
        if (collision.gameObject.tag == "npcMais")
        {
            painel.SetActive(true);
          
            Debug.Log("entrou");
        }
        else
        if (collision.gameObject.tag == "npcMenos")
        {
            
            painel.SetActive(true);
            Debug.Log("entrou");
        }
    }*/
}
