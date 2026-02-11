using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject Iniciar;
    [SerializeField] GameObject users;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Creditos()
    {
       users.SetActive(true);
    }
    public void NovoJogo()
    {
        Iniciar.SetActive(true);
    }
    public void Volta()
    {
       users.SetActive(false);
    }
    public void Ok()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
