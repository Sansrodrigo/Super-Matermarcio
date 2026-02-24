using UnityEngine;

public class Boss_bullet : MonoBehaviour
{
    float next_x, veloci = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_x = Random.Range(-8.26f, 8.18f);
        transform.position = new Vector3(next_x, 3.92f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, veloci * Time.deltaTime, 0f);
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().Vida--;
            
        }
        if (collision.gameObject.CompareTag("parede"))
        {
            Destroy(gameObject);
        }
    }
}
