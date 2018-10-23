using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameObject boom;
    private GameObject playerBoom;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController'");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Borders")
        {
            return;
        }
        boom = Instantiate(explosion, transform.position, transform.rotation);
        if (collision.tag == "Player")
        {
            playerBoom = Instantiate(playerExplosion, collision.transform.position, collision.transform.rotation);
            gameController.GameOver();
        }
        if(collision.tag == "Bolt")
        {
            gameController.AddScore(scoreValue);
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Destroy(boom, 0.5f);
        Destroy(playerBoom, 0.5f);
        
        
    }
}
