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
            ScreenUtility.WriteColoredString(attackPlayer.Name + ", sua vez!!", ConsoleColor.Black, ConsoleColor.DarkYellow);
            Console.WriteLine();
            dinossaurView.ListDinossaurs(attackPlayer.GetDinossaurs());
            attackDino = attackPlayer.SelectDino(ScreenUtility.readInt("Selecione um dino para atacar...: "));
            WriteMainMenu();
            WriteTurn(turnNumber);
            ScreenUtility.WriteColoredString(defensePlayer.Name + ", sua vez!!", ConsoleColor.Black, ConsoleColor.DarkYellow);
            Console.WriteLine();
            dinossaurView.ListDinossaurs(defensePlayer.GetDinossaurs());
            defenseDino = defensePlayer.SelectDino(ScreenUtility.readInt("Selecione um dino para defender...: "));
            return new Turn(turnNumber, attackPlayer.Name, defensePlayer.Name, attackDino, defenseDino);
        }

        public void WriteTurn(int numeroTurn){
            ScreenUtility.WriteColoredString("Turn: " + numeroTurn + " ", ConsoleColor.Black, ConsoleColor.DarkRed);
            ScreenUtility.WriteColoredString(("").PadRight(40, '-'), ConsoleColor.Black, ConsoleColor.DarkRed);
            Console.WriteLine();
        }

        public void ShowTurnResult(Turn turn){
            WriteMainMenu();
            System.Console.WriteLine();

            int pRow = 5; //Console row position.
            int pCol = 0; //Console column position.

            //Write attack player info
            ScreenUtility.WriteColoredAtPosition(   turn.AttackPlayer, 
                                                    ConsoleColor.Black, ConsoleColor.DarkYellow, 
                                                    pCol, pRow);
            pRow++;
            ScreenUtility.WriteColoredAtPosition(   ("").PadRight(turn.AttackPlayer.Length+3, '-'), 
                                                    ConsoleColor.Black, ConsoleColor.DarkYellow, 
                                                    pCol, pRow);
            pRow++;
            ScreenUtility.WriteColoredAtPosition(   $"Dino >> {turn.AttackDino.Name}", 
                                                    ConsoleColor.Black, ConsoleColor.DarkMagenta, 
                                                    pCol, pRow);
            pRow++;
            ScreenUtility.WriteColoredAtPosition(   "Pontos ataque:... ",
                                                    ConsoleColor.Black, ConsoleColor.DarkGreen, 
                                                    pCol, pRow);
            if (turn.AttackPenaltyType == 1){
                ScreenUtility.WriteColoredStringNoLine($" (-{turn.AtackPenaltyValue})", 
                                                     ConsoleColor.Black, ConsoleColor.DarkRed);
            }
            ScreenUtility.WriteColoredStringNoLine($" {turn.AttackDinoRef.AttackPoints}", 
                                                    ConsoleColor.Black, ConsoleColor.DarkGreen);
            pRow++;
            ScreenUtility.WriteColoredAtPosition(   "Pontos Defesa:... ", 
                                                    ConsoleColor.Black, ConsoleColor.DarkBlue, 
                                                    pCol, pRow);
            if (turn.AttackPenaltyType != 1){
                ScreenUtility.WriteColoredStringNoLine($" (-{turn.AtackPenaltyValue})", 
                                                     ConsoleColor.Black, ConsoleColor.DarkRed);
            }
            ScreenUtility.WriteColoredStringNoLine($" {turn.AttackDinoRef.DefensePoints}", 
                                                    ConsoleColor.Black, ConsoleColor.DarkBlue);
            //HitPoints
            pRow = 7;
            pCol = 27;
            ScreenUtility.WriteColoredAtPosition(   $">> Dano {turn.HitPoints} >>", 
                                                    ConsoleColor.DarkRed, ConsoleColor.White, 
                                                    pCol, pRow);


            //Write attack player info
            pRow = 5;
            pCol = 50;
            ScreenUtility.WriteColoredAtPosition(   turn.DefensePlayer, 
                                                    ConsoleColor.Black, ConsoleColor.DarkYellow, 
                                                    pCol, pRow);
            pRow++;
            ScreenUtility.WriteColoredAtPosition(   ("").PadRight(turn.DefensePlayer.Length+3, '-'), 
                                                    ConsoleColor.Black, ConsoleColor.DarkYellow, 
                                                    pCol, pRow);
            pRow++;
            ScreenUtility.WriteColoredAtPosition(   $"Dino >> {turn.DefenseDino.Name}", 
                                                    ConsoleColor.Black, ConsoleColor.DarkMagenta, 
                                                    pCol, pRow);
            pRow++;
            ScreenUtility.WriteColoredAtPosition(   $"Pontos ataque:... {turn.DefenseDinoRef.AttackPoints}", 
                                                    ConsoleColor.Black, ConsoleColor.DarkGreen, 
                                                    pCol, pRow);
            pRow++;
            ScreenUtility.WriteColoredAtPosition(   "Pontos Defesa:... ", 
                                                    ConsoleColor.Black, ConsoleColor.DarkBlue, 
                                                    pCol, pRow);
            // ScreenUtility.WriteColoredStringNoLine(" " + turn.DefenseDino.DefensePoints, 
            //                                         ConsoleColor.Black, ConsoleColor.Gray);
            ScreenUtility.WriteColoredStringNoLine($" (-{turn.HitPoints})", 
                                                    ConsoleColor.Black, ConsoleColor.DarkRed);
            ScreenUtility.WriteColoredStringNoLine(" " + (turn.DefenseDinoRef.DefensePoints - turn.HitPoints), 
                                                    ConsoleColor.Black, ConsoleColor.DarkBlue);

            Console.ReadKey();

        }
    }

}