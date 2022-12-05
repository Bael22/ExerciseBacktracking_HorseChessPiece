using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking_Knight
{
    internal class Caballo
    {
        public static bool Comprobador(int[,] a)
        {
            for(int i=0; i<a.GetLength(0); i++)
            {
                for (int f = 0; f < a.GetLength(1); f++)
                {
                    if (a[i, f] == 0) return false;
                }
            }
            return true;
        }
        public static bool Restriccion(int[,]a,int f,int c, ref int cont)
        {
            if (f >= a.GetLength(0) || f < 0 || c >= a.GetLength(1) || c < 0)
                return false;
            if(a[f,c] != 0) return false;
            ++cont;
            a[f, c] = cont;
            
            return true;
        }
        public static bool KnightSol(int[,] a,int fila,int col,ref int cont)
        {
            if (Comprobador(a))
                return true;
            else
            { bool flag = false;//
               // do {//
                    if (fila == 0 && col == 0&&cont==1)
                    {
                        Random r = new Random();
                    fila = r.Next(0, a.GetLength(0));
                    col = r.Next(0, a.GetLength(1));
                    //fila = 7; col = 0;
                        a[fila, col] = cont;
                    }
                    if (Restriccion(a, fila - 2, col - 1,ref cont) && KnightSol(a, fila - 2, col - 1, ref cont))//arriba izq+
                        return true;//flag=true;
                else if (Restriccion(a, fila - 1, col - 2, ref cont) && KnightSol(a, fila - 1, col - 2, ref cont))//arriba izq-
                    return true;//flag=true;
                else if (Restriccion(a, fila - 2, col + 1, ref cont) && KnightSol(a, fila - 2, col + 1, ref cont))//arriba der+
                    return true;//flag=true;
                else if (Restriccion(a, fila - 1, col + 2, ref cont) && KnightSol(a, fila - 1, col + 2, ref cont))//arriba der-
                    return true;//flag=true;
                else if (Restriccion(a, fila + 2, col + 1, ref cont) && KnightSol(a, fila + 2, col + 1, ref cont))//abajo der+
                    return true;//flag=true;
                else if (Restriccion(a, fila + 1, col + 2, ref cont) && KnightSol(a, fila + 1, col + 2, ref cont))//abajo der-
                    return true;//flag=true;
                else if (Restriccion(a, fila + 2, col - 1, ref cont) && KnightSol(a, fila + 2, col - 1, ref cont))//abajo izq+
                    return true;//flag=true;
                else if (Restriccion(a, fila + 1, col - 2, ref cont) && KnightSol(a, fila + 1, col - 2, ref cont))//abajo izq-
                    return true;//flag=true;

                else
                    {
                    --cont;
                        a[fila, col] = 0;
                         //if(!(fila == 0 && col == 0)) return flag;
                         return false;
                    }
               // } while (flag==false);//
                //return flag;
            }
            
        }
        public static int[] Falta(int[,] a)
        {
            int[] arr=new int[64];
            int cont = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int f = 0; f < a.GetLength(1); f++)
                {
                    arr[cont]=a[i, f];cont++;
                }
            }

            return ordenar(arr); ;
        }
        public static int[] ordenar(int[] a)
        {
            for(int i = 0; i < a.Length-1; i++)
            {
                for (int f = 0; f < a.Length-1; f++)
                {
                    if (a[f] > a[f+1])
                    {
                        int aux = a[f];
                        a[f] = a[f + 1];
                        a[f+1]=aux;
                    }
                }
            }
            return a;
        }

    }
}
