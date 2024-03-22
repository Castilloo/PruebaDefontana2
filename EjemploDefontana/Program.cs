//Respuestas
//1-1.
var list = new List<int>();
var random = new Random();

for (int i = 0; i < 10000000; i++)
{
    int value = random.Next(-100000, 100001);
    list.Add(value);
}

// foreach (var num in list)
// {
//     Console.WriteLine(num);
// }

//1-2.
var cantidadElementos = list.Count;
Console.WriteLine($"{cantidadElementos}");

var valorMax = list.Max();
Console.WriteLine($"{valorMax}");

var valorMin = list.Min();
Console.WriteLine($"{valorMin}");

var average = list.Average();
Console.WriteLine($"{average}");


//1-3.
var valoresCero = list.Where(n => n == 0).Count();
Console.WriteLine($"{valoresCero}");

//1-4. 
var rankingValores =
    list.GroupBy(n => n)
        .ToDictionary(n => n.Key, n => n.Count())
        .OrderByDescending(n => n.Value)
        .Take(5);

Console.WriteLine($"{string.Join(", ", rankingValores)}");



//1-5.
var array = new List<int>();
for (int i = 0; i < list.Count; i++)
{
    List<int> arrMayores = array.Where(n => n >= list[i]).ToList();
    if (arrMayores.Count == 0 || i == 0)
    {
        array.Add(list[i]);
    }
    else
    {
        int valor = arrMayores.First();
        int index = array.IndexOf(valor);
        array.Insert(index, list[i]);
    }
}

foreach (var val in array)
    Console.WriteLine(val);

// //1.6
var valoresParesModificados = list.Select(n => n % 2 != 0 ? n + 1 : n);
Console.WriteLine($"{valoresParesModificados}");


// //2-1.
var characters = "abcdefghijklmnopqrstuvwxyz";
var charsarr = new char[4];
List<string> words = new List<string>();

for (double j = 0; j < 10000000; j++)
{
    for (int i = 0; i < charsarr.Length; i++)
    {
        charsarr[i] = characters[random.Next(characters.Length)];
    }

    var resultString = new String(charsarr);
    words.Add(resultString);
}

foreach (var w in words)
{
    Console.WriteLine(w);
}

// //2-2
int numHolas = words.Count(n => n.Equals("hola"));

Console.WriteLine(numHolas);

// //3-1
int simulaciones = 1000000;
Random rnd = new Random();
int contador = 0;
const int totalPersonas = 23;

for (int i = 0; i < simulaciones; i++)
{
    var fechas = new List<int>();

    for (int j = 0; j < totalPersonas; j++)
    {
        int fechaRandom = rnd.Next(1, 366);
        fechas.Add(fechaRandom);
    }

    var fechasSinDuplicado = fechas.Distinct().ToList();

    if (fechasSinDuplicado.Count < totalPersonas) contador++;
}

double probabilidadPromedio = (double)contador / simulaciones;

Console.WriteLine($"Probabildad para 1 millón de escenarios: {probabilidadPromedio:P}");