using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy_Script : MonoBehaviour
{
    public float MoveSpeed;
    public float MoveTimer;

    private float _activeTimer;
    private bool _left;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

	void Start ()
	{
	    _activeTimer = MoveTimer;
	    _rigidbody2D = GetComponent<Rigidbody2D>();
	    _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
        if (_activeTimer > 0)
        {
            _activeTimer -= Time.deltaTime;
            if (_left)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }
        if (_activeTimer <= 0)
        {
            _left = !_left;
            _activeTimer = MoveTimer;
        }
	}

    void MoveLeft()
    {
        float step = MoveSpeed * Time.deltaTime;
        _rigidbody2D.velocity = new Vector2(-step, _rigidbody2D.velocity.y);
        _spriteRenderer.flipX = false;
    }

    void MoveRight()
    {
        float step = MoveSpeed * Time.deltaTime;
        _rigidbody2D.velocity = new Vector2(step, _rigidbody2D.velocity.y);
        _spriteRenderer.flipX = true;
    }
}
