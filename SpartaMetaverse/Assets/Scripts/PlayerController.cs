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

        // 플레이어 애니메이션 및 방향 저장
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

        //// 스페이스를 누르면 조사 상호작용
        //if(Input.GetKeyDown(KeyCode.Space) && scanObject != null)
        //{
        //    Debug.Log(scanObject.name);
        //}

        // 스페이스바는 유니티에서 점프로 등록되어 있다
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            diaMan.Action(scanObject);
        }
    }

    // 고정 처리
    private void FixedUpdate()
    {
        // 플레이어 이동 
        rb.velocity = new Vector2 (h, v) * speed;


        // 조사
        // 플레이어가 바라보는 방향으로 레이캐스트를 쏴서 체크한다
        // 레이어를 받아와, ObjectNpc 레이어인 것들만 스캔한다
        Debug.DrawRay(rb.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, dirVec, 0.7f,
            LayerMask.GetMask("ObjectNpc"));

        // 쏜 레이캐스트가 뭔가에 맞았을 때
        if(rayHit.collider != null)
        {
            // 맞은 상호작용 대상 저장
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;

    }
}
