using System;
public class Dinossauro
{
    private string nome;

    private int pontosdeataque;

    private int pontosdedefesa;

    private bool vivo;

    public Dinossauro(string n, int pa, int pd){
        nome = n;
        pontosdeataque = pa;
        pontosdedefesa = pd;
        vivo = true;
        
    }

    public int atacar(){
        if (new Random().Next(1,100) <= 50){
            pontosdeataque--;
            return 1;
        }
        else{
            defender(1);
            return 2;
        }
    }

    public void defender(int dano){
        pontosdedefesa = pontosdedefesa - dano;
        if(pontosdedefesa <= 0)
            morrer();
    }

    public string getNome(){
        return nome;
    }

    public bool estaVivo(){
        return vivo;
    }

    public int getPontosDeDefesa(){
        return pontosdedefesa;
    }

    public int getPontosDeAtaque(){
        return pontosdeataque;
    }

    private void morrer(){
        vivo = false;
    }

}