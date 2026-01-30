using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class teste : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* Renderer rend = GetComponent<Renderer>();
         rend.material.color = Color.red;
        */
       Teste();
        
    }
    [SerializeField] Text texto;
    [SerializeField] InputField resposta;
    
    bool ativo = false;
    int HP = 20;
    float tempo = 0;
    // Update is called once per frame
    KeyCode[] key = { KeyCode.Space,KeyCode.Keypad0,KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9, };
    KeyCode[] User = new KeyCode[3];
    int i;

    string inprimir,resultado;
    float a = 0, b = 0, c = 0;
    public void Update()
    {
        for(i = 0;i <key.Length;i++)
        {
            key [i] = (KeyCode)i;

        }
       for(i = 0; i < User.Length; i++)
        {


        }

        tempo += Time.deltaTime;
        if (tempo >= 2 && ativo == true)
        {
            ativo = false;
            Teste();

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Verifica();
        }
    }

    public void Teste()
    {
       

        
        a = Random.Range(0, 11);
        b = Random.Range(0, 11);
        c = a * b;
         inprimir = a + " X " + b;
        texto.text = inprimir;

    }
   
    public void Verifica()
    {
        
        int Usuario;

        if (int.TryParse(resposta.text, out Usuario))
        {
            if (Usuario == c)
            {
             
                resultado = " Correto ";
                texto.text = resultado;
                Debug.Log("acerto");
                Debug.Log("---------------------");
              ativo = true;
                
                
                    tempo = 0;
               
               
            }
            else
            {

                
                resultado = " Errado!! ";
                texto.text = resultado;

                HP--;
                Debug.Log("errro");
                Debug.Log(HP);
                Debug.Log("---------------------");

                ativo = true;
               
                    tempo = 0;
              
                


            }


        }
    }
}
