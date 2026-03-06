using UnityEngine;

public class EqualObject : MonoBehaviour
{
    private bool playerNearby = false;
    private void Update()
    {
        if(playerNearby && Input.GetKeyDown(KeyCode.Z))
        {
            if(ArenaManager.instance != null)
            {
                Debug.Log("Entrou no get key");
                ArenaManager.instance.ConfirmAnswer();
               
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
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
