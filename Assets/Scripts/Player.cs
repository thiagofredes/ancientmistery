using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [HideInInspector]
    public static Player instance;

    public float speed;

    public bool frozen = true;

    private CollisionDetection collisionManagement;

    private PlayerState currentState;

    private SpriteRenderer mSprite;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        mSprite = this.gameObject.GetComponent<SpriteRenderer>();
        currentState = new Investigating(this);
    }

    public void Move(Vector3 movement)
    {
        this.transform.Translate(movement);
        if (movement.x < 0f)
            mSprite.flipX = true;
        else
            mSprite.flipX = false;
    }

    public void SetState(PlayerState newState)
    {
        this.currentState = newState;
        Debug.Log("new state is " + this.currentState);
    }

    void Update()
    {
        if(!frozen)
            currentState.Update();
    }
}
