using System;
using System.Collections.Generic;

class UIDisplay
{
    public static UIDisplay uiDisplay = new UIDisplay();
    private CursorTweaker cursorTweaker = new CursorTweaker();


    public void DisplayGrid()
    {
        int linesNumber = GridUpdate.gridUpdate.GetLinesNumber();
        int columnsNumber = GridUpdate.gridUpdate.GetColumnsNumber();
        char[,] array = GridUpdate.gridUpdate.GetArray();

        cursorTweaker.Start();

        for (int i = 0; i < linesNumber; i++)
        {
            for (int j = 0; j < columnsNumber; j++)
            {
                Console.Write(array[i, j]);
            }
            Console.WriteLine();
        }
    } // Affiche la zone de jeu à l'écran
    public void DisplayWelcomeMessage()
    {
        cursorTweaker.Write(33, 6, "Bienvenue dans Asky The Snake !");
        cursorTweaker.Write(10, 10, "Pour gagner, récupérez tous les fruits (o) avant la fin du temps imparti.");
        cursorTweaker.Write(10, 11, "Mais attention aux obstacles (#)!");
        cursorTweaker.Write(10, 13, "Pour commencer, veuillez sélectionner un mode de difficulté (touche 1, 2 ou 3):");
        cursorTweaker.Write(10, 15, "1. Facile : aucun obstacle en dehors des murs, Asky se déplace lentement" );
        cursorTweaker.Write(10, 16, "2. Normale : quelques obstacles, Asky se déplace à vitesse moyenne (non disponible)");
        cursorTweaker.Write(10, 17, "3. Difficile : beaucoup d'obstacles, Asky se déplace rapidement (non disponible)");
    } // Affiche le texte du menu principal
    public void DisplayGameOverMessage()
    {
        cursorTweaker.Write(40, 8, "Vous avez perdu !");
        cursorTweaker.Write(18, 12, "Cette fenêtre se fermera automatiquement dans quelques secondes");
    } // Affiche Le message de Game Over
    public void DisplayWinMessage()
    {
        cursorTweaker.Write(34, 8, "Félicitations!! Vous avez gagné !");
        cursorTweaker.Write(18, 12, "Cette fenêtre se fermera automatiquement dans quelques secondes");
    } // Affiche le message de victoire
    public void DisplayCountdown()
    {
         cursorTweaker.Write(60, 3, "La partie démarre dans :  " + GridUpdate.gridUpdate.GetValue());
    } // Affiche le compte à rebours
    public void DisplayCharacter()
    {
        int updatedX = GridUpdate.gridUpdate.GetValueUpdatedX();
        int updatedY = GridUpdate.gridUpdate.GetValueUpdatedY();
        int previousX = GridUpdate.gridUpdate.GetValuePreviousX();
        int previousY = GridUpdate.gridUpdate.GetValuePreviousY();
        int fruitsNumber = GridUpdate.gridUpdate.GetFruitsNumber();
        int snakeTailCoordinateCount = GridUpdate.gridUpdate.GetSnakeTailCoordinateCount();
        List<int> snakeTailCoordinateX = GridUpdate.gridUpdate.GetSnakeTailCoordinateX();
        List<int> snakeTailCoordinateY = GridUpdate.gridUpdate.GetSnakeTailCoordinateY();

        cursorTweaker.Write(updatedX, updatedY, 'Y');

        if (snakeTailCoordinateCount == 0)
        {
            cursorTweaker.Write(previousX, previousY, ' ');
        }
        else
        {
            cursorTweaker.Write(previousX, previousY, '¤');

            for (int i = 0; i < snakeTailCoordinateCount - 1; i++)
            {
                cursorTweaker.Write(snakeTailCoordinateX[i], snakeTailCoordinateY[i], '¤');
            }

            cursorTweaker.Write(snakeTailCoordinateX[snakeTailCoordinateCount - 1], snakeTailCoordinateY[snakeTailCoordinateCount - 1], ' ');
        }
       
        cursorTweaker.Write(60, 3, "Nombre de fruits restants : " + (fruitsNumber - snakeTailCoordinateCount) + " ");
        // cursorTweaker.Write(60, 3, "Position de X : " + GridUpdate.gridUpdate.GetValueUpdatedX() + " ");
        //cursorTweaker.Write(60, 5, "Position de Y : " + GridUpdate.gridUpdate.GetValueUpdatedY() + " ");
    } // Affiche le personnage à l'écran
}
