using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Class used to handle player health
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int shield = 0;

    public Slider healthSlider;
    public Slider shieldSlider;

    // Use this for initialization
    void Start()
    {
        shieldSlider.value = shield;
    }

    /// <summary>
    /// Reset health
    /// </summary>
    public void ResetHealth()
    {
        //Reset health
        health = 100;

        healthSlider.value = health;
    }

    /// <summary>
    /// Add health by amount
    /// </summary>
    /// <param name="amount"></param>
    public void AddHealth(int amount)
    {
        int tmp = health + amount;
        if (health < 100)
        {
            health = Mathf.Min(tmp, 100);
            healthSlider.value = health;
        }
    }

    /// <summary>
    /// Add shield by amount
    /// </summary>
    /// <param name="amount"></param>
    public void AddShield(int amount)
    {
        int tmp = shield + amount;
        if (shield < 50)
        {
            shield = Mathf.Min(tmp, 50);
            shieldSlider.value = shield;
        }
    }

    /// <summary>
    /// Let player take damage by amount. If player is killed respawn after 5 seconds
    /// Also handle update of kill score for player who fired killing bullet
    /// </summary>
    /// <param name="other"></param>
    /// <param name="amount"></param>
    /// <param name="bullet"></param>
    public void TakeDamage(Collider other, int amount, GameObject bullet)
    {
        // Decrement the player's health or shield by amount.
        if (shield > 0)
            shield -= amount;
        else
            health -= amount;

        healthSlider.value = health;
        shieldSlider.value = shield;

        if (health <= 0)
        {
            PlayerKilled();

            if (bullet.tag == "Player1")
            {
                GameController.Player1Kills++;
            }
            if (bullet.tag == "Player2")
            {
                GameController.Player2Kills++;
            }
            if (bullet.tag == "Player3")
            {
                GameController.Player3Kills++;
            }
            if (bullet.tag == "Player4")
            {
                GameController.Player4Kills++;
            }

            //Game ends when first player has 5 kills
            if (GameController.Player1Kills > 4 | GameController.Player2Kills > 4 | GameController.Player3Kills > 4 | GameController.Player4Kills > 4)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");
            }
        }
    }

    /// <summary>
    /// Start reoutine for respawn
    /// </summary>
    private void PlayerKilled()
    {
        StartCoroutine(Respawn());
    }

    /// <summary>
    /// Respawn
    /// </summary>
    /// <returns></returns>
    IEnumerator Respawn()
    {
        SkinnedMeshRenderer render = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        render.enabled = false;
        gameObject.transform.position = new Vector3(99, 0, -99);

        yield return new WaitForSeconds(5);

        ResetHealth();

        if (gameObject.tag == "Player1")
        {
            gameObject.transform.position = new Vector3(13, 0, -13);
        }
        if (gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(-13, 0, 13);
        }
        if (gameObject.tag == "Player3")
        {
            gameObject.transform.position = new Vector3(-13, 0, -13);
        }
        if (gameObject.tag == "Player4")
        {
            gameObject.transform.position = new Vector3(13, 0, 13);
        }

        gameObject.GetComponent<Animation_Controller>().pistol.SetActive(true);
        gameObject.GetComponent<Animation_Controller>().akm.SetActive(false);
        render.enabled = true;
    }
}
