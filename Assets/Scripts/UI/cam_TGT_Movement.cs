using Unity.VisualScripting;
using UnityEngine;

public class cam_TGT_Movement : MonoBehaviour
{
    Vector2 basePOS;
    Vector2 movementPOS;

    void Start()
    {
        basePOS = transform.localPosition;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementPOS.y = 0.5f;
            transform.localPosition = Vector2.MoveTowards(basePOS,movementPOS,1*Time.deltaTime);        
        }
        else
        {
            movementPOS = basePOS;
        }
        
    }
}
