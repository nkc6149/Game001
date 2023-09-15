using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir; //移動方向保存
    float speed;    // 移動速度保存
    Animator anm;   // アニメーターコンポーネントを保存

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float jumpPower = 5.0f;

    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        // アニメーターコンポーネント取得
        anm = GetComponent<Animator>();
        speed = 3; // 初期スピード

        if (rigidbody2d == null)
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal"); //左右移動
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (rigidbody2d == null)
        {
            return;
        }

        //// 移動
        //rigidbody2d.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidbody2d.velocity.y);

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            anm.Play("Jump");
        }
        // アニメーション設定
        if (dir.x == 0) anm.Play("idle");
        else if (dir.x == 1) anm.Play("Run");
        else if (dir.x == -1) anm.Play("Run");
    }
}   