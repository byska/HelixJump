using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        var current = offset + target.position;

        if (current.y > transform.position.y)
            return;

        transform.position = current;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
