using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


class Tests
{
    public static void Test_1_1()
    {
        Matrix m = new Matrix(0, 0);
        Console.WriteLine("Тест задания 1. Ввод массива вручную");
        for (int i = 0; i < 3; i++) 
        {
            m.input();
            Console.WriteLine(m);

        }
        Console.WriteLine();
    }

    public static void Test_1_2()
    {
        Console.WriteLine("Тест задания 1. Заполнение случайными числами");
        for (int i = 0; i < 3; i++)
        {
            int n = UserInput.intInput(true, "Введите порядок матрицы: ");
            Matrix m = new Matrix(n, n);
            m.randomNumbers();
            Console.WriteLine(m);
        }
        Console.WriteLine();
    }

    public static void Test_1_3()
    {
        Console.WriteLine("Тест задания 1. Заполнение с конца");
        for (int i = 0; i < 3; i++)
        {
            int n = UserInput.intInput(true, "Введите порядок матрицы: ");
            Matrix m = new Matrix(n, n);
            m.obr();
            Console.WriteLine(m);
        }
        Console.WriteLine();
    }

    public static void Test_2()
    {
        Console.WriteLine("Тест задания 2. Нахождение подмассива");
        for (int i = 0; i < 3; i++)
        {
            int n = UserInput.intInput(true, "Введите количество строк матрицы: ");
            int m = UserInput.intInput(true, "Введите количество столбцов матрицы: ");

            Matrix matrix = new Matrix(n, m);
            matrix.random();

            Console.WriteLine(matrix);

            Console.WriteLine();
            Console.WriteLine(matrix.maxArrSum());
        }
        Console.WriteLine();
    }

    public static void Test_3()
    {
        Console.WriteLine("Тест задания 3. aT + 2b + cT");
        int n = UserInput.intInput(true, "Введите количество строк в матрице: ");
        int m = UserInput.intInput(true, "Введите количество столбцов в матрице: ");

        Matrix a = new Matrix(n, m);
        a.random();
        Console.WriteLine("Матрица a");
        Console.WriteLine(a);

        Matrix b = new Matrix(m, n);
        b.random();
        Console.WriteLine("Матрица b");
        Console.WriteLine(b);

        Matrix c = new Matrix(n, m);
        c.random();
        Console.WriteLine("Матрица c");
        Console.WriteLine(c);

        Console.WriteLine(Matrix.f(a, b, c));
    }

    public static void Test_4()
    {
        Console.WriteLine("Тест задания 4");
        for (int i = 0; i < 3; i++)
        {
            MyFile.GenRandomBin($"exe2{i}.bin");
            int[] arr = MyFile.ReadNumbersBin($"exe2{i}.bin");
            Console.WriteLine("Числа в входном файле: ");
            for (int j = 0; j < arr.Length; j++)
            {
                Console.Write(arr[j]);
            }
            Console.WriteLine();

            int n = UserInput.intInput(false, "Введите число n: ");
            int m = UserInput.intInput(false, "Введите число m: ");

            MyFile.NewNumbersBin($"exe2{i}.bin", $"outexe2{i}.bin", n, m);

            arr = MyFile.ReadNumbersBin($"exe2{i}.bin");
            Console.WriteLine("Числа в выходном файле: ");
            for (int j = 0; j < arr.Length; j++)
            {
                Console.Write(arr[j]);
            }
            Console.WriteLine();

            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void Test_5()
    {
        Console.WriteLine("Тест задания 5");
        Person[] people = new Person[10];
        string[] types = new string[3];

        types[0] = "чемодан";
        types[1] = "сумка";
        types[2] = "коробка";

        Random random = new Random();

        people[0].name = "Человек 1";
        people[0].baggage = [new Unit(types[0], random.Next(1, 100))];

        for (int i = 1; i < people.Length; i++)
        {
            people[i].name = $"Человек {i+1}";

            Unit[] units = new Unit[random.Next(1, 5)];

            for (int j = 0;j < units.Length;j++) 
            {
                units[i].type = types[random.Next(types.Length)];
                units[i].weight = random.Next(1, 100);
            }

            people[i].baggage = units;

            Console.WriteLine($"Имя: {people[i].name}");
            Console.WriteLine($"Багаж: ");
            foreach (Unit unit in units)
            {
                Console.Write($"{unit.type}: {unit.weight}, ");
            }
            Console.WriteLine();
        }

        MyFile.WritePeopleXML("p.xml", people);
        int m = UserInput.intInput(true, $"Введите максимальную массу: ");
        Console.WriteLine(MyFile.ExistPerson("p.xml", m));


        Console.WriteLine();
    }

    public static void Test_6()
    {
        Console.WriteLine("Тест задания 6");

        for (int i = 0; i < 3; i++) 
        {
            MyFile.GenRandomTxt($"6{i+1}.txt");

            int[] arr = MyFile.ReadNumbersTxt($"6{i + 1}.txt");
            Console.WriteLine("Числа в файле: ");
            foreach (int n in arr) { Console.Write($"n "); }

            Console.WriteLine($"max - min = {MyFile.Diff($"6{i + 1}.txt")}");

            Console.WriteLine();
        }


        Console.WriteLine();
    }

    public static void Test_7()
    {
        Console.WriteLine("Тест задания 7");

        for (int i = 0; i < 3; i++)
        {
            MyFile.GenRandomTxt2($"7{i + 1}.txt");

            Console.WriteLine($"Числа записаны в фыйле 7{i + 1}.txt");

            Console.WriteLine($"min = {MyFile.MinElTxt($"7{i + 1}.txt")}");

            Console.WriteLine();
        }


        Console.WriteLine();
    }

    public static void Test_8()
    {
        Console.WriteLine("Тест задания 8");

        for (int i = 0; i < 3; i++)
        {
            char ch = UserInput.charInput();
            Console.Write("Введите название выходного файла: ");
            string file = Console.ReadLine();

            MyFile.ReWriteTxt("8.txt", file, ch);
            
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
