using UnityEngine;
using System.Collections.Generic;

public class DialogDB : MonoBehaviour {

    private Dictionary<string, string> dialogs;


    void Start()
    {
        LoadAllDialogs();
    }

    public string GetDialog(string dialog)
    {
        return dialogs[dialog];
    }

    private void LoadAllDialogs()
    {
        dialogs = new Dictionary<string, string>();

        dialogs.Add("bomb_dialog", "TYPE IN THE PASSWORD\n");
        dialogs.Add("torn_papers", "Sheets of paper lie on the ground.\nThe characters 'dfxhtrycy' are in one of them.");
        dialogs.Add("correct_password", "CORRECT");
        dialogs.Add("incorrect_password", "INCORRECT!");
        dialogs.Add("julius_caesar", "A painting of Julius Caesar.\nLooks as powerful as the books tell.");
        dialogs.Add("cleopatra", "A painting of Cleopatra.\nShe was known by her incredible beauty.");
        dialogs.Add("bookshelf", "A bookshelf full of books on criptography.\nOne of them is called 'Vigenère'.");
        dialogs.Add("start0", "I am detective John Criptis and my experience\nis solving cases involving ancient things.");
        dialogs.Add("start1", "There is a bomb here, and I am the only one\nwho can deactivate it.");
        dialogs.Add("start2", "'Why', do you wonder?");
        dialogs.Add("start3", "Because the crazy guy who planted the bomb\nwas fascinated by ancient history.");
        dialogs.Add("start4", "He studied many ancient technologies\nand one of them was the criptography.");
        dialogs.Add("start5", "And I know that the solution for this mistery\nis the sum of everything inside this room.");
        dialogs.Add("game_over1", "Cleopatra was the key to decypher 'dfxhtrycy'.\nThe result was the word 'butterfly'.");
        dialogs.Add("game_over2", "The crazy guy used the Vigenère cyhper here...\nInteresting...");
        dialogs.Add("game_over3", "I hope the cops catch him as soon as possible!");
    }
}
