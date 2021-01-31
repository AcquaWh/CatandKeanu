using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepinillo : MonoBehaviour
{
    [SerializeField, Range(1,100)]
    int daño;

    public int Daño { get => daño; }
}
