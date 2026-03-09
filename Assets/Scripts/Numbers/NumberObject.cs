using UnityEngine;

public class NumberObject : MonoBehaviour
{
    public int NumberValue;
    private bool playerNearby = false;
    private void Start()
    {
        if(ArenaManager.instance == null)
        {
            Debug.Log("manager esta null no start");
        }
    }
    private void Update()
    {
        if (ArenaManager.instance == null)
        {
            Debug.Log("NumbersManage esta null no update");
        }
        if(playerNearby && Input.GetKeyDown(KeyCode.Z) && CompareTag("buttons"))
        {
            ArenaManager.instance.AddNumber(NumberValue);
            Debug.Log("chamou o add");
        }
        if (playerNearby && Input.GetKeyDown(KeyCode.Z) && gameObject.name == "Delete")
        {
            ArenaManager.instance.RemoveNumber();
        }
        if (playerNearby && Input.GetKeyDown(KeyCode.Z) && gameObject.name == "Confirm")
        {
            ArenaManager.instance.ConfirmAnswer();
            Number_Spawn.instance.RandomizePosition();
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
