using System;
using System.Collections.Generic; 
public static class ScreenUtility{

    public static int readInt(string label){
        int valor = 0;

            while(true){
                Console.Write(label);
                if(int.TryParse(Console.ReadLine(), out valor)){
                    break;
                }else{Console.WriteLine("Valor Inválido");}
            }
        return valor;
    }

    public static double readDouble(string label){
        double valor = 0;

            while(true){
                Console.Write(label);
                if(double.TryParse(Console.ReadLine(), out valor)){
                    break;
                }else{Console.WriteLine("Valor Inválido");}
            }
        return valor;
    }
}