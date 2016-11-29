using UnityEngine;
using System.Collections;

public class ReadingMessage : PlayerState
{

    private ObjectOfInterest triggerObject;

    public ReadingMessage(Player player, ObjectOfInterest triggerObject)
    {
        playerRef = player;
        this.triggerObject = triggerObject;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            triggerObject.SkipMessage();
            playerRef.SetState(new Investigating(playerRef));
        }
    }

}
