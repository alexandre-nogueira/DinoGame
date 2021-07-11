using System;
using System.Collections.Generic; 

namespace DinoGame.Util{
    public static class ScreenUtility{


        public static void WriteColoredString(String text, ConsoleColor bg, ConsoleColor fg){
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteColoredStringNoLine(String text, ConsoleColor bg, ConsoleColor fg){
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteColoredAtPosition(String text, ConsoleColor bg, ConsoleColor fg, int column, int row){
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            Console.SetCursorPosition(column, row);
            Console.Write(text);
            Console.ResetColor();
        }

        public static int ReadInt(string label){
            int valor = 0;

                while(true){
                    Console.Write(label);
                    if(int.TryParse(Console.ReadLine(), out valor)){
                        break;
                    }else{Console.WriteLine("Valor Inválido");}
                }
            return valor;
        }

        public static double ReadDouble(string label){
            double valor = 0;

                while(true){
                    Console.Write(label);
                    if(double.TryParse(Console.ReadLine(), out valor)){
                        break;
                    }else{Console.WriteLine("Valor Inválido");}
                }
            return valor;
        }

        
    public static int ReadInt(string label, int maxInputValue){
        ConsoleKeyInfo cki;
        var sb = new System.Text.StringBuilder();
        int inputValue = 0;

        Console.Write(label);
        while(true){
            cki = Console.ReadKey(true);
            
            //Se foi digitado um número válido
            if (char.IsDigit(cki.KeyChar))
            {
                sb.Append(cki.KeyChar);
                inputValue = int.Parse(sb.ToString());
                if (inputValue <= maxInputValue){
                    Console.Write(cki.KeyChar);
                } else
                    sb.Remove(sb.Length-1, 1);
            }
            else if(cki.Key == ConsoleKey.Backspace){
                if(sb.Length > 0){
                    sb.Remove(sb.Length-1, 1);
                    Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                }
            
            }else if(cki.Key == ConsoleKey.Enter){
                if(int.TryParse(sb.ToString(), out inputValue))
                    return inputValue;
            }else continue;

        }
    }
    }
}