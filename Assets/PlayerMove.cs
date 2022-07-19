using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Vector2 boxSize;
    public float maxSpeed;
    private Vector3 moveDirection = Vector3.zero;
    public LayerMask whatIsLayer;
    private int index = 1;
    private float curTime = 0;
    public float coolTime = 0.5f;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(curTime);
            if (curTime <= 0)
            {
                //Debug.Log("Attack!");
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.position, boxSize, whatIsLayer);
                for (int i = 0; i < collider2Ds.Length; i++)
                {
                    if(collider2Ds[i].GetComponent<EnemyMove>())
                    {
                        collider2Ds[i].GetComponent<EnemyMove>().TakeDamage(1);
                        //Debug.Log(collider2Ds[i].name + " On Damaged");
                    }
                }
                GetComponentInChildren<Animator>().SetTrigger("Attack");
                curTime = coolTime;
            }
        }
        curTime -= Time.deltaTime;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, y, 0);
        transform.position += moveDirection * maxSpeed * Time.deltaTime;

        
        if (x > 0)
            index = 7;
        else if (x < 0)
            index = 6;
        else if (y < 0)
            index = 5;
        else if (y > 0)
            index = 4;
        else
        {
            if (index >= 4)
                index -= 4;
        }
        spriteRenderer.sprite = sprites[index];

        //Debug.Log(x);
        //Debug.Log(y);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireCube(pos.position, boxSize);
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    //Debug.Log(collision.transform.tag);
    //    if (collision.transform.CompareTag("Enemy") && gameObject.layer != 9)
    //        OnDamaged();
    //}


    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Wall"))
    //    {
    //        Vector2 temp = collision.transform.position - transform.position;
    //        Debug.Log(temp);

    //        if (temp.x > 0)
    //        {
    //            transform.position -= new Vector3(maxSpeed, 0) * Time.deltaTime;
    //        }
    //        else
    //        {
    //            transform.position += new Vector3(maxSpeed, 0) * Time.deltaTime;
    //        }
    //    }
    //}
}
