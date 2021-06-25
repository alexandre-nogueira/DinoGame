using System;
namespace DinoGame.Views{
public class DinoGameView{

    const int HEADERHEIGHT = 3;

    //Campos da tela

    public void InicialScreen(){
        WriteMainMenu();
        WriteDinoAscii();
        Console.BackgroundColor =ConsoleColor.White;
        Console.ForegroundColor =ConsoleColor.Black;
        Console.WriteLine("Vamos iniciar o jogo, pressione enter!");
        Console.ResetColor();
        Console.ReadKey();
    }

    public void WriteMainMenu(){
        Console.Clear();
        Console.WriteLine(("").PadRight(80, '='));
        Console.WriteLine("--------------------         BATALHA DE DINOSSAUROS         --------------------");
        Console.WriteLine(("").PadRight(80, '='));
        Console.WriteLine();
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

    
    public void WritePointsLine(int pAttackPoints, int pDefensePoints){
        int cursorTop = Console.CursorTop;
        int cursorLeft = Console.CursorLeft;
        Console.SetCursorPosition(0, Console.CursorTop+2);
        Console.SetCursorPosition(0, Console.CursorTop);
        for(int i = 0; i < pAttackPoints; i++){
            Console.Write('+');
        }
        Console.Write(("").PadRight(pDefensePoints, '-'));
        Console.WriteLine();
        Console.WriteLine();
        ClearCurrentConsoleLine();
        Console.WriteLine("Pontos de Ataque...: " + pAttackPoints);
        ClearCurrentConsoleLine();
        Console.WriteLine("Pontos de Defesa...: " + pDefensePoints);

        Console.SetCursorPosition(cursorLeft, cursorTop);

    }

    public string GetPlayerName(string playerNumber){
        //Nome
        WriteMainMenu();
        Console.Write("Nome do Jogador " + playerNumber + " : ");
        return Console.ReadLine();
    }

    public void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }


    public int readInt(string label, int maxInputValue){
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