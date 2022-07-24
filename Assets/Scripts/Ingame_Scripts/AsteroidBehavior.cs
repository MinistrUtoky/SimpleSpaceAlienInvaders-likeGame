using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -9.9)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player_Controller playerController = collision.GetComponent<Player_Controller>();
            if (playerController != null)
            {
                playerController.TakingDamage();
            }
        }
    }
}
