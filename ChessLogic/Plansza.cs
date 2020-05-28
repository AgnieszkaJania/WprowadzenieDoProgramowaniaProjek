using Logika;
using System;
using System.Collections.Generic;

namespace ChessLogic
{
    /// <summary>
    /// Strony na planszy
    /// </summary>
    public enum Strona
    {
        Biała,
        Czarna
    }
    /// <summary>
    /// Klasa symulująca planszę do gry w szachy
    /// </summary>
    public class Plansza
    {
        /// <summary>
        /// Lista możliwych stanów gry
        /// </summary>
        public enum Status
        {
            Gra,
            Mat,
            Pat
        }
        /// <summary>
        /// Aktualny stan gry
        /// </summary>
        public Status StanGry { get; private set; }
        /// <summary>
        /// Lista wszystkich bierek na planszy
        /// </summary>
        readonly List<Bierka> bierki;
        /// <summary>
        /// Funkcja wołana w momencie promocjii pionka
        /// </summary>
        readonly Func<Bierki> promocjaPionka;
        /// <summary>
        /// Funkcja wołana w momencie zakończenia gry
        /// </summary>
        readonly Func<Status, object> koniecGry;
        /// <summary>
        /// Konstruktor tworzący planszę do gry
        /// </summary>
        public IReadOnlyList<Bierka> Bierki => bierki.AsReadOnly();
        public Plansza(Func<Bierki> promocjaPionka, Func<Status, object> koniecGry, bool init = true)
        {
            this.promocjaPionka = promocjaPionka;
            this.koniecGry = koniecGry;
            bierki = new List<Bierka>();

            if (init)
                Init();
        }
        /// <summary>
        /// Tworzenie podstawowej planszy
        /// </summary>
        public void Init()
        {

        }
    }
}
