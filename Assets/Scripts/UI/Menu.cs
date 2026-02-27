using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    [SerializeField] GameObject users;
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
    public void teste()
    {
        Player.save.Load();
    }

}
