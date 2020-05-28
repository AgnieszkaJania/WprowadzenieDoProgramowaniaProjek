using ChessLogic;

namespace Logika
{
    /// <summary>
    /// Lista wszystkich możliwych bierek
    /// </summary>
    public enum Bierki
    {
        Krol,
        Hetman,
        Goniec,
        Skoczek,
        Wieża,
        Pionek
    }
    /// <summary>
    /// Interface dla każdej bierki
    /// </summary>
    public abstract class Bierka
    {
        /// <summary>
        /// Nazwa bierki
        /// </summary>
        public string Nazwa { get; private set; }
        /// <summary>
        /// Strona po której gra bierka
        /// </summary>
        public Strona Kolor { get; private set; }
        /// <summary>
        /// Plansza na której znajduje się bierka
        /// </summary>
        Plansza plansza;
        /// <summary>
        /// Informacja o tym czy bierka wykonała już jakiś ruch
        /// </summary>
        public bool PierwszyRuch { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Punkt pozycja { get; private set; }
    }
}
