
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Player; //Pode ser o player ou outra coisa
    [SerializeField] public GameObject camTarget;

    [SerializeField] float offsetDistance = 1f; 
    [SerializeField] float smoothSpeed = 5f; 
    
    private Vector3 targetOffset = Vector3.zero;
    private Vector3 currentOffset = Vector3.zero;
    private Vector3 originalCameraOffset = Vector3.zero;

    [SerializeField] public Vector3 customCameraPosition = Vector3.zero;
    [SerializeField] public bool useCustomPosition = false;

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "World_1" || SceneManager.GetActiveScene().name == "House0_F0")
        {
            if (SceneManager.GetActiveScene().name == "House0_F0")
                offsetDistance = 0;
            else
            {
                offsetDistance = 1;
            }

            // Se está usando posição customizada
            if(useCustomPosition)
            {
                if (camTarget != null)
                    customCameraPosition = camTarget.transform.position - Player.transform.position;

                targetOffset = customCameraPosition;
            }
            else
            {
                Vector3 inputDirection = Vector3.zero;

                if (!useCustomPosition)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                        inputDirection += Vector3.up;
                    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                        inputDirection += Vector3.down;
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                        inputDirection += Vector3.left;
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                        inputDirection += Vector3.right;
                }

                
                // Define o offset alvo baseado na entrada
                if(inputDirection.magnitude > 0)
                {
                    inputDirection = inputDirection.normalized;
                    targetOffset = new Vector3(inputDirection.x * offsetDistance, inputDirection.y * offsetDistance, -10f);
                }
                else
                {
                    targetOffset = new Vector3(0f, 0f, -10f);
                }
            }
            
            currentOffset = Vector3.Lerp(currentOffset, targetOffset, Time.deltaTime * smoothSpeed);

            transform.position = Player.transform.position + currentOffset;
        }
        else
        {
            Player = null;
        }
    }
}
