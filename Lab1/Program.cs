/*
 * Created by SharpDevelop.
 * User: Artiom
 * Date: 15-Sep-20
 * Time: 14:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Xml.Schema;

namespace Lab1
{
	class Program
	{
		static Tuple<int, int, int, char> Func1 (int[] arr, string str)
        {
			int min, max = min = arr[0];
			int sum = 0;
			foreach (int num in arr)
            {
				if (min > num)
					min = num;

				if (max < num)
					max = num;

				sum += num;
            }
			return Tuple.Create(min,max, sum, str[0]);
        }
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!\n");


			//	===============
			//	   Примитивы 
			//	===============	


			bool BoolVar = true; Console.WriteLine(BoolVar);

			char CharVar = 'c'; Console.WriteLine(CharVar);
			// Wide Char walking but he's always in frame (2 байта)

			// С плавающей точкой
			double DoubleVar = 13.3; Console.WriteLine(DoubleVar);
			// float, decimal
			// decimal - наибольшая точность, наименьший диапазон
			// 4, 8, 16 байтов

			// Целочисленные
			byte ByteVar = 255; Console.WriteLine(ByteVar);
			sbyte SByteVar = -128; Console.WriteLine(SByteVar);
			int IntVar = -20; Console.WriteLine(IntVar);
			//long, short
			uint UIntVar = 20; Console.WriteLine(UIntVar);
			//ulong, short
			// 8, 16, 32, 64 байта




			//	===============
			//	  Приведения  
			//	===============

			// Неявные

			Console.Write("\nНеявные преобразования\n");

			long LongVar = IntVar; Console.WriteLine(LongVar);
			float FloatVar = IntVar; Console.WriteLine(FloatVar);
			ByteVar = 30; Console.WriteLine(ByteVar); // Неявное преобразование константного выражения типа int в byte
			IntVar = ByteVar; Console.WriteLine(IntVar);
			IntVar = SByteVar; Console.WriteLine(IntVar);



			// Явные

			Console.Write("\nЯвные преобразования\n");

			LongVar = (long)13.5; Console.WriteLine(LongVar);
			FloatVar = (float)DoubleVar; Console.WriteLine(FloatVar);
			IntVar = (int)'c'; Console.WriteLine(IntVar);
			CharVar = (char)67; Console.WriteLine(CharVar);
			SByteVar = (sbyte)IntVar; Console.WriteLine(SByteVar);


			// Convert

			Console.Write("\nConvert\n");

			CharVar = System.Convert.ToChar(68); Console.WriteLine(CharVar);



			// Упаковка и распаковка

			IntVar = 20;
			object Box = IntVar; // Неявное преобразование
			IntVar = (int)Box; // Явное

			// Неявная типизация

			Console.Write("\nНеявно типизированная переменная\n");
			var Variable1 = 3; Console.WriteLine(Variable1);
			Console.WriteLine(Variable1.GetType().FullName);
			Console.WriteLine(IntVar.GetType().FullName);

			//It is important to understand that the var keyword does not mean "variant" and does not indicate that the variable is loosely typed, or late-bound. 
			//It just means that the compiler determines and assigns the most appropriate type.



			var Variable2 = "String"; Console.WriteLine(Variable2);
			Console.WriteLine(Variable2.GetType().FullName);
			Variable1 = 'c'; Console.WriteLine(Variable1); // Исключение - неявное приведение char к int
														   // Variable1 = "c"; - ошибка
														   // var NullVar = null; // не Nullable

			// Nullable

			Console.Write("\nNullable\n");
			char? NullChar = 'c'; Console.WriteLine(NullChar);
			NullChar = null; Console.WriteLine(NullChar);
			string NullStr = null; // аыа
			object NullObj = null; // аыааыаыаыа


			//	===============
			//	    String  
			//	===============


			Console.Write("\nString\n");

			string s1 = "I am a string";
			string s2 = "I am a string";
			string s3 = "I am a string too";

			if (s1 == s2) Console.WriteLine("s1 == s2");
			else Console.WriteLine("s1 != s2");
			if (s2 == s3) Console.WriteLine("s2 == s3");
			else Console.WriteLine("s2 != s3");

			Console.WriteLine(s1 + s3);
			Console.WriteLine(s2.Replace("am", "might be"));
			Console.WriteLine(String.Copy(s3));
			Console.WriteLine(s2.Insert(7, s1.Substring(3, 5)));
			Console.WriteLine(s3.Remove(1, 5));
			string[] words = s2.Split(' ');

			foreach (var word in words)
			{
				Console.WriteLine($"Слово: {word}");
			}
			string EmptyStr = "";
			Console.WriteLine($"Пустая строка: {EmptyStr}");
			Console.WriteLine($"Null-строка: {NullStr}");
			Console.WriteLine(string.IsNullOrEmpty(NullStr));
			Console.WriteLine(string.IsNullOrEmpty(EmptyStr));
			Console.WriteLine(string.IsNullOrEmpty(s1));

			StringBuilder sb = new StringBuilder("Денис Божко");
			sb.Remove(0, 5);
			sb.Insert(0, "Маэстро");
			sb.Append(" Понасенков");
			Console.WriteLine(sb);

			//	===============
			//	    Массив  
			//	===============


			int[,] arr = { { 1, 2 }, { 3, 4 } };
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					Console.Write($"{arr[i, j]} ");
				}
				Console.Write("\n");
			}

			string[] sArray = { "Привет,", "я строка" };
			Console.WriteLine($"sArray length = {sArray.GetLength(0)}");
			sArray[1] = "Я массив строк";

			var str = "hello world"; // Неявно типизированныая строка
			var arr2 = new double[3][]; // Неявно типизированный массив
			arr2[0] = new double[2];
			arr2[1] = new double[3];
			arr2[2] = new double[4];
			string tempStr;
			string[] numbers;


			for (int i = 0; i < arr2.GetLength(0); i++)
			{
				tempStr = Console.ReadLine();
				numbers = tempStr.Split();
				for (int j = 0; j < arr2[i].GetLength(0); j++)
				{
					arr2[i][j] = System.Convert.ToDouble(numbers[j]);
				}

			}

			Console.Write("\n==========\n\n");

			for (int i = 0; i < arr2.GetLength(0); i++)
			{
				for (int j = 0; j < arr2[i].GetLength(0); j++)
				{
					Console.Write($"{arr2[i][j]} ");
				}
				Console.Write("\n");
			}


			//	===============
			//	    Кортежи  
			//	===============

			Console.Write("\nКортежи\n");

			(int, string, char, string, ulong) tuple = (10, "hello", 'c', "world", 99);

			Console.Write($"1:{tuple.Item1}\n3:{tuple.Item3}\n4:{tuple.Item4}\n");

			(int a, byte b) left = (5, 10);
			(long a, int b) right = (5, 10);
			Console.WriteLine($"left == right: {left == right}");

			//	===============
			//	    Функции
			//	===============
			int[] arr4 = { 1, 3, 2, 5 };
			Tuple<int, int, int, char> FuncRes = Func1(arr4, "KONO DIO DA");
			int int1, int2, int3;
			char char1;
			(int1, int2, int3, char1) = FuncRes; // Распаков очка

			Console.Write($"min: {int1}\t max: {int2}\tsum: {int3}\tfirst char: {char1}\n");

			//	===============
			// Checked/Unchecked
			//	===============
			try
			{
				checked
				{
					int a = int.MaxValue;
					a = a + 1;
					Console.WriteLine(a);
				}
			} catch (Exception e)
            {
				Console.WriteLine($"\nChecked overflow");
            }
			try
			{
				int b = unchecked(int.MaxValue + 1);
				Console.WriteLine(b);
			} catch (Exception e)
            {
				Console.WriteLine($"\nUnchecked overflow");
            }
	Console.Write("\n");
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);

	


		}
	}
}