using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    private float nextShotTime;

    [SerializeField]
    private int healthPoints = 3;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private int spd = 6;
    [SerializeField]
    private GameObject playerExplosion;
    private AudioSource laserSound;
    void Start()
    {
        transform.position = new Vector3(0, -3, 0);
        laserSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        SpaceshipMovement();
        Shooting();
    }

    public void TakingDamage()
    {
        healthPoints--;
        if (healthPoints == 0)
        {
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
    }

    private void Shooting()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextShotTime)
            {
                laserSound.Play();
                nextShotTime = Time.time + fireRate;
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = transform.position + new Vector3(0, 1.3f, 0);
                    bullet.transform.rotation = Quaternion.identity;
                    bullet.SetActive(true);
                }
            }
        }
    }

    private void SpaceshipMovement()
    {
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * spd * horInput);
        transform.Translate(Vector3.up * Time.deltaTime * spd * vertInput);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.07f)
        {
            transform.position = new Vector3(transform.position.x, -4.07f, 0);
        }
        if (transform.position.x > 9.7f)
        {
            transform.position = new Vector3(-9.7f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.7f)
        {
            transform.position = new Vector3(9.7f, transform.position.y, 0);
        }
    }
}
