using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField]
    private int laserSpd = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * laserSpd * Time.deltaTime);
        if (transform.position.y > 5.7f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
