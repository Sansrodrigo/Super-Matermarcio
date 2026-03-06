
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss_arena : MonoBehaviour
{
    public static Save_do_mundo save = new Save_do_mundo();
    [SerializeField] GameObject bullet;
    [SerializeField] Text Vida;
    float tempo_disparo = 0f;
    public int Hp_boss = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Instantiate(bullet, transform.position, Quaternion.identity);
      
    }

    // Update is called once per frame
    void Update()
    {

        if (Hp_boss == 3)
        {
            Vida.text = "Hp Boss: 3";
        }
        if (Hp_boss == 2)
        {
            Vida.text = "Hp Boss: 2";
        }
        if (Hp_boss == 2)
        {
            Vida.text = "Hp Boss: 1";
        }
        if (Hp_boss <= 0)
        {
            SceneManager.LoadScene("Gameplay");
        }
        tempo_disparo += Time.deltaTime;
        if(tempo_disparo >= 1f)
        {
            tempo_disparo = 0f;
           // Instantiate(bullet, transform.position, Quaternion.identity);
           // Instantiate(bullet, transform.position, Quaternion.identity);
        }
        
    }
}
