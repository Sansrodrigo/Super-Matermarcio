using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArenaManager : MonoBehaviour
{
    public static ArenaManager instance;

    [Header("Health Parameters")]
    [SerializeField] Text bossLife;
    public int Hp_Enemy = 3;

    [Header("Equation Parameters")]
    public Text equationText;
    public Text playerAnswerText;

    [Header("PlayerInput Parameters")]
    public int correctAnswer;
    private string playerAnswer = "";

    [SerializeField] public GameObject Correto;
    [SerializeField] public GameObject Errado;
    [SerializeField] Number_Spawn numberSpawn;

    private void Update()
    {
        BossLife();
    }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GenerateEquation(); //Gera a equaçao inicial quando a cena começa
    }
    void GenerateEquation() //gerador de equacoes
    {
       
        int a = Random.Range(1, 11);
        int b = Random.Range(1, 11);

        correctAnswer = a * b;
        equationText.text = a + " x " + b + " = ";

        playerAnswer = "";
        playerAnswerText.text ="";
    }
    public void AddNumber(int number) //adiciona e converte os numeros de string 
    {
        playerAnswer += number.ToString();
        //atualiza a tela
        playerAnswerText.text = playerAnswer;
    }
    public void ConfirmAnswer() //confirma a resposta do jogador, compara com a resposta correta e aplica o dano no boss
    {
        int playerResult;
        if(int.TryParse(playerAnswer, out playerResult))
        {
            if(playerResult == correctAnswer)
            {
                Debug.Log("correto");
                Correto.SetActive(true);

                Hp_Enemy--;
                             
                StartCoroutine(checkTimer());
                GenerateEquation();

            }
            else
            {
                StartCoroutine(checkTimer());
                Errado.SetActive(true);
                Debug.Log("errado");
            }
        }
        playerAnswer = "";
        playerAnswerText.text = "";
    }
    
    public void BossLife() //atualiza a vida do boss no Text e verifica se ele foi derrotado
    {
        bossLife.text = "HP: " + Hp_Enemy + "/3";
        if (Hp_Enemy <= 0)
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    IEnumerator checkTimer() //corrotina para mostrar o feedback de resposta correta ou errada por um tempo determinado
    {
        yield return new WaitForSeconds(3f);
        Correto.SetActive(false);
        Errado.SetActive(false);
        StopCoroutine(checkTimer());
    } 
}
