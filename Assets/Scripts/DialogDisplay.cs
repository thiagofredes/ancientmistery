using UnityEngine;
using UnityEngine.UI;
using System.Text;


public class DialogDisplay : MonoBehaviour
{
    public DialogDB db;

    public CanvasRenderer dialogBox;

    public Text textRenderer;

    private StringBuilder stringBuilder;


    // Use this for initialization
    void Start()
    {
        dialogBox.SetAlpha(0f);
        textRenderer.text = "";
        stringBuilder = new StringBuilder();
    }

    public void ShowDialog(string dialog)
    {
        dialogBox.SetAlpha(1f);
        stringBuilder.Append(db.GetDialog(dialog));
        textRenderer.text = stringBuilder.ToString();
    }

    public void SkipMessage()
    {
        Clear();
    }

    public void Clear()
    {
        dialogBox.SetAlpha(0f);
        stringBuilder.Remove(0, stringBuilder.Length);
        textRenderer.text = "";
    }

    public void EraseCharacter()
    {
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        textRenderer.text = stringBuilder.ToString();
    }

    public void AddCharacter(char c)
    {
        stringBuilder.Append(c);
        textRenderer.text = stringBuilder.ToString();
    }
}
