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
    public int id;
    [SerializeField] public GameObject Correto;
    [SerializeField] public GameObject Errado;
    [SerializeField] public Number_Spawn numberSpawn;
    [SerializeField] Animator[] animator_Boss = new Animator[3];
   
    float tempo = 0f;

    private void Update()
    {
        if (Hp_Enemy <= 0)
        {

            SaveManager.save.inimigo[id].isActive = false;
            SceneManager.LoadScene("World_1");
        }

        tempo += Time.deltaTime;

        if(tempo >= 3f)
        {
            tempo = 0f;
            Correto.SetActive(false);
            Errado.SetActive(false);
        }
        Perda_de_Vida();
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        int id = SaveManager.save.inimigoArenaID;
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
    public void Perda_de_Vida()
    {

        animator_Boss[0].SetInteger("Dano_Coracao", Hp_Enemy);
        animator_Boss[1].SetInteger("Dano_Coracao", Hp_Enemy);
        animator_Boss[2].SetInteger("Dano_Coracao", Hp_Enemy);
    }


}
