using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    
    public TextMeshProUGUI TMPtext;
    int times = 300;

    public GameObject enemies1;
    public GameObject enemies2;
    GameObject[] Spawn_points;
    
    void Start()
    {
        Spawn_points = GameObject.FindGameObjectsWithTag("Spawn_point");
        InvokeRepeating("Down_Time", 0.0f, 1.0f);
        InvokeRepeating("Spawn_enemies", 0.0f, 7.0f);
    }

    void Down_Time()
    {
        times--;
        TMPtext.text = times.ToString();

        if(times <= 0)
        {
            Debug.Log("Congurulations, You Win");
        }
    }

    void Spawn_enemies()
    {
        int rndm = Random.Range(0, Spawn_points.Length);
        GameObject new_enemiesone = Instantiate(enemies1, Spawn_points[rndm].transform.position, Quaternion.identity);
        GameObject new_enemiestwo = Instantiate(enemies2, Spawn_points[rndm].transform.position, Quaternion.identity);
    }

   
}
