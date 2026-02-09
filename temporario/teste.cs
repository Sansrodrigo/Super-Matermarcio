using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;



public class teste : MonoBehaviour
{
    public bool correto;
    [SerializeField] GameObject soma;
    [SerializeField] GameObject subtracao;
    [SerializeField] GameObject multiplicacao;
    [SerializeField] Text texto;
    [SerializeField] GameObject Derrota;
    private int A = 0;
    private int aux = 1;
    public int HP = 4;
    float tempo = 0;
    KeyCode[] key = { KeyCode.Keypad0, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9 };
    List<int> User = new List<int>();
    string imprimir, resultado;
    float a = 0, b = 0, c = 0;
    public int count = 0;
    bool troca = false;
    [SerializeField] GameObject painelDeExercicios;
    void Start()
    {
      

    }
    public void Update()
    {
        for (int i = 0; i < key.Length; i++)
        {
            if (Input.GetKeyDown(key[i]) && User.Count < 3)
                {
                    User.Add(i);
                   
                    tempo = 0;
                }

        }
        if (tempo > 2)
        {
            
            User.Clear();
        }
            tempo += Time.deltaTime;
    }
  
    /// Variaveis que dao random nas contas de matematica
   
    public void TesteMultiplicacao()
    {



        a = Random.Range(0, 11);
        b = Random.Range(0, 11);
        c = a * b;
        imprimir = a + " X " + b;
        texto.text = imprimir;

    }
    public void TesteSubtracao()
    {

        a = Random.Range(0, 11);
        b = Random.Range(0, 11);
        c = a - b;
        imprimir = a + " - " + b;
        texto.text = imprimir;
    }
    public void TesteSoma()
    {

        a = Random.Range(1, 11);
        b = Random.Range(1, 11);
        c = a + b;
        imprimir = a + " + " + b;
        texto.text = imprimir;
        
    }

    // Variavel que verifica se esta correto ou errado
    public void Verifica()
    {
       
        Debug.Log("entrou");
        for (int i = User.Count - 1; i > -1; i--)
        {
            A += User[i] * aux;
            aux *= 10;   
        }
        Debug.Log(A);
        if (c == A)
        {
            resultado = " Correto ";
            texto.text = resultado;               
            tempo = 0;
            count++;
        }      
        if (c != A)
        {
            resultado = " Errado!! ";
            texto.text = resultado;
            HP--;
        }
        if(HP < 0)
        {
            Derrota.SetActive(true);
        }
        User.Clear();
        Debug.Log(A);
        A = 0;
        aux = 1;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //colissoes e suas interracoes
        if (collision.gameObject.tag == "npcMultipicacao")
        {
            Verifica();
            painelDeExercicios.SetActive(true);
            Debug.Log("entrou Multipicacao");
            TesteMultiplicacao();
            if (count > 4)
            {
                GameObject.Destroy(multiplicacao);
                count = 0;
                tempo = 0;
            }
        }
        if (collision.gameObject.tag == "npcSoma")
        {
            Verifica();
            painelDeExercicios.SetActive(true);
            Debug.Log("entrou Soma");
            TesteSoma();

            if (count > 4)
            {
                GameObject.Destroy(soma);
                count = 0;
                tempo = 0;
            }
        }
        if (collision.gameObject.tag == "npcSubtracao")
        {
            Verifica();
            painelDeExercicios.SetActive(true);
            Debug.Log("entrou Subtracao");
            TesteSubtracao();
            if (count > 4)
            {
                GameObject.Destroy(subtracao);
                count = 0;
                tempo = 0;
            }
        }
    }
}