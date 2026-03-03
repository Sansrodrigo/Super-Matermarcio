using UnityEngine;

public class EqualObject : MonoBehaviour
{
    private bool playerNeaby = false;
    private void Update()
    {
        if(playerNeaby && Input.GetKeyDown(KeyCode.Space))
        {
            if(NumbersManager.instance != null)
            {
                Debug.Log("Entrou no get key");
                NumbersManager.instance.ConfirmAnswer();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Entrou na colisao");
            playerNeaby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNeaby = false;
        }
    }
}
