using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriplePowerUp : MonoBehaviour {

    private float speed = 3.0f;


	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collision");
            Player player = other.GetComponent<Player>();

            player.EnableTripleShot();

            Destroy(this.gameObject);
        }
    }
}
