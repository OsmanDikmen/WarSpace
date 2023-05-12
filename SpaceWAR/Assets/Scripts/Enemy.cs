using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    NavMeshAgent enemy;
    TextMeshProUGUI TMPtext_Gold;

    int Health = 100;
    bool atack = false;
    int Wealth_now;
    int pointAdd;
     
    

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        TMPtext_Gold = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
        Wealth_now = int.Parse(TMPtext_Gold.text);
    }


    void Update()
    {
        Enemy_Atack();
        pointAdd = int.Parse(TMPtext_Gold.text);
        Wealth_now =  pointAdd;
    }

    void Enemy_Atack()
    {
        float distance = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);

        if(distance > 1.9f)
        {
            enemy.destination = GameObject.FindWithTag("Player").transform.position;
            atack = false;
            CancelInvoke("Get_Health");
        }
        else
        {
            if(atack == false)
            {
                InvokeRepeating("Get_Health", 0.0f, 2.0f);
                atack = true;
            }
            
        }
    }
    public void Down_health(int damage)
    {
        Health -= damage;

        if(Health <= 0)
        {   
            Wealth_now +=10;
            TMPtext_Gold.text = Wealth_now.ToString();
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject);
            Destroy(enemy);
            
        }
    }
    void Get_Health()
    {
        GameObject.FindWithTag("Player").GetComponent<Hero>().Down_health();
    }
}
