public class Turn{

    private int number;
    private string attackPlayer;
    private string defensePlayer;

    public Dinossaur attackDino;
    public Dinossaur defenseDino;

    private int attackDinoInicialPoints;
    private int attackDinoFinalPoints;
    private int defenseDinoInicialPoints;
    private int defenseDinoFinalPoints;


    public int hitPointsAttack;
    public int hitPoints;

    public int GetNumber(){
        return number;
    }

    public string GetAttackPlayer() {
        return attackPlayer;
    }

    public string GetDefensePlayer(){
        return defensePlayer;
    }

    public Dinossaur GetAttackDino(){
        return attackDino;
    }

    public Dinossaur GetDefenseDino(){
        return defenseDino;
    }

    public int GetattackDinoInicialPoints(){
        return attackDinoInicialPoints;
    }

    public int GetAttackDinoFinalPoints(){
        return attackDinoFinalPoints;
    }

    public int GetDefenseDinoInicialPoints(){
        return defenseDinoInicialPoints;
    }

    public int GetDefenseDinoFinalPoints(){
        return defenseDinoFinalPoints;
    }
    public Turn(int pNumber, string pAttackPlayer, string pDefensePlayer, Dinossaur pAttackDino, Dinossaur pDefenseDino){                     
        number = pNumber;
        attackPlayer = pAttackPlayer;
        defensePlayer = pDefensePlayer;
        attackDino = pAttackDino;
        defenseDino = pDefenseDino;

         attackDinoInicialPoints = pAttackDino.GetAttackPoints();
         defenseDinoInicialPoints = pDefenseDino.GetDefensePoints();
    }

    public int GetAttackParameter(){
        return attackDino.GetAttackPoints();
    }

    public void RegisterAttack(){

        attackDinoFinalPoints = attackDino.GetAttackPoints();
        defenseDinoFinalPoints = defenseDino.GetDefensePoints();
    }


}