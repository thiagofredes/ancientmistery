using UnityEngine;
using System.Collections;

public abstract class ObjectOfInterest : MonoBehaviour
{
    public virtual void Activate() { }
    public virtual void SkipMessage() { }
}
