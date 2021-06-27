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

    private int diceType;

    private int maxPoints;

    DinoGameView dinoGameView = new DinoGameView();
    PlayerController playerController = new PlayerController();
    DinossaurController dinossaurController = new DinossaurController();
    TurnController turnController = new TurnController();

        public void InitGame(){
            dinoGameView.InicialScreen();
            InitPlayers();
            InitDinosPerPlayer();
            InitDiceType();
            IntMaxPoints();
            CreateDinos(player1);
            CreateDinos(player2);
            FinishInitProcess();
        }

        public void InitPlayers(){
            player1 = playerController.CreateNewPlayer("1");
            player2 = playerController.CreateNewPlayer("2");
        }

        public void InitDinosPerPlayer(){
            dinosPerPlayer = dinoGameView.GetDinosPerPlayer(MAXDINOSPERPLAYER);
        }

        public void InitDiceType(){
            diceType = dinoGameView.GetDiceType(MAXDICENUMBER);
        }

        public void IntMaxPoints(){
            maxPoints = dinoGameView.GetMaxPoints(MAXPOSSIBLEPOINTS);
        }

        public void FinishInitProcess(){
            dinoGameView.ShowAllsetScreen();
            playerController.ShowPlayer(player1);
            dinossaurController.ListDinosssaurs(player1.GetDinossaurs());
            playerController.ShowPlayer(player2);
            dinossaurController.ListDinosssaurs(player2.GetDinossaurs());
            Console.ReadKey();
        }

        public void CreateDinos(Player player){
            dinossaurController.CreateDinossaurs(player, dinosPerPlayer, maxPoints);
        }

        public int RollDice(){
            //Random r = new Random();
            //return r.Next(1, diceType);
            return dinoGameView.GetDiceResult(diceType);
        }

        public void InitTurn(){

            Player attackPlayer;
            Player defensePlayer;
            int newTurnNumber;

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
            newTurnNumber = (currentTurn == null ? 1 : currentTurn.GetNumber()+1);
            currentTurn = turnController.StartNewTurn(newTurnNumber, attackPlayer,defensePlayer);
            
        }


        public void ExecutePlay(){
            double attackValue;
            int penalidadeAtaque;
            
            //Attack player roll the dice
            currentTurn.diceValue = RollDice();
  
            //Attack value is calculated
            attackValue = (currentTurn.GetAttackDino().GetAttackPoints() / (diceType*1.00)) * currentTurn.diceValue;
            //Console.WriteLine("value do dado:: " + diceValue + " Parametro ataque: " + currentTurn.GetAttackDino().GetAttackPoints() + " value ataque: " + attackValue);

            //O dano é inflingido no Dinossaur de defesa e ataque
            currentTurn.GetDefenseDino().Defend((int)attackValue);
            penalidadeAtaque = currentTurn.GetAttackDino().Attack();

            currentTurn.RegisterAttack(attackValue, penalidadeAtaque, 1);

            turnController.FinishTurn(currentTurn);
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
            dinoGameView.ShowFinshGameScreen(winner, turns);
        }


    }
}