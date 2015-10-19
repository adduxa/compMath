using System;

namespace Lab2 {
	internal class Func {
		private readonly Func<double, double> _function;
		private readonly string _mathNotation;

		public Func(string mathNotation, Func<double, double> function) {
			_mathNotation = mathNotation;
			_function = function;
		}

		public double Calculate(double argument) {
			return _function(argument);
		}

		public override string ToString() {
			return _mathNotation;
		}
	}
}