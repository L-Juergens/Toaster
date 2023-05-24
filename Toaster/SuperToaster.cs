using System.Timers;

namespace Toaster
{
    public class SuperToaster : Toaster
    {
        public SuperToaster(string farbe, int slots)
        {
            Farbe = farbe;
            Schaechte = slots;
            Zeit = 15;
            ToastAnzahl = 0;
        }
        public int Temperatur { get; set; }

        readonly object _locker = new object(); // Objekt, auf das der Monitor schaut/synchronisiert
        bool _ok; // Zustand des Vorgangs
        public new void Toasten()
        {
            System.Timers.Timer timer = new(3000);
            timer.AutoReset = true;
            timer.Elapsed += OnTimedEvent;
            timer.Start(); // Gleicher Timer wie im Basis-Toaster
            lock (_locker) // Keyword zur Synchronisierung von Prozessen:
            {
                _ok = true; // Zustand wird auf true gesetzt
                Monitor.Wait(_locker, Convert.ToInt32(Zeit) * 1000); // Solange nichts passiert, wird wieder die Toast-Zeit abgewartet
                if (!_ok) // Wenn Zustand aber nicht true ist, wird der Vorgang abgebrochen
                {
                    timer.Stop();
                    Console.WriteLine("Toastvorgang abgebrochen. Temperatur zu hoch!");
                    Console.Read();
                    Console.Clear();
                    Program.Main(null);
                }
                timer.Stop();
            }
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Temperatur += 100; // Event steigert jetzt zusätzlich die Temperatur, um Überhitzen zu simulieren
            Console.WriteLine($" Toasting... Temp: {Temperatur}°C");
            TemperaturMessen(Temperatur); // Es wird gemessen, ob Temperatur im akzeptablen Bereich liegt
        }
        public void TemperaturMessen(int temperatur)
        {
            if (temperatur >= 500) // Wenn die Temperatur zu hoch ist...
            {
                lock (_locker) // ...wird per lock das Objekt angesprochen, auf das beide Methoden schauen
                {
                    _ok = false; // Zustand wird auf false gesetzt
                    Monitor.Pulse(_locker); // und mit Pulse werden die Methoden, die auf den _locker schauen, refresht
                }
            }
        }
    }
}
