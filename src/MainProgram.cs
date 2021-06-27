using System;
using DinoGame.Controllers;

namespace DinoGame{
public class MainProgram{

    GameController gameController = new GameController();


    static void Main(string[] asgs)
    {
        GameController gameController = new GameController();

        gameController.InitGame();

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
}