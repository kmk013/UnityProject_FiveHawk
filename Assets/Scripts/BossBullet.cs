using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {

    public float damage = 2;
    public float speed = 800;

	void Update () {
        transform.position += transform.up * speed * Time.deltaTime;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Player"))
        {
            collision.GetComponent<Player>().hp -= damage;
            Destroy(this.gameObject);
        }
    }
}
