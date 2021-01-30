using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    int maxHp = 5;
    int currentHp;
    SpriteRenderer gato;
    Rigidbody2D rb2D;
    [SerializeField, Range(0.1f, 15f)]
    float moveSpeed = 2f;

    [SerializeField]
    Color rayColor;
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField, Range(0.1f, 20f)]
    float jumpForce = 7f;


    void Awake(){
        anim = GetComponent<Animator>();
        gato = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHp = maxHp;   
    }

    void Update()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        gato.flipX = Flip;
    }

    void FixedUpdate()
    {
        if(Grounding)
        {
            if(JumpButton)
            {
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);   
            }
        }
    }

    void LateUpdate()
    {
       anim.SetBool("grounding", Grounding);
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

    bool Flip 
    {
        get => Axis.x > 0 ? false : Axis.x < 0f ? true : gato.flipX;
    }

    bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    bool JumpButton
    {
        get => Input.GetButtonDown("Jump");
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
