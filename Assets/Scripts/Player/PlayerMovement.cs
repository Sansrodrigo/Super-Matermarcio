
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 3.5f;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

       
    }

    void Update()
    {
        Vector2 movementVector = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow)) movementVector.x = -1;
        else if (Input.GetKey(KeyCode.RightArrow)) movementVector.x = 1;

        if (Input.GetKey(KeyCode.UpArrow)) movementVector.y = 1;
        else if (Input.GetKey(KeyCode.DownArrow)) movementVector.y = -1;
        _rb.linearVelocity = movementVector * Speed;

        if (Input.GetKeyUp(KeyCode.F7)) SceneManager.LoadScene("Gameplay");
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}