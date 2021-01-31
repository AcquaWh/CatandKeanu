using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int maxHp = 5;
    int currentHp = 5;

    public void AddPoints(int points)
    {
        if(currentHp + points <= maxHp)
        {
            currentHp++;

            Debug.Log(currentHp);
        }
    }
}
