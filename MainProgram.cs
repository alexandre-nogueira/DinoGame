using System;

public class MainProgram{

    GameController gameController = new GameController();


    static void Main(string[] asgs)
    {
        GameController gameController = new GameController();

        gameController.InitGame();

        //Create Dinos
        gameController.CreateDinos(gameController.player1);
        gameController.CreateDinos(gameController.player2);
        
        gameController.ShowAllsetScreen();

        while(true){
            gameController.InitTurn();
            gameController.ExecutePlay();
            gameController.FinishTurn();
            if (gameController.HasWinner()){
                gameController.FinishGame();
                break;
            }
        }

    }

}