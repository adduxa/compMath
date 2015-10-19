/**
* Университет ИТМО
* Кафедра вычислительной техники
* Вычислительная математика
* 
* Лабораторная работа №2
* Интегрирование
* Вариант: Метод трапеций
* 
* Выполнил:
* студент II курса факультета КТиУ
* Дьяков Андрей Александрович, группа P3200
* 
* Преподаватель:
* Кучер Алексей Владимирович
* 
* Санкт-Петербург, 2015г.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lab2 {
	internal class Program {
		private const int DefaultFunction = 3;
		private const double DefaultLowerLimit = 0;
		private const double DefaultUpperLimit = 10;
		private const double DefaultAccuracy = 0.0001;

		private static void Main(string[] args) {
			var functions = new List<Func>();
			functions.Add(new Func("y = 2", x => 2));
			functions.Add(new Func("y = x", x => x));
			functions.Add(new Func("y = Log10(x^e)", x => Math.Log10(Math.Pow(x,Math.E))));
			functions.Add(new Func("y = x^2", x => Math.Pow(x, 2)));
			functions.Add(new Func("y = sin(x)", x => Math.Sin(x)));

			Console.WriteLine("Доступные для интегрирования функции:");
			functions.ForEach(curr => { Console.WriteLine("{0}: {1}", functions.IndexOf(curr) + 1, curr); });
			var choosenFunc = DefaultFunction;
			Console.Write("Введите номер функции: [{0}] ", DefaultFunction);
			var answer = Console.ReadLine();
			if(answer != "") {
				ReadInt(out choosenFunc, str: answer, postError: "Введите номер функции: ",
					error: "Некорректное значение! Ожидается ввод целого числа от 1 до " + functions.Count,
					condition: i => i > 0 && i <= functions.Count);
			}
			choosenFunc -= 1;

			var lowerLimit = DefaultLowerLimit;
			Console.Write("Введите нижний предел интегрирования: [{0}] ", DefaultLowerLimit);
			answer = Console.ReadLine();
			if(answer != "") {
				ReadDouble(out lowerLimit, str: answer, postError: "Введите нижний предел интегрирования: ");
			}

			var upperLimit = DefaultUpperLimit;
			Console.Write("Введите верхний предел интегрирования: [{0}] ", DefaultUpperLimit);
			answer = Console.ReadLine();
			if(answer != "") {
				ReadDouble(out upperLimit, str: answer, postError: "Введите верхний предел интегрирования: ");
			}

			var accuracy = DefaultAccuracy;
			Console.Write
				("Введите точность: [{0}] ", DefaultAccuracy);
			answer = Console.ReadLine();
			if(answer != "") {
				ReadDouble(out accuracy, str: answer, postError: "Введите точность: ",
					error: "Некорректное значение! Ожидается ввод положительного вещественного числа", condition: i => i > 0);
			}

			var tr = new TrapezoidalRule();
			var res = tr.Calculate(functions[choosenFunc], lowerLimit, upperLimit, accuracy);

			Console.WriteLine();
			Console.WriteLine("Функция: {0}", functions[choosenFunc]);
			Console.WriteLine("Результат: {0}", Math.Round(res.Result, RoundDigits(accuracy)));
			Console.WriteLine("Количество разбиений: {0}", res.Segments);
			Console.WriteLine("Погрешность: {0}", Math.Round(res.Accuracy, RoundDigits(accuracy)));

			Console.WriteLine();
			Console.Write("Программа завершена. Нажмите любую клавишу для выхода...");
			Console.ReadKey();
		}

		private static int RoundDigits(double accuracy) {
			return Math.Abs((int)Math.Floor(Math.Log10(accuracy))) + 1;
		}

		public static bool ReadInt(out int var, string message = "",
			string error = "Некорректное значение! Ожидается ввод целого числа", string postError = null, string str = null,
			Predicate<int> condition = null) {
			var res = true;
			if(postError == null) {
				postError = message;
			}
			Console.Write(message);
			while(!(int.TryParse(res ? str ?? Console.ReadLine() : Console.ReadLine(), out var) && (condition == null || condition.Invoke(var)))) {
				res = false;
				str = null;
				Console.WriteLine(error);
				Console.Write(postError);
			}
			return res;
		}

		public static bool ReadDouble(out double var, string message = "",
			string error = "Некорректное значение! Ожидается ввод вещественного числа", string postError = null,
			string decimalSeparator = null, string negativeSign = null, bool negative = true, string str = null,
			Predicate<double> condition = null) {
			var res = true;
			postError = postError ?? message;
			decimalSeparator = decimalSeparator ?? NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
			negativeSign = negativeSign ?? NumberFormatInfo.CurrentInfo.NegativeSign;

			var pattern = "[" + negativeSign + "]*[0-9]+[^0-9-]*[0-9]*";
			const string replacePattern = "[^0-9-]+";

			Console.Write(message);


			var rgx = new Regex(replacePattern);
			var err = false;
			bool done;
			do {
				if(err) {
					Console.WriteLine(error);
					Console.Write(postError);
					res = false;
				} else {
					err = true;
				}

				var match = Regex.Match(res ? str ?? Console.ReadLine() : Console.ReadLine(), pattern);
				var number = rgx.Replace(match.Value, decimalSeparator);

				done = double.TryParse(number, out var);
			} while(!(done && (condition == null || condition.Invoke(var))));

			return res;
		}
	}
}