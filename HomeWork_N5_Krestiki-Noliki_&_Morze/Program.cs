using System;

//Задание 1.
//Создайте приложение «Крестики-Нолики». Пользователь играет с компьютером.
//При старте игры случайным образом выбирается, кто ходит первым.
//Игроки ходят по очереди. Игра может закончиться победой одного из игроков или ничьей.
//Используйте механизмы пространств имён.

//Задание 2.
//Добавьте к первому заданию возможность игры с другим пользователем.

//Задание 3.
//Создайте приложение для перевода обычного текста в азбуку Морзе.
//Пользователь вводит текст. Приложение отображает введенный текст азбукой Морзе.
//Используйте механизмы пространств имён.

//Задание 4.
//Добавьте к предыдущему заданию механизм перевода текста из азбуки Морзе в обычный текст.

namespace HomeWork_N5
{
    internal class Player
    {
        private string _name;
        private char _symbol;
        private bool _human;
        private string _title;
        public Player()
        {
            _name = "player";
            _symbol = '\0';
            _human = true;
            _title = null;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public char Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        public bool Human
        {
            get { return _human; }
            set { _human = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
    internal class Field
    {
        private int _size;
        private char _empty;
        private char _cross;
        private char _zero;
        private char[,] _field;
        private int _row;
        private int _col;
        public Field()
        {
            _size = 3;
            _empty = '-';
            _cross = 'X';
            _zero = 'O';
            _field = new char[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _field[i, j] = _empty;
                }
            }
        }
        public char Cross
        {
            get { return _cross; }
        }
        public char Zero
        {
            get { return _zero; }
        }
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }
        public int Col
        {
            get { return _col; }
            set { _col = value; }
        }
        public int Size
        {
            get { return _size; }
        }
        public bool isWin(Player player)
        {
            int count = 0;
            //Проверка строк
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_field[i, j] == player.Symbol)
                    {
                        count++;
                    }
                }
                if (count == _size)
                {
                    return true;
                }
                count = 0;
            }
            count = 0;
            //Проверка столбцов
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_field[j, i] == player.Symbol)
                    {
                        count++;
                    }
                }
                if (count == _size)
                {
                    return true;
                }
                count = 0;
            }
            count = 0;
            //Проверка диагонали слева направо
            for (int i = 0; i < _size; i++)
            {
                if (_field[i, i] == player.Symbol)
                {
                    count++;
                }
            }
            if (count == _size)
            {
                return true;
            }
            count = 0;
            //Проверка диагонали справа налево
            for (int i = 0; i < _size; i++)
            {
                if (_field[i, _size - i - 1] == player.Symbol)
                {
                    count++;
                }
                if (count == _size)
                {
                    return true;
                }
            }
            if (count == _size)
            {
                return true;
            }
            return false;
        }
        public bool isFill()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_field[i, j] == _empty) return false;
                }
            }
            return true;
        }
        public void showField()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(_field[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        public bool isEmpty(int row, int col)
        {
            return (_field[row, col] == _empty);
        }
        public void fillCell(int row, int col, Player player)
        {
            _field[row, col] = player.Symbol;
        }
        public void motion(Player player)
        {
            Random rnd = new Random();
            Console.WriteLine("Ходят " + player.Title);
            if (player.Human)
            {
                Console.WriteLine("Введите номер строки и номер столбца или номер ячейки (соответственно цифровой клавиатуре):");
                Console.WriteLine("Input number of row and number of column or number of cell (accordingly, the numeric keypad):");
                string input = Console.ReadLine();
                if (input.Length == 1)
                {
                    switch (input)
                    {
                        case "1":
                            _row = 2;
                            _col = 0;
                            break;
                        case "2":
                            _row = 2;
                            _col = 1;
                            break;
                        case "3":
                            _row = 2;
                            _col = 2;
                            break;
                        case "4":
                            _row = 1;
                            _col = 0;
                            break;
                        case "5":
                            _row = 1;
                            _col = 1;
                            break;
                        case "6":
                            _row = 1;
                            _col = 2;
                            break;
                        case "7":
                            _row = 0;
                            _col = 0;
                            break;
                        case "8":
                            _row = 0;
                            _col = 1;
                            break;
                        case "9":
                            _row = 0;
                            _col = 2;
                            break;
                    }
                }
                else
                {
                    string[] inputs = input.Split(new char[] { ' ', ',', '.', ';', ':', '-', '/' });
                    _row = Convert.ToInt32(inputs[0]) - 1;
                    _col = Convert.ToInt32(inputs[1]) - 1;
                }
            }
            else
            {
                _row = rnd.Next() % _size;
                _col = rnd.Next() % _size;
            }

        }
    }
    internal class Program
    {
        static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t*** HOME WORK N5 ***\n");
            Console.WriteLine("Выберите задачу из списка:\n");
            Console.WriteLine("\t1. Создайте приложение «Крестики-Нолики»." +
                "Пользователь играет с компьютером." +
                "При старте игры случайным образом выбирается, кто ходит первым." +
                "Игроки ходят по очереди. Игра может закончиться победой одного из игроков или ничьей." +
                "Используйте механизмы пространств имён.");
            Console.WriteLine("2. Добавьте к первому заданию возможность игры с другим пользователем.");
            Console.WriteLine("3. Создайте приложение для перевода обычного текста в азбуку Морзе." +
                "Пользователь вводит текст. Приложение отображает введенный текст азбукой Морзе." +
                "Используйте механизмы пространств имён.");
            Console.WriteLine("4. Добавьте к предыдущему заданию механизм перевода текста из азбуки Морзе в обычный текст.");
            Console.WriteLine("5. Выход из программы.\n");
            Console.WriteLine("Введите номер задачи (цифру и Enter):\n");
            bool exit = false;
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    case "2": Tasks.Task_1(); break;
                    case "3": Tasks.Task_2(); break;
                    case "4": Tasks.Task_3(); break;
                    case "5":
                    case "": exit = true; break;
                    default: Console.WriteLine("Такого пункта нет в списке задач, попробуйте ещё раз."); break;
                }
            } while (!exit);
        }
    }
    class Tasks
    {
        public static void Task_1()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t *** Задание 5, задача 1 и 2. ***\n");
            Console.WriteLine("\tЗадача 1. Создайте приложение «Крестики-Нолики»." +
                "Пользователь играет с компьютером." +
                "При старте игры случайным образом выбирается, кто ходит первым." +
                "Игроки ходят по очереди. Игра может закончиться победой одного из игроков или ничьей." +
                "Используйте механизмы пространств имён." +
                "\tЗадача 2. Добавьте к первому заданию возможность игры с другим пользователем.");

            //создание игроков:
            Console.Write("Введите имя первого игрока: ");
            Player player_1 = new Player();
            player_1.Name = Console.ReadLine();
            player_1.Human = true;

            //Добавьте к первому заданию возможность игры с другим пользователем.
            Console.Write("Введите имя второго игрока (для игры с компьютером нажмите Enter): ");
            Player player_2 = new Player();
            player_2.Name = Console.ReadLine();

            //Пользователь играет с компьютером.
            if (player_2.Name == String.Empty)
            {
                player_2.Name = "Computer";
                player_2.Human = false;
            }
            //Добавьте к первому заданию возможность игры с другим пользователем.
            else
            {
                player_2.Human = true;
            }

            //При старте игры случайным образом выбирается, кто ходит первым.
            Random rnd = new Random();
            Player player;
            Field field = new Field();
            if (rnd.Next() % 2 == 0)
            {
                player = player_1;
                player_1.Symbol = field.Cross;
                player_1.Title = "Крестики-CROSS";
                player_2.Symbol = field.Zero;
                player_2.Title = "Нолики-ZERO";
            }
            else
            {
                player = player_2;
                player_1.Symbol = field.Zero;
                player_1.Title = "Нолики-ZERO";
                player_2.Symbol = field.Cross;
                player_2.Title = "Крестики-CROSS";
            }

            //Игроки ходят по очереди.
            do
            {
                Console.Clear();
                if (player == player_1)
                {
                    player = player_2;
                }
                else
                {
                    player = player_1;
                }
                Console.WriteLine("Playing is " + player.Name + " " + player.Title);
                field.showField();
                do
                {
                    field.motion(player);
                } while (!field.isEmpty(field.Row, field.Col));
                field.fillCell(field.Row, field.Col, player);
            } while (!field.isWin(player)&& !field.isFill());

            //Игра может закончиться победой одного из игроков или ничьей.
            if (field.isWin(player))
            {
                Console.Clear();
                Console.WriteLine("Победили " + player.Title + " Win!");
                if (player.Human)
                {
                    Console.WriteLine("CONGRATULATIONS!!! " + player.Name + ", поздравляем с победой!!!");
                }
                else
                {
                    Console.WriteLine("Вы проиграли! Победил компьютер! You lose! Computer win!");
                }
                field.showField();
            }
            if (field.isFill())
            {
                Console.WriteLine("Ничья! Игра окончена! Game over!");
            }

            Console.WriteLine("Для возврата в меню нажмите Enter.");
            Console.ReadKey();
            Program.Menu();
        }
        public static void Task_2()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t *** Задание 5, задача 3. ***\n");
            Console.WriteLine("\tЗадача 3. Создайте приложение для перевода обычного текста в азбуку Морзе." +
                "Пользователь вводит текст. Приложение отображает введенный текст азбукой Морзе." +
                "Используйте механизмы пространств имён.");
            
            //Ввод исходной строки
            Console.WriteLine("Введите текст, который нужно превести в азбуку Морзе: ");
            string in_str = Console.ReadLine();
            string temp = in_str;
            temp = temp.ToLower();
            
            //Обработка

            temp = temp.Replace("0", "----- ");
            temp = temp.Replace("1", ".---- ");
            temp = temp.Replace("2", "..--- ");
            temp = temp.Replace("3", "...-- ");
            temp = temp.Replace("4", "....- ");
            temp = temp.Replace("5", "..... ");
            temp = temp.Replace("6", "-.... ");
            temp = temp.Replace("7", "--... ");
            temp = temp.Replace("8", "---.. ");
            temp = temp.Replace("9", "----. ");

            temp = temp.Replace("a", ".- ");
            temp = temp.Replace("b", "-... ");
            temp = temp.Replace("c", "-.-. ");
            temp = temp.Replace("d", "-.. ");
            temp = temp.Replace("e", ". ");
            temp = temp.Replace("f", "..-. ");
            temp = temp.Replace("g", "--. ");
            temp = temp.Replace("h", ".... ");
            temp = temp.Replace("i", ".. ");
            temp = temp.Replace("j", ".--- ");
            temp = temp.Replace("k", "-.- ");
            temp = temp.Replace("l", ".-.. ");
            temp = temp.Replace("m", "-- ");
            temp = temp.Replace("n", "-. ");
            temp = temp.Replace("o", "--- ");
            temp = temp.Replace("p", ".--. ");
            temp = temp.Replace("q", "--.- ");
            temp = temp.Replace("r", ".-. ");
            temp = temp.Replace("s", "... ");
            temp = temp.Replace("t", "- ");
            temp = temp.Replace("u", "..- ");
            temp = temp.Replace("v", "...- ");
            temp = temp.Replace("w", ".-- ");
            temp = temp.Replace("x", "-..- ");
            temp = temp.Replace("y", "-.-- ");
            temp = temp.Replace("z", "--.. ");

            temp = temp.Replace("а", ".- ");
            temp = temp.Replace("б", "-... ");
            temp = temp.Replace("в", ".-- ");
            temp = temp.Replace("г", "--. ");
            temp = temp.Replace("д", "-.. ");
            temp = temp.Replace("е", ". ");
            temp = temp.Replace("ё", ". ");
            temp = temp.Replace("ж", "....- ");
            temp = temp.Replace("з", "--.. ");
            temp = temp.Replace("и", ".. ");
            temp = temp.Replace("й", ".--- ");
            temp = temp.Replace("к", "-.- ");
            temp = temp.Replace("л", ".-.. ");
            temp = temp.Replace("м", "-- ");
            temp = temp.Replace("н", "-. ");
            temp = temp.Replace("о", "--- ");
            temp = temp.Replace("п", ".--. ");
            temp = temp.Replace("р", ".-. ");
            temp = temp.Replace("с", "... ");
            temp = temp.Replace("т", "- ");
            temp = temp.Replace("у", "..- ");
            temp = temp.Replace("ф", "..-. ");
            temp = temp.Replace("х", ".... ");
            temp = temp.Replace("ц", "-.-. ");
            temp = temp.Replace("ч", "---. ");
            temp = temp.Replace("ш", "---- ");
            temp = temp.Replace("щ", "--.- ");
            temp = temp.Replace("ъ", "--.-- ");
            temp = temp.Replace("ы", "-.-- ");
            temp = temp.Replace("ь", "-..- ");
            temp = temp.Replace("э", "..-.. ");
            temp = temp.Replace("ю", "..-- ");
            temp = temp.Replace("я", ".-.- ");

            temp = temp.Replace(",", "--..-- ");
            temp = temp.Replace("!", "-.-.-- ");
            temp = temp.Replace("?", "..--.. ");
            temp = temp.Replace("'", ".----. ");
            temp = temp.Replace("\"", ".-..-. ");
            temp = temp.Replace(":", "---... ");
            temp = temp.Replace(";", "---... ");
            temp = temp.Replace("+", ".-.-. ");
            temp = temp.Replace("-.-.-- ", "!");
            temp = temp.Replace("=", "-...- ");
            temp = temp.Replace("_", "..--.- ");
            temp = temp.Replace("/", "-..-. ");
            temp = temp.Replace("(", "-.--. ");
            temp = temp.Replace(")", "-.--.- ");
            temp = temp.Replace("&", ".-... ");
            temp = temp.Replace("$", "...-..- ");
            temp = temp.Replace("@", ".--.-. ");

            //Вывод результата
            Console.WriteLine(temp);

            Console.WriteLine("Для возврата в меню нажмите Enter.");
            Console.ReadKey();
            Program.Menu();
        }
        public static void Task_3()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t *** Задание 5, задача 4. ***\n");
            Console.WriteLine("\tЗадача 3. Создайте приложение для перевода обычного текста в азбуку Морзе." +
                "Пользователь вводит текст. Приложение отображает введенный текст азбукой Морзе." +
                "Используйте механизмы пространств имён.");
            Console.WriteLine("\tЗадача 4. Добавьте к предыдущему заданию механизм перевода текста из азбуки Морзе в обычный текст.");

            //Ввод исходной строки
            Console.WriteLine("Введите текст Морзе, который нужно расшифровать: ");
            string in_morze = Console.ReadLine();
            string temp = in_morze + " ";

            //Обработка результата
            temp = temp.Replace("...-..- ", "$");
            temp = temp.Replace(".-..-. ", "\"");
            temp = temp.Replace("..--.. ", "?");
            temp = temp.Replace(".----. ", "'");
            temp = temp.Replace("---... ", ":");
            temp = temp.Replace("---... ", ";");
            temp = temp.Replace("..--.- ", "_");
            temp = temp.Replace("-.--.- ", ")");
            temp = temp.Replace(".--.-. ", "@");
            temp = temp.Replace("--..-- ", ",");
            temp = temp.Replace("....- ", "ж");
            temp = temp.Replace("--.-- ", "ъ");
            temp = temp.Replace("..-.. ", "э");
            temp = temp.Replace("----- ", "0");
            temp = temp.Replace(".---- ", "1");
            temp = temp.Replace("..--- ", "2");
            temp = temp.Replace("...-- ", "3");
            temp = temp.Replace("....- ", "4");
            temp = temp.Replace("..... ", "5");
            temp = temp.Replace("-.... ", "6");
            temp = temp.Replace("--... ", "7");
            temp = temp.Replace("---.. ", "8");
            temp = temp.Replace("----. ", "9");
            temp = temp.Replace(".-.-. ", "+");
            temp = temp.Replace("-...- ", "=");
            temp = temp.Replace("-..-. ", "/");
            temp = temp.Replace("-.--. ", "(");
            temp = temp.Replace(".-... ", "&");
            temp = temp.Replace("-... ", "б");
            temp = temp.Replace("--.. ", "з");
            temp = temp.Replace(".--- ", "й");
            temp = temp.Replace(".-.. ", "л");
            temp = temp.Replace(".--. ", "п");
            temp = temp.Replace("..-. ", "ф");
            temp = temp.Replace(".... ", "х");
            temp = temp.Replace("-.-. ", "ц");
            temp = temp.Replace("---. ", "ч");
            temp = temp.Replace("--.- ", "щ");
            temp = temp.Replace("-.-- ", "ы");
            temp = temp.Replace("-..- ", "ь");
            temp = temp.Replace("..-- ", "ю");
            temp = temp.Replace(".-.- ", "я");
            temp = temp.Replace("-... ", "b");
            temp = temp.Replace("-.-. ", "c");
            temp = temp.Replace("..-. ", "f");
            temp = temp.Replace(".... ", "h");
            temp = temp.Replace(".--- ", "j");
            temp = temp.Replace(".-.. ", "l");
            temp = temp.Replace(".--. ", "p");
            temp = temp.Replace("--.- ", "q");
            temp = temp.Replace("...- ", "v");
            temp = temp.Replace("-..- ", "x");
            temp = temp.Replace("-.-- ", "y");
            temp = temp.Replace("--.. ", "z");
            temp = temp.Replace(".-- ", "в");
            temp = temp.Replace("--. ", "г");
            temp = temp.Replace("-.. ", "д");
            temp = temp.Replace("-.- ", "к");
            temp = temp.Replace("--- ", "о");
            temp = temp.Replace(".-. ", "р");
            temp = temp.Replace("... ", "с");
            temp = temp.Replace("..- ", "у");
            temp = temp.Replace("---- ","ш");
            temp = temp.Replace("-.. ", "d");
            temp = temp.Replace("--. ", "g");
            temp = temp.Replace("-.- ", "k");
            temp = temp.Replace("--- ", "o");
            temp = temp.Replace(".-. ", "r");
            temp = temp.Replace("... ", "s");
            temp = temp.Replace("..- ", "u");
            temp = temp.Replace(".-- ", "w");
            temp = temp.Replace(".- ", "а");
            temp = temp.Replace(".. ", "и");
            temp = temp.Replace("-- ", "м");
            temp = temp.Replace("-. ", "н");
            temp = temp.Replace(".- ", "a");
            temp = temp.Replace(".. ", "i");
            temp = temp.Replace("-- ", "m");
            temp = temp.Replace("-. ", "n");
            temp = temp.Replace("- ", "т");
            temp = temp.Replace("- ", "t");
            temp = temp.Replace(". ", "е");
            temp = temp.Replace(". ", "e");

            //Вывод результата
            Console.WriteLine(temp);


            Console.WriteLine("Для возврата в меню нажмите Enter.");
            Console.ReadKey();
            Program.Menu();
        }
    }
}

