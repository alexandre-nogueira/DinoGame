using System;

public class Controlador{

    JogoDinossauro jogo = new JogoDinossauro();


    static void Main(string[] asgs)
    {
        JogoDinossauro jogo = new JogoDinossauro();

        // Tela.telaInicial();
        // jogo.inicializarJogadores();
        // jogo.inicializarQtdDinos();
        // jogo.inicializarTipoDado();
        // jogo.inicializarQtdMaxPontosPersonagem();
        jogo.inicializarJogo();

        //Criar Dinossauros
        jogo.criarDinosDoJogador(jogo.jogador1);
        jogo.criarDinosDoJogador(jogo.jogador2);
        
        jogo.exibirTelaTudoPronto();

        while(true){
            jogo.iniciarTurno();
            jogo.executarJogada();
            jogo.finalizarTurno();
            if (jogo.alguemGanhou()){
                jogo.finalizarJogo();
                break;
            }
        }

    }

}