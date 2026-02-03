using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class teste : MonoBehaviour
{
    public bool correto;
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
    KeyCode[] key = { KeyCode.Space,KeyCode.Keypad0,KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3,
        KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9, };
    //List<int> User = new List int[3];
    int i;

    string inprimir,resultado;
    float a = 0, b = 0, c = 0;
    public void Update()
    {
        for(i = 0;i <key.Length;i++)
        {
            //if (Input.GetKeyDown(key[i]))
                //User.AddRange( i);

        }
       //for(i = 0; i < User.Length; i++)
        {
            // Verifica quando 3 dígitos foram digitados
            if(resposta.text.Length == 3)
            {
                Verifica();
            }
        }

        tempo += Time.deltaTime;
        if (tempo >= 2 && ativo == true)
        {
            ativo = false;
            resposta.text = "";
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
         inprimir = a + " * " + b;
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
                
                correto = true;
                    tempo = 0;
               
               
            }
            else
            {

                correto = false;
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
