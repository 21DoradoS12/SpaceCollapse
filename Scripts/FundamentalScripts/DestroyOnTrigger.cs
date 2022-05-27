using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    private GameManager gameManager;
    private BoostTime boostTime;
    private ShipControl shipControl;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shipControl.HP > 0)
        {
            if (other.tag == "Meteor" || other.tag == "TinyMeteor" || other.tag == "Asteroid" || other.tag == "FlyingSaucer" || other.tag == "ShootingSaucer" || other.tag == "BigSaucer")
            {
                Destroy(other.gameObject);
                gameManager.DecreasScoreBelow();
            }
            if (other.tag == "Bullet")
            {
                Destroy(other.gameObject);
            }
            if (other.tag == "FirstBoss" || other.tag == "ThirdBoss" || other.tag == "SecondBoss")
            {
                Destroy(other.gameObject);
                gameManager.GameOverText.enabled = true;
                gameManager.ReloadGameBut.enabled = true;
                gameManager.ReloadGameIm.enabled = true;
            }
            else
                Destroy(other.gameObject);
        }
        else
            Destroy(other.gameObject);
    }
    void Start()
    {
        shipControl = GameObject.FindObjectOfType<ShipControl>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        boostTime = GameObject.FindObjectOfType<BoostTime>();
    }
    void Update()
    {

    }
}
