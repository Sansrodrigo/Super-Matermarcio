using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumbersManager : MonoBehaviour
{
  public static NumbersManager instance;
    [SerializeField] Text Vida;
    float tempo_disparo = 0f;
    public int Hp_boss = 3;
    [SerializeField] public GameObject Correto;
    [SerializeField] public GameObject Errado;
    public Text equationText;
    public Text playerAnswerText;

    public int correctAnswer;
    private string playerAnswer = "";
    private void Update()
    {
        float tempo = Time.deltaTime;
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
    private void Start()
    {
       
        Debug.Log("entrou no start");
        GenerateEquation();
    }
    //gerador de equacoes
    void GenerateEquation()
    {
       
        int a = Random.Range(1, 11);
        int b = Random.Range(1, 11);

        correctAnswer = a * b;
        equationText.text = a + " x " + b + " = ";

        playerAnswer = "";
        playerAnswerText.text ="";
    }
    //adiciona e converte os numeros de string 
    public void AddNumber(int number)
    {
        playerAnswer += number.ToString();
        //atualiza a tela
        playerAnswerText.text = playerAnswer;
    }
    public void ConfirmAnswer()
    {
        int playerResult;
        if(int.TryParse(playerAnswer, out playerResult))
        {
            if(playerResult == correctAnswer)
            {
                Debug.Log("correto");
                Correto.SetActive(true);

                //dano que inflige o boss aqui
                //GetComponent<Boss_arena>().Hp_boss--;
                Hp_boss--;
                //Debug.Log(GetComponent<Boss_arena>().Hp_boss);                                                  
               GenerateEquation();
               Boss();
            }
            else
            {
                // GetComponent<Player>().Vida--;
                Errado.SetActive(true);
                Debug.Log("errado");
            }
        }
        playerAnswer = "";
        playerAnswerText.text = "";
    }
   public void Boss()
    {
        if (Hp_boss == 3)
        {
            Vida.text = "Hp Boss: 3";
        }
        if (Hp_boss == 2)
        {
            Vida.text = "Hp Boss: 2";
        }
        if (Hp_boss == 2)
        {
            Vida.text = "Hp Boss: 1";
        }
        if (Hp_boss <= 0)
        {
            SceneManager.LoadScene("Gameplay");
        }                                   
   
        tempo_disparo += Time.deltaTime;
        if (tempo_disparo >= 1f)
        {
            tempo_disparo = 0f;
             //Instantiate(bullet, transform.position, Quaternion.identity);
            // Instantiate(bullet, transform.position, Quaternion.identity);
        }

    }   
}
