using System;
using DinoGame.Models;
using System.Collections.Generic;
using DinoGame.Util;

namespace DinoGame.Views{
    public class DinossaurView : MainGameView{


//Create new dino screen
        public void CreateDinossaur(Player player, int numberOfDinos, int maxPoints){
            for(int i=0; i < numberOfDinos; i++){
                WriteMainMenu();
                int dinoNumber = i +1;
                ScreenUtility.WriteColoredString(player.GetName() + " - Dino " + dinoNumber, ConsoleColor.Black, ConsoleColor.Yellow);
                ScreenUtility.WriteColoredString(("").PadRight(40, '='), ConsoleColor.Black, ConsoleColor.Yellow);
                player.AddDinossaur(CreateDinossaur(maxPoints));
            }
        }

        private Dinossaur CreateDinossaur(int maxPoints){
            string name;
            int attackPoints;
            int defensePoints;

            //Nome
            Console.Write("Nome do Dino: ");
            name = Console.ReadLine();

            attackPoints = EnterAttackPoints(maxPoints);
            defensePoints = maxPoints - attackPoints;

            return new Dinossaur(name, attackPoints, defensePoints);
        }

        public int EnterAttackPoints(int maxPoints){
            ConsoleKeyInfo cki;
            var sb = new System.Text.StringBuilder();
            int value = 0;

            Console.Write("Pontos de Ataque: ");
            while(true){
                cki = Console.ReadKey(true);
                
                //Se foi digitado um número válido
                if (char.IsDigit(cki.KeyChar))
                {
                    sb.Append(cki.KeyChar);
                    value = int.Parse(sb.ToString());
                    if (value < maxPoints){
                        Console.Write(cki.KeyChar);
                        WritePointsLine(value, maxPoints-value);
                    } else
                        sb.Remove(sb.Length-1, 1);
                }
                else if(cki.Key == ConsoleKey.Backspace){
                    if(sb.Length > 0){
                        sb.Remove(sb.Length-1, 1);
                        Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                        Console.Write(' ');
                        Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                        if(int.TryParse(sb.ToString(), out value)){
                            WritePointsLine(value, maxPoints-value);
                        }else{
                            WritePointsLine(0, maxPoints-value);
                        }
                    }
                
                }else if(cki.Key == ConsoleKey.Enter){
                    if(int.TryParse(sb.ToString(), out value))
                        return value;
                }else continue;

            }
        }

            public void WritePointsLine(int pAttackPoints, int pDefensePoints){
                int cursorTop = Console.CursorTop;
                int cursorLeft = Console.CursorLeft;
                var sb = new System.Text.StringBuilder();
                Console.SetCursorPosition(0, Console.CursorTop+2);
                Console.SetCursorPosition(0, Console.CursorTop);
                for(int i = 0; i < pAttackPoints; i++){
                    // Console.Write('+');
                    sb.Append("+");
                }
                ScreenUtility.WriteColoredStringNoLine(sb.ToString(), ConsoleColor.Black, ConsoleColor.DarkGreen);
                // Console.Write(sb.ToString());
                ScreenUtility.WriteColoredStringNoLine(("").PadRight(pDefensePoints, '-'), ConsoleColor.Black, ConsoleColor.DarkCyan);
                // Console.Write(("").PadRight(pDefensePoints, '-'));
                Console.WriteLine();
                Console.WriteLine();
                ClearCurrentConsoleLine();
                ScreenUtility.WriteColoredString("Pontos de Ataque...: " + pAttackPoints, ConsoleColor.Black, ConsoleColor.DarkGreen);
                // Console.WriteLine("Pontos de Ataque...: " + pAttackPoints);
                ClearCurrentConsoleLine();
                ScreenUtility.WriteColoredString("Pontos de Defesa...: " + pDefensePoints, ConsoleColor.Black, ConsoleColor.DarkCyan);
                // Console.WriteLine("Pontos de Defesa...: " + pDefensePoints);

                Console.SetCursorPosition(cursorLeft, cursorTop);

            }

//Table list dinos

        public void ListDinossaurs(List<Dinossaur> dinossaurs){
            int numeroDino = 0;
            Console.WriteLine("{0,-5} {1,-25} {2,15} {3,15} {4,-8}", "Nr", "Dino", "Pontos Ataque", "Pontos Defesa", "Status");
            Console.WriteLine(("").PadRight(80,'-'));
            foreach (Dinossaur dinossaur in dinossaurs)
            {
                numeroDino++;
                Console.WriteLine("{0,-5} {1,-25} {2,15} {3,15} {4,-8}", 
                                    numeroDino, 
                                    dinossaur.GetName(), 
                                    dinossaur.GetAttackPoints(),
                                    dinossaur.GetDefensePoints(),
                                    (dinossaur.IsAlive() ? "Vivo" : "Morto"));
            }
            Console.WriteLine(("").PadRight(80,'-'));
            Console.WriteLine();
        }
//Pick a dino and return to controller

//Display Dinossaur data

    }
}