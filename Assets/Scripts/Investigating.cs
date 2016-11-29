using UnityEngine;
using System.Collections;

public class Investigating : PlayerState
{

    private Vector2 movement;

    private CollisionDetection collisionManagement;

    public Investigating(Player player)
    {
        playerRef = player;
        movement = new Vector2();
        collisionManagement = new CollisionDetection(playerRef);
    }

    public override void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0f && v == 0f)
        {
            movement.Set(h, v);
            if (collisionManagement.CanMove(movement))
            {
                playerRef.Move(new Vector3(playerRef.speed * Time.deltaTime * h, 0f, 0f));
            }
        }
        else if (v != 0f && h == 0f)
        {
            movement.Set(h, v);
            if (collisionManagement.CanMove(movement))
            {
                playerRef.Move(new Vector3(0f, playerRef.speed * Time.deltaTime * v, 0f));
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject collisionObject = collisionManagement.GetCollisionObject();
            if (collisionObject != null)
            {
                ObjectOfInterest interaction = collisionObject.GetComponent<ObjectOfInterest>();
                if (interaction != null)
                {
                    Debug.Log("Interaction = " + interaction);
                    interaction.Activate();
                }
            }
        }
    }
}
