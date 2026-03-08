using UnityEngine;

public class Boss_bullet : MonoBehaviour
{
    float next_x, next_y, veloci = 4f;
    int State = 0;
    float timer = 0f;
    int bullet_state = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_x = Random.Range(-8.26f, 8.18f);
        transform.position = new Vector3(next_x, 3.92f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        bullet_state = Random.Range(0, 1);
        Debug.Log(bullet_state);

        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            State = bullet_state;
            timer = 0f;
        }
        StateBullet();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerStateManager>().Vida--;
            
        }
        if (collision.gameObject.CompareTag("bounds"))
        {
            Destroy(gameObject);
        }
    }
    public void StateBullet()
    {
        switch (State)
        {
            case 0:
                next_x = Random.Range(-8.26f, 8.18f);
                transform.position -= new Vector3(0f,veloci * Time.deltaTime, 0f);
                break;
            case 1:
                next_y = Random.Range(5.09f, - 4.25f);
                transform.position -= new Vector3(veloci * Time.deltaTime,0f, 0f);
                break;
        }
    }
}
