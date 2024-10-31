using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;


class MyFile
{
    // 4
    public static void GenRandomBin(string file, int k = 10, int a = 0, int b = 100)
    {
        Random random = new Random();

        using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.OpenOrCreate)))
        {
            writer.Write(k);
            for (int i = 0; i < k; i++)
            {
                writer.Write(random.Next(a, b));
            }
        }

    }

    // 4
    public static void WriteNumbersBin(string file, int[] arr)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.OpenOrCreate)))
        {
            writer.Write(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                writer.Write(arr[i]);
            }
        }
    }

    // 4
    public static int[] ReadNumbersBin(string file)
    {

        using (BinaryReader reader = new BinaryReader(File.Open("person.dat", FileMode.Open)))
        { 
            int k = reader.ReadInt32();
            int[] arr = new int[k];
            for (int i = 0; i < k; i++)
            {
                arr[i] = reader.ReadInt32();
            }
            return arr;
        }
    }

    // 4
    public static void NewNumbersBin(string file,string outFile, int n, int m)
    {
        int[] arr = MyFile.ReadNumbersBin(file);
        int k = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % m == 0 && arr[i] % n != 0)
                k++;
        }
        int[] newArr = new int[k];
        k = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % m == 0 && arr[i] % n != 0)
                arr[k] = arr[i];
                k++;
        }

        MyFile.WriteNumbersBin(outFile, newArr);
    }

    // 5
    public static void WritePeopleXML(string file, Person[] arr)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person[]));
        using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, arr);
        }
    }
    
    // 5
    public static Person[] ReadPeopleXML(string file)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person[]));
        using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
        {
            fs.Position = 0;
            Person[]? arr = xmlSerializer.Deserialize(fs) as Person[];
            if (arr is null)
            {
                return [];
            }
            return arr;
        }

    }

    // 5
    public static bool ExistPerson(string file, int m)
    {
        Person[] p = ReadPeopleXML(file);
        foreach (Person person in p) 
        { 
            if (person.baggage.Length == 1 && person.baggage[0].weight < m)
            {
                return true;
            }
        }
        return false;
    }

    // 6 write
    public static void GenRandomTxt(string file, int k = 10, int a = 0, int b = 100)
    {
        Random random = new Random();

        using (StreamWriter writer = new StreamWriter(file, false))
        {
            for (int i = 0; i < k; i++)
            {
                writer.WriteLine(random.Next(a, b));
            }
        }

    }

    // 6 read
    public static int[] ReadNumbersTxt(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string text = reader.ReadToEnd();
            string[] split_text = text.Split("\n");

            int[] arr = new int[split_text.Length];

            for (int i = 0; i < split_text.Length; i++)
            {
                arr[i] = int.Parse(split_text[i]);
            }

            return arr;
        }
    }

    // 6
    public static int Diff(string file)
    {
        int[] arr = ReadNumbersTxt(file);
        int max_n = arr[0];
        int min_n = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (max_n < arr[i]) { max_n = arr[i]; }
            else if (min_n > arr[i]) { min_n = arr[i]; }
        }
        return max_n - min_n;
    }

    // 7
    public static void GenRandomTxt2(string file, int n = 10, int m = 10, int a = 0, int b = 100)
    {
        Random random = new Random();

        using (StreamWriter writer = new StreamWriter(file, false))
        {
            for (int i = 0; i < n; i++)
            {
                int arr_size = random.Next(1, m);
                int[] arr = new int[arr_size];
                for (int j = 0; j < arr_size; j++)
                {
                    arr[j] = random.Next(a, b);
                }
                writer.WriteLine(string.Join(" ", arr));
            }
        }

    }

    // 7
    public static int MinElTxt(string file)
    {
        int min_n = Int32.MinValue;
        using (StreamReader reader = new StreamReader(file))
        {
            string text = reader.ReadToEnd();
            string[] split_text = text.Split("\n");

            for (int i = 0; i < split_text.Length; i++)
            {
                string[] split_line = split_text[i].Split(" ");
                for (int j = 0; j < split_text.Length; j++)
                {
                    int n = int.Parse(split_line[j]);
                    if (min_n > n) { min_n = n; }
                }
            }
        }
        return min_n;
    }

    // 8
    public static void ReWriteTxt(string file, string outFile, char ch)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string text = reader.ReadToEnd();
            string[] split_text = text.Split("\n");

            using (StreamWriter writer = new StreamWriter(outFile, false))
            {
                foreach (string line in split_text)
                {
                    if (line.Length != 0 && line[0] == ch)
                    {
                        Console.WriteLine(line);
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }


}
