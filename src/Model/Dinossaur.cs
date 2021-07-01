using System;

namespace DinoGame.Models{
public class Dinossaur
{
    public string Name { get; private set; }

    public int AttackPoints { get; private set; }

    public int DefensePoints { get; private set; }

    public bool IsDinoAlive { get; private set; }

    public Dinossaur(string n, int pa, int pd){
        Name = n;
        AttackPoints = pa;
        DefensePoints = pd;
        IsDinoAlive = true;

    }


    public int Attack(){
        if (new Random().Next(1,100) <= 50){
            AttackPoints--;
            return 1;
        }
        else{
            Defend(1);
            return 2;
        }
    }

    public void Defend(int hitPoints){
        DefensePoints = DefensePoints - hitPoints;
        if(DefensePoints <= 0)
            Die();
    }

    private void Die(){
        IsDinoAlive = false;
    }

}
}