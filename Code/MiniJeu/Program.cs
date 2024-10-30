using System;
using System.Threading;

namespace MiniJeu
{
    class Program
    {
        static void Main(string[] args)
        {
            GridUpdate.gridUpdate.GenerateMainMenuInterface(); // On génère le menu principal
            UIDisplay.uiDisplay.DisplayGrid(); // On l'affiche à l'écran
            UIDisplay.uiDisplay.DisplayWelcomeMessage(); // On affiche le texte du menu

            while (!GridUpdate.gridUpdate.GetValueOne()) // Tant que le joueur n'a pas appuyé sur la touche "1"
            {
                System.Threading.Thread.Sleep(60);
                CharacterController.characterController.CheckKeyboardInput(); // On check les entrées clavier              
            }

            Console.Clear(); // On efface le menu
            GridUpdate.gridUpdate.GenerateGrid(); // On crée la zone de jeu
            GridUpdate.gridUpdate.GenerateConsole(); // Ainsi que l'interface utilisateur
            GridUpdate.gridUpdate.GenerateFruits(); // On génère les fruits sur la map
            UIDisplay.uiDisplay.DisplayGrid(); // On affiche le tout à l'écran

            Timer countdownTimer = new Timer(GridUpdate.gridUpdate.Countdown, null, 0, 1000);

            while (GridUpdate.gridUpdate.GetValue() != 0) // On lance un compte à rebours de quelques secondes avant le début de la partie
            {
                System.Threading.Thread.Sleep(60);  // Permet de limiter la consommation du CPU
                UIDisplay.uiDisplay.DisplayCountdown(); // On l'affiche à l'écran
            }

            Timer movementTimer = new Timer(GridUpdate.gridUpdate.UpdateCharacterPosition, null, 0, 200);
            
            while (!GridUpdate.gridUpdate.CheckCollision()) // Tant qu'il n'y a pas de collisions avec un obstacle
            {
                System.Threading.Thread.Sleep(60);
                CharacterController.characterController.CheckKeyboardInput(); // On check les entrées clavier
                GridUpdate.gridUpdate.UpdateVectorDirection(); // On met à jour la position du personnage
                UIDisplay.uiDisplay.DisplayCharacter(); // On affiche le personnage à l'écran

                if (GridUpdate.gridUpdate.AllFruitsHasBeenEaten()) // Si tous les fruits sont mangés on affiche le message de victoire
                {
                    Console.Clear();
                    GridUpdate.gridUpdate.GenerateMainMenuInterface(); 
                    UIDisplay.uiDisplay.DisplayGrid(); 
                    UIDisplay.uiDisplay.DisplayWinMessage(); 
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
            }
            // Si il y a une collision avec un obstacle, on affiche le message de Game Over
            Console.Clear();
            GridUpdate.gridUpdate.GenerateMainMenuInterface(); 
            UIDisplay.uiDisplay.DisplayGrid(); 
            UIDisplay.uiDisplay.DisplayGameOverMessage();
            Thread.Sleep(5000);
            Environment.Exit(0);          
        }
    }
}