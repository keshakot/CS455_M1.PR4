using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter( Collision collisionInfo ) 
    {
    	//if ( collisionInfo.collider.tag == "Obstacle" )
        if ( collisionInfo.collider.tag == "Flocker" )
    	{
    	    movement.enabled = false;
    	    FindObjectOfType<GameManager>().EndGame();
    	}
    }
}
