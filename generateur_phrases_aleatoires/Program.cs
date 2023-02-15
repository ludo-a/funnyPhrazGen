using System.Data.Common;

static string ObtainRandEl(string[] t)
{
    Random rnd = new Random();
    int index = rnd.Next(0, t.Length);
    return t[index];
}

static string GeneratePhrase(string[] s, string[] v, string[] c)
{
    string sujet = ObtainRandEl(s);
    string verbe = ObtainRandEl(v);
    string complement = ObtainRandEl(c);
    string phrase = sujet + " " + verbe + " " + complement;
    phrase = phrase.Replace("à le", "au");
    return phrase;
}

var sujets = new string[]
{
    "Un nain",
    "Un castord",
    "Une poule",
    "Un chevalier",
    "Une vache",
    "Un robot",
    "Un magicien",
    "Un canard",
};

var verbes = new string[]
{
    "mange",
    "écrase",
    "détruit",
    "observe",
    "attrape",
    "regarde",
    "avale",
    "nettoie",
    "se bat avec",
    "s'accroche à",
};

var compléments = new string[]
{
    "une voiture",
    "une fusée",
    "une carpe",
    "la baignoire",
    "la pizza",
    "le sushi",
    "la play",
    "le dauphin",
    "le papier toilette",
    "la pelle à tarte",
    "une éponge",
    "un sac de patate",
};

List<string> list = new List<string>();

static int AskQuestion(string question) 
{
    while (true)
    {
        Console.Write(question);
        string reponse = Console.ReadLine();
        try
        {
            int reponseInt = int.Parse(reponse);
            return reponseInt;
        }
        catch
        {
            Console.WriteLine("ERREUR : Vous devez rentrer un nombre");
        }
    }
}

static int AskNumber(string question, int max)
{
    int min = 1;
    int nombre = AskQuestion(question);
    if ((nombre >= min) && (nombre <= max))
    {
        // valide
        return nombre;
    }
    Console.WriteLine("ERREUR : Le nombre doit être compris entre " + min + " et " + max);

    return AskNumber(question, max);
}

int Nb_Phrases = AskNumber("Combien de phrases Voulez-vous ? : ", int.MaxValue);
int Nb_double = 0;

for(int i =0; i < Nb_Phrases; i++)
{
    string phrase = GeneratePhrase(sujets, verbes, compléments);
    if (!list.Contains(phrase))
    {
        list.Add(phrase);
    }
    else
    {
        Nb_double+= 1;
    }
}

list.ForEach(p =>
{ 
    Console.WriteLine(p); 
});

Console.WriteLine($"\nNombre de phrases demandés : {Nb_Phrases}");
Console.WriteLine($"Nombre de phrases réalisés : {Nb_Phrases-Nb_double}");
Console.WriteLine($"Nombre de doublons évités : {Nb_double}");