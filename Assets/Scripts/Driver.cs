using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [Header("Car Movement")]
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] string boostTag;

    private float moveSpeed;

    void Awake()
    {
        moveSpeed = slowSpeed;
    }

    void Start()
    {
        Debug.Log("Vroom!!!");
    }

    void Update()
    {
        // Adjust user input to configured values, normalized by deltaTime
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical")    * moveSpeed  * Time.deltaTime;
        // Apply user input
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == boostTag)
        {
            moveSpeed = boostSpeed;
            Debug.Log("GO FAST JUICE...GO!!!!!!");
        }
    }
}
