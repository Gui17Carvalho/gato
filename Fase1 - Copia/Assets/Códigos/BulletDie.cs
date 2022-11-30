using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{
    public float dieTime, damage;
    public GameObject diePEffect;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Player")
        {
            if(collisionGameObject.GetComponent<HealthScript>() != null)
            {
                collisionGameObject.GetComponent<HealthScript>().TakeDamage(damage);
            }
            Die();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
    // Update is called once per frame
    void Die()
    {
       if(diePEffect != null)
       {
        Instantiate(diePEffect, transform.position, Quaternion.identity);
       }
       Destroy(gameObject);
    }
}
