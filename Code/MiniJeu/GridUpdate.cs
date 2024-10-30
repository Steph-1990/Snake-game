using System;
using System.Collections.Generic;
using System.Threading;

class GridUpdate
{
    public static GridUpdate gridUpdate = new GridUpdate();

    private static int linesNumber = 25;
    private static int columnsNumber = 100;
    private static char[,] array = new char[linesNumber, columnsNumber];

    private int x = 25;
    private int y = 12;
    private int previousX = 0;
    private int previousY = 0;
    private int updatedX = 0;
    private int updatedY = 0;
    private int lastVectorDirectionX = 1;
    private int lastVectorDirectionY = 0;
    private int fruitsNumber = 20;
    public int value = 5;
    private bool up = false;
    private bool down = false;
    private bool right = false;
    private bool left = false;
    private bool one = false;
    private bool yes = false;
    private bool no = false;
    private char fruit = 'o'; // Symbole d'un fruit
    private char wall = '#'; // Symbole d'un mur
    private List<int> snakeTailCoordinatesX = new List<int>() { };
    private List<int> snakeTailCoordinatesY = new List<int>() { };

    public bool CheckCollision()
    {
        if (array[updatedY, updatedX] == '¤' || array[y, x] == '#')
        {
            lastVectorDirectionX = 0;
            lastVectorDirectionY = 0;

            return true;
        }
        return false;
    } // Vérifie si le personnage entre en collision avec un obstacle
    public void GenerateMainMenuInterface()
    {
        for (int i = 0; i < linesNumber; i++)
        {
            for (int j = 0; j < columnsNumber; j++)
            {
                if ((i > 0 && i < 24) && (j > 0 && j < 99))
                {
                    array[i, j] = ' ';
                }
                else
                {
                    array[i, j] = wall;
                }
            }
        }
    } // Crée l'interface du menu principal
    public void GenerateGrid()
    {
        for (int i = 0; i < linesNumber; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                if ((i > 0 && i < 24) && (j > 0 && j < 49))
                {
                    array[i, j] = ' ';
                }
                else
                {
                    array[i, j] = wall;
                }
            }
        }
    } // Crée la zone de jeu
    public void GenerateConsole()
    {
        for (int i = 0; i < linesNumber; i++)
        {
            for (int j = 50; j < columnsNumber; j++)
            {
                if ((i > 0 && i < 24) && (j > 55 && j < columnsNumber-1))
                {
                    array[i, j] = ' ';
                }
                else
                {
                    array[i, j] = wall;
                }
            }
        }
    } // Crée l'interface contenant les informations nécessaires au joueur
    public void GenerateFruits() // Génère les fruits aléatoirement sur la map
    {
        Random rand = new Random();
        int randomLines = 0;
        int randomColumns = 0;

        for (int i = 0; i < fruitsNumber; i++)
        {
            randomLines = rand.Next(1, 24);
            randomColumns = rand.Next(1, 49);
            array[randomLines, randomColumns] = fruit;
        }
    } 
    public bool OneFruitHasBeenEaten() // Passe à true si un fruit a été mangé
    {
        if (array[y,x] == 'o')
        {         
            return true;
        }
        return false;
    }
    public bool AllFruitsHasBeenEaten() // Passe à true si tous les fruits ont été mangés
    {
        if (fruitsNumber - snakeTailCoordinatesX.Count == 0)
        {
            return true;
        }
        return false;
    }
    public void UpdateCharacterPosition(Object o) // Met à jour la position du personnage
    {

        if (snakeTailCoordinatesX.Count == 1)
        {
            snakeTailCoordinatesX[0] = previousX;   // La première partie de la queue sera toujours derrière la tête
            snakeTailCoordinatesY[0] = previousY;
        }
        else if (snakeTailCoordinatesX.Count > 1)
        {
            for (int i = snakeTailCoordinatesX.Count - 1; i > 0; i--)
            {
                snakeTailCoordinatesX[i] = snakeTailCoordinatesX[i - 1];
                snakeTailCoordinatesY[i] = snakeTailCoordinatesY[i - 1];
            }

            snakeTailCoordinatesX[0] = previousX;
            snakeTailCoordinatesY[0] = previousY;
        }

        if (OneFruitHasBeenEaten())
        {
            array[y, x] = ' '; 

            if (snakeTailCoordinatesX.Count == 0)        
            {
                snakeTailCoordinatesX.Add(previousX);
                snakeTailCoordinatesY.Add(previousY);
            }
            else
            {
                snakeTailCoordinatesX.Add(snakeTailCoordinatesX[snakeTailCoordinatesX.Count - 1]);
                snakeTailCoordinatesY.Add(snakeTailCoordinatesY[snakeTailCoordinatesY.Count - 1]);

            }
        }

        previousX = x;
        previousY = y;

        updatedX = x + lastVectorDirectionX; // Position de X après déplacement
        updatedY = y + lastVectorDirectionY; // Position de Y après déplacement

        x = updatedX; 
        y = updatedY;
    }
    public void Countdown(Object o) // Compte à rebours avant le début de la partie
    {
        value--;
    }
    public void UpdateVectorDirection()
    {
        if (up && y > 1)
        {
            lastVectorDirectionY = -1;
            lastVectorDirectionX = 0;
            up = false;
        }
        else if (down && y < 23)
        {
            lastVectorDirectionY = 1;
            lastVectorDirectionX = 0;
            down = false;
        }
        else if (left && x > 1)
        {
            lastVectorDirectionX = -1;
            lastVectorDirectionY = 0;
            left = false;
        }
        else if (right && x < 48)
        {
            lastVectorDirectionX = 1;
            lastVectorDirectionY = 0;
            right = false;
        }
        else
        {
            up = false;
            down = false;
            right = false;
            left = false;
        }
    } // Met à jour la direction dans laquelle se déplace le personnage
    public void SetValueUp(bool up)
    {
        this.up = up;
    }
    public void SetValueDown(bool down)
    {
        this.down = down;
    }
    public void SetValueLeft(bool left)
    {
        this.left = left;
    }
    public void SetValueRight(bool right)
    {
        this.right = right;
    }
    public void SetValueOne(bool one)
    {
        this.one = one;
    }
    public bool GetValueOne()
    {
        return one;
    }
    public int GetLinesNumber()
    {
        return linesNumber;
    }
    public int GetColumnsNumber()
    {
        return columnsNumber;
    }
    public int GetValuePreviousX()
    {
        return previousX;
    }
    public int GetValuePreviousY()
    {
        return previousY;
    }
    public int GetSnakeTailCoordinateCount()
    {
        return snakeTailCoordinatesX.Count;
    }
    public int GetFruitsNumber()
    {
        return fruitsNumber;
    }
    public List<int> GetSnakeTailCoordinateX()
    {
        return snakeTailCoordinatesX;
    }
    public List<int> GetSnakeTailCoordinateY()
    {
        return snakeTailCoordinatesY;
    }
    public int GetValueUpdatedX()
    {
        return updatedX;
    }
    public int GetValueUpdatedY()
    {
        return updatedY;
    }
    public int GetValue()
    {
        return value;
    }
    public char[,] GetArray()
    {
        return array;
    }   
}
