
namespace DinoGame.Models{
public class Turn{

    public int Number {get; private set; }
    public string AttackPlayer {get; private set; }
    public string DefensePlayer {get; private set; }

    public Dinossaur AttackDino {get; private set; }
    public Dinossaur DefenseDino {get; private set; }

    public Dinossaur AttackDinoRef {get; private set; }
    public Dinossaur DefenseDinoRef {get; private set; }

    public int DiceValue {get; set;}
    public int HitPoints {get; set;}
    public int AttackPenaltyType {get; set;}
    public int AtackPenaltyValue {get; set;}

    public Turn(int pNumber, string pAttackPlayer, string pDefensePlayer, Dinossaur attackDino, Dinossaur defenseDino){                     
        Number = pNumber;
        AttackPlayer = pAttackPlayer;
        DefensePlayer = pDefensePlayer;
        AttackDino = new Dinossaur (attackDino.Name, attackDino.AttackPoints, attackDino.DefensePoints);
        DefenseDino = new Dinossaur(defenseDino.Name, defenseDino.AttackPoints, defenseDino.DefensePoints);
        AttackDinoRef = attackDino;
        DefenseDinoRef = defenseDino;
    }

    public void RegisterAttack(double pHitPoints, int penaltyType, int pentaltyValue){

        HitPoints = (int)pHitPoints;
        AttackPenaltyType = penaltyType;
        AtackPenaltyValue = pentaltyValue;
    }


}
}