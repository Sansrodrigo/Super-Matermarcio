using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArenaManager : MonoBehaviour
{
    public static ArenaManager instance;
    int tipoEquacao;
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
    [SerializeField] public Number_Spawn numberSpawn;

    float tempo_disparo = 0f;
    float tempo = 0f;

    private void Update()
    {
        bossLife.text = "HP: " + Hp_Enemy + "/3";
        if (Hp_Enemy <= 0)
        {
            SceneManager.LoadScene("Gameplay");
        }

        tempo += Time.deltaTime;

        if(tempo >= 3f)
        {
            tempo = 0f;
            Correto.SetActive(false);
            Errado.SetActive(false);
        }
        
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        int id = Save_do_mundo.save.inimigoArenaID;
        tipoEquacao = id;
        GenerateEquation();
    }

    void GenerateEquation()    //gerador de equacao
    {
        int a = Random.Range(1, 11);
        int b = Random.Range(1, 11);

        if (tipoEquacao == 0) // MULTIPLICACAO
        {
            correctAnswer = a * b;
            equationText.text = a + " x " + b + " = ";
        }

        else if (tipoEquacao == 1) // SOMA
        {
             a = Random.Range(1, 21);
             b = Random.Range(1, 21);
            correctAnswer = a + b;
            equationText.text = a + " + " + b + " = ";
        }

        else if (tipoEquacao == 2) // SUBTRAÇAO
        {
            a = Random.Range(1, 21);
            b = Random.Range(1, 21);
            if (a >= b)
            {
                correctAnswer = a - b;
                equationText.text = a + " - " + b + " = ";
            }
            else
            {
                correctAnswer = b - a;
                equationText.text = b + " - " + a + " = ";
            }
        }

        playerAnswer = "";
        playerAnswerText.text = "";
    }


    public void AddNumber(int number) //adiciona e converte os numeros de string 
    {
        if(playerAnswer.Length < 3)
            playerAnswer += number.ToString();
        //atualiza a tela
        playerAnswerText.text = playerAnswer;

    }
    public void RemoveNumber()
    {
        if (playerAnswer.Length > 0)
        {
            playerAnswer = playerAnswer.Substring(0, playerAnswer.Length - 1);
            playerAnswerText.text = playerAnswer;
        }
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
                GenerateEquation();
            }
            else
            {
                Errado.SetActive(true);
                Debug.Log("errado");
            }

            // Atualiza a posição de todos os botões (instâncias de Number_Spawn) — ex.: 10 botões
            Number_Spawn[] spawns = FindObjectsOfType<Number_Spawn>();
            foreach (var s in spawns)
            {
                s.RandomizePosition();
            }
        }
        playerAnswer = "";
        playerAnswerText.text = "";
        
    }
   public void Boss()
    {

        if (Hp_Enemy == 3)
        {
            bossLife.text = "Hp Boss: 3";
        }
        if (Hp_Enemy == 2)
        {
            bossLife.text = "Hp Boss: 2";
        }
        if (Hp_Enemy == 1)
        {
            bossLife.text = "Hp Boss: 1";
        }

        tempo_disparo += Time.deltaTime;
        if (tempo_disparo >= 1f)
        {
            tempo_disparo = 0f;
            // Instantiate(bullet, transform.position, Quaternion.identity);
            // Instantiate(bullet, transform.position, Quaternion.identity);
        }

    }   
}
