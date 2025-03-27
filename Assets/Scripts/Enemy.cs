using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float speed = 3f;
    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            //คำนวณทิศทางจาก Enemy ไปหา Player

            transform.position += direction * speed * Time.deltaTime;
            //เคลื่อนที่เข้าหา Player

            transform.LookAt(player);
            //Enemy หันหน้าไปทาง Player

        }
    }// Update

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }//TakeDamge


    








}
