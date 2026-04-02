using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector2 velocityLimitMinMax;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var vertical = rb.linearVelocity;
        vertical.y = Math.Clamp(vertical.y, velocityLimitMinMax.x, velocityLimitMinMax.y);
        rb.linearVelocity = vertical;
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
