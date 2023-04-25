using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle;
    int minAngle = -60;
    int maxAngle = 20;
    bool toucheGround;

    public Score score;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;
    [SerializeField]
    private AudioSource swim , hit , point ;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale= 0; 
        sp= GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        FishSwim();
        
    }

    private void FixedUpdate()
    {
        FishRotation();
    }
    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver ==false)
        {
            swim.Play();
            if (GameManager.gameStarted==false)
            {
                _rb.gravityScale = 2;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }
            
        }

    }
    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }
        if (toucheGround ==false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("Column")&&GameManager.gameOver==false)
        {
            gameManager.GameOver();
            FishDieEffect();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                FishDieEffect();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }


        }
    }
    void GameOver()
    {
        anim.enabled= false;    
        sp.sprite = fishDied;
        toucheGround = true;
        transform.rotation= Quaternion.Euler(0, 0, -90);
    }
    void FishDieEffect()
    {
        hit.Play();
    }
}
