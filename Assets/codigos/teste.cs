using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class teste : MonoBehaviour
{
    public bool correto;
    [SerializeField] Text texto;
    [SerializeField] InputField resposta;
    private int A = 0;
    private int aux = 1;
    bool ativo = false;
    int HP = 20;
    float tempo = 0;
    KeyCode[] key = {KeyCode.Keypad0, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9};
    List<int> User = new List <int>();
    string inprimir, resultado;
    float a = 0, b = 0, c = 0;


    void Start()
    {
        TesteDivisao();
        TesteMulti();

    }
     public void Update()
    {
        for(i = 0; i < User.Length; i++)
        {
            
            if (Input.GetKeyDown(key[i]))
            {
            User.Add(i);
            }
            for(i = User.Count-1; i > -1 ; i--)
            {
                A += User[i] * aux;
                aux * 10;
            }
            Verifica(A);
        }

        tempo += Time.deltaTime;
        if (tempo >= 2 && ativo == true)
        {
            ativo = false;
            resposta.text = "";
            Teste();

        }
    }
    public void TesteMulti()
    {



        a = Random.Range(0, 11);
        b = Random.Range(0, 11);
        c = a * b;
        inprimir = a + " X " + b;
        texto.text = inprimir;

    }
    public void TesteDivisao()
    {

        a = Random.Range(0, 11);
        b = Random.Range(0, 11);
        c = a / b;
        inprimir = a + " / " + b;
        texto.text = inprimir;
    }

    public void Verifica(int a)
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
