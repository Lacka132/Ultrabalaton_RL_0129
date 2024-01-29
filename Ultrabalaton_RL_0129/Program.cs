string[] input = File.ReadAllLines("ub2017egyeni.txt");
Verseny[] data = new Verseny[input.Length];
for (int i = 1; i < input.Length; i++)
{
    data[i] = new Verseny(input[i]);
}
Console.WriteLine($"{input.Length} egyéni sportoló indult a versenyen.");

int teljesnoi = 0;
for (int i = 0; i < input.Length; i++)
{
    if (data[i].identitas == "Noi")
    {
        if (data[i].tavszazalek == 100)
        {
            teljesnoi++;
        }

    }
}
Console.WriteLine($"{teljesnoi} női versenyző teljesítette az egész távot.");

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

}