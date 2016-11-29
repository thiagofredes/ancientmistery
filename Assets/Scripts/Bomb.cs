using UnityEngine;
using System.Collections;

public class Bomb : ObjectOfInterest
{
    public string password;

    public int passwordSize;

    public AudioClip success;

    public AudioClip failure;

    public InitDisplayController initDisplayController;

    public DialogController bombDialogController;

    public DialogController gameOverDialogController;

    private AudioSource source;

    public void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }

    public override void Activate()
    {
        bombDialogController.Activate("bomb_dialog");
        Player.instance.SetState(new DisarmingBomb(Player.instance, this, passwordSize));
    }

    public void Submit(string password)
    {
        StartCoroutine(ShowSubmitResult(password));
    }

    private IEnumerator ShowSubmitResult(string password)
    {
        bombDialogController.Clear();
        if(password == this.password) // CORRECT PASSWORD!
        {
            bombDialogController.Activate("correct_password");
            source.PlayOneShot(success);
            yield return new WaitForSeconds(3f);
            bombDialogController.Clear();
            gameOverDialogController.Activate("game_over1");
            yield return new WaitForSeconds(7f);
            gameOverDialogController.Clear();
            gameOverDialogController.Activate("game_over2");
            yield return new WaitForSeconds(7f);
            gameOverDialogController.Clear();
            gameOverDialogController.Activate("game_over3");
            yield return new WaitForSeconds(7f);
            gameOverDialogController.Clear();
            initDisplayController.FadeAlpha(1f);
        }
        else //WRONG PASSWORD!
        {
            bombDialogController.Activate("incorrect_password");
            source.PlayOneShot(failure);
        }
        yield return new WaitForSeconds(2f);
        bombDialogController.Clear();
        Player.instance.SetState(new Investigating(Player.instance));
    }

    public void AddPasswordCharacter(char c)
    {
        bombDialogController.AddCharacterToText(c);
    }

    public void ErasePasswordCharacter()
    {
        bombDialogController.EraseCharacterFromText();
    }
}
