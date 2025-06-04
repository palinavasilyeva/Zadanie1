// file: Sfera.cs
using System;

namespace FiguryLib
{
    public class Sfera : Figura3D, IMierzalna2D
    {
        public Punkt3D O { get; set; }
        public double R { get; set; }

        public Sfera() : base()
        {
            O = Punkt3D.ZERO;
            R = 0;
        }

        public Sfera(Punkt3D srodek, double promien = 0, string nazwa = "", Kolor kolor = Kolor.Niebieski) 
            : base(nazwa, kolor)
        {
            O = srodek;
            R = promien >= 0 ? promien : throw new ArgumentException("Promień nie może być ujemny.");
        }

        public double Pole => 4 * Math.PI * R * R;

        public override void Przesun(double dx, double dy, double dz)
        {
            O = new Punkt3D(O.X + dx, O.Y + dy, O.Z + dz);
        }

        public override void Przesun(Wektor3D kierunek)
        {
            O = new Punkt3D(O.X + kierunek.X, O.Y + kierunek.Y, O.Z + kierunek.Z);
        }

        public void Skaluj(double wspSkalowania)
        {
            if (wspSkalowania <= 0) throw new ArgumentException("Współczynnik skalowania musi być dodatни.");
            R *= wspSkalowania;
        }

        public override string ToString() => $"Sfera({O}, {R})";

        public virtual string ToString(Format format)
        {
            return format == Format.Prosty
                ? ToString()
                : $"{base.ToString()}, {ToString()}, Pole = {Pole:0.##}";
        }

        public static explicit operator Okrag2D(Sfera sfera)
        {
            return new Okrag2D(new Punkt2D(sfera.O.X, sfera.O.Y), sfera.R, sfera.Nazwa, sfera.Kolor);
        }
    }
}