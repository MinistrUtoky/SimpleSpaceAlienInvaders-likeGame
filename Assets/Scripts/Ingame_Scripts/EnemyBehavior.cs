using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private int speed = 3;
    [SerializeField]
    private GameObject enemyExplosion;
    [SerializeField]
    private AudioClip explosionSound;
    [SerializeField]
    private float m_volume;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);   
        if (transform.position.y < -6.7f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            collision.gameObject.SetActive(false);
            Annihilation();
        }
        else if (collision.tag == "Player")
        {
            Player_Controller playerController = collision.GetComponent<Player_Controller>();
            if (playerController != null)
            {
                playerController.TakingDamage();
            }
            Annihilation();
        }
        else if (collision.tag == "Asteroid")
        {
            Annihilation();
        }
    }
    
    private void Annihilation()
    {
        Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, m_volume);
        Destroy(this.gameObject);
    }
}
