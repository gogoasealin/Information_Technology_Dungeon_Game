using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFireDestroy : MonoBehaviour {

    [SerializeField] private AnimationClip bombExplodeAnimation;

	void Start () {
        Invoke("Erase", bombExplodeAnimation.length);
    }
	
	void Erase()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Breakable" || other.gameObject.name.Contains("BreakablePlatform"))
        {
            Destroy(other.gameObject);
        } 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
