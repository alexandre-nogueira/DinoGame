using System;
using System.Collections.Generic;
using DinoGame.Util;

namespace DinoGame.Models{
public class Player{

    private string name;
    private List<Dinossaur> Dinossaurs = new List<Dinossaur>();

        public Player(string playerName){
        name = playerName;
    }

    public Player(string playerName, List<Dinossaur> dinos){
        name = playerName;
        Dinossaurs = dinos;
    }

    public void AddDinossaur(Dinossaur dino){
        Dinossaurs.Add(dino);
    }

    public string GetName(){
        return name;
    }

    public Dinossaur SelectDino(string acao){
        ListDinos();
        int dinoNumber = ScreenUtility.readInt("Selecione um dino para " + acao + ": ");
        return Dinossaurs[dinoNumber-1];
    }

    public void ListDinos(){
        int numeroDino = 0;
        Console.WriteLine("{0,-5} {1,-25} {2,15} {3,15} {4,-8}", "Nr", "Dino", "Pontos Ataque", "Pontos Defesa", "Status");
        Console.WriteLine(("").PadRight(80,'-'));
        foreach (Dinossaur Dinossaur in Dinossaurs)
        {
            numeroDino++;
            Console.WriteLine("{0,-5} {1,-25} {2,15} {3,15} {4,-8}", 
                                numeroDino, 
                                Dinossaur.GetName(), 
                                Dinossaur.GetAttackPoints(),
                                Dinossaur.GetDefensePoints(),
                                (Dinossaur.IsAlive() ? "Vivo" : "Morto"));
        }
        Console.WriteLine(("").PadRight(80,'-'));
        Console.WriteLine();
    }

    public bool HasDinosAlive(){
        foreach (Dinossaur Dinossaur in Dinossaurs)
        {
            if (Dinossaur.IsAlive()){
                return true;
            }
        }
        return false;
    }

}
}