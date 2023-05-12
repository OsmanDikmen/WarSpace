using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero : MonoBehaviour
{
    public TextMeshProUGUI TMPtext_Health;
    int Health_now = 100;

    public void Down_health()
    {
        Health_now -=5;
        TMPtext_Health.text = Health_now.ToString();

        if(Health_now <= 0)
        {
            Debug.Log("You Lost");
        }
    }



}
