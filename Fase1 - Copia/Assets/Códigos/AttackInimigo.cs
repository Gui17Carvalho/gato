using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInimigo : MonoBehaviour
{
     public Animator anim;
    public SpriteRenderer sprite;

    private int vida = 1;
    public float moveSpeed = 1f;


    public BoxCollider2D colliderAtk;
    public BoxCollider2D colliderCheckAtk;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform)
        {
            //sprite.flipX = true;
            colliderAtk.offset = new Vector2(-0.41f, 0.4f);
            colliderCheckAtk.offset = new Vector2(-0.41f, 0.4f);
        }
        else
        {
            //sprite.flipX = false;
            colliderAtk.offset = new Vector2(0.41f, 0.4f);
            colliderCheckAtk.offset = new Vector2(0.41f, 0.4f);
        }

        Move();

    }
    private void Move()
        {
            if (CheckAttack.checkAttack == true)
            {
                StartCoroutine("Attack");
            }
        }

        IEnumerator Attack()
        {
            anim.SetBool("attack", true);
            moveSpeed = 0;

            yield return new WaitForSeconds(5.0f);
            anim.SetBool("attack", false);
            moveSpeed = 1;

            if(vida<=3 && vida>0){
            vida -= 1;
    
            }

            CheckAttack.checkAttack = false;
        }
}
