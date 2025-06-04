// file: Kula.cs
using System;

namespace FiguryLib
{
    public class Kula : Sfera, IMierzalna3D
    {
        public Kula() : base() { }

        public Kula(Punkt3D srodek, double promien = 0, string nazwa = "") 
            : base(srodek, promien, nazwa)
        {
            O = srodek;
            R = promien;
        }

        public double Objetosc => (4.0 / 3.0) * Math.PI * R * R * R;

        public override string ToString() => $"Kula({O}, {R})";

        public override string ToString(Format format)
        {
            return format == Format.Prosty
                ? ToString()
                : $"{base.ToString(format)}, Objętość = {Objetosc:0.##}";
        }

        public static explicit operator Okrag2D(Kula kula)
        {
            return new Okrag2D(new Punkt2D(kula.O.X, kula.O.Y), kula.R, kula.Nazwa, kula.Kolor);
        }

        public static explicit operator Kolo2D(Kula kula)
        {
            return new Kolo2D(new Punkt2D(kula.O.X, kula.O.Y), kula.R, kula.Nazwa);
        }
    }

    public static class KulaExtensions
    {
        public static Kula ToKula(this Sfera sfera)
        {
            return new Kula(sfera.O, sfera.R, sfera.Nazwa);
        }

        public static Sfera ToSfera(this Kula kula)
        {
            return new Sfera(kula.O, kula.R, kula.Nazwa, kula.Kolor);
        }
    }
}