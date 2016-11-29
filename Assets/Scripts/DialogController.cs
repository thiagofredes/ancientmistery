using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour
{

    public DialogDisplay display;

    public void Activate(string dialog)
    {
        display.ShowDialog(dialog);
    }

    public void SkipMessage()
    {
        display.SkipMessage();
    }

    public void Clear()
    {
        display.Clear();
    }

    public void AddCharacterToText(char c)
    {
        display.AddCharacter(c);
    }

    public void EraseCharacterFromText()
    {
        display.EraseCharacter();
    }
}
