using UnityEngine;
using UnityEngine.UI;

public class NumbersManager : MonoBehaviour
{
  public static NumbersManager instance;

    public Text equationText;
    public Text playerAnswerText;

    public int correctAnswer;

    private string playerAnswer = "";

    private void Awake()
    {
        
        instance = this;
    }
    private void Start()
    {
        Debug.Log("entrou no start");
        GeneratEquation();
    }
    //gerador de equacoes
    void GeneratEquation()
    {
        int a = Random.Range(1, 11);
        int b = Random.Range(1, 11);

        correctAnswer = a * b;
        equationText.text = a + " x " + b;

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
                //dano que inflige o boss aqui
               // GetComponent<Boss_arena>().Hp_boss--;
                GeneratEquation();
            }
            else
            {
               // GetComponent<Player>().Vida--;
                Debug.Log("errado");
            }
        }
        playerAnswer = "";
        playerAnswerText.text = "";
    }
}
