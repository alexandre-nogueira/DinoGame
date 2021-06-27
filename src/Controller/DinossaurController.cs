using System;
using System.Collections.Generic;
using DinoGame.Models;
using DinoGame.Views;

namespace DinoGame.Controllers{
    public class DinossaurController{
        DinossaurView dinossaurView = new DinossaurView();

        public void CreateDinossaurs(Player player, int numberOfDinos, int maxPoints){
            dinossaurView.CreateDinossaur(player, numberOfDinos, maxPoints);
        }

        public void ListDinosssaurs(List<Dinossaur> dinossaurs){
            dinossaurView.ListDinossaurs(dinossaurs);
        }

    }
}