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
            ScreenUtility.WriteColoredString("Vamos iniciar o jogo, pressione enter!", ConsoleColor.Black, ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        public void WriteDinoAscii(){
            for (int i=0; i<=25 ; i++)
            {
                Console.SetCursorPosition(i+1, HEADERHEIGHT);
                ScreenUtility.WriteColoredString("                __ ", ConsoleColor.Black, ConsoleColor.DarkGreen);
                Console.SetCursorPosition(i+1, HEADERHEIGHT+1);
                ScreenUtility.WriteColoredString("               / _)", ConsoleColor.Black, ConsoleColor.DarkGreen);
                Console.SetCursorPosition(i+1, HEADERHEIGHT+2);
                ScreenUtility.WriteColoredString("      _.----._/ /  ", ConsoleColor.Black, ConsoleColor.DarkGreen);
                Console.SetCursorPosition(i+1, HEADERHEIGHT+3);
                ScreenUtility.WriteColoredString("     /         /   ", ConsoleColor.Black, ConsoleColor.DarkGreen);
                Console.SetCursorPosition(i+1, HEADERHEIGHT+4);
                ScreenUtility.WriteColoredString("  __/ (  | (  |    ", ConsoleColor.Black, ConsoleColor.DarkGreen);
                Console.SetCursorPosition(i+1, HEADERHEIGHT+5);
                ScreenUtility.WriteColoredString(" /__.-'|_|--|_|    ", ConsoleColor.Black, ConsoleColor.DarkGreen);
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

        public void ShowAllsetScreen(){
            WriteMainMenu();
            ScreenUtility.WriteColoredString("Tudo pronto, vamos comerçar!!", ConsoleColor.Black, ConsoleColor.DarkGreen);
            Console.WriteLine();
        }

        public void ShowFinshGameScreen(Player winner, List<Turn> turns){
            WriteMainMenu();
            Console.WriteLine("O winner é:....... " + winner.Name);
            foreach (Turn turn in turns)
            {
                turnView.WriteTurn(turn.Number);
                ScreenUtility.WriteColoredString(turn.AttackPlayer, ConsoleColor.Black, ConsoleColor.DarkYellow);
                Console.WriteLine("Dino Ataque >> " + turn.AttackDino.Name + 
                turn.AttackDino.AttackPoints); 
                // " Pontos finais: " + turn.GetAttackDinoFinalPoints());
                Console.WriteLine("Dino Defesa >> " + turn.DefenseDino.Name);
                // " Pontos Iniciais: " + turn.GetDefenseDinoInicialPoints() + 
                // " Pontos finais: " + turn.GetDefenseDinoFinalPoints());
                Console.WriteLine();
            }

        }

    }
}