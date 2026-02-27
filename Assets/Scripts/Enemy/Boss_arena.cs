
using UnityEngine;

public class Boss_arena : MonoBehaviour
{
    [SerializeField] GameObject bullet;
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

      
        tempo_disparo += Time.deltaTime;
        if(tempo_disparo >= 1f)
        {
            tempo_disparo = 0f;
            Instantiate(bullet, transform.position, Quaternion.identity);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
        
    }
}
