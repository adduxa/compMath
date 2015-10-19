using System;

namespace Lab2 {
	internal class TrapezoidalRule {
		private const long InitialSegments = 10;

		public CalculationResult Calculate(Func func, double begin, double end, double accuracy) {
			var sign = Math.Sign(end - begin);
			double[] temp = {Math.Min(begin, end), Math.Max(begin, end)};
			begin = temp[0];
			end = temp[1];
			var segments = InitialSegments/2;
			var res = double.PositiveInfinity;
			double prevRes;
			do {
				prevRes = res;
				segments *= 2;
				var h = (end - begin)/segments;
				res = (func.Calculate(begin) + func.Calculate(end))/2;
				for(var i = 1; i <= segments - 1; i++) {
					res += func.Calculate(begin + h*i);
				}
				res *= h;
			} while((Math.Abs(res - prevRes))/3 > accuracy);
			res *= sign;
			return new CalculationResult(res, segments, (Math.Abs(res - prevRes))/3);
		}

		public struct CalculationResult {
			public readonly double Result;
			public readonly long Segments;
			public readonly double Accuracy;

			public CalculationResult(double result, long segments, double accuracy) {
				Result = result;
				Segments = segments;
				Accuracy = accuracy;
			}
		}
	}
}