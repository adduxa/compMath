using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1 {
	internal class MatrixFileReader {
		private readonly StreamReader _sr;
		public readonly int Dimensions;
		public readonly double E;
		private string _currentLine;
		private string[] _currentLineArr;
		private int _linesDone;
		private int _pointer;

		public MatrixFileReader(StreamReader sr) {
			_sr = sr;
			if(!ParseDouble(_sr.ReadLine(), out E, negative: false)) {
				throw new Exception(
					"Ошибка формата файла! Превая строка должна содержать точность вычислений, являющуюся положительным вещественным числом");
			}
			_currentLine = _sr.ReadLine();
			_currentLineArr = _currentLine.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
			Dimensions = _currentLineArr.Length;
			_linesDone++;
		}

		public double Next() {
			if(_pointer == Dimensions) {
				if(_linesDone == Dimensions) {
					throw new Exception("Ошибка формата файла! Количество строк меньше, чем требуется");
				}
				if(_sr.EndOfStream) {
					throw new Exception("Ошибка формата файла! Неожиданный конец файла");
				}
				_currentLine = _sr.ReadLine();
				_currentLineArr = _currentLine.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
				if(_currentLineArr.Length != Dimensions) {
					throw new Exception(
						$"Ошибка формата файла! Количество элементов в разных строках отличается (строка {_linesDone + 1})");
				}
				_linesDone++;
				_pointer = 0;
			}

			double result;
			if(!ParseDouble(_currentLineArr[_pointer], out result)) {
				throw new Exception(
					$"Ошибка формата файла! Невозможно интерпретировать '{_currentLineArr[_pointer]}' как число (строка {_linesDone + 1}, число {_pointer + 1})");
			}
			_pointer++;
			return result;
		}

		public void Close() {
			_sr.Close();
		}

		public static bool ParseDouble(string str, out double var, string decimalSeparator = null, string negativeSign = null,
			bool negative = true) {
			decimalSeparator = decimalSeparator ?? NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
			negativeSign = negativeSign ?? NumberFormatInfo.CurrentInfo.NegativeSign;

			var pattern = "[" + negativeSign + "]*[0-9]+[^0-9-]*[0-9]*";
			const string replacePattern = "[^0-9-]+";

			var rgx = new Regex(replacePattern);
			var match = Regex.Match(str, pattern);
			var number = rgx.Replace(match.Value, decimalSeparator);

			var res = double.TryParse(number, out var) && (negative || var >= 0);

			return res;
		}
	}
}