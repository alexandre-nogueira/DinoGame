using System;
using DinoGame.Models;
using DinoGame.Util;


namespace DinoGame.Views{
    public class TurnView : MainGameView{
        DinossaurView dinossaurView = new DinossaurView();
        public Turn CreateTurn(int turnNumber, Player attackPlayer, Player defensePlayer){
             Dinossaur attackDino;
             Dinossaur defenseDino;
            WriteMainMenu();
            WriteTurn(turnNumber);
            Console.WriteLine(attackPlayer.GetName() + ", sua vez!!");
            Console.WriteLine();
            dinossaurView.ListDinossaurs(attackPlayer.GetDinossaurs());
            attackDino = attackPlayer.SelectDino(ScreenUtility.readInt("Selecione um dino para atacar...: "));
            WriteMainMenu();
            WriteTurn(turnNumber);
            Console.WriteLine(defensePlayer.GetName() + ", sua vez!!");
            Console.WriteLine();
            dinossaurView.ListDinossaurs(defensePlayer.GetDinossaurs());
            defenseDino = defensePlayer.SelectDino(ScreenUtility.readInt("Selecione um dino para defender...: "));
            return new Turn(turnNumber, attackPlayer.GetName(), defensePlayer.GetName(), attackDino, defenseDino);
        }

        public void WriteTurn(int numeroTurn){
            Console.BackgroundColor =ConsoleColor.White;
            Console.ForegroundColor =ConsoleColor.Black;
            Console.WriteLine("Turn: " + numeroTurn + " ");
            Console.WriteLine();
            Console.ResetColor();
        }

        public void ShowTurnResult(Turn turn){
                        Console.WriteLine("O Player " + turn.GetAttackPlayer() + " atacou o dino " + turn.GetDefenseDino().GetName() + 
                    " com o dino " + turn.GetAttackDino().GetName() + " e tirou " + turn.hitPoints + " pontos de vida");
            Console.WriteLine("Agora o dino " + turn.GetDefenseDino().GetName() + " tem apenas " + turn.GetDefenseDino().GetDefensePoints());

            //Console.WriteLine("Penalidade de ataque: " + (penalidadeAtaque ==1 ? "ataque" : "defesa"));

            Console.ReadKey();

        }
    }

}