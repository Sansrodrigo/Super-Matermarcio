using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool playerNearby = false;
    public GameObject TelaVitoria;
   

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Z) && gameObject.name == "Portal")
        {
            SceneManager.LoadScene("Vitoria");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
