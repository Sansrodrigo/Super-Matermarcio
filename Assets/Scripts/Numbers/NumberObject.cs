using UnityEngine;

public class NumberObject : MonoBehaviour
{
    public int NumberValue;
    private bool playerNeaby = false;
    private void Start()
    {
        if(NumbersManager.instance == null)
        {
            Debug.Log("manager esta null no start");
        }
    }
    private void Update()
    {
        if(NumbersManager.instance == null)
        {
            Debug.Log("NumbersManage esta null no update");
        }
        if(playerNeaby && Input.GetKeyDown(KeyCode.Z))
        {
            NumbersManager.instance.AddNumber(NumberValue);
            Debug.Log("chamou o add");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
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
