using System;

namespace Logika
{
    /// <summary>
    /// Przechowuje informacje o punktach w przeszczeni 2D
    /// </summary>
    public class Punkt
    {
        /// <summary>
        /// Pozycja szerokości w przeszczeni
        /// </summary>
        public int X { get; private set; }
        /// <summary>
        /// Pozycja wysokości w przeszczeni
        /// </summary>
        public int Y { get; private set; }
        /// <summary>
        /// Zwraca sumę X+Y
        /// </summary>
        public int XplusY => X + Y;
        /// <summary>
        /// Konstruktor punktu
        /// </summary>
        /// <param name="x">pozycja x</param>
        /// <param name="y">pozycja y</param>
        public Punkt(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Konstruktor punktu
        /// </summary>
        /// <param name="punkt">punkt na podstawie którego tworzy</param>
        public Punkt(Punkt punkt)
        {
            X = punkt.X;
            Y = punkt.Y;
        }
        /// <summary>
        /// Sprawdza czy koordynaty znajdują się pomiędzy min i max
        /// </summary>
        /// <param name="max">max</param>
        /// <param name="min">min</param>
        /// <returns>Zwraca prawda jeżeli koordynaty znajdują się pomiędzy min i max</returns>
        public bool Pomiedzy(int max, int min)
        {
            if (X > max || X < min)
                return false;
            if (Y > max || Y < min)
                return false;
            return true;
        }
        /// <summary>
        /// Sprawdza czy dwa punkty mają takie same koordynaty
        /// </summary>
        /// <param name="obj">Obiekt do sprawdzenia</param>
        /// <returns>Zwraca prawda jeżeli punkty mają takiesame koordynaty</returns>
        public override bool Equals(object obj)
        {
            return obj is Punkt punkt &&
                   X == punkt.X &&
                   Y == punkt.Y;
        }
        /// <summary>
        /// Sprawdza czy dwa punkty mają takie same koordynaty
        /// </summary>
        /// <param name="punkt1">Pierwszy punkt do sprawdzenia</param>
        /// <param name="punkt2">Drugi punkt do sprawdzenia</param>
        /// <returns>Zwraca prawda jeżeli punkty mają takiesame koordynaty</returns>
        public static bool operator ==(Punkt punkt1, Punkt punkt2)
        {
            return (punkt1.Equals(punkt2));
        }
        /// <summary>
        /// Sprawdza czy dwa punkty mają różne koordynaty
        /// </summary>
        /// <param name="punkt1">Pierwszy punkt do sprawdzenia</param>
        /// <param name="punkt2">Drugi punkt do sprawdzenia</param>
        /// <returns>Zwraca prawda jeżeli punkty mają różne koordynaty</returns>
        public static bool operator !=(Punkt punkt1, Punkt punkt2)
        {
            return (!punkt1.Equals(punkt2));
        }
        /// <summary>
        /// Odejmuje koordynaty dwóch punktów
        /// </summary>
        /// <param name="punkt1">odjemna</param>
        /// <param name="punkt2">odjemnik</param>
        /// <returns>Zwraca różnicę koordynatów</returns>
        public static Punkt operator -(Punkt punkt1, Punkt punkt2)
        {
            return new Punkt(punkt1.X - punkt2.X, punkt1.Y - punkt2.Y);
        }
        /// <summary>
        /// Dodaje koordynaty dwóch punktów
        /// </summary>
        /// <param name="punkt1">składnik 1</param>
        /// <param name="punkt2">składnik 2</param>
        /// <returns>Zwraca sumę koordynatów</returns>
        public static Punkt operator +(Punkt punkt1, Punkt punkt2)
        {
            return new Punkt(punkt1.X + punkt2.X, punkt1.Y + punkt2.Y);
        }
        /// <summary>
        /// Zamienia punkt na text
        /// </summary>
        /// <returns>zwraca text</returns>
        public override string ToString()
        {
            return $"{X} {Y}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
