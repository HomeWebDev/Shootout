using UnityEngine;
using System.Collections;

public class Animation_Controller : MonoBehaviour
{
    Animation anim;
    public float speed;

    CharacterController controller;
    public float rotationDamping = 20f;
    public string horizontalAxis;
    public string verticalAxis;

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
        float moveV = Input.GetAxis(verticalAxis);
        float moveH = Input.GetAxis(horizontalAxis);

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        movement *= speed;

        Rigidbody body = GetComponent<Rigidbody>();
        

        if (moveV != 0 || moveH != 0)
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
