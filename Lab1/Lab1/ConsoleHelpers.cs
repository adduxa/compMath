using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1 {
	internal class ConsoleHelpers {
		private const int TabLength = 6;
		private const int NumOfDigits = 0;
		private const int UpperLimit = 10;
		private const int LowerLimit = -10;
		private const int RoundDigits = 3;
		private int _dimensions = 5;

		private string _filePath;
		private MatrixFileReader _fileReader;
		private bool _randomFill;
		private bool _useFile;

		public double E = 0.001;

		public double[,] Matrix;

		private int _dimensionl {
			get { return _dimensions; }
		}

		private int _dimensionc {
			get { return _dimensions + 1; }
		}

		public int ReadMatrix(string[] args) {
			string answer;
			switch(args.Length) {
				case 0:
					Console.Write("Ввод из файла? (y/n): [n] ");
					answer = Console.ReadLine();
					if(answer == "y" || answer == "yes" || answer == "Y") {
						_useFile = true;
						Console.Write("Укажите путь до файла: ");
						_filePath = Console.ReadLine();
					} else {
						_useFile = false;
					}
					break;
				case 1:
					_useFile = true;
					Console.WriteLine("Используем файл {0}", args[0]);
					_filePath = args[0];
					break;
				default:
					_useFile = true;
					Console.WriteLine("Введено несколько агрументов. Используем первый");
					Console.WriteLine("Используем файл {0}", args[0]);
					_filePath = args[0];
					break;
			}

			if(_useFile) {
				while(!File.Exists(_filePath)) {
					Console.WriteLine("Ошибка! Заданый файл не существует!");
					Console.Write("Укажите путь до файла: ");
					_filePath = Console.ReadLine();
				}

				try {
					var sr = File.OpenText(_filePath);
					_fileReader = new MatrixFileReader(sr);
				}
				catch(Exception e) {
					Console.WriteLine(e.Message);
				}
				E = _fileReader.E;
				Console.WriteLine("Введённая точность вычислений: [{0}] ", E);
				_dimensions = _fileReader.Dimensions - 1;
				Matrix = new double[_dimensionl, _dimensionc];
			} else {
				Console.Write("Введите количество неизвестных: [{0}] ", _dimensions);
				answer = Console.ReadLine();
				if(answer != "") {
					ReadInt(out _dimensions, postError: "Введите количество неизвестных: ",
						error: "Некорректное значение! Ожидается ввод положительного целого числа", negative: false, zero: false);
				}
				Matrix = new double[_dimensionl, _dimensionc];

				Console.Write("Сгенерировать коэффициенты случайным образом? (y/n): [y] ");
				answer = Console.ReadLine();
				_randomFill = answer == "y" || answer == "yes" || answer == "Y" || answer == "";

				Console.Write("Введите точность вычислений: [{0}] ", E);
				answer = Console.ReadLine();
				if(answer != "") {
					ReadDouble(out E, postError: "Введите точность: ",
						error: "Некорректное значение! Ожидается ввод положительного вещественного числа", negative: false);
				}
			}

			var rand = new Random();
			if(_randomFill) {
				Console.WriteLine("Полученная матрица:");
			} else if(_useFile) {
				Console.WriteLine("Введённая матрица:");
			} else {
				Console.WriteLine(
					"Введите коэффициенты матрицы {0}x{1} (последний столбец - вектор свободных членов) (ввод элемента клавишей Enter):",
					_dimensionc, _dimensionl);
			}

			Console.Write("   ");
			for(var c = 0; c < _dimensionc - 1; c++) {
				var lastCursorLeft = Console.CursorLeft;
				Console.Write(c + 1);
				var numLength = (c + 1).ToString().Length;
				var spaceLength = Math.Max(TabLength - numLength, 0);
				Console.SetCursorPosition(lastCursorLeft + numLength + spaceLength + 1, Console.CursorTop);
			}
			Console.WriteLine("Вектор");
			for(var l = 0; l < _dimensionl; l++) {
				Console.Write("{0}: ", l + 1);
				var beautiful = true;
				for(var c = 0; c < _dimensionc; c++) {
					var previousCursorLeft = Console.CursorLeft;
					if(_randomFill) {
						var numOfDigitsDec = (int)Math.Pow(10, NumOfDigits);
						Matrix[l, c] = Convert.ToDouble(rand.Next(LowerLimit*numOfDigitsDec, UpperLimit*numOfDigitsDec))/numOfDigitsDec;
						Console.WriteLine(Matrix[l, c]);
					} else if(_useFile) {
						try {
							Matrix[l, c] = _fileReader.Next();
						}
						catch(Exception e) {
							Console.WriteLine();
							Console.WriteLine(e.Message);
							_fileReader.Close();
							return 1;
						}
						Console.WriteLine(Matrix[l, c]);
					}
					if(_randomFill || _useFile ||
						beautiful &&
						ReadDouble(out Matrix[l, c], "",
							"Некорректное значение! Ожидается ввод вещественного числа. А ещё вы только что сломали красивый ввод матрицы",
							"Введите элемент матрицы " + (l + 1) + "," + (c + 1) + ": ")) {
						var numLength = Matrix[l, c].ToString().Length;
						var spaceLength = Math.Max(TabLength - numLength, 0);
						Console.SetCursorPosition(previousCursorLeft + numLength + spaceLength + 1, Console.CursorTop - 1);
					} else {
						if(beautiful) {
							beautiful = false;
						} else {
							ReadDouble(out Matrix[l, c], "Введите элемент матрицы " + (l + 1) + "," + (c + 1) + ": ");
						}
					}
				}
				Console.WriteLine();
			}
			if(_useFile) {
				_fileReader.Close();
			}
			return 0;
		}

		public bool ReadInt(out int var, string message = "",
			string error = "Некорректное значение! Ожидается ввод целого числа", string postError = null, bool negative = true,
			bool zero = true) {
			var res = true;
			if(postError == null) {
				postError = message;
			}
			Console.Write(message);
			while(!int.TryParse(Console.ReadLine(), out var) || !negative && var < 0 || !zero && var == 0) {
				res = false;
				Console.WriteLine(error);
				Console.Write(postError);
			}
			return res;
		}

		public bool ReadDouble(out double var, string message = "",
			string error = "Некорректное значение! Ожидается ввод вещественного числа", string postError = null,
			string decimalSeparator = null, string negativeSign = null, bool negative = true) {
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

				var match = Regex.Match(Console.ReadLine(), pattern);
				var number = rgx.Replace(match.Value, decimalSeparator);

				done = double.TryParse(number, out var);
			} while(!done || !negative && var < 0);

			return res;
		}

		public void WriteMatrix(double[,] matrix, string variable = "X") {
			var dimensionl = matrix.GetLength(0);
			var dimensionc = matrix.GetLength(1);
			Console.Write("   ");
			for(var c = 0; c < dimensionc - 1; c++) {
				var lastCursorLeft = Console.CursorLeft;
				Console.Write("{0}{1}", variable, c + 1);
				var numLength = (c + 1).ToString().Length;
				var spaceLength = Math.Max(TabLength - numLength, 0);
				Console.SetCursorPosition(lastCursorLeft + numLength + spaceLength + 1, Console.CursorTop);
			}
			Console.WriteLine("Вектор");
			for(var l = 0; l < dimensionl; l++) {
				Console.Write("{0}: ", l + 1);
				for(var c = 0; c < dimensionc; c++) {
					var previousCursorLeft = Console.CursorLeft;
					Console.WriteLine(Math.Round(matrix[l, c], RoundDigits));
					var numLength = Math.Round(matrix[l, c], RoundDigits).ToString().Length;
					var spaceLength = Math.Max(TabLength - numLength, 0);
					Console.SetCursorPosition(previousCursorLeft + numLength + spaceLength + 1, Console.CursorTop - 1);
				}
				Console.WriteLine();
			}
		}

		public void WriteVectorHorizontally(double[] vector, string variable = "X") {
			for(var c = 0; c < vector.Length; c++) {
				var lastCursorLeft = Console.CursorLeft;
				Console.Write("{0}{1}", variable, c + 1);
				var numLength = (c + 1).ToString().Length;
				var spaceLength = Math.Max(TabLength - numLength, 0);
				Console.SetCursorPosition(lastCursorLeft + numLength + spaceLength + 1, Console.CursorTop);
			}
			Console.WriteLine();
			for(var c = 0; c < vector.Length; c++) {
				var previousCursorLeft = Console.CursorLeft;
				Console.WriteLine(Math.Round(vector[c], RoundDigits));
				var numLength = Math.Round(vector[c], RoundDigits).ToString().Length;
				var spaceLength = Math.Max(TabLength - numLength, 0);
				Console.SetCursorPosition(previousCursorLeft + numLength + spaceLength + 1, Console.CursorTop - 1);
			}
			Console.WriteLine();
		}

		public string WordEnding(int num) {
			string ending;
			switch(num%10) {
				case 1:
					ending = "ю";
					break;
				case 2:
				case 3:
				case 4:
					ending = "и";
					break;
				default:
					ending = "й";
					break;
			}
			return ending;
		}
	}
}