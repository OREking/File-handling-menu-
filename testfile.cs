using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testfile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Add users");
            Console.WriteLine("2. search for users");
            Console.WriteLine("3. Display all users");
            Console.WriteLine("4. Delete users");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                add();
            }
            if (choice == 2)
            {
                search();
            }
            if (choice == 3)
            {
                display();

            }
            if (choice == 4)
            {
                delete();
            }



        }
        public static void search()
        {

            Console.WriteLine("Enter name to search from our list");

            string searchName = Console.ReadLine();

            //read all lines from file into the array str, one array element for each line
            string[] str = File.ReadAllText("X:/Btec Computing/classwork/test.txt")
                                         .Split(new string[] { Environment.NewLine },
                                                               StringSplitOptions.None);

            for (int i = 0; i < str.Length; i++)
            {
                string[] name = str[i].Split(','); //use comma as delimiter to separate each value
                if (name[0] == searchName) //name is in position 0

                    Console.WriteLine(name[0] + " has been found in line " + i);

            }
        }
        public static void add()
        {
            Console.WriteLine("what is your name and username? (name,username)");
            string name = Console.ReadLine();          

            using (StreamWriter sw = File.AppendText("X:/Btec Computing/classwork/test.txt"))
            {
                sw.WriteLine(name);
                sw.Close();

            }

        }
        public static void display()
        {
            string data;
            FileStream fsSource = new FileStream("X:/Btec Computing/classwork/test.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fsSource))
            {
                while ((data = sr.ReadLine()) != null)
                {
                    Console.WriteLine(data);
                }
            }

        }
        public static void delete()
        {
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(fileName).Where(l => l != "removeme");
            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(fileName);
            File.Move(tempFile, fileName);


        }
    }

}         
