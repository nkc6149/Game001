using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float jumpPower = 5.0f;

    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        if (rigidbody2d == null)
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody2d == null)
        {
            return;
        }

        // ˆÚ“®
        rigidbody2d.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidbody2d.velocity.y);

        // ƒWƒƒƒ“ƒv
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}