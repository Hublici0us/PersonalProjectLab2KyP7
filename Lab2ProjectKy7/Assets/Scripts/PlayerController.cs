using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public int health = 100;

    public Camera playerCam;

    public ParticleSystem shablooey;
    public ParticleSystem healthyParticle;


    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        CameraFollow();
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    void CameraFollow()
    {
        playerCam.transform.position = new Vector3(playerRb.position.x, 20, playerRb.position.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            float cooldown = 0; cooldown = cooldown - Time.deltaTime;

            if (cooldown <= 0 && health > 0)
            {
                health--;
                Debug.Log(health);
                cooldown = 2;
            }
            else if (health <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        Debug.Log("PP");
        shablooey.Play();
    }
}
