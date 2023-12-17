using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemMovimento : MonoBehaviour
{
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 150);
        }
    }
}
