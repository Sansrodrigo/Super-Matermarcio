
using System.Collections;
using UnityEngine;

public class Movement_Enemy : MonoBehaviour
{
    float timerSave = 0f;
    public int id;
    float speed = 3f;
    public float minX, maxX, minY, maxY;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SaveManager.save.Load();

        if (SaveManager.save.inimigo[id].isActive == false)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = SaveManager.save.inimigo[id].position;
        SaveManager.save.Save();

        StartCoroutine(dirChanger());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bounds")) 
        {
            StartCoroutine(dirChanger());
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            SaveManager.save.inimigo[id].isActive = false;
            SaveManager.save.inimigo[id].position = transform.position;
            SaveManager.save.Save();
        }
    }

    IEnumerator dirChanger()
    {
        int prevrandMove = -1;
        int randTime = Random.Range(1, 4);
        int randMove = Random.Range(0, 4);

        if (randMove == prevrandMove)
        {
            prevrandMove = randMove;
            StartCoroutine(dirChanger());
        }
        else
        {
            prevrandMove = randMove;
            switch (randMove)
            {
                case 0: rb.linearVelocity = Vector2.left * speed; break;
                case 1: rb.linearVelocity = Vector2.right * speed; break;
                case 2: rb.linearVelocity = Vector2.up * speed; break;
                case 3: rb.linearVelocity = Vector2.down * speed; break;
            }

            yield return new WaitForSeconds(randTime);

            StartCoroutine(dirChanger());
        }         
    }
}

/*
 * mundo 1 
 * minx = -2.86 maxx = 6.13
 * miny = 1.08 maxy = -3.2
 * 
 * ______________________________________________
 * mundo 2 ????????
 * 
 * 
 * ______________________________________________
 * mundo 3 ????
 * 
 * 
 * _______________________________________________
 * the final boss ????
 * 
 * 
 */