using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public float hp;
    public float damage;

    private Animator animator;
    private bool isReverse = true;
    
	private void Start () {
        animator = GetComponent<Animator>();
	}
	
	private void Update () {
        FireScaler();
	}

    private void FireScaler()
    {

        if (hp <= 0)
        {
            if (GameManager.Instance.playerQuality == PlayerQuality.FIRE && isReverse)
            {
                ReverseColor();
                if (hp == 0)
                    hp = 1;
                else
                    hp = Mathf.Abs(hp);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else if (hp <= 3)
        {
            animator.SetInteger("FireState", 4);
            damage = 1;
        }
        else if (hp <= 5)
        {
            animator.SetInteger("FireState", 3);
            damage = 1;
        }
        else if (hp <= 10)
        {
            animator.SetInteger("FireState", 2);
            damage = 1;
        }
        else if (hp <= 15)
        {
            animator.SetInteger("FireState", 1);
            damage = 2;
        }
        else if (hp <= 20)
        {
            animator.SetInteger("FireState", 0);
            damage = 3;
        }
    }
    
    private void ReverseColor()
    {
        Color c = new Color(0, 0, 0, 255);
        GetComponent<SpriteRenderer>().color = c;
        isReverse = false;
    }
}
