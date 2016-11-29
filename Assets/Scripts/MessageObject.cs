using UnityEngine;
using System.Collections;

public class MessageObject : ObjectOfInterest
{
    public string dialogKey;
    public DialogController dialogController;
    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }
    
    public override void Activate()
    {
        dialogController.Activate(dialogKey);
        source.PlayOneShot(clip);
        Player.instance.SetState(new ReadingMessage(Player.instance, this));
    }

    public override void SkipMessage()
    {
        dialogController.SkipMessage();
    }
}
