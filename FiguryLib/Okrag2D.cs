// file: Okrag2D.cs
using System;

namespace FiguryLib
{
    public class Okrag2D : Figura2D, IMierzalna1D
    {
        public Punkt2D O { get; set; }
        public double R { get; set; }

        public Okrag2D() : base()
        {
            O = Punkt2D.ZERO;
            R = 0;
        }

        public Okrag2D(Punkt2D srodek, double promien = 0, string nazwa = "", Kolor kolor = Kolor.Czerwony) 
            : base(nazwa, kolor)
        {
            O = srodek;
            R = promien >= 0 ? promien : throw new ArgumentException("Promień nie może być ujemny.");
        }

        public double Dlugosc => 2 * Math.PI * R;

        public override void Przesun(double dx, double dy)
        {
            O = new Punkt2D(O.X + dx, O.Y + dy);
        }

        public override void Przesun(Wektor2D kierunek)
        {
            O = new Punkt2D(O.X + kierunek.X, O.Y + kierunek.Y);
        }

        public void Skaluj(double wspSkalowania)
        {
            if (wspSkalowania <= 0) throw new ArgumentException("Współczynnik skalowania musi być dodatni.");
            R *= wspSkalowania;
        }

        public override string ToString() => $"Okrag2D({O}, {R})";

        public virtual string ToString(Format format)
        {
            return format == Format.Prosty
                ? ToString()
                : $"{base.ToString()}, {ToString()}, Długość = {Dlugosc:0.##}";
        }
    }

    public static class Okrag2DExtensions
    {
        public static Kolo2D ToKolo2D(this Okrag2D okrag)
        {
            return new Kolo2D(okrag.O, okrag.R, okrag.Nazwa);
        }

        public static Okrag2D ToOkrag2D(this Kolo2D kolo)
        {
            return new Okrag2D(kolo.O, kolo.R, kolo.Nazwa, kolo.Kolor);
        }
    }
}