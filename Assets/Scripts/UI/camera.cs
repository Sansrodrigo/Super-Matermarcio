using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{
    [SerializeField] GameObject camTarget; //Pode ser o player ou outra coisa
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Gameplay")
        {
            transform.position = camTarget.transform.position + new Vector3(0f, 0f, -10f);
        }
        else
        {
            camTarget = null;
        }
    }
}
