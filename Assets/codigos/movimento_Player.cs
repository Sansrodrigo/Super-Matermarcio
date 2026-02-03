using UnityEngine;




public class movimento_Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }
    float pulo = 4f, velocidade = 2f;
    // Update is called once per frame
    
    private void FixedUpdate()
    {
       /* if (Input.GetKeyDown(KeyCode.W))
        {
            //GetComponent<Rigidbody2D>().AddForce (new Vector3(0f, 5f, 0f), ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocityX,pulo );
        }
       */ //No momento não havera pulo
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(velocidade, GetComponent<Rigidbody2D>().linearVelocityY);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-velocidade, GetComponent<Rigidbody2D>().linearVelocityY);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "chao")
    }
}
