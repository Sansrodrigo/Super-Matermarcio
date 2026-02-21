using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    [SerializeField] GameObject users;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    // ativa o painel creditos
    public void Creditos()
    {
        users.SetActive(true);
    }
    // começa o jogo
    public void NovoJogo()
    {
        SceneManager.LoadScene("Gameplay");

    }
    // desativa o painel creditos
    public void Volta()
    {
        users.SetActive(false);
    }
    
    
}
