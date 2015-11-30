/**
 * Университет ИТМО
 * Кафедра вычислительной техники
 * Вычислительная математика
 * 
 * Лабораторная работа №4
 * Решение обыкновенных дифференциальных уравнений. Задача Коши
 * Вариант: Метод Эйлера
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
using System.Windows.Forms;

namespace Lab4 {
	internal static class Program {
		public static List<Data> DataList;

		/// <summary>
		///     Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		private static void Main() {
			var ni = new NewtonInterpolation();
			var em = new EulersMethod();

			DataList = new List<Data>();
			DataList.Add(new Data("y' = cos y + 3x", (x, y) => Math.Cos(y) + 3*x, em, ni));
			DataList.Add(new Data("y'=sinx", (x, y) => Math.Sin(x), em, ni));


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}