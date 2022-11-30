using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OssoColetavel : MonoBehaviour
{public int ammoToAdd;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colGO = col.gameObject;
        if(colGO.name == "Player")
        {
            colGO.GetComponent<PlayerShoot>().UpdateAmmo(ammoToAdd);
            Destroy(gameObject);
        }
        
        
    }
}