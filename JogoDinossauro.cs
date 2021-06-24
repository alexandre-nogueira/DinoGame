using System;
using System.Collections.Generic;


class JogoDinossauro
{

    //Constantes
    const int numeroMaxDinos = 5;
    const int numeroMaxDado = 20;
    const int pontosMaximosPossiveis = 80;

    public Jogador jogador1;
    public Jogador jogador2;

    private Jogador vencedor;
    private int dinosPorJogador;

    private List<Turno> turnos = new List<Turno>();
    private Turno turnoAtual;

    private double tipoDado;

    private int pontosMaxPersonagem;

    JogoDinossauroView jogoView = new JogoDinossauroView();

    public void inicializarJogo(){
        jogoView.telaInicial();
        inicializarJogadores();
        inicializarQtdDinos();
        inicializarTipoDado();
        inicializarQtdMaxPontosPersonagem();
    }

    public int getDinosPorJogador(){
        return dinosPorJogador;
    }

    public void inicializarJogadores(){
        
        jogador1 = new Jogador(jogoView.getNomeJogador("1"));
        jogador2 = new Jogador(jogoView.getNomeJogador("2"));
        // jogador1 = criarJogador("1");
        // jogador2 = criarJogador("2");
    }

    public void inicializarQtdDinos(){
                
        jogoView.escreverMenu();
        dinosPorJogador = jogoView.readInt("Dinos por Jogador: ", numeroMaxDinos);
    }

    public void inicializarTipoDado(){
                
        jogoView.escreverMenu();
        tipoDado = jogoView.readInt("Qual o número máximo do seu dado? ", numeroMaxDado);
        //tipoDado = Utilitario.readDouble("Qual o número máximo do seu dado? ");
    }

    public void inicializarQtdMaxPontosPersonagem(){
                
        jogoView.escreverMenu();
        pontosMaxPersonagem = jogoView.readInt("Pontos máximos por dino: ", pontosMaximosPossiveis);
        //pontosMaxPersonagem = Utilitario.readInt("Pontos máximos por dino: ");
    }

    public void exibirTelaTudoPronto(){
        jogoView.escreverMenu();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Tudo pronto, vamos comerçar!!");
        Console.WriteLine("-----------------------------");

        jogador1.listarDinos();
        jogador2.listarDinos();
        Console.ReadKey();
    }

    private void escreverTurno(int numeroTurno){
        Console.BackgroundColor =ConsoleColor.White;
        Console.ForegroundColor =ConsoleColor.Black;
        Console.WriteLine("Turno: " + numeroTurno + " ");
        Console.WriteLine();
        Console.ResetColor();
    }
    // public Jogador criarJogador(int numeroJogador){
    //     return new Jogador(jogoView.getNomeJogador(numeroJogador));
    // }

    public void criarDinosDoJogador(Jogador jogador){
        for(int i=0; i < dinosPorJogador; i++){
            jogoView.escreverMenu();
            int numeroDino = i +1;
            Console.WriteLine("Jogador " + jogador.getNome() + " - Dino " + numeroDino);
            Console.WriteLine("-----------------------------");
            jogador.adicionarDinossauro(criarDinossauro());
        }
    }

    public Dinossauro criarDinossauro(){
        string nome;
        int pontosdeataque;
        int pontosdedefesa;

        //Nome
        Console.Write("Nome do Dino: ");
        nome = Console.ReadLine();

       pontosdeataque = EntrarPontosAtaque();
       pontosdedefesa = pontosMaxPersonagem - pontosdeataque;

       return new Dinossauro(nome, pontosdeataque, pontosdedefesa);
    }

    public int rolarDados(){
        //Random r = new Random();
        //return r.Next(1, tipoDado);
        while(true){
            int valorDadoLido = Utilitario.readInt("Valor do dado: ");
            if ( valorDadoLido <= tipoDado) 
                return valorDadoLido;
        }
    }

    public void iniciarTurno(){

        Dinossauro dinoAtaque;
        Dinossauro dinoDefesa;
        Jogador jogadorAtaque;
        Jogador jogadorDefesa;

        if(turnoAtual == null){
            jogadorAtaque = jogador1;
            jogadorDefesa = jogador2;
        }else if(turnoAtual.getJogadorAtacante() == jogador1.getNome()){
            jogadorAtaque = jogador2;
            jogadorDefesa = jogador1;
        }else{
            jogadorAtaque = jogador1;
            jogadorDefesa = jogador2;
        }
        jogoView.escreverMenu();
        escreverTurno(turnoAtual == null ? 1 : turnoAtual.getNumeroTurno()+1);

        Console.WriteLine(jogadorAtaque.getNome() + ", sua vez!!");
        Console.WriteLine();
        dinoAtaque = jogadorAtaque.selecionarDino("Atacar");
        jogoView.escreverMenu();
        escreverTurno(turnoAtual == null ? 1 : turnoAtual.getNumeroTurno()+1);
        Console.WriteLine(jogadorDefesa.getNome() + ", sua vez!!");
        Console.WriteLine();
        dinoDefesa = jogadorDefesa.selecionarDino("Defender");
        turnoAtual = new Turno((turnoAtual == null ? 1 : turnoAtual.getNumeroTurno()+1), jogadorAtaque.getNome(), jogadorDefesa.getNome(), dinoAtaque, dinoDefesa);
    }


