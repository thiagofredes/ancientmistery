using UnityEngine;
using System.Collections.Generic;

public class CollisionDetection
{
    public float rayLength = 0.01f;

    public float borderTolerance = 0.01f;

    private int numberOfRays = 3;

    private Vector2 rayCastOffset;

    private Bounds colliderBounds;

    private Collider2D mCollider;

    private Ray2D[] rays;

    private GameObject lastCollisionObject;


    public CollisionDetection(Player playerRef, float rayLength = 0.02f, float borderTolerance = 0.01f)
    {
        mCollider = playerRef.GetComponent<Collider2D>();
        rays = new Ray2D[numberOfRays];
        rayCastOffset = new Vector2();
        lastCollisionObject = null;
        this.rayLength = rayLength;
        this.borderTolerance = borderTolerance;
    }

    private void SetRayOrigins(Vector2 movement)
    {
        Vector2 origin1 = new Vector2(), origin2 = new Vector2(), origin3 = new Vector2();

        rayCastOffset.Set(movement.x * colliderBounds.extents.x, movement.y * colliderBounds.extents.y);
        colliderBounds = mCollider.bounds;

        if (rayCastOffset.x > 0f) { // right
            origin1.Set(colliderBounds.center.x + colliderBounds.extents.x + borderTolerance, colliderBounds.center.y + colliderBounds.extents.y);
            origin2.Set(colliderBounds.center.x + colliderBounds.extents.x + borderTolerance, colliderBounds.center.y);
            origin3.Set(colliderBounds.center.x + colliderBounds.extents.x + borderTolerance, colliderBounds.center.y - colliderBounds.extents.y);
            rays[0] = new Ray2D(origin1, Vector2.right);
            rays[1] = new Ray2D(origin2, Vector2.right);
            rays[2] = new Ray2D(origin3, Vector2.right);
        }
        else if (rayCastOffset.x < 0f) // left
        {
            origin1.Set(colliderBounds.center.x - colliderBounds.extents.x - borderTolerance, colliderBounds.center.y + colliderBounds.extents.y);
            origin2.Set(colliderBounds.center.x - colliderBounds.extents.x - borderTolerance, colliderBounds.center.y);
            origin3.Set(colliderBounds.center.x - colliderBounds.extents.x - borderTolerance, colliderBounds.center.y - colliderBounds.extents.y);
            rays[0] = new Ray2D(origin1, -Vector2.right);
            rays[1] = new Ray2D(origin2, -Vector2.right);
            rays[2] = new Ray2D(origin3, -Vector2.right);
        }
        else if (rayCastOffset.y > 0f) // up
        {
            origin1.Set(colliderBounds.center.x - colliderBounds.extents.x, colliderBounds.center.y + borderTolerance + colliderBounds.extents.y);
            origin2.Set(colliderBounds.center.x, colliderBounds.center.y + colliderBounds.extents.y + borderTolerance);
            origin3.Set(colliderBounds.center.x + colliderBounds.extents.x, colliderBounds.center.y + borderTolerance + colliderBounds.extents.y);
            rays[0] = new Ray2D(origin1, Vector2.up);
            rays[1] = new Ray2D(origin2, Vector2.up);
            rays[2] = new Ray2D(origin3, Vector2.up);
        }
        else if (rayCastOffset.y < 0f) // down
        {
            origin1.Set(colliderBounds.center.x - colliderBounds.extents.x, colliderBounds.center.y - borderTolerance - colliderBounds.extents.y);
            origin2.Set(colliderBounds.center.x, colliderBounds.center.y - colliderBounds.extents.y - borderTolerance);
            origin3.Set(colliderBounds.center.x + colliderBounds.extents.x, colliderBounds.center.y - borderTolerance - colliderBounds.extents.y);
            rays[0] = new Ray2D(origin1, -Vector2.up);
            rays[1] = new Ray2D(origin2, -Vector2.up);
            rays[2] = new Ray2D(origin3, -Vector2.up);
        }
    }

    public bool CanMove(Vector2 movement)
    {
        RaycastHit2D hit2D;      
        SetRayOrigins(movement);
        //for(int r=0; r<numberOfRays; r++)
        //{
        //    Debug.DrawRay(rays[r].origin, rays[r].direction * raysLength, Color.magenta);
        //}
        for (int r = 0; r < numberOfRays; r++)
        {
            hit2D = Physics2D.Raycast(rays[r].origin, rays[r].direction, rayLength);
            if (hit2D.collider != null)
            {
                //Debug.Log("Ray number " + r + " with origin = " + rays[r].origin);
                //Debug.Log("Collided with " + hit2D.collider.gameObject.name);
                lastCollisionObject = hit2D.collider.gameObject;
                return false;
            }
        }
        lastCollisionObject = null;
        return true;
    }

    public GameObject GetCollisionObject()
    {
        return lastCollisionObject;
    }
}
