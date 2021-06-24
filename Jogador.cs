using System;
using System.Collections.Generic;
public class Jogador{

    private string nome;
    private List<Dinossauro> dinossauros = new List<Dinossauro>();

        public Jogador(string nomeJogador){
        nome = nomeJogador;
    }

    public Jogador(string nomeJogador, List<Dinossauro> dinos){
        nome = nomeJogador;
        dinossauros = dinos;
    }

    public void adicionarDinossauro(Dinossauro dino){
        dinossauros.Add(dino);
    }

    public string getNome(){
        return nome;
    }

    public Dinossauro selecionarDino(string acao){
        listarDinos();
        int numeroDino = Utilitario.readInt("Selecione um dino para " + acao + ": ");
        return dinossauros[numeroDino-1];
    }

    public void listarDinos(){
        int numeroDino = 0;
        Console.WriteLine("{0,-5} {1,-25} {2,15} {3,15} {4,-8}", "Nr", "Dino", "Pontos Ataque", "Pontos Defesa", "Status");
        Console.WriteLine(("").PadRight(80,'-'));
        foreach (Dinossauro dinossauro in dinossauros)
        {
            numeroDino++;
            Console.WriteLine("{0,-5} {1,-25} {2,15} {3,15} {4,-8}", 
                                numeroDino, 
                                dinossauro.getNome(), 
                                dinossauro.getPontosDeAtaque(),
                                dinossauro.getPontosDeDefesa(),
                                (dinossauro.estaVivo() ? "Vivo" : "Morto"));
        }
        Console.WriteLine(("").PadRight(80,'-'));
        Console.WriteLine();
    }

    public bool temDinosVivos(){
        foreach (Dinossauro dinossauro in dinossauros)
        {
            if (dinossauro.estaVivo()){
                return true;
            }
        }
        return false;
    }

}