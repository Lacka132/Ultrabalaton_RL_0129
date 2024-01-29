string[] input = File.ReadAllLines("ub2017egyeni.txt");
Verseny[] data = new Verseny[input.Length];
static Verseny Gyoztes(Verseny[] versenyek, string kategoria)
{
    Verseny gyoztes = versenyek[1];

    for (int i = 1; i < versenyek.Length; i++)
    {
        if (versenyek[i].identitas == kategoria && versenyek[i].tavszazalek == 100)
        {
            int gyoztesIdo = gyoztes.IdoOraInSeconds();
            int jelenlegiIdo = versenyek[i].IdoOraInSeconds();

            if (jelenlegiIdo < gyoztesIdo)
            {
                gyoztes = versenyek[i];
            }
        }
    }

    return gyoztes;
}
for (int i = 1; i < input.Length; i++)
{
    data[i] = new Verseny(input[i]);
}
Console.WriteLine($"{input.Length} egyéni sportoló indult a versenyen.");

int noi = 0;
int ferfims = 0;
int ferfi = 0;

for (int i = 1; i < input.Length; i++) 
{
    if (data[i].identitas == "Noi")
    {
        if (data[i].tavszazalek == 100)
        {
            noi++;
        }
    }
    else 
    {
        if (data[i].tavszazalek == 100)
        {
            ferfims += data[i].IdoOraInSeconds();
            ferfi++;
        }
    }
}

Console.WriteLine($"Ennyi női versenyző teljesítette az egész távot: {noi}");

if (ferfi > 0)
{
    double averageMaleTimeInHours = ferfims / 3600.0 / ferfi;
    Console.WriteLine($"Az átlagos teljesítési idő férfi versenyzők esetében: {averageMaleTimeInHours:F2} óra");
}
else
{
    Console.WriteLine("Nincs elérhető adat a férfi versenyzők átlagos teljesítési idejéről.");
}


Verseny noiGyoztes = Gyoztes(data, "Noi");


Verseny ferfiGyoztes = Gyoztes(data, "Ferfi");


Console.WriteLine($"Női kategória győztese:\nNév: {noiGyoztes.nev}\nRajtszám: {noiGyoztes.szam}\nIdőeredmény: {noiGyoztes.ido}");


Console.WriteLine($"Férfi kategória győztese:\nNév: {ferfiGyoztes.nev}\nRajtszám: {ferfiGyoztes.szam}\nIdőeredmény: {ferfiGyoztes.ido}");


struct Verseny
{
    public string nev;
    public int szam;
    public string identitas;
    public string ido;
    public int tavszazalek;

    public Verseny(string line)
    {
        string[] splitted = line.Split(';');
        string[] time = line.Split(':');
        nev = splitted[0];
        szam = int.Parse(splitted[1]);
        identitas = splitted[2];
        ido = splitted[3];
        tavszazalek = int.Parse(splitted[4]);
        splitted[3] = time[0];


    }

    public int IdoOraInSeconds()
    {
        string[] timeParts = ido.Split(':');
        int ora = int.Parse(timeParts[0]);
        int perc = int.Parse(timeParts[1]);
        int ms = int.Parse(timeParts[2]);

        return ora * 3600 + perc * 60 + ms;
    }

}