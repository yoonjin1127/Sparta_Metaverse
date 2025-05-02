using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    DialogueManager diaMan;

    public float speed;
    Animator animator;
    SpriteRenderer spr;

    Rigidbody2D rb;

    Vector3 dirVec;

    GameObject scanObject;

    float h;
    float v;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spr = GetComponentInChildren<SpriteRenderer>();
        diaMan = DialogueManager.instance;
    }

    private void Update()
    {
        h = diaMan.isAction ? 0 : Input.GetAxis("Horizontal");
        v = diaMan.isAction ? 0 : Input.GetAxis("Vertical");

        // �÷��̾� �ִϸ��̼� �� ���� ����
        if (h < 0)
        {
            spr.flipX = true;
            animator.SetBool("IsMove", true);
            dirVec = Vector3.left;
        }
        else if (h > 0)
        {
            spr.flipX = false;
            animator.SetBool("IsMove", true);
            dirVec = Vector3.right;
        }
        else if (v > 0)
        {
            animator.SetBool("IsMove", true);
            dirVec = Vector3.up;
        }
        else if (v < 0)
        {
            animator.SetBool("IsMove", true);
            dirVec = Vector3.down;
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

        //// �����̽��� ������ ���� ��ȣ�ۿ�
        //if(Input.GetKeyDown(KeyCode.Space) && scanObject != null)
        //{
        //    Debug.Log(scanObject.name);
        //}

        // �����̽��ٴ� ����Ƽ���� ������ ��ϵǾ� �ִ�
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            diaMan.Action(scanObject);
        }
    }

    // ���� ó��
    private void FixedUpdate()
    {
        // �÷��̾� �̵� 
        rb.velocity = new Vector2 (h, v) * speed;


        // ����
        // �÷��̾ �ٶ󺸴� �������� ����ĳ��Ʈ�� ���� üũ�Ѵ�
        // ���̾ �޾ƿ�, ObjectNpc ���̾��� �͵鸸 ��ĵ�Ѵ�
        Debug.DrawRay(rb.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, dirVec, 0.7f,
            LayerMask.GetMask("ObjectNpc"));

        // �� ����ĳ��Ʈ�� ������ �¾��� ��
        if(rayHit.collider != null)
        {
            // ���� ��ȣ�ۿ� ��� ����
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;

    }
}