    public void executarJogada(){
        int valorDado;
        double valorDoAtaque;
        int penalidadeAtaque;
        
        //Jogador atacante rola o dado
        valorDado = rolarDados();
        turnoAtual.dadoAtaque = valorDado;

        //O calculo do ataque é executado
        valorDoAtaque = (turnoAtual.getDinoAtacante().getPontosDeAtaque() / tipoDado) * valorDado;
        Console.WriteLine("valor do dado:: " + valorDado + " Parametro ataque: " + turnoAtual.getDinoAtacante().getPontosDeAtaque() + " valor ataque: " + valorDoAtaque);
        Console.ReadKey();

        //O dano é inflingido no dinossauro de defesa e ataque
        turnoAtual.getDinoDefensor().defender((int)valorDoAtaque);
        penalidadeAtaque = turnoAtual.getDinoAtacante().atacar();

        turnoAtual.registrarAtaque();

        //Exibir os dados do Turno
        jogoView.escreverMenu();
        escreverTurno(turnoAtual.getNumeroTurno());
        Console.WriteLine("O jogador " + turnoAtual.getJogadorAtacante() + " atacou o dino " + turnoAtual.getDinoDefensor().getNome() + 
                " com o dino " + turnoAtual.getDinoAtacante().getNome() + " e tirou " + valorDoAtaque + " pontos de vida");
        Console.WriteLine("Agora o dino " + turnoAtual.getDinoDefensor().getNome() + " tem apenas " + turnoAtual.getDinoDefensor().getPontosDeDefesa());

        Console.WriteLine("Penalidade de ataque: " + (penalidadeAtaque ==1 ? "ataque" : "defesa"));

        Console.ReadKey();

    }

    public void finalizarTurno(){
        turnos.Add(turnoAtual);
    }


    public bool alguemGanhou(){
        if(!jogador1.temDinosVivos()){
            vencedor = jogador2;
            return true;
        }
        if(!jogador2.temDinosVivos()){
            vencedor = jogador1;
            return true;
        }
        return false;

    }
    public void finalizarJogo(){
        jogoView.escreverMenu();
        Console.WriteLine("O vencedor é:....... " + vencedor.getNome());
        foreach (Turno turno in turnos)
        {
            escreverTurno(turno.getNumeroTurno());
            Console.WriteLine("Dino Ataque " + turno.getDinoAtacante().getNome() +
            " Pontos Iniciais: " + turno.getDinoAtacantePontosIniciais() + 
            " Pontos finais: " + turno.getDinoAtacantePontosFinais());
            Console.WriteLine("Dino Defesa " + turno.getDinoDefensor().getNome() +
            " Pontos Iniciais: " + turno.getDinoDefensorPontosIniciais() + 
            " Pontos finais: " + turno.getDinoDefensorPontosFinais());
            Console.WriteLine();
        }


    }

     public int EntrarPontosAtaque(){
        ConsoleKeyInfo cki;
        var sb = new System.Text.StringBuilder();
        int valor = 0;

        Console.Write("Pontos de Ataque: ");
        while(true){
            cki = Console.ReadKey(true);
            
            //Se foi digitado um número válido
            if (char.IsDigit(cki.KeyChar))
            {
                sb.Append(cki.KeyChar);
                valor = int.Parse(sb.ToString());
                if (valor < pontosMaxPersonagem){
                    Console.Write(cki.KeyChar);
                    jogoView.escreveLinhaPontos(valor, pontosMaxPersonagem-valor);
                } else
                    sb.Remove(sb.Length-1, 1);
            }
            else if(cki.Key == ConsoleKey.Backspace){
                if(sb.Length > 0){
                    sb.Remove(sb.Length-1, 1);
                    Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                    if(int.TryParse(sb.ToString(), out valor)){
                        jogoView.escreveLinhaPontos(valor, pontosMaxPersonagem-valor);
                    }else{
                        jogoView.escreveLinhaPontos(0, pontosMaxPersonagem-valor);
                    }
                }
            
            }else if(cki.Key == ConsoleKey.Enter){
                if(int.TryParse(sb.ToString(), out valor))
                    return valor;
            }else continue;

        }
    }

}