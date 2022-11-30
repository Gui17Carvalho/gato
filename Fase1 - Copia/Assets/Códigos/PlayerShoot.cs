using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    public int maxAmmo;

    private bool isShooting;
    private int currentAmmo;

    public Transform shootPos;
    public GameObject bullet;
    
    public TextMeshProUGUI AmmoText;
    void Start()
    {
        currentAmmo = maxAmmo;
        isShooting = false;
        AmmoText.text = currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !isShooting && currentAmmo > 0)
        {
            StartCoroutine(Shoot());
            UpdateAmmo(-1);
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
    public void UpdateAmmo(int ammo)
    {
        currentAmmo += ammo;
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        AmmoText.text = currentAmmo.ToString();
    }
}
