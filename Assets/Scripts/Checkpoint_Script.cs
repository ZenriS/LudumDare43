using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Script : MonoBehaviour
{
    private GameManager_Script _gameManagerScript;
    public bool EndCheckpoint;
    public Sprite Sprite;
    private SpriteRenderer _spriteRenderer;


    void Start ()
	{
	    _gameManagerScript = FindObjectOfType<GameManager_Script>();
	    _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            if (!EndCheckpoint)
            {
                _gameManagerScript.Checkpoint = this.transform;
                _spriteRenderer.sprite = Sprite;
            }
            else
            {
                _gameManagerScript.Winner();
            }
            
        }
    }
}
