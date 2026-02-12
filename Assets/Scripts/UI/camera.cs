using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _camera.transform.position = transform.position + new Vector3(0f, 0f, -10f);     
    }
}
