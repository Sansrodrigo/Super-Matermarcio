using UnityEngine;

public class Tear_Behaviour : MonoBehaviour
{
    float speed = 4f;
    
    void Update()
    {
        transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 0f));
    }
    public void OnTriggerEnter2D(Collider2D collision) //Player toma dano ao encostar
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerStateManager>().Vida--;
            collision.gameObject.GetComponent<PlayerStateManager>().audioDano.Play();
        }

        if (collision.gameObject.name == "ProjectileBounds")
        {
            Destroy(gameObject);
        }
    }
}
