using UnityEngine;
using System.Collections;

public class Animation_Controller : MonoBehaviour
{
    Animation anim;
    public float speed;

    CharacterController controller;
    public float rotationDamping = 20f;

    // Use this for initialization
    void Start ()
    {
        controller = (CharacterController)(GetComponent(typeof(CharacterController)));
        anim = GetComponent<Animation>();
        anim["Take 001"].speed = 3.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //float move = Input.GetAxis("Vertical");
        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        movement *= speed;

        Rigidbody body = GetComponent<Rigidbody>();
        

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) 
            || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play();
        }
        else
            anim.Stop();


        //body.AddForce(movement * speed * Time.deltaTime);

        controller.Move(movement * Time.deltaTime);

        if (movement != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(movement),
                Time.deltaTime * rotationDamping);

    }
}
