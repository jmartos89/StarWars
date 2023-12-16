using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private int speed;
    [SerializeField]
    private float distanceToPlayer;

    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;
    [SerializeField]
    private float timeBetweensBullet;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Attack", 1, timeBetweensBullet);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            transform.LookAt(player.transform.position);

            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > distanceToPlayer) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        for(int i = 0; i < posRotBullet.Length; ++i) {
            Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
        }
    }
}
