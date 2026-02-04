using UnityEngine;

public class Multicos : MonoBehaviour
{
    float velocidade = 3f;
    int gerador;
    float timer;
    float timer2;
    float timer3;
    float timer4;
    float timer5;
    int dic = 1;
    void Start()
    {
        gerador = Random.Range(0, 5);
        Debug.Log(gerador);

    }

    // Update is called once per frame
    void Update()
    {



        timer += Time.deltaTime;
        if (gerador == 0)
        {
            velocidade = 3f;
            transform.position -= new Vector3(velocidade * Time.deltaTime, 0, 0);
            timer += Time.deltaTime;
            if (timer >= 6)
            {
                timer = 0;
                gerador = Random.Range(0, 5);
            }

        }

        if (gerador == 1)
        {
            velocidade = 3f;
            transform.position += new Vector3(velocidade * Time.deltaTime, 0, 0);
            timer2 += Time.deltaTime;
            if (timer2 >= 6)
            {
                timer2 = 0;
                gerador = Random.Range(0, 5);
            }

        }

        if (gerador == 2)
        {
            velocidade = 3f;
            transform.position += new Vector3(0, velocidade * Time.deltaTime, 0);
            timer3 += Time.deltaTime;
            if (timer3 >= 6)
            {
                timer3 = 0;
                gerador = Random.Range(0, 5);
            }
        }

        if(gerador == 3)
        {
            velocidade = 3f;
            transform.position -= new Vector3(0, velocidade * Time.deltaTime, 0);
            timer4 += Time.deltaTime;
            if (timer4 >= 6)
            {
                timer4 = 0;
                gerador = Random.Range(0, 5);
            }
        }

        if(gerador == 4)
        {
            velocidade = 0;
            timer5 += Time.deltaTime;
            if(timer5 >= 6)
            {
                timer5 = 0;
                gerador= Random.Range(0, 5);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "agua")
        {
            transform.position -= new Vector3(0, dic * velocidade * Time.deltaTime, 0);
        }
        if (gameObject.tag == "agua")
        {
            transform.position += new Vector3(0, dic * velocidade * Time.deltaTime, 0);
        }
        if (gameObject.tag == "agua")
        {
            transform.position -= new Vector3(dic * velocidade * Time.deltaTime, 0, 0);
        }
        if (gameObject.tag == "agua")
        {
            transform.position += new Vector3(dic * velocidade * Time.deltaTime, 0, 0);
        }
    }
}
