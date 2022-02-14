using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject LaserPrefab;

    [SerializeField]
    private GameObject TripleLaserPrefab;


    public float speed = 5.0f;

    public bool canTripleShot = false;


    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0.0f;

	// Use this for initialization
	void Start () {
        Debug.Log("Hello!");
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void Shoot() {
        if (Time.time > canFire)
        {

            if (canTripleShot) {
                Instantiate(TripleLaserPrefab, transform.position, Quaternion.identity);

            }
            else
                Instantiate(LaserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            canFire = Time.time + fireRate;
        }
    }
    private void Movement() {
        float hpos = Input.GetAxis("Horizontal");
        float vpos = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * hpos);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vpos);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        }

        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
        }
    }

    public void EnableTripleShot() {
        canTripleShot = true;
        StartCoroutine( TripleShotOff());
    }

    IEnumerator TripleShotOff() {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }
}
