using UnityEngine;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections;

public class DisarmingBomb : PlayerState
{
    private Bomb bomb;

    private int passwordSize;

    private int currentPasswordSize;

    private StringBuilder passwordBuilder;

    private bool canType;

    public DisarmingBomb(Player player, Bomb bomb, int passwordSize)
    {
        playerRef = player;
        this.bomb = bomb;
        this.passwordSize = passwordSize;
        currentPasswordSize = 0;
        passwordBuilder = new StringBuilder();
        canType = true;
    }

    public override void Update()
    {
        if (canType)
        {
            string input = Input.inputString;
            input = Regex.Replace(input, @"[^a-zA-Z\b\r]", "");
            for (int c = 0; c < input.Length; c++)
            {
                if (input[c] == '\b')
                {
                    if (currentPasswordSize > 0)
                    {
                        passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
                        bomb.ErasePasswordCharacter();
                        currentPasswordSize--;
                    }
                }
                else if (input[c] == '\r')
                {
                    bomb.Submit(passwordBuilder.ToString());
                    currentPasswordSize = 0;
                    passwordBuilder.Remove(0, passwordBuilder.Length);
                    canType = false;
                }
                else if (currentPasswordSize < passwordSize)
                {
                    passwordBuilder.Append(input[c]);
                    bomb.AddPasswordCharacter(input[c]);
                    currentPasswordSize++;
                }
            }
        }
    }
}
