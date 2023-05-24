using System.Timers;

namespace Toaster
{
    public class Toaster
    {
        #region CTOR
        public Toaster(string farbe, int slots)
        {
            Farbe = farbe;
            Schaechte = slots;
            Zeit = 15;
            ToastAnzahl = 0;
        } // Konstruktor beinhaltet unveränderbare oder default Einstellungen
        public Toaster() { }
        #endregion
        #region Fields
        private int _toastAnzahl; // Backingfield
        #endregion
        #region Properties
        public int ToastAnzahl
        {
            get { return _toastAnzahl; } 
            set
            {
                if (value > Schaechte) value = Schaechte; // Toastanzahl kann maximal Zahl der Schächte entsprechen
                _toastAnzahl = value;
            }
        }
        public int Schaechte { get; set; }
        public int Zeit { get; set; }
        public string Farbe { get; set; }
        public enum ToastZustand
        {
            nicht = 0,
            leicht = 1,
            stark = 2,
            schwarz = 3
        }
        #endregion
        #region Methods
        public void ToastEinfueheren(int toasts)
        {
            ToastAnzahl = toasts;
            Console.WriteLine($"{toasts} Toasts eingeführt.");
        }
        public void Toasten()
        {
            System.Timers.Timer timer = new(3000); // Startet einen Timer, der alle 3 Sekunden ein Event auslöst
            timer.AutoReset = true; // Timer-Event wird für jeden Tick und nicht nur ein Mal ausgelöst
            timer.Elapsed += OnTimedEvent; // Methode wird dem Event angehängt
            timer.Start(); // Startet den Timer
            Thread.Sleep(Zeit * 1000); // Wartet die (eingestellte) Zeit in Sekunden
            timer.Stop();
            timer.Dispose(); // Beendet und verwirft den Timer
        }
        public void ToastAuswerfen() // Zeigt an, wie viel Toast zu welchem Grad getoastet ist.
        {
            Console.WriteLine($"{ToastAnzahl} Toasts wurden {(ToastZustand)Converter.Convert(Zeit)} getoastet.");
            Console.Read(); // Eigene Converter-Klasse konvertiert vergangene Zeit zu Toast-Zustand
        }
        public void ZeitEinstellen(int zeit)
        {
            Zeit = zeit;
            Console.WriteLine($"Zeit auf {zeit}s geändert.");
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(" Toasting..."); // Event zeichnet den Toast-Vorgang auf
        }
        #endregion
    }
}
