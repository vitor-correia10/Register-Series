using System;

namespace DIO.Series
{
    class Program
    {
        static RepositorySerie repository = new RepositorySerie();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;

                    case "2":
                        InsertSerie();
                        break;
                    
                    case "3":
                        UpdateSerie();
                        break;

                    case "4":
                        ExcludeSerie();
                        break;

                    case "5":
                        ViewSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(); 
                }
                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you!");
            Console.ReadLine();
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Digit the Serie's ID");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Gender), i));
            }
            Console.WriteLine("Type a Gender in the options above: ");
            int entryGender = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the title: ");
            string entryTitle = Console.ReadLine();

            Console.WriteLine("Type the serie's year ");
            int entryYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the serie's description");
            string entryDescription = Console.ReadLine();

            Serie updateSerie = new Serie(
                id: indiceSerie,
                gender: (Gender)entryGender,
                title: entryTitle,
                year: entryYear,
                description: entryDescription
            );

            repository.Update(indiceSerie, updateSerie);
        }
        private static void ListSeries()
        {
            Console.WriteLine("List Series");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No series registered");
                return;
            }
            foreach(var serie in list)
            {
                var excluded = serie.returnExcluded();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (excluded ? "*Excluded*" : ""));
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Insert a Serie");

            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Gender), i));
            }
            Console.WriteLine("Type a Gender in the options above: ");
            int entryGender = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the title: ");
            string entryTitle = Console.ReadLine();

            Console.WriteLine("Type the serie's year ");
            int entryYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the serie's description");
            string entryDescription = Console.ReadLine();

            Serie newSerie = new Serie(
                id: repository.NextId(),
                gender: (Gender)entryGender,
                title: entryTitle,
                year: entryYear,
                description: entryDescription
            );

            repository.Insert(newSerie);
        }

        private static void ExcludeSerie()
        {
            Console.WriteLine("Type the serie's ID: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repository.Exclude(indiceSerie);
        }

        private static void ViewSerie()
        {
            Console.WriteLine("Type the serie's ID: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series");
            Console.WriteLine("Press an option");
            Console.WriteLine("1- Series List");
            Console.WriteLine("2- Insert New Serie");
            Console.WriteLine("3- Update a Serie");
            Console.WriteLine("4- Exclude a Serie");
            Console.WriteLine("5- View a Serie");
            Console.WriteLine("C- Clean Screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
