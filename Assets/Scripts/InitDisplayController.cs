using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class InitDisplayController : MonoBehaviour {

    public DialogController dialogController;

    public Image fader;

	// Use this for initialization
	void Start () {
        StartCoroutine(ShowMessages());
	}	

    private IEnumerator ShowMessages()
    {
        fader.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        dialogController.Activate("start0");
        yield return new WaitForSeconds(5f);
        dialogController.Clear();
        dialogController.Activate("start1");
        yield return new WaitForSeconds(5f);
        dialogController.Clear();
        dialogController.Activate("start2");
        yield return new WaitForSeconds(5f);
        dialogController.Clear();
        dialogController.Activate("start3");
        yield return new WaitForSeconds(5f);
        dialogController.Clear();
        dialogController.Activate("start4");
        yield return new WaitForSeconds(5f);
        dialogController.Clear();
        dialogController.Activate("start5");
        yield return new WaitForSeconds(8f);
        dialogController.Clear();
        Player.instance.frozen = false;
        yield return null;
    }

    public void FadeAlpha(float alpha)
    {
        StartCoroutine(Fade(alpha));
        
    }

    private IEnumerator Fade(float alpha)
    {
        fader.CrossFadeAlpha(alpha, 2f, false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Title");
    }

}
