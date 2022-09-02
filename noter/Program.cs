using System.Xml.Linq;

string directory = Directory.GetCurrentDirectory() + "/notes";
if (!Directory.Exists(directory))
{
    Directory.CreateDirectory(directory);
}
Directory.SetCurrentDirectory(directory);

while (true)
{
    Console.Clear();
    Console.WriteLine("Noter by seikkailija007\n");
    Console.WriteLine("[0] Poistu");
    Console.WriteLine("[1] Luo uusi muistiinpano");
    Console.WriteLine("[2] Avaa muistiinpano");
    char mode = Console.ReadKey().KeyChar;
    if (mode == '0')
    {
        Console.Clear();
        break;
    }
    else if (mode == '1')
    {
        NewNote();
    }
    else if (mode == '2')
    {
        ShowNotes();
    }
}

void NewNote()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Muistiinpanon nimi: ");
        string name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine(name + " \n\n Muistiinpano:");
        string note = Console.ReadLine();
        Console.WriteLine("\n[1] Tallenna [2] Kirjoita uudelleen [3] Takaisin");
        char ans = Console.ReadKey().KeyChar;
        if (ans == '1')
        {
            using (StreamWriter sw = File.CreateText(name + ".txt"))
            {
                sw.WriteLine(note);
            }
            Console.Clear();
            return;
        }
        else if (ans == '2')
        {
            
        }
        else if (ans == '3')
        {
            return;
        }
    }
}

void ShowNotes()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("[0] Takaisin");
        Console.WriteLine("[1] Avaa muistiinpano");
        Console.WriteLine("[2] Näytä kaikki muistiinpanot");
        char mode = Console.ReadKey().KeyChar;
        if (mode == '0')
        {
            return;
        }
        else if (mode == '1')
        {
            Console.Clear();
            Console.WriteLine("Muistiinpanon nimi: ");
            string name = Console.ReadLine();
            string file = name + ".txt";
            
            if (File.Exists(file))
            {
                while (true)
                {

                    Console.Clear();
                    string[] note = File.ReadAllLines(file);
                    Console.WriteLine("Muistiinpano: " + name + "\n\n");
                    foreach (string line in note)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine("\n[0] Takaisin [1] Poista muistiinpano");
                    mode = Console.ReadKey().KeyChar;
                    if (mode == '0')
                    {
                        break;
                    }
                    else if (mode == '1')
                    {
                        Console.Clear();
                        Console.WriteLine("Haluatko varmasti poistaa muistiinpanon: " + name);
                        Console.WriteLine("[y] kyllä [n] ei");
                        char ans = Console.ReadKey().KeyChar;
                        if (ans == 'y')
                        {
                            File.Delete(file);
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Tätä muistiinpanoa ei ole. [0] Takaisin");
                Console.ReadKey();
            }
        }
        else if (mode == '2')
        {
            Console.Clear();
            while (true)
            {
                string[] fileEntries = Directory.GetFiles(directory);
                int number = 1;

                foreach (string currentFile in fileEntries)
                {
                    string FileName = Path.GetFileNameWithoutExtension(currentFile);
                    Console.WriteLine(number + " " + FileName);
                    number++;
                }
                Console.WriteLine("\n[0] Takaisin [1] Poista muistiinpano");
                mode = Console.ReadKey().KeyChar;
                if (mode == '0')
                {
                    break;
                }
                else if (mode == '1')
                {
                    Console.Clear();
                    number = 1;
                    foreach (string currentFile in fileEntries)
                    {
                        string FileName = Path.GetFileNameWithoutExtension(currentFile);
                        Console.WriteLine(number + " " + FileName);
                        number++;
                    }
                    Console.WriteLine("\nMuistiinpanon nimi: ");
                    string name = Console.ReadLine();
                    string file = name + ".txt";
                    Console.Clear();
                    bool found = false;
                    foreach (string currentFile in fileEntries)
                    {
                        string fileName = Path.GetFileName(currentFile);
                        if (file == fileName)
                        {
                            found = true;
                            break;
                        }
                        else
                        {
                            found = false;
                        }
                    }
                    if (found)
                    {
                        Console.Clear();
                        Console.WriteLine("Haluatko varmasti poistaa muistiinpanon: " + name);
                        Console.WriteLine("[y] kyllä [n] ei");
                        char ans = Console.ReadKey().KeyChar;
                        if (ans == 'y')
                        {
                            File.Delete(file);
                            Console.Clear();
                            Console.WriteLine("Muistiinpano poistettu");
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Muistiinpanoa ei löytynyt");
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();
                }
            }
        }
        else if (mode == '0')
        {
            break;
        }
    }
}
