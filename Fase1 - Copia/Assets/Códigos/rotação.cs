using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotação : MonoBehaviour
{

    public Vector3 EixoRotação;
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(EixoRotação * velocidade * Time.deltaTime);
    }
}
