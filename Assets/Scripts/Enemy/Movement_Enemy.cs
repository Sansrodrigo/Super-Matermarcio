
using UnityEngine;

public class Movement_Enemy : MonoBehaviour
{
    float timerSave = 0f;
    public int id;
    float velocidade = 3f;
    int gerador;
    float timer;
    float timer2;
    float timer3;
    float timer4;
    float timer5;
    Vector2 dic;
    Rigidbody2D rb;
    public static Save_do_mundo save = new Save_do_mundo();

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        Save_do_mundo.save.Load();

        if (Save_do_mundo.save.inimigo[id].inimigoActive == false)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Save_do_mundo.save.inimigo[id].position;

        EscolherDirecao();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (gerador == 0)
        {
            velocidade = 3f;
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                timer = 0;
                EscolherDirecao();
            }
        }
        if (gerador == 1)
        {
            velocidade = 3f;
            timer2 += Time.deltaTime;
            if (timer2 >= 5)
            {
                timer2 = 0;
                EscolherDirecao();
            }
        }
        if (gerador == 2)
        {
            velocidade = 3f;
            timer3 += Time.deltaTime;
            if (timer3 >= 5)
            {
                timer3 = 0;
                EscolherDirecao();
            }
        }
        if(gerador == 3)
        {
            velocidade = 3f;
            
            timer4 += Time.deltaTime;
            if (timer4 >= 5)
            {
                timer4 = 0;
                EscolherDirecao();
            }
        }

        if(gerador == 4)
        {
            velocidade = 0;
            timer5 += Time.deltaTime;
            if(timer5 >= 5)
            {
                timer5 = 0;
                EscolherDirecao();
            }
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = dic * velocidade;
        timerSave += Time.deltaTime;
        if (timerSave >= 15)
        {
            timerSave = 0;
            save.inimigo[id].position = transform.position;
            save.Save();
        }
    }
       
    void EscolherDirecao()
    {
        int gerador = Random.Range(0, 4);
        switch (gerador)
        {
            case 0: dic = Vector2.left; break;
            case 1: dic = Vector2.right; break;
            case 2: dic = Vector2.up; break;
            case 3: dic = Vector2.down; break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bounds") || collision.gameObject.CompareTag("Player"))
        {
            dic = -dic;
            timer = 0;
        }
        if (collision.gameObject.CompareTag("Player"))
        {

            save.inimigo[id].position = transform.position;
        }
    }
}
