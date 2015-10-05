using System;
using System.Linq;

namespace Lab1 {
internal class SimpleIterations {
public const int CalculationLimit = 1000;
public const long MaxDivergence = long.MaxValue;

private readonly int _dimencionl;
private readonly int _dimencionc;

public readonly double[,] Matrix;
private double[] _lastVector;
		
public readonly double[] InitialVector;

public SimpleIterations(double[,] matrix) {
	Matrix = matrix;
	_dimencionl = Matrix.GetLength(0);
	_dimencionc = Matrix.GetLength(1);
	ExpressedMatrix = new double[_dimencionl, _dimencionc];
	InitialVector = new double[_dimencionl];
	_lastVector = new double[_dimencionl];
	CurrentVector = new double[_dimencionl];
}

public readonly double[,] ExpressedMatrix;

public int Steps { get; private set; }

public double[] Differences {
	get {
		var differences = new double[_dimencionl];
		for(var l = 0; l < _dimencionl; l++) {
			differences[l] = Math.Abs(_lastVector[l] - CurrentVector[l]);
		}
		return differences;
	}
}

public double[] Errors {
	get {
		var errors = new double[_dimencionl];
		var alphas = CalculateAlphas(ExpressedMatrix);
		for(int l = 0; l < _dimencionl; l++) {
			errors[l] = alphas[l]/(1 - alphas[l])*Differences[l];
		}
		return errors;
	}
}

public double MaxError {
	get {
		var alphas = CalculateAlphas(ExpressedMatrix);
		return alphas.Max()/(1 - alphas.Max())*Differences.Max();
	}
}

public double[] CurrentVector { get; }

public void MakeDiagonal() {
	for(var l = 0; l < _dimencionl; l++) {
		var id = Array.IndexOf(GetColumn(Matrix, l, true, l), GetColumn(Matrix, l, true, l).Max());
		if(id > l) {
			SwapRows(Matrix, l, id);
		}
	}
}

private double[] GetColumn(double[,] array, int index, bool abs = false, int startIndex = 0) {
	var column = new double[array.GetLength(0)];
	for(var l = startIndex; l < array.GetLength(0); l++) {
		column[l] = abs ? Math.Abs(array[l, index]) : array[l, index];
	}
	return column;
}

private void SwapRows(double[,] a, int indexOne, int indexTwo) {
	for(var i = 0; i <= a.GetUpperBound(1); ++i) {
		var t = a[indexOne, i];
		a[indexOne, i] = a[indexTwo, i];
		a[indexTwo, i] = t;
	}
}

public void ExpressVariables() {
	for(var l = 0; l < _dimencionl; l++) {
		for(var c = 0; c < _dimencionc; c++) {
			ExpressedMatrix[l, c] = -1*Matrix[l, c]/Matrix[l, l];
		}
		ExpressedMatrix[l, l] = 0;
	}
}

public double[] CalculateAlphas(double[,] matrix) {
	var alphas = new double[_dimencionl];
	for(var l = 0; l < _dimencionl; l++) {
		for(var c = 0; c < _dimencionc - 1; c++) {
			alphas[l] += l == c ? 0 : Math.Abs(matrix[l, c]);
		}
	}
	return alphas;
}

public struct DiagonallyDominantResults {
	public DiagonallyDominantResults(bool soft, bool strict) {
		Soft = soft;
		Strict = strict;
	}
	public readonly bool Soft;
	public readonly bool Strict;
}

public DiagonallyDominantResults IsDiagonallyDominant(double[,] matrix) {
	bool resultSoft = true;
	bool resultStrict = true;
	bool resultStrictOnce = false;
	var alphas = CalculateAlphas(matrix);
    for(int l = 0; l < alphas.Length; l++) {
		var alpha = alphas[l];
		resultSoft &= alpha <= Math.Abs(matrix[l, l]);
		resultStrictOnce |= alpha < Math.Abs(matrix[l, l]);
		resultStrict &= alpha < Math.Abs(matrix[l, l]);
	}
			
	return new DiagonallyDominantResults(resultSoft & resultStrictOnce, resultStrict);
}

public void SetInitialVector() {
	for(var l = 0; l < _dimencionl; l++) {
		InitialVector[l] = ExpressedMatrix[l, _dimencionc - 1];
	}
}


public void Begin(double E) {
	do {
		Step();
	} while(Differences.Max() > E && Steps < CalculationLimit && Differences.Max() < MaxDivergence);
	if(Steps >= CalculationLimit) {
		throw new Exception($"Количество итераций превысило установленный лимит ({CalculationLimit})");
	}
	if(Differences.Max() >= MaxDivergence) {
		throw new Exception("Разность значений превысила установленный лимит - итерации расходятся, невозможно найти решение");
	}
}

public double[] Step() {
	_lastVector = Steps > 0 ? (double[])CurrentVector.Clone() : (double[])InitialVector.Clone();
	Array.Clear(CurrentVector, 0, _dimencionl);
	for(var l = 0; l < _dimencionl; l++) {
		for(var c = 0; c < _dimencionc - 1; c++) {
			CurrentVector[l] += ExpressedMatrix[l, c]*_lastVector[c];
		}
		CurrentVector[l] += ExpressedMatrix[l, _dimencionc - 1];
	}
	Steps++;
	return CurrentVector;
}
}
}