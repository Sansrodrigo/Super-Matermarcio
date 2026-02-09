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
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-5, 0);
        }
        else
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(5, 0);
        }
        else
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 5);
        }
        else
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -5);
        }

        if (canvas.GetComponent<teste>().count == 4)
        {
            Debug.Log("entrou no teste");
            painel.SetActive(false);
        }
    }
 
}
