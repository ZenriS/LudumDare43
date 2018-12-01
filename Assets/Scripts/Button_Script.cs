using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;
    public MovingPlatform_Script MovingPlatformScript;
    private bool _runOnce;

	// Use this for initialization
	void Start ()
	{
	    _boxCollider2D = GetComponent<BoxCollider2D>();
	    _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {

            //activate somthing
            if (!_runOnce)
            {
                _spriteRenderer.color = Color.green;
                MovingPlatformScript.Active = !MovingPlatformScript.Active;
                _runOnce = true;
            }
            
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            if (_runOnce)
            {
                _spriteRenderer.color = Color.red;
                MovingPlatformScript.Active = !MovingPlatformScript.Active;
                _runOnce = false;
            }
        }
    }
}
