using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int maxHp = 5;
    int currentHp;
    [SerializeField, Range(0.1f, 15f)]
    float moveSpeed = 2f;

    void Start()
    {
        currentHp = maxHp;   
    }

    void Update()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Pepino")) 
        {
            Destroy(other.gameObject);
            currentHp--;
            Debug.Log(currentHp);

            if (fatalDamage)
            {
                die();
            } 
        }
        else if (other.CompareTag("Whiskas")) 
        {
            if (currentHp + 1 <= maxHp)
            {
                Destroy(other.gameObject);
                currentHp++;
            }
            Debug.Log(currentHp);
        }
    }

    private void die()
    {
        // TODO: Animaciones de muerte y la v
        Debug.Log("DEAD");
    }

    private bool fatalDamage
    {
        get => currentHp <= 0;
    }

    Vector2 Axis
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
