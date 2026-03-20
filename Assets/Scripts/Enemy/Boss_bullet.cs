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
        next_x = Random.Range(-9.46f, 8.49f);
        transform.position = new Vector3(next_x, 7.84f, 0f);
        //instatie te a atencao e pega o next.x
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

        if (transform.position.y <= -6.28)
        {
            Destroy(gameObject);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision) //Player toma dano ao encostar
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            collision.gameObject.GetComponent<PlayerStateManager>().Vida--;
            
            collision.gameObject.GetComponent<PlayerStateManager>().audioDano.Play();
        }
    }


    public void StateBullet()
    {
        switch (State)
        {
            case 0:
                next_x = Random.Range(-9.46f, 8.49f);
                transform.position -= new Vector3(0f,veloci * Time.deltaTime, 0f);
                break;
            case 1:
                next_y = Random.Range(5.09f, - 4.25f);
                transform.position -= new Vector3(veloci * Time.deltaTime,0f, 0f);
                break;
        }
    }
}
