using UnityEngine;

public class Animacao : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    [SerializeField] Animator animator;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
            {
            animator.SetBool("esquerda", true);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("esquerda", false);
        }
       
        
    }
}
