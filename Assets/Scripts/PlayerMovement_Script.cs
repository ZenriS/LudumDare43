using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Script : MonoBehaviour
{

    public float MoveSpeed;
    public float JumpPower;
    public float SmashForce;
    public bool DoSmash;
    public Sprite[] Sprites;
    public bool IsDead;
    
    private float _horInput;
    private Rigidbody2D _rigidbody2D;
    private bool _grounded;
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;
    private GameManager_Script _gameManagerScript;
    private int _smashCount;

    void Start ()
	{
	    _rigidbody2D = GetComponent<Rigidbody2D>();
	    _boxCollider2D = GetComponent<BoxCollider2D>();
	    _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
        if (!IsDead)
        {
            Movement();
            Jump();
            //Smash();
            if (Input.GetButtonDown("Sacrifices"))
            {
                Sacrifices();
            }
        }
	}

    void Movement()
    {
        float moveStep = MoveSpeed * Time.deltaTime;
        _horInput = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(_horInput * moveStep, _rigidbody2D.velocity.y);
        if (_horInput  <= -0.1f)
        {
            _spriteRenderer.flipX = true;
            _gameManagerScript.CamFollowScript.Offset = -3;
        }
        if(_horInput >= 0.1f)
        {
            _spriteRenderer.flipX = false;
            _gameManagerScript.CamFollowScript.Offset = 3;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") & _grounded)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpPower));
            _grounded = false;
        }
    }

    void Sacrifices()
    {
        if (!IsDead)
        {
            _spriteRenderer.sprite = Sprites[1];
            //transform.localScale = new Vector3(1, 0.5f, 1);
            float collX = _boxCollider2D.size.x;
            float collY = _boxCollider2D.size.y;
            collY /= 2;
            _boxCollider2D.size = new Vector2(collX, 0.46f);
            collY /= 2;
            _boxCollider2D.offset = new Vector2(0, -0.51f);
            IsDead = true;
            _gameManagerScript.Invoke("NewPlayer", 0.5f);
            _gameManagerScript.DeadPlayers.Add(this.gameObject);
            transform.name = "DeadPlayer" + _gameManagerScript.DeadPlayers.Count;
        }
    }

    void Smash()
    {
        if (Input.GetButtonDown("Vertical") && !DoSmash && !_grounded)
        {
            _smashCount++;
            if (_smashCount == 2)
            {
                _rigidbody2D.gravityScale = SmashForce;
                DoSmash = true;
            }
        }
    }

    public void Setup(GameManager_Script gm)
    {
        _gameManagerScript = gm;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground" || coll.transform.tag == "Player")
        {
            DoSmash = false;
            _grounded = true;
            _smashCount = 0;
            _rigidbody2D.gravityScale = 1;
            if (IsDead)
            {
                _rigidbody2D.isKinematic = true;
                _rigidbody2D.useFullKinematicContacts = true;
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            }
        }

        if (coll.transform.tag == "Enemy")
        {
            if (DoSmash)
            {
                Destroy(coll.gameObject);
            }
            else
            {
                Sacrifices();
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground" || coll.transform.tag == "Player")
        {
            _grounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Death")
        {
            Sacrifices();
            //Destroy(this.gameObject);
        }
    }
   
}
