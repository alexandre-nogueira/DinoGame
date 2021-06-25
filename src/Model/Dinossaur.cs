using System;

namespace DinoGame.Models{
public class Dinossaur
{
    private string name;

    private int attackPoints;

    private int defensePoints;

    private bool isAlive;

    public Dinossaur(string n, int pa, int pd){
        name = n;
        attackPoints = pa;
        defensePoints = pd;
        isAlive = true;

    }


    public int Attack(){
        if (new Random().Next(1,100) <= 50){
            attackPoints--;
            return 1;
        }
        else{
            Defend(1);
            return 2;
        }
    }

    public void Defend(int hitPoints){
        defensePoints = defensePoints - hitPoints;
        if(defensePoints <= 0)
            Die();
    }

    public string GetName(){
        return name;
    }

    public bool IsAlive(){
        return isAlive;
    }

    public int GetDefensePoints(){
        return defensePoints;
    }

    public int GetAttackPoints(){
        return attackPoints;
    }

    private void Die(){
        isAlive = false;
    }

}
}