using UnityEngine;

public class EG : MonoBehaviour
{
   private bool playerNearby = false;
   private int count = 0;
   [SerializeField] GameObject camTarget;

    private void Update()
    {
        playerNearby = true;
        if (playerNearby && Input.GetKeyDown(KeyCode.Z))
        {
            count++;
            if(count == 5)
            {
                GameObject.Destroy(gameObject);
            }
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
