using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;



namespace MiApp 
{
  class Program 
  {
    static void Main(string[] args)
    {
            int valortotal,pesototal=0;
            Pale pale1 = new Pale(1, 171);
            Pale pale2 = new Pale(4, 49);
            Pale pale3 = new Pale(3, 98);
            Pale pale4 = new Pale(11, 130);
            Pale pale5 = new Pale(9, 96);
            Pale pale6 = new Pale(5, 90);
            int[] limits = { 17, 4, 5, 1, 1, 3 };
            int pesoMAX = 17;
            
            List<Pale> pales = new List<Pale>()
            {
                pale1,pale2,pale3,pale4,pale5,pale6
            };
            
            Console.WriteLine("Quiere meter la mayor cantidad de valor en un barco con un peso maximo de : " + pesoMAX);
            Console.WriteLine("Y tiene los siguientes pales:");
            int i = 1;
            foreach( Pale pale in pales)
            {
                Console.WriteLine("Pale " + i + " ---- Peso : " + pale.peso + " ---- Valor : " + pale.valor);
                i++;
            }

            int opcion = 0;
            do
            {
                Console.WriteLine("Con que paradigma quiere resolver el problema:\n1-Voraz\n2-Dinamica\n3-Vuelta Atras");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Voraz(pales);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Dinamica(pesoMAX, pales);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        VueltaAtras();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (opcion != 4);

            

            //int[] sol = Voraz(pales);
           
            //    pesototal = pale1.peso*sol[0] + pale2.peso*sol[1] + pale3.peso*sol[2]  + pale4.peso*sol[3]  + pale5.peso*sol[4] + pale6.peso*sol[5];
            //valortotal = pale1.valor*sol[0] + pale2.valor*sol[1] + pale3.valor*sol[2] + pale4.valor*sol[3] + pale5.valor*sol[4]+ pale6.valor*sol[5];
        
            //Console.WriteLine("El peso total es "+ pesototal);
            //Console.WriteLine("El Valor total es "+ valortotal);
            //Console.WriteLine("Las cantidades son Pale1: "+ sol[0]+" Pale2: "+sol[1]+" Pale3: "+sol[2]+" Pale4 "+sol[3]+" Pale5 "+sol[4]+" Pale6 "+sol[5]);

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

        //for (Pale pale : pales) {
        //    while (pale.peso <= pesoMAX) {
        //        capacidadMochila -= elemento.peso;
        //        valorTotal += elemento.valor;
        //        cantidades[elementos.indexOf(elemento)]++;
        //    }
        //}


        return sol;
    }
    static void Dinamica(int capacidadMax, List<Pale> pales)
    {
            int numeroDePales = pales.Count;
            int[,] solucionesPosibles = new int[numeroDePales + 1, capacidadMax + 1];
            List<Pale> palesSelecionados = new List<Pale>();

            for (int numeroDePalesGuardados = 0; numeroDePalesGuardados <= numeroDePales; numeroDePalesGuardados++)
            {
                for (int w = 0; w <= capacidadMax; w++)
                {
                    if (numeroDePalesGuardados == 0 || w == 0)
                    {
                        solucionesPosibles[numeroDePalesGuardados, w] = 0;
                    }
                    else if (pales[numeroDePalesGuardados - 1].peso <= w)
                    {
                        solucionesPosibles[numeroDePalesGuardados, w] = Math.Max(pales[numeroDePalesGuardados - 1].valor + solucionesPosibles[numeroDePalesGuardados - 1, w - pales[numeroDePalesGuardados - 1].peso], solucionesPosibles[numeroDePalesGuardados - 1, w]);
                    }
                    else
                    {
                        solucionesPosibles[numeroDePalesGuardados, w] = solucionesPosibles[numeroDePalesGuardados - 1, w];
                    }
                }
            }

            int valorMaximo = solucionesPosibles[numeroDePales, capacidadMax];
            int capacidadRestante = capacidadMax;

            Console.WriteLine("Valor maximo en el barco = " + valorMaximo);

            Console.Write("Pales seleccionado: ");
            for (int i = numeroDePales; i > 0 && valorMaximo > 0; i--)
            {
                if (solucionesPosibles[i, capacidadRestante] != solucionesPosibles[i - 1, capacidadRestante])
                {
                    palesSelecionados.Add(pales[i - 1]);
                    valorMaximo = valorMaximo - pales[i - 1].valor;
                    capacidadRestante = capacidadRestante - pales[i - 1].peso;
                }
            }

            palesSelecionados.Reverse(); // Reversar la lista para que los elementos estén en orden original

            foreach (Pale pale in palesSelecionados)
            {
                Console.WriteLine("Peso: " + pale.peso + " Valor: "+ pale.valor);
            }

            Console.WriteLine();
        }
    static void VueltaAtras()
    {
        
        
    }


  }
  
}