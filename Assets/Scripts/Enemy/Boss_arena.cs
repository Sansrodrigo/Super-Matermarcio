
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss_arena : MonoBehaviour
{
    public static SaveManager save = new SaveManager();
    [SerializeField] GameObject bullet;

    float tempo_disparo = 0f;
    public int Hp_boss = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //>>GetComponent<PlayerStateManager>().transform.position = new Vector3(-3.84f, 0.56f, 0f);
        Instantiate(bullet, transform.position, Quaternion.identity);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp_boss <= 0)
        {
           
            SceneManager.LoadScene("World_1");
        }
        tempo_disparo += Time.deltaTime;
        if(tempo_disparo >= 1f)
        {
            tempo_disparo = 0f;
            Instantiate(bullet, transform.position, Quaternion.identity);
            Instantiate(bullet, transform.position, Quaternion.identity);

        }
        
    }
}
