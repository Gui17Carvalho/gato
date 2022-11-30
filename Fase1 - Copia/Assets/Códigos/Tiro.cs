using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float shootSpeed, shootTimer;
     private bool isShooting;

      public Transform shootPos;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        int direction()
        {
        if(this.transform.localScale.x < 0f)
        {
            return -1;
        }
        else
        {
            return +1;
        }
        }

        isShooting = true;
        GameObject newbullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
        newbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newbullet.transform.localScale = new Vector2(newbullet.transform.localScale.x * direction(), newbullet.transform.localScale.y);

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
