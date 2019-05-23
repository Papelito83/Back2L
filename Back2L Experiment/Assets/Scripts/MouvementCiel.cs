using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementCiel : MonoBehaviour
{
    public GameObject ciel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = ciel.transform.position.x;

        ciel.transform.position = new Vector3(xPos+0.5f*Time.deltaTime, 0, 0);

        if (xPos >= 12.0f)
        {
            ciel.transform.position = new Vector3(0.5f * Time.deltaTime, 0, 0); 
        }
    }
}
