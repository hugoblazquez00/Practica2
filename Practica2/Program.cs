using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;



namespace MiApp 
{
  class Program 
  {
    public static Pale pale1 = new Pale(1,171);
    public static Pale pale2 = new Pale(4,49);
    public static Pale pale3 = new Pale(3,98);
    public static Pale pale4 = new Pale(11,130);
    public static Pale pale5 = new Pale(9,96);
    public static Pale pale6 = new Pale(5,90);
    public static int[] limits = {17,4,5,1,1,3};
    public static int pesoMAX = 17;

    static void Main(string[] args)
    {
        int valortotal,pesototal=0;
        
        List<Pale> pales = new List<Pale>();
        pales.Add(pale1);
        pales.Add(pale2);
        pales.Add(pale3);
        pales.Add(pale4);
        pales.Add(pale5);
        pales.Add(pale6);

        int[] sol = Voraz(pales);
        pesototal = pale1.peso*sol[0] + pale2.peso*sol[1] + pale3.peso*sol[2]  + pale4.peso*sol[3]  + pale5.peso*sol[4] + pale6.peso*sol[5];
        valortotal = pale1.valor*sol[0] + pale2.valor*sol[1] + pale3.valor*sol[2] + pale4.valor*sol[3] + pale5.valor*sol[4]+ pale6.valor*sol[5];
        
        Console.WriteLine("El peso total es "+ pesototal);
        Console.WriteLine("El Valor total es "+ valortotal);
        Console.WriteLine("Las cantidades son Pale1: "+ sol[0]+" Pale2: "+sol[1]+" Pale3: "+sol[2]+" Pale4 "+sol[3]+" Pale5 "+sol[4]+" Pale6 "+sol[5]);
    }

    static int[] Voraz(List<Pale> pales)
    {
        int[] sol = {0,0,0,0,0,0};
        int pesoacumulado=0;
        int i=0;
        
        
        while(pesoacumulado<pesoMAX && i<=5){
            if(pales[i].peso+pesoacumulado<pesoMAX){

            }


            pesoacumulado = pale1.peso*sol[0] + pale2.peso*sol[1] + pale3.peso*sol[2]  + pale4.peso*sol[3]  + pale5.peso*sol[4] + pale6.peso*sol[5];
        }

        for (Pale pale : pales) {
            while (pale.peso <= pesoMAX) {
                capacidadMochila -= elemento.peso;
                valorTotal += elemento.valor;
                cantidades[elementos.indexOf(elemento)]++;
            }
        }


        return sol;
    }
    static void Dinamica()
    {
        
    }
    static void VueltaAtras()
    {
        
        
    }


  }

  
  






























  
}