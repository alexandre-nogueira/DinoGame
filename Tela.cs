using System;

public class JogoDinossauroView{

    const int alturaHeader = 3;

    //Campos da tela
    public string nomeJogador1;

    public void telaInicial(){
        escreverMenu();
        escreverDinoAscii();
        Console.BackgroundColor =ConsoleColor.White;
        Console.ForegroundColor =ConsoleColor.Black;
        Console.WriteLine("Vamos iniciar o jogo, pressione enter!");
        Console.ResetColor();
        Console.ReadKey();
    }

    public void escreverMenu(){
        Console.Clear();
        Console.WriteLine(("").PadRight(80, '='));
        Console.WriteLine("--------------------         BATALHA DE DINOSSAUROS         --------------------");
        Console.WriteLine(("").PadRight(80, '='));
        Console.WriteLine();
    }

    public void escreverDinoAscii(){
        for (int i=0; i<=25 ; i++)
        {
            Console.SetCursorPosition(i+1, alturaHeader);
            Console.WriteLine("                __ ");
            Console.SetCursorPosition(i+1, alturaHeader+1);
            Console.WriteLine("               / _)");
            Console.SetCursorPosition(i+1, alturaHeader+2);
            Console.WriteLine("      _.----._/ /  ");
            Console.SetCursorPosition(i+1, alturaHeader+3);
            Console.WriteLine("     /         /   ");
            Console.SetCursorPosition(i+1, alturaHeader+4);
            Console.WriteLine("  __/ (  | (  |    ");
            Console.SetCursorPosition(i+1, alturaHeader+5);
            Console.WriteLine(" /__.-'|_|--|_|    ");
            Console.WriteLine();
            System.Threading.Thread.Sleep(80);
        }
    }

    
    public void escreveLinhaPontos(int pPontosAtaque, int pPontosDefesa){
        int cursorTop = Console.CursorTop;
        int cursorLeft = Console.CursorLeft;
        Console.SetCursorPosition(0, Console.CursorTop+2);
        Console.SetCursorPosition(0, Console.CursorTop);
        for(int i = 0; i < pPontosAtaque; i++){
            Console.Write('+');
        }
        Console.Write(("").PadRight(pPontosDefesa, '-'));
        Console.WriteLine();
        Console.WriteLine();
        ClearCurrentConsoleLine();
        Console.WriteLine("Pontos de Ataque...: " + pPontosAtaque);
        ClearCurrentConsoleLine();
        Console.WriteLine("Pontos de Defesa...: " + pPontosDefesa);

        Console.SetCursorPosition(cursorLeft, cursorTop);


    }

    public string getNomeJogador(string numeroJogador){
        //Nome
        escreverMenu();
        Console.Write("Nome do Jogador " + numeroJogador + " : ");
        return Console.ReadLine();
    }

    public void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }


    public int readInt(string label, int valorMaximo){
        ConsoleKeyInfo cki;
        var sb = new System.Text.StringBuilder();
        int valor = 0;

        Console.Write(label);
        while(true){
            cki = Console.ReadKey(true);
            
            //Se foi digitado um número válido
            if (char.IsDigit(cki.KeyChar))
            {
                sb.Append(cki.KeyChar);
                valor = int.Parse(sb.ToString());
                if (valor <= valorMaximo){
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
                if(int.TryParse(sb.ToString(), out valor))
                    return valor;
            }else continue;

        }
    }

}