using System;
using System.Collections.Generic;
using DinoGame.Models;
using DinoGame.Views;
using DinoGame.Util;

namespace DinoGame.Controllers{
public class GameController
{

    //Constantes
    const int MAXDINOSPERPLAYER = 5;
    const int MAXDICENUMBER = 20;
    const int MAXPOSSIBLEPOINTS = 80;

    public Player player1;
    public Player player2;

    private Player winner;
    private int dinosPerPlayer;

    private List<Turn> turns = new List<Turn>();
    private Turn currentTurn;

    private double diceType;

    private int maxPoints;

    DinoGameView dinoGameView = new DinoGameView();

    public void InitGame(){
        dinoGameView.InicialScreen();
        InitPlayers();
        InitDinosPerPlayer();
        InitDiceType();
        IntMaxPoints();
    }

    public int getDinosPorPlayer(){
        return dinosPerPlayer;
    }

    public void InitPlayers(){
        
        player1 = new Player(dinoGameView.GetPlayerName("1"));
        player2 = new Player(dinoGameView.GetPlayerName("2"));

    }

    public void InitDinosPerPlayer(){
                
        dinoGameView.WriteMainMenu();
        dinosPerPlayer = dinoGameView.readInt("Dinos por Player: ", MAXDINOSPERPLAYER);
    }

    public void InitDiceType(){
                
        dinoGameView.WriteMainMenu();
        diceType = dinoGameView.readInt("Qual o número máximo do seu dado? ", MAXDICENUMBER);
        //diceType = Utilitario.readDouble("Qual o número máximo do seu dado? ");
    }

    public void IntMaxPoints(){
                
        dinoGameView.WriteMainMenu();
        maxPoints = dinoGameView.readInt("Pontos máximos por dino: ", MAXPOSSIBLEPOINTS);
        //maxPoints = Utilitario.readInt("Pontos máximos por dino: ");
    }

    public void ShowAllsetScreen(){
        dinoGameView.WriteMainMenu();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Tudo pronto, vamos comerçar!!");
        Console.WriteLine("-----------------------------");

        player1.ListDinos();
        player2.ListDinos();
        Console.ReadKey();
    }

    private void WriteTurn(int numeroTurn){
        Console.BackgroundColor =ConsoleColor.White;
        Console.ForegroundColor =ConsoleColor.Black;
        Console.WriteLine("Turn: " + numeroTurn + " ");
        Console.WriteLine();
        Console.ResetColor();
    }
    // public Player criarPlayer(int numeroPlayer){
    //     return new Player(dinoGameView.GetPlayerName(numeroPlayer));
    // }

    public void CreateDinos(Player player){
        for(int i=0; i < dinosPerPlayer; i++){
            dinoGameView.WriteMainMenu();
            int dinoNumber = i +1;
            Console.WriteLine("Player " + player.GetName() + " - Dino " + dinoNumber);
            Console.WriteLine("-----------------------------");
            player.AddDinossaur(CreateDinossaur());
        }
    }

    public Dinossaur CreateDinossaur(){
        string name;
        int attackPoints;
        int defensePoints;

        //Nome
        Console.Write("Nome do Dino: ");
        name = Console.ReadLine();

       attackPoints = EnterAttackPoints();
       defensePoints = maxPoints - attackPoints;

       return new Dinossaur(name, attackPoints, defensePoints);
    }

    public int RollDice(){
        //Random r = new Random();
        //return r.Next(1, diceType);
        while(true){
            int diceValue = ScreenUtility.readInt("value do dado: ");
            if ( diceValue <= diceType) 
                return diceValue;
        }
    }

