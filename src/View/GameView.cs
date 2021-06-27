using System;
using DinoGame.Util;
using DinoGame.Models;
using System.Collections.Generic;

namespace DinoGame.Views{
public class DinoGameView : MainGameView{

    const int HEADERHEIGHT = 3;

    PlayerView playerView = new PlayerView();
    TurnView turnView = new TurnView();

        public void InicialScreen(){
            WriteMainMenu();
            WriteDinoAscii();
            Console.BackgroundColor =ConsoleColor.White;
            Console.ForegroundColor =ConsoleColor.Black;
            Console.Write("Vamos iniciar o jogo, pressione enter!");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void WriteDinoAscii(){
            for (int i=0; i<=25 ; i++)
            {
                Console.SetCursorPosition(i+1, HEADERHEIGHT);
                Console.WriteLine("                __ ");
                Console.SetCursorPosition(i+1, HEADERHEIGHT+1);
                Console.WriteLine("               / _)");
                Console.SetCursorPosition(i+1, HEADERHEIGHT+2);
                Console.WriteLine("      _.----._/ /  ");
                Console.SetCursorPosition(i+1, HEADERHEIGHT+3);
                Console.WriteLine("     /         /   ");
                Console.SetCursorPosition(i+1, HEADERHEIGHT+4);
                Console.WriteLine("  __/ (  | (  |    ");
                Console.SetCursorPosition(i+1, HEADERHEIGHT+5);
                Console.WriteLine(" /__.-'|_|--|_|    ");
                Console.WriteLine();
                System.Threading.Thread.Sleep(80);
            }
        }
    
        public int GetDinosPerPlayer(int maxNumberOfDinos){
            WriteMainMenu();
            return ScreenUtility.ReadInt("Dinos por Player...: ", maxNumberOfDinos);
        }

        public int GetDiceType(int maxDiceNumber){
            WriteMainMenu();
            return ScreenUtility.ReadInt("Qual o número máximo do seu dado? ", maxDiceNumber);
        }
        
        public int GetMaxPoints(int maxPoins){
            WriteMainMenu();
            return ScreenUtility.ReadInt("Pontos totais a distribuir por dino...: ", maxPoins);
        }

        public int GetDiceResult(int maxDiceNumber){
            WriteMainMenu();
            return ScreenUtility.ReadInt("Valor do dado...: ", maxDiceNumber);
        }

        public void ShowAllsetScreen(Player player1, Player player2){
            WriteMainMenu();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Tudo pronto, vamos comerçar!!");
            Console.WriteLine("-----------------------------");
        }

        public void ShowFinshGameScreen(Player winner, List<Turn> turns){
            WriteMainMenu();
            Console.WriteLine("O winner é:....... " + winner.GetName());
            foreach (Turn turn in turns)
            {
                turnView.WriteTurn(turn.GetNumber());
                Console.WriteLine("Dino Ataque " + turn.GetAttackDino().GetName() +
                " Pontos Iniciais: " + turn.GetattackDinoInicialPoints() + 
                " Pontos finais: " + turn.GetAttackDinoFinalPoints());
                Console.WriteLine("Dino Defesa " + turn.GetDefenseDino().GetName() +
                " Pontos Iniciais: " + turn.GetDefenseDinoInicialPoints() + 
                " Pontos finais: " + turn.GetDefenseDinoFinalPoints());
                Console.WriteLine();
            }

        }

    }
}