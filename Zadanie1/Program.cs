using System;
using System.Collections.Generic;
using FiguryLib;

namespace Figury
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Proste testy konstrukcji i modyfikacji: Okrag2D");
            Okrag2D o1 = new Okrag2D();
            Console.WriteLine(o1);
            o1.Rysuj();
            Console.WriteLine(o1.ToString(Format.Pelny));
            o1.Nazwa = "o1";
            o1.O = new Punkt2D(2, 2);
            o1.R = 2;
            Console.WriteLine(o1.ToString(Format.Pelny));

            Console.WriteLine("\n--- Proste testy: Kolo2D");
            Kolo2D k1 = new Kolo2D(srodek: new Punkt2D(1, 1), promien: 2);
            k1.Rysuj();
            Console.WriteLine(k1.ToString(Format.Pelny));

            Console.WriteLine("--- --- rzutowanie koła na okrąg");
            Okrag2D o2 = (Okrag2D)k1;
            Console.WriteLine(o2.ToString(Format.Pelny));

            Console.WriteLine("--- --- konwersja koła na okrąг");
            Okrag2D o2_1 = k1.ToOkrag2D();
            Console.WriteLine(o2_1.ToString(Format.Pelny));

            Console.WriteLine("--- --- konwersja okręgu na koło");
            Kolo2D k2 = o1.ToKolo2D();
            Console.WriteLine(k2.ToString(Format.Pelny));

            Console.WriteLine("--- --- przesuwanie, skalowanie");
            k2.Przesun(1, 1);
            Console.WriteLine($"Po przesunięciu {k2.Nazwa}: {k2.ToString(Format.Pelny)}");

            k2.Skaluj(2);
            Console.WriteLine($"Po skalowaniu {k2.Nazwa}: {k2.ToString(Format.Pelny)}");

            Console.WriteLine("\n--- Proste testy: Sfera, Kula");
            Sfera s1 = new Sfera(new Punkt3D(1, -1, 0), promien: 2);
            Console.WriteLine(s1.ToString(Format.Pelny));
            Kula ku1 = new Kula();
            Console.WriteLine(ku1.ToString(Format.Pelny));
            ku1.R = 3;
            ku1.Rysuj();

            Kula ku2 = new Kula(srodek: Punkt3D.ZERO, promien: 1);
            Sfera s2 = ku2.ToSfera(); //конверсия kuli na sferę
            s2.R = 2;
            Console.WriteLine(s2.ToString(Format.Pelny));

            var o3 = (Okrag2D)s2; //rzutowanie sfery na okrąг
            Console.WriteLine(o3.ToString(Format.Pelny));

            var o4 = (Okrag2D)ku2; //rzutowanie kuli na okrąг
            Console.WriteLine(o4.ToString(Format.Pelny));

            var k3 = (Kolo2D)ku2; //rzutowanie kuli на koło
            Console.WriteLine(k3.ToString(Format.Pelny));

            // Добавляем вывод для ku3
            var ku3 = s2.ToKula(); //конверсия сферы на кулю
            Console.WriteLine(ku3.ToString(Format.Pelny)); // Проверка параметров ku3

            Console.WriteLine("\n ** Lista Figur **");
            List<Figura> lista = new List<Figura> { o1, k1, o2, o2_1, k2, s1, ku1, ku2, s2, ku3, o3, o4, k3 };
            foreach (var x in lista)
                x.Rysuj();

            Console.WriteLine($"Średnia długość figur = ... ");
            Console.WriteLine($"Sumaryczne pole figur = ... ");
            Console.WriteLine($"Objętość figury największej = ... ");

            // Вычисления средней длины, суммарного поля и максимальной объёмности
            double sumDlugosc = 0;
            int countDlugosc = 0;
            double sumPole = 0;
            double maxObjetosc = 0;

            foreach (var figura in lista)
            {
                if (figura is IMierzalna1D m1d)
                {
                    sumDlugosc += m1d.Dlugosc;
                    countDlugosc++;
                }
                if (figura is IMierzalna2D m2d)
                {
                    sumPole += m2d.Pole;
                }
                if (figura is IMierzalna3D m3d)
                {
                    maxObjetosc = Math.Max(maxObjetosc, m3d.Objetosc);
                }
            }

            double sredniaDlugosc = countDlugosc > 0 ? sumDlugosc / countDlugosc : 0;
            Console.WriteLine($"Średnia długość figur = {sredniaDlugosc:0.##}");
            Console.WriteLine($"Sumaryczne pole figur = {sumPole:0.##}");
            Console.WriteLine($"Objętość figury największej = {maxObjetosc:0.##}");
        }
    }
}