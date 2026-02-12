using UnityEngine;

public class Marcio_Animation : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Up_Walk", true);
        }
        else 
        {
            animator.SetBool("Up_Walk", false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("Down_Walk", true);
        }
        else
        {
            animator.SetBool("Down_Walk", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow)))
        {
            animator.SetBool("H_Walk", true);
        }
        else
        {
            animator.SetBool("H_Walk", false);
        }

    }
}

