using UnityEngine;
using System.Collections;

/// <summary>
/// Class used to hande player animations and movements
/// </summary>
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
    public GameObject akm;
    public GameObject pistol;

    private bool firstTime = true;
    private int initLoops = 4;


    // Use this for initialization
    void Start ()
    {
        controller = (CharacterController)(GetComponent(typeof(CharacterController)));
        anim = GetComponent<Animation>();
        anim["Take 001"].speed = 3.0f;
        akm.SetActive(false);
        pistol.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Set fire rate based on current weapon
        if (akm.activeSelf)
        {
            fireRate = DefaultFirerate / 2;
        }
        else if(pistol.activeSelf)
        {
            fireRate = DefaultFirerate;
        }

        PlayerHealth playerHealth = this.GetComponent<PlayerHealth>();

        //Use timer to handle when player can shoot, don't allow shots when player is dead
        if (Input.GetButton(fireButton) & Time.time > nextFire & playerHealth.health > 0)
        {
            nextFire = Time.time + fireRate;

            shot.tag = this.tag;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        //Handle movements based on axises
        float moveV = Input.GetAxis(verticalAxis);
        float moveH = Input.GetAxis(horizontalAxis);

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        movement *= speed;

        //Play animation if player is moving
        if (moveV != 0 || moveH != 0)
        {
            anim.Play();
        }
        else
            anim.Stop();

        controller.Move(movement * Time.deltaTime);

        //Handle rotation
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.LookRotation(movement),
                                 Time.deltaTime * rotationDamping);

        }
    }
}
