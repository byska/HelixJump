using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour,IDragHandler
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private float startPoint;

    public void OnDrag(PointerEventData eventData)
    {
        float rotationAmount = eventData.delta.x * speed;
        target.Rotate(Vector3.up * rotationAmount);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
