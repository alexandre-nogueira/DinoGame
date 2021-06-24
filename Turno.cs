public class Turno{

    private int numeroDoTurno;
    private string jogadorAtacante;
    private string jogadorDefensor;

    public Dinossauro dinoAtacante;
    public Dinossauro dinoDefensor;

    private int dinoAtaquePontosIniciais;
    private int dinoAtaquePontosFinais;
    private int dinoDefensorPontosIniciais;
    private int dinoDefensorPontosFinais;


    public int dadoAtaque;
    public int dano;

    public int getNumeroTurno(){
        return numeroDoTurno;
    }

    public string getJogadorAtacante() {
        return jogadorAtacante;
    }

    public string getJogadorDefensor(){
        return jogadorDefensor;
    }

    public Dinossauro getDinoAtacante(){
        return dinoAtacante;
    }

    public Dinossauro getDinoDefensor(){
        return dinoDefensor;
    }

    public int getDinoAtacantePontosIniciais(){
        return dinoAtaquePontosIniciais;
    }

    public int getDinoAtacantePontosFinais(){
        return dinoAtaquePontosFinais;
    }

    public int getDinoDefensorPontosIniciais(){
        return dinoDefensorPontosIniciais;
    }

    public int getDinoDefensorPontosFinais(){
        return dinoDefensorPontosFinais;
    }
    public Turno(int pNumero, string pJogadorAtacante, string pJogadorDefensor, Dinossauro pDinoAtacante, Dinossauro pDinoDefensor){                     
        numeroDoTurno = pNumero;
        jogadorAtacante = pJogadorAtacante;
        jogadorDefensor = pJogadorDefensor;
        dinoAtacante = pDinoAtacante;
        dinoDefensor = pDinoDefensor;

         dinoAtaquePontosIniciais = pDinoAtacante.getPontosDeAtaque();
         dinoDefensorPontosIniciais = pDinoDefensor.getPontosDeDefesa();
    }

    public int getParametroAtaque(){
        return dinoAtacante.getPontosDeAtaque();
    }

    public void registrarAtaque(){

        dinoAtaquePontosFinais = dinoAtacante.getPontosDeAtaque();
        dinoDefensorPontosFinais = dinoDefensor.getPontosDeDefesa();
    }


}