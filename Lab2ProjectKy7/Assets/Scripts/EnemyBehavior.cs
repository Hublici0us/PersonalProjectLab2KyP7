using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5;


    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        if (player.health > 0)
        {
            transform.LookAt(GameObject.Find("Player").transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            return;
        }
    }
}
