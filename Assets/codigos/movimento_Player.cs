using UnityEngine;




public class movimento_Player : MonoBehaviour
{
    [SerializeField] GameObject foi;
    [SerializeField] GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }
    float pulo = 4f, velocidade = 3f;
    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, velocidade * Time.deltaTime, 0f);
        }
        else
            if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0f, velocidade * Time.deltaTime, 0f);
        }
        else
            if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(velocidade * Time.deltaTime, 0f, 0f);
        }
        else
            if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(velocidade * Time.deltaTime, 0f, 0f);
        }
            if (canvas.GetComponent<teste>().correto == true)
            {
                Debug.Log("entrou no teste");

                foi.SetActive(false);
            }
        }
        void OnTriggerEnter2D(Collider2D collision)

        {
            if (collision.gameObject.tag == "npc")
            {
                foi.SetActive(true);
                Debug.Log("entrou");
            }

        }
    }

