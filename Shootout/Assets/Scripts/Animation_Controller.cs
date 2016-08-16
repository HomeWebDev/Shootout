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
    public string fireButton;

    public float fireRate;
    private float DefaultFirerate = 0.25f;
    private float nextFire;

    public Transform shotSpawn;
    public GameObject shot;
    public GameObject weapon;
    public Transform weaponSpawn;

    private bool firstTime = true;
    private int initLoops = 4;


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
        if( weapon!= null)
        {
            if (weapon.tag == "AKM")
            {
                fireRate = DefaultFirerate / 2;
            }
            else
            {
                fireRate = DefaultFirerate;
            }
        }
        else
        {
            fireRate = DefaultFirerate;
        }
        PlayerHealth playerHealth = this.GetComponent<PlayerHealth>();

        if (Input.GetButton(fireButton) & Time.time > nextFire & playerHealth.health > 0)
        {
            nextFire = Time.time + fireRate;

            shot.tag = this.tag;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            

            //print("Shot: " + shot.tag.ToString());

            //Transform bullet = Instantiate(bulletPrefab) as Transform;
            //Physics.IgnoreCollision(shot.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>(), false);

            //shot.GetComponent<BulletScript>().IgnoreCollider(GetComponent<Collider>());
        }


        float moveV = Input.GetAxis(verticalAxis);
        float moveH = Input.GetAxis(horizontalAxis);

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        //Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
        movement *= speed;

        //Rigidbody body = GetComponent<Rigidbody>();
        

        if (moveV != 0 || moveH != 0)
        {
            anim.Play();
        }
        else
            anim.Stop();


        //body.AddForce(movement * speed * Time.deltaTime);

        controller.Move(movement * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.LookRotation(movement),
                                 Time.deltaTime * rotationDamping);

            //print("movement: " + moveV);
        }

        //print("updated");

        //if (firstTime)
        //{
        //    movement = new Vector3(0.001f, 0.0f, 0.0f);

        //    controller.Move(movement * Time.deltaTime);

        //    if (movement != Vector3.zero)
        //    {
        //        transform.rotation = Quaternion.Slerp(transform.rotation,
        //                             Quaternion.LookRotation(movement),
        //                             Time.deltaTime * rotationDamping);
        //    }
        //    initLoops--;

        //    if (initLoops < 1)
        //    {
        //        firstTime = false;
        //    }
        //}
    }
}
