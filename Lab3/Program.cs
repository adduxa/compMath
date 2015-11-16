/**
 * Университет ИТМО
 * Кафедра вычислительной техники
 * Вычислительная математика
 * 
 * Лабораторная работа №3
 * Приближение функций
 * Вариант: Интерполирование многочленом Ньютона
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
using System.Linq;
using System.Windows.Forms;

namespace Lab3 {
	internal static class Program {
		public static List<Data> DataList;

		/// <summary>
		///     Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		private static void Main() {
			var ni = new NewtonInterpolation();

			DataList = new List<Data>();
			DataList.Add(new Data("sin 0..2π 4N", Math.Sin, 0, 2*Math.PI, 4, ni));
			DataList.Add(new Data("sin 0..2π 10N", Math.Sin, 0, 2*Math.PI, 10, ni));
			DataList.Add(new Data("sin 0..2π 10N отклонённый", DataList.Last(), ni).Deviate());
			DataList.Add(new Data("sin 0..50π 10N", Math.Sin, 0, 50*Math.PI, 10, ni));


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}