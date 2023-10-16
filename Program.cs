
class Comida
{
    public string Nombre;
    public int Calorias;
    public bool EsPicante;
    public bool EsDulce;

    // Constructor para la clase Comida
    public Comida(string nombre, int calorias, bool esPicante, bool esDulce)
    {
        Nombre = nombre;
        Calorias = calorias;
        EsPicante = esPicante;
        EsDulce = esDulce;
    }
}

class Buffet
{
    public List<Comida> Menu;

    // Constructor para la clase Buffet
    public Buffet()
    {
        Menu = new List<Comida>()
        {
            new Comida("Pizza", 1200, false, false),
            new Comida("Ensalada", 300, false, false),
            new Comida("Pastel de Chocolate", 1500, false, true),
            new Comida("Sushi", 800, false, false),
            new Comida("Alitas Picantes", 1200, true, false),
            new Comida("Helado", 1000, false, true),
            new Comida("Chili", 900, true, false)
        };
    }

    public Comida Servir()
    {
        Random rand = new Random();
        int indice = rand.Next(Menu.Count);
        return Menu[indice];
    }
}

class Ninja
{
    private int consumoCalorico;
    public List<Comida> HistorialComidas;

    // Constructor para la clase Ninja
    public Ninja()
    {
        consumoCalorico = 0;
        HistorialComidas = new List<Comida>();
    }

    // Propiedad "getter" para verificar si el Ninja está lleno
    public bool EstaLleno
    {
        get { return consumoCalorico > 1200; }
    }

    // Método para comer un objeto de tipo Comida
    public void Comer(Comida elemento)
    {
        if (!EstaLleno)
        {
            consumoCalorico += elemento.Calorias;
            HistorialComidas.Add(elemento);
            Console.WriteLine($"El Ninja comió {elemento.Nombre}. Es {(elemento.EsPicante ? "picante" : "no picante")}, {(elemento.EsDulce ? "dulce" : "no dulce")}.");
        }
        else
        {
            Console.WriteLine("¡El Ninja está demasiado lleno para comer!");
        }
    }
}

class Programa
{
    static void Main()
    {
        Buffet buffet = new Buffet();
        Ninja ninja = new Ninja();

        while (!ninja.EstaLleno)
        {
            Comida porcion = buffet.Servir();
            ninja.Comer(porcion);
        }
    }
}
