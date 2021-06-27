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

    public Player(){}

    public Player(string playerName, List<Dinossaur> dinos){
        name = playerName;
        Dinossaurs = dinos;
    }

    public void AddDinossaur(Dinossaur dino){
        Dinossaurs.Add(dino);
    }

    public List<Dinossaur> GetDinossaurs(){
        return Dinossaurs;
    }

    public string GetName(){
        return name;
    }

    public Dinossaur SelectDino(int id){
        return Dinossaurs[id-1];
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