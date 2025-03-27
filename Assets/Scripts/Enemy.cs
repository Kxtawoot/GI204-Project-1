using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float speed = 3f;
    public int damage = 10;
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
            //�ӹǳ��ȷҧ�ҡ Enemy ��� Player

            transform.position += direction * speed * Time.deltaTime;
            //����͹�������� Player

            transform.LookAt(player);
            //Enemy �ѹ˹��价ҧ Player

        }
    }// Update

    private void OnTriggerEnter(Collider other)
    {
        // ��Ǩ�ͺ����繡�ê��Ѻ Player �������
        if (other.CompareTag("Player"))
        {
            // �Ҥ���๹�� PlayerHealth � Player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // ��Ǩ�ͺ��� PlayerHealth ������
            if (playerHealth != null)
            {
                // Ŵ HP �ͧ Player
                playerHealth.TakeDamage(damage);  // �ӡ��Ŵ HP �ͧ Player
            }

            // ����� Enemy ������ѧ�ҡ��
            Destroy(gameObject);  // Enemy ������ѧ�ҡ��
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }//TakeDamge


    








}
