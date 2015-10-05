using System;
using System.Linq;

namespace Lab1 {
	internal class Program {
		private static ConsoleHelpers _io;
		private static SimpleIterations _si;
		private const bool Debug = false;

		private static int Main(string[] args) {
			_io = new ConsoleHelpers();
			if(_io.ReadMatrix(args) == 1) {
				Console.Write("Программа завершена. Нажмите любую клавишу для выхода...");
				Console.ReadKey();
				return 1;
			}
			Console.WriteLine();

			_si = new SimpleIterations(_io.Matrix);

			var isDiagonallyDominant = _si.IsDiagonallyDominant(_si.Matrix);
            Console.WriteLine("Матрица {0}обладает {1}диагональным преобладанием", isDiagonallyDominant.Soft ? "" : "не ", isDiagonallyDominant.Strict ? "строгим " : "");
			Console.WriteLine("Коэффициенты сходимости:");
			_io.WriteVectorHorizontally(_si.CalculateAlphas(_si.Matrix), "");
			Console.WriteLine();

			if(!isDiagonallyDominant.Soft) {
				_si.MakeDiagonal();
				Console.WriteLine("Преобразованная матрица:");
				_io.WriteMatrix(_si.Matrix);
				Console.WriteLine();
				Console.WriteLine("Коэффициенты сходимости:");
				_io.WriteVectorHorizontally(_si.CalculateAlphas(_si.Matrix), "");
				Console.WriteLine();
			}

			_si.ExpressVariables();
			Console.WriteLine("Выраженные неизвестные:");
			_io.WriteMatrix(_si.ExpressedMatrix);
			Console.WriteLine();
			Console.WriteLine("Коэффициенты сходимости:");
			_io.WriteVectorHorizontally(_si.CalculateAlphas(_si.ExpressedMatrix), "");
			Console.WriteLine();
			/*
			Console.WriteLine("Матрица {0}обладает диагональным преобладанием", _si.IsDiagonallyDominant() ? "" : "не ");
			Console.WriteLine("Коэффициенты сходимости:");
			_io.WriteVectorHorizontally(_si.Alphas, "");
			Console.WriteLine();
			*/
			_si.SetInitialVector();
			Console.WriteLine("Вектор начальных значений:");
			_io.WriteVectorHorizontally(_si.InitialVector);
			Console.WriteLine();

			try {
				if(!Debug) {
					_si.Begin(_io.E);
				} else {
					do {
						Console.WriteLine("Итерация {0}:", _si.Steps);
						_io.WriteVectorHorizontally(_si.Step());
					} while(_si.Differences.Max() > _io.E && _si.Steps < 1000 && _si.Differences.Max() < SimpleIterations.MaxDivergence);
					if(_si.Steps >= SimpleIterations.CalculationLimit) {
						throw new Exception($"Количество итераций превысило установленный лимит ({SimpleIterations.CalculationLimit})");
					}
					if(_si.Differences.Max() >= SimpleIterations.MaxDivergence) {
						throw new Exception("Разность значений превысила установленный лимит - итерации расходятся, решений нет");
					}
				}

				Console.WriteLine("Решение найдено за {0} итераци{1}", _si.Steps, _io.WordEnding(_si.Steps));
				_io.WriteVectorHorizontally(_si.CurrentVector);
				Console.WriteLine();

				Console.WriteLine("Последняя разность значений:");
				_io.WriteVectorHorizontally(_si.Differences);
				Console.WriteLine();

				Console.WriteLine("Погрешности последнего вычисления:");
				_io.WriteVectorHorizontally(_si.Errors);
				Console.WriteLine();

				Console.WriteLine("Максимальная погрешность: {0}", _si.MaxError);
			}
			catch(Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine("Это произошло спустя {0} итераци{1}", _si.Steps, _io.WordEnding(_si.Steps));
			}
			


			Console.WriteLine();
			Console.Write("Программа завершена. Нажмите любую клавишу для выхода...");
			Console.ReadKey();
			return 0;
		}
	}
}