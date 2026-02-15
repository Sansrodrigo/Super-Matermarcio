using UnityEngine;

public class Boss_bullet : MonoBehaviour
{
    float next_x, veloci = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_x = Random.Range(-8.26f, 8.18f);
        transform.position = new Vector3(next_x, 3.92f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, veloci, 0f);
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("player"))
        {
            collision.gameObject.GetComponent<Player>().Vida--;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("parede"))
        {
            Destroy(gameObject);
        }
    }
}
