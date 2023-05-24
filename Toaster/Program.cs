namespace Toaster
{
    public class Program
    {
        static Toaster toaster = new Toaster("rot", 2);
        static SuperToaster superToaster = new SuperToaster("gelb", 4); //Toaster werden mit diesen Argumenten erstellt
        public static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Toast-Programm\n\n Optionen:\n Zeiteinstellen (1)\n Toastmenge einlegen (2)\n Starten (3)\n Supertoaster Starten (4)\n Supertoaster zurücksetzen (5)");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Zeit eingeben:");
                        var zeit = Console.ReadLine();
                        toaster.ZeitEinstellen(int.Parse(zeit)); //Stellt die Toastzeit ein.
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Toastmenge eingeben:");
                        var toast = Console.ReadLine();
                        toaster.ToastEinfueheren(int.Parse(toast)); //Stellt die Menge an Toast ein. Nicht größer als Schachtzahl.
                        break;
                    case "3":
                        Console.Clear();
                        toaster.Toasten(); //Führt den Toastvorgang in Echtzeit durch.
                        Console.Clear();
                        toaster.ToastAuswerfen(); //Gibt das Ergebnis des Toastvorgangs aus.
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(" Zeit eingeben:\n");
                        var time = Console.ReadLine();
                        Console.WriteLine(" Toasts einlegen:");
                        var toa = Console.ReadLine();
                        superToaster.ToastAnzahl = int.Parse(toa); //Werte lassen sich alternativ direkt über die Properties setzen
                        superToaster.Zeit = int.Parse(time);
                        Console.Clear();
                        superToaster.Toasten(); //Durch Vererbung kann auch die Methode der Basisklasse verwendet werden
                        Console.Clear();
                        superToaster.ToastAuswerfen();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine($"Temperatur zurücksetzen ({superToaster.Temperatur}):");
                        var temp = Console.ReadLine();
                        superToaster.Temperatur = (int.Parse(temp)); //Setzt die Temperatur auf einen Wert (zurück).
                        break;
                }
                Console.Clear();
                Main(null);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Es ist ein (Eingabe-)Fehler unterlaufen. Neustart...");
                Console.Read();
                Main(null);
            }
        }
    }
}