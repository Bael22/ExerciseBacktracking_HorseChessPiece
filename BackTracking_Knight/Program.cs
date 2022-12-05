using BackTracking_Knight;

int[,] a = new int[8, 8];
bool ff=true;
do { } while (!ff); Console.WriteLine("a"+ff);
int z = 1;
Caballo.KnightSol(a, 0, 0,ref z);
for (int i = 0; i < a.GetLength(0); i++)
{
    for (int f = 0; f < a.GetLength(1); f++)
    {
        if( a[i, f].ToString().Count()==1)
        Console.Write(a[i, f]+" ,");
        else Console.Write(a[i, f] + ",");
        
    }
    Console.WriteLine();
}

int[] b = Caballo.Falta(a);
Console.WriteLine();
for(int i=0;i<b.Length;i++)
{
    Console.Write(b[i]+",");
}
