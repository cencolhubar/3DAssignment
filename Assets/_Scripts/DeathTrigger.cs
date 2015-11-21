using UnityEngine;
using System.Collections;

/// <summary>
/// This class kills the player when he falls into the abyss. After three tries the game is over
/// </summary>

public class DeathTrigger : MonoBehaviour {
    private SpawnManager gameController;
    // Use this for initialization
    public AudioSource sound;
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //Gets a reference to game controller so the score can be updated 
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<SpawnManager>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' Script");
        }
    }

    void OnTriggerExit(Collider other)
    {

        
        
        if (other.gameObject.CompareTag("Enemy"))
        { sound.Play();
            gameController.lives--;
            gameController.UpdateLives();
            if (gameController.lives > 0) {

                GameObject player = other.gameObject;

                player.GetComponent<Transform>().position = new Vector3(220,9, 88);

           }
           else if (gameController.lives <= 0)
            {
                gameController.lives = 0;
                gameController.GameOver();
               

            }
        }
    }
}
