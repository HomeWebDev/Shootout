using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        Rigidbody body = GetComponent<Rigidbody>();

        body.AddForce(movement * speed * Time.deltaTime);
    }
}
