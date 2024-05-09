using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour , IHitAble
{
    [Header("controller")]
    public bool stop = false;
    public bool hit = false;

    [Header("Speed")]
    [Tooltip("increase speed value by time")]
    [SerializeField] float speedIncrease = 2;
    [Tooltip("for set player max speed")]
    [SerializeField][Range(0, 100)] float maxSpeed = 1000;
    [Tooltip("for set player start speed")]
    [SerializeField][Range(-100, 100)] float startSpeed = 500;
    [Tooltip("for set player min speed")]
    [SerializeField][Range(-100, 100)]const float minSpeed = 0;

    [Header("Jump")]
    [Tooltip("Layer of the Ground")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool isGrounded;//current ground
    [SerializeField] private float jumpForce;
    public float currentSpeed{get;set;}
    private Rigidbody2D rb;
    private InputControl input;
    private GameManager gameManager;

    bool ground() // check if it ground or not
    {
        RaycastHit2D _hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y), Vector2.down, 0.1f, groundLayer);
        isGrounded = _hit.collider != null;
        return isGrounded;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputControl>();
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
        currentSpeed = startSpeed;
    }


    private void FixedUpdate()
    {
        isGrounded = ground();// check if it ground or not
        if(gameManager.isStart)
            move();
    }

    private void move()
    {

        // TODO add isStart in GameManager
        if(currentSpeed < maxSpeed && !stop && !hit || input.jump & isGrounded)
            currentSpeed += speedIncrease * Time.deltaTime; 

        
        Debug.Log(currentSpeed);
        
        float speed; // run speed
        float _jumpF;// jump force

        if (!stop)
        {
            if (input.jump & isGrounded)
            {
                _jumpF = jumpForce;
                speed = 0;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                _jumpF = 0;
                speed = currentSpeed;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            rb.AddForce(Vector2.up * _jumpF + Vector2.right * speed * Time.deltaTime,ForceMode2D.Impulse);
        }
    }

    public void _Hit()
    {
        hit = true;
        stop = true;
        currentSpeed = startSpeed;
        if(hit)
            StartCoroutine(takeDamege());
    }

    IEnumerator takeDamege()
    {
        yield return new WaitForSeconds(1.5f);
        hit = false;
        stop = false;
    }

}
