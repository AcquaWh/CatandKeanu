using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int maxHp = 5;
    int currentHp = 5;

    public void DeletePoints(int daño)
    {
        currentHp--;
        Debug.Log("tu vida es:" + currentHp);
        if(fatalDamage)
        {
            Debug.Log("te moriste");
        }
    }
    public void AddPoints(int points)
    {
        if(currentHp + points <= maxHp)
        {
            currentHp++;
            Debug.Log("tu vida es:" + currentHp);
        }
    }

    bool fatalDamage
    {
        get => currentHp <= 0;
    }
}
