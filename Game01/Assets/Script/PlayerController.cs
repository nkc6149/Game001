using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir; //�ړ������ۑ�
    float speed;    // �ړ����x�ۑ�
    Animator anm;   // �A�j���[�^�[�R���|�[�l���g��ۑ�

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float jumpPower = 5.0f;

    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g�擾
        anm = GetComponent<Animator>();
        speed = 3; // �����X�s�[�h

        if (rigidbody2d == null)
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal"); //���E�ړ�
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (rigidbody2d == null)
        {
            return;
        }

        //// �ړ�
        //rigidbody2d.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidbody2d.velocity.y);

        // �W�����v
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            anm.Play("Jump");
        }
        // �A�j���[�V�����ݒ�
        if (dir.x == 0) anm.Play("idle");
        else if (dir.x == 1) anm.Play("Run");
        else if (dir.x == -1) anm.Play("Run");
    }
}   