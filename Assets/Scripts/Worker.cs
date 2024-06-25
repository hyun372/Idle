using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rigid;
    private Vector2 currentDirection;
    private float colTimer = 0;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetInitialDirection();
    }

    private void Update()
    {  
        if (colTimer >= 0.1f)
        {
            SetRandomDirection();
            colTimer = 0;
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = currentDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Vector2 reflectedDirection = Vector2.Reflect(currentDirection, normal).normalized;

        // 반사된 벡터가 초기 방향과 동일하거나 반대 방향인 경우, 새 방향을 임의로 조정
        if (Mathf.Approximately(Vector2.Dot(reflectedDirection, currentDirection), 1.0f) ||
            Mathf.Approximately(Vector2.Dot(reflectedDirection, currentDirection), -1.0f))
        {
            SetRandomDirection();
        }
        else
        {
            float angle = Vector2.SignedAngle(Vector2.right, reflectedDirection);
            float targetAngle = Mathf.Round((angle - 45) / 90) * 90 + 45;
            currentDirection = Quaternion.Euler(0, 0, targetAngle) * Vector2.right; // 새 방향 설정
        }

        rigid.velocity = currentDirection * speed;

        if(collision.gameObject.CompareTag(TagAndLayers.TagName.Work))
        {
            Work work = collision.gameObject.GetComponent<Work>();
            if (work != null) { work.OnClicked(); }   
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        colTimer += Time.deltaTime;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colTimer = 0;
    }

    private void SetInitialDirection()
    {
        currentDirection = new Vector2(1, 1).normalized; // 초기 이동 방향 설정 (북동)
    }

    private void SetRandomDirection()
    {
        float angle = Random.Range(0, 4) * 90 + 45;
        currentDirection = Quaternion.Euler(0, 0, angle) * Vector2.right;
    }
}
