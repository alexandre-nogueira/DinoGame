using System;
using System.Collections.Generic;

using DinoGame.Util;

namespace DinoGame.Models{
    public class Player{

        public string Name { get; set; }
        private List<Dinossaur> Dinossaurs = new List<Dinossaur>();

        public Player(string playerName){
            Name = playerName;
        }

        public Player(){}

        public Player(string playerName, List<Dinossaur> dinos){
            Name = playerName;
            Dinossaurs = dinos;
        }

        public void AddDinossaur(Dinossaur dino){
            Dinossaurs.Add(dino);
        }

        public List<Dinossaur> GetDinossaurs(){
            return Dinossaurs;
        }

        public Dinossaur SelectDino(int id){
            return Dinossaurs[id-1];
        }


        public bool HasDinosAlive(){
            foreach (Dinossaur Dinossaur in Dinossaurs)
            {
                if (Dinossaur.IsDinoAlive){
                    return true;
                }
            }
            return false;
        }

    }
}