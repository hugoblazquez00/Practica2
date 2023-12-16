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
            Pale pale1 = new Pale(1, 171, 1);
            Pale pale2 = new Pale(4, 49, 2);
            Pale pale3 = new Pale(3, 98, 3);
            Pale pale4 = new Pale(11, 130, 4);
            Pale pale5 = new Pale(9, 96, 5);
            Pale pale6 = new Pale(5, 90, 6);
            int[] limits = { 17, 4, 5, 1, 1, 3 };
            int pesoMAX = 17;
            
            List<Pale> pales = new List<Pale>()
            {
                pale1,pale2,pale3,pale4,pale5,pale6
            };


            int opcion = 0;
            do
            {
                Console.WriteLine("Quiere meter la mayor cantidad de valor en un barco con un peso maximo de : " + pesoMAX);
                Console.WriteLine("Y tiene los siguientes pales:");
                foreach (Pale pale in pales)
                {
                    Console.WriteLine("Pale " + pale.numeroDePale + " ---- Peso : " + pale.peso + " ---- Valor : " + pale.valor);

                }

                Console.WriteLine("Con que paradigma quiere resolver el problema:\n1-Voraz\n2-Dinamica\n3-Vuelta Atras");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Voraz(pesoMAX,pales);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Dinamica(pesoMAX, pales);
                        
                        break;
                    case 3:
                        VueltaAtras();
                        
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

    static int[] Voraz(int pesoMAX,List<Pale> pales )
    {
        int[] sol = {0,0,0,0,0,0};
        int pesoacumulado=0;
        int i=0;
        
        
        while(pesoacumulado<pesoMAX && i<=5){
            if(pales[i].peso+pesoacumulado<pesoMAX){

            }


            //pesoacumulado = pale1.peso*sol[0] + pale2.peso*sol[1] + pale3.peso*sol[2]  + pale4.peso*sol[3]  + pale5.peso*sol[4] + pale6.peso*sol[5];
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
    static void Dinamica(int pesoMAX, List<Pale> pales)
    {
            // ----- Obtencion de las diferentes soluciones + la solucion final -----

            int numeroDePales = pales.Count;
            // Utilizaremos la matriz "solucionesPosibles" para guardar el valor de las soluciones en funcion de la
            // cantidad de pales guardados y el peso que ocupen.
            int[,] solucionesPosibles = new int[numeroDePales + 1, pesoMAX + 1];
            // "palesSelecionados" lo usaremos para guardar los pales selecionados en la solucion final.
            List<Pale> palesSelecionados = new List<Pale>();

            for (int numeroDePalesRevisados = 0; numeroDePalesRevisados <= numeroDePales; numeroDePalesRevisados++)
            {
                for (int pesoActual = 0; pesoActual <= pesoMAX; pesoActual++)
                {
                    // Cuando el bucle acaba de empezar el valor de la solucion posible es 0.
                    if (numeroDePalesRevisados == 0 || pesoActual == 0)
                    {
                        solucionesPosibles[numeroDePalesRevisados, pesoActual] = 0;
                    }
                    // Si el peso del pale es menor o igual que el peso actual, guardara en una nueva solucion el valor maximo entre la solucion anterior, y la suma del valor de la solucion anterior mas el de ese pale, pero restando el peso que consumes al añadir ese pale.
                    else if (pales[numeroDePalesRevisados - 1].peso <= pesoActual)
                    {
                        solucionesPosibles[numeroDePalesRevisados, pesoActual] = Math.Max(pales[numeroDePalesRevisados - 1].valor + solucionesPosibles[numeroDePalesRevisados - 1, pesoActual - pales[numeroDePalesRevisados - 1].peso], solucionesPosibles[numeroDePalesRevisados - 1, pesoActual]);

                    }
                    else
                    {
                        // Si el peso supera el maximo, se quedara con la solucion anterior
                        solucionesPosibles[numeroDePalesRevisados, pesoActual] = solucionesPosibles[numeroDePalesRevisados - 1,pesoActual];
                    }
                }
            }

            // ----- Representacion de la solucion final -----

            // Guardamos el peso maximo y el valor de la solucion final, la cual es la que ya ha revisado todas las combianciones con todos los pales y pesos.
            int valorMaximo = solucionesPosibles[numeroDePales, pesoMAX];
            int capacidadRestante = pesoMAX;

            Console.WriteLine("Valor maximo en el barco = " + valorMaximo);

            Console.WriteLine("Pales seleccionado: ");
            // Para recuperar cuales han sido los pales selecionados, comprobamos las diferentes soluciones viendo cuando son diferente, que significa que en ese momento se añadio un pale, y se añade ese pale a la lista de pales seleccionados.
            
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
                Console.WriteLine("Pale " + pale.numeroDePale + " ---- Peso : " + pale.peso + " ---- Valor : " + pale.valor);
            }
            Console.ReadLine();
            Console.Clear();
        }
    static void VueltaAtras()
    {


            Console.ReadLine();
            Console.Clear();
    }


  }
  
}