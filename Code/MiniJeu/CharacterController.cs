using System;

class CharacterController
{
    public static CharacterController characterController = new CharacterController();

    private ConsoleKey key = new ConsoleKey();
    private KeyboardTweaker keyboardTweaker = new KeyboardTweaker();

    public void CheckKeyboardInput()
	{
        key = keyboardTweaker.NextEvent();

        switch (key)
        {
            case ConsoleKey.S:

                GridUpdate.gridUpdate.SetValueDown(true);
                break;

            case ConsoleKey.Z:

                GridUpdate.gridUpdate.SetValueUp(true);
                break;

            case ConsoleKey.Q:

                GridUpdate.gridUpdate.SetValueLeft(true);
                break;

            case ConsoleKey.D:

                GridUpdate.gridUpdate.SetValueRight(true);
                break;

            case ConsoleKey.NumPad1:

                GridUpdate.gridUpdate.SetValueOne(true);
                break;

            case ConsoleKey.D1:

                GridUpdate.gridUpdate.SetValueOne(true);
                break;
        }
    } // Vérifie les entrées clavier
}
