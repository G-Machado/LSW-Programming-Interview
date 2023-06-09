using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private void Awake()
    {
        instance = this; 
    }

    public float speed;
    private Rigidbody2D rb;
    public Animator anim;
    public InventoryManager inventory;

    public GameObject InventoryUI;
    public Animator inventoryUIAnim;

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

        rb.velocity = finalVel * speed;

        anim.SetFloat("MovementBlend", finalVel.magnitude);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUIAnim.SetBool("opened", !inventoryUIAnim.GetBool("opened"));
        }
    }
}
