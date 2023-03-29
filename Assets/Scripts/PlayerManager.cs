using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 finalVel = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
            );

        //if(finalVel.magnitude > .5f) rb.velocity = finalVel * speed;
        //else rb.velocity = Vector2.zero;

        rb.velocity = finalVel * speed;

        Debug.Log(finalVel.magnitude);
        anim.SetFloat("MovementBlend", finalVel.magnitude);
    }

}