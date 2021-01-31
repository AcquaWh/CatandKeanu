using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Platform2DUtils.GameplaySystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Gato : MonoBehaviour
{
    protected Animator anim;
    protected SpriteRenderer spr;
    protected Rigidbody2D rb2D;
    [SerializeField, Range(0.1f, 20f)]
    protected float moveSpeed = 2f;
    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField, Range(0.1f, 20f)]
    protected float jumpForce = 7f;
    [SerializeField, Range(0.1f, 20f)]
    protected float maxVelX = 1f;

    void Awake(){
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected bool Flip
    {
        get => GameplaySystem.Axis.x > 0 ? false : GameplaySystem.Axis.x < 0f ? true : spr.flipX;
    }

    protected bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Whiskas"))
        {
            Comida whiskas = other.GetComponent<Comida>();
            Gamemanager.instance.Score.AddPoints(whiskas.Points);
            Destroy(other.gameObject);
        } else if(other.CompareTag("Pepinillo"))
        {
            Pepinillo pepinillo = other.GetComponent<Pepinillo>();
            Gamemanager.instance.Score.DeletePoints(pepinillo.Daño);
            Destroy(other.gameObject);
        }
    }
    
}
