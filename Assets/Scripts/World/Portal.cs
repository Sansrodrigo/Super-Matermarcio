using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool playerNearby = false;
    public GameObject TelaVitoria;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Z) && gameObject.name == "Portal")
        {
            TelaVitoria.SetActive(true);
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
