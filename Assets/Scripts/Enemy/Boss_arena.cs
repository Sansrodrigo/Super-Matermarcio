
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss_arena : MonoBehaviour
{
    public static Save_do_mundo save = new Save_do_mundo();
    [SerializeField] GameObject bullet;

    public int Hp_boss = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp_boss <= 0)
        {
            SceneManager.LoadScene("World_1");
        }  
    }
}
