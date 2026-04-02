using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour,IDragHandler
{
    [SerializeField] private Transform main;
    [SerializeField] private float speed;

    private float startPoint;

    public void OnDrag(PointerEventData eventData)
    {
        var rotation = main.rotation;
        var current = rotation.eulerAngles.y;
        current += eventData.delta.x * speed;
        rotation.eulerAngles = new Vector3(0,current, 0);

        main.rotation = rotation;
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
