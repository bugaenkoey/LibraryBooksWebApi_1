using static Program;

namespace LibraryBooksWebApi_1
{
    public static class RandomData
    {
        public static int RandomScore()
        {
            Random rnd2 = new Random();
            return rnd2.Next(1, 5);

        }
        public static string RndStrInChar(int count)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string str = new string(Enumerable.Repeat(chars, count)
                 .Select(s => s[random.Next(s.Length)]).ToArray());
            return str;
        }
        public static string RandomString(string[] strings)
        {
            Random rnd = new Random();
            int r = rnd.Next(0, strings.Length);
            return strings[r];
        }

        public static CustomGenre RandomGenre()
        {
            Array values = Enum.GetValues(typeof(CustomGenre));
            Random random = new Random();
            return (CustomGenre)values.GetValue(random.Next(values.Length));

        }

        public enum CustomGenre
        {
            Fiction,
            ScienceFiction,
            HistoricalFiction,
            NonFiction,
            Mystery,
            LiteraryFiction,
            Horror,
            ScienceFantasy,
            GraphicNovel,
            GenreFiction,
            ChildrensLiterature,
            Humor,
            Satire,
        }


        public static string[] topAuthorsUkr = new string[]
        {
            "Андрій Кокотюха",
            "Андрій Курков",
            "Богдан Зіновій Хмельницький",
            "Василь Стефаник",
            "Григорій Квітка-Основ'яненко",
            "Григорій Тютюнник",
            "Іван Багряний",
            "Іван Білик",
            "Іван Франко",
            "Леся Українка",
            "Марія Матіос",
            "Михайло Коцюбинський",
            "Оксана Забужко",
            "Павло Тичина",
            "Сергій Жадан",
            "Софія Андрухович",
            "Тарас Шевченко",
            "Юрій Андрухович",
            "Юрій Іздрик",
            "Юрій Винничук"
        };




        public enum TopAutor
        {
            Unknown,
            Andriy_Kokotyukha,
            Andriy_Kurkov,
            Bohdan_Zinoviy_Khmelnitsky,
            Vasyl_Stefanyk,
            Hryhoriy_Kvitka_Osnovyanenko,
            Hryhoriy_Tyutyunnyk,
            Ivan_Bahrianyi,
            Ivan_Bilyk,
            Ivan_Franko,
            Lesya_Ukrayinka,
            Maria_Matios,
            Mykhailo_Kotsiubynsky,
            Oksana_Zabuzhko,
            Pavlo_Tychyna,
            Serhiy_Zhadan,
            Sofiya_Andrukhovych,
            Taras_Shevchenko,
            Yuri_Andrukhovych,
            Yuri_Izdryk,
            Yuri_Vynnychuk
        }

        public static string[] topAuthors = new string[]
        {
            "Andriy Kokotyukha",
            "Andriy Kurkov",
            "Bohdan Zinoviy Khmelnitsky",
            "Vasyl Stefanyk",
            "Hryhoriy Kvitka-Osnovyanenko",
            "Hryhoriy Tyutyunnyk",
            "Ivan Bahrianyi",
            "Ivan Bilyk",
            "Ivan Franko",
            "Lesya Ukrayinka",
            "Maria Matios",
            "Mykhailo Kotsiubynsky",
            "Oksana Zabuzhko",
            "Pavlo Tychyna",
            "Serhiy Zhadan",
            "Sofiya Andrukhovych",
            "Taras Shevchenko",
            "Yuri Andrukhovych",
            "Yuri Izdryk",
            "Yuri Vynnychuk"
        };

    }
}