    public void InitTurn(){

        Dinossaur attackDino;
        Dinossaur defenseDino;
        Player attackPlayer;
        Player defensePlayer;

        if(currentTurn == null){
            attackPlayer = player1;
            defensePlayer = player2;
        }else if(currentTurn.GetAttackPlayer() == player1.GetName()){
            attackPlayer = player2;
            defensePlayer = player1;
        }else{
            attackPlayer = player1;
            defensePlayer = player2;
        }
        dinoGameView.WriteMainMenu();
        WriteTurn(currentTurn == null ? 1 : currentTurn.GetNumber()+1);

        Console.WriteLine(attackPlayer.GetName() + ", sua vez!!");
        Console.WriteLine();
        attackDino = attackPlayer.SelectDino("Atacar");
        dinoGameView.WriteMainMenu();
        WriteTurn(currentTurn == null ? 1 : currentTurn.GetNumber()+1);
        Console.WriteLine(defensePlayer.GetName() + ", sua vez!!");
        Console.WriteLine();
        defenseDino = defensePlayer.SelectDino("Defend");
        currentTurn = new Turn((currentTurn == null ? 1 : currentTurn.GetNumber()+1), attackPlayer.GetName(), defensePlayer.GetName(), attackDino, defenseDino);
    }


    public void ExecutePlay(){
        int diceValue;
        double attackValue;
        int penalidadeAtaque;
        
        //Player atacante rola o dado
        diceValue = RollDice();
        currentTurn.hitPointsAttack = diceValue;

        //O calculo do ataque é executado
        attackValue = (currentTurn.GetAttackDino().GetAttackPoints() / diceType) * diceValue;
        Console.WriteLine("value do dado:: " + diceValue + " Parametro ataque: " + currentTurn.GetAttackDino().GetAttackPoints() + " value ataque: " + attackValue);
        Console.ReadKey();

        //O dano é inflingido no Dinossaur de defesa e ataque
        currentTurn.GetDefenseDino().Defend((int)attackValue);
        penalidadeAtaque = currentTurn.GetAttackDino().Attack();

        currentTurn.RegisterAttack();

        //Exibir os dados do Turn
        dinoGameView.WriteMainMenu();
        WriteTurn(currentTurn.GetNumber());
        Console.WriteLine("O Player " + currentTurn.GetAttackPlayer() + " atacou o dino " + currentTurn.GetDefenseDino().GetName() + 
                " com o dino " + currentTurn.GetAttackDino().GetName() + " e tirou " + attackValue + " pontos de vida");
        Console.WriteLine("Agora o dino " + currentTurn.GetDefenseDino().GetName() + " tem apenas " + currentTurn.GetDefenseDino().GetDefensePoints());

        Console.WriteLine("Penalidade de ataque: " + (penalidadeAtaque ==1 ? "ataque" : "defesa"));

        Console.ReadKey();

    }

    public void FinishTurn(){
        turns.Add(currentTurn);
    }


    public bool HasWinner(){
        if(!player1.HasDinosAlive()){
            winner = player2;
            return true;
        }
        if(!player2.HasDinosAlive()){
            winner = player1;
            return true;
        }
        return false;

    }
    public void FinishGame(){
        dinoGameView.WriteMainMenu();
        Console.WriteLine("O winner é:....... " + winner.GetName());
        foreach (Turn Turn in turns)
        {
            WriteTurn(Turn.GetNumber());
            Console.WriteLine("Dino Ataque " + Turn.GetAttackDino().GetName() +
            " Pontos Iniciais: " + Turn.GetattackDinoInicialPoints() + 
            " Pontos finais: " + Turn.GetAttackDinoFinalPoints());
            Console.WriteLine("Dino Defesa " + Turn.GetDefenseDino().GetName() +
            " Pontos Iniciais: " + Turn.GetDefenseDinoInicialPoints() + 
            " Pontos finais: " + Turn.GetDefenseDinoFinalPoints());
            Console.WriteLine();
        }


    }

     public int EnterAttackPoints(){
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
                    dinoGameView.WritePointsLine(value, maxPoints-value);
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
                        dinoGameView.WritePointsLine(value, maxPoints-value);
                    }else{
                        dinoGameView.WritePointsLine(0, maxPoints-value);
                    }
                }
            
            }else if(cki.Key == ConsoleKey.Enter){
                if(int.TryParse(sb.ToString(), out value))
                    return value;
            }else continue;

        }
    }

}
}