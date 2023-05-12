using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skills : MonoBehaviour
{
    float frequency = 11.0f;
    float damage = 42.0f;
    float shots = 3.0f;
    float diagonal = 1.0f;

    public Image increase1;
    public Image decrease1;
    public Image shootUp1;
    public Image diagonal1;
    public Image arsenal1;



    int frequencyi = 11;
    int damagei = 42;
    int shooti = 3; 
    int diagonali = 1;    

    TextMeshProUGUI TMPtext_Gold;
    public GameObject mHero;
    int Wealth_Point;

    void Start()
    {
        TMPtext_Gold = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
    }

    public void arsenal10()
    {
        StartCoroutine(Seconds());
    }
    IEnumerator Seconds() {
        float firstRate = mHero.GetComponent<Shoots>().fireRate;
        float endTime = Time.time + 25f;
        while (Time.time < endTime) {
            mHero.GetComponent<Shoots>().fireRate = 0.1f;
            yield return null;
        }
        mHero.GetComponent<Shoots>().fireRate = firstRate;
    }

    public void shootSameTime()
    {
        StartCoroutine(Secondss());
    }
    IEnumerator Secondss() {
        int firstDemage = mHero.GetComponent<Shoots>().ExDemage;
        float endTime = Time.time + 5f;
        while (Time.time < endTime) {
            mHero.GetComponent<Shoots>().ExDemage = 75;
            yield return null;
        }
        mHero.GetComponent<Shoots>().ExDemage = firstDemage;
    }
 
    public void diagonal10()
    {
        Wealth_Point = int.Parse(TMPtext_Gold.text);
        if (diagonali > 0 && Wealth_Point >= 30)
        {
            mHero.GetComponent<Shoots>().diagon = 90.0f;
            diagonali --;
            diagonal1.fillAmount = diagonali/diagonal;
            Debug.Log("diagonal boom");
            Wealth_Point -=20;
            TMPtext_Gold.text = Wealth_Point.ToString();
        }
    }
    public void shootUp10()
    {
        Wealth_Point = int.Parse(TMPtext_Gold.text);
        if (shooti > 0 && Wealth_Point >= 20)
        {
            mHero.GetComponent<Shoots>().ExFire += 1; 
            shooti --;
            shootUp1.fillAmount = shooti/shots;
            Debug.Log("shots boom");
            Wealth_Point -=20;
            TMPtext_Gold.text = Wealth_Point.ToString();
        }   
    }

    public void increase10()
    {
        Wealth_Point = int.Parse(TMPtext_Gold.text);
        if (frequencyi > 0 && Wealth_Point >= 20)
        {
            mHero.GetComponent<Shoots>().fireRate -= 0.1f;
            frequencyi --;
            increase1.fillAmount = frequencyi/frequency;
            Debug.Log("increase boom");  
            Wealth_Point -=20;
            TMPtext_Gold.text = Wealth_Point.ToString();          
        }
        
    }
    public void decrease10()
    {
        Wealth_Point = int.Parse(TMPtext_Gold.text);
        if (damagei > 0 && Wealth_Point >= 10)
        {
            mHero.GetComponent<Shoots>().ExDemage += 5;
            damagei --;
            decrease1.fillAmount = damagei/damage;
            Debug.Log("decrease boom");
            Wealth_Point -=20;
            TMPtext_Gold.text = Wealth_Point.ToString(); 
        }    
    }
}
