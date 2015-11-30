using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab4 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			dataComboBox.Items.AddRange(Program.DataList.Select(data => data.Name).ToArray());
			dataComboBox.SelectedIndex = 0;
			x0TextBox.Text = y0TextBox.Text = "0";
			endTextBox.Text = "5";
			accuracyTextBox.Text = "10";
		}
		
		private void calculateButton_Click(object sender, EventArgs e) {
			try {
				var steps = int.Parse(accuracyTextBox.Text);

				yTextBox.Text = Program.DataList[dataComboBox.SelectedIndex].Interpolate(double.Parse(xTextBox.Text), steps).ToString();
			}
			catch(FormatException) {
				MessageBox.Show("Ожидается ввод вещественного числа", "Некорректное значение!");
			}
		}

		private void solveButton_Click(object sender, EventArgs e) {
			try {
				var x0 = double.Parse(x0TextBox.Text);
				var y0 = double.Parse(y0TextBox.Text);
				var end = double.Parse(endTextBox.Text);
				var accuracy = int.Parse(accuracyTextBox.Text);

				Program.DataList[dataComboBox.SelectedIndex].Solve(x0, y0, end, accuracy);
				calculateButton.Enabled = true;

				var data = Program.DataList[dataComboBox.SelectedIndex].SourcePoints;
				chart.Series.FindByName("Data").Points.Clear();
				foreach(var dataPoint in data) {
					chart.Series.FindByName("Data").Points.Add(dataPoint);
				}

				chart.Series.FindByName("Interpolated").Points.Clear();
				foreach(var dataPoint in Program.DataList[dataComboBox.SelectedIndex].InterpolatedPoints) {
					chart.Series.FindByName("Interpolated").Points.Add(dataPoint);
				}
			}
			catch(FormatException) {
				MessageBox.Show("Ожидается ввод вещественного числа", "Некорректное значение!");
			}
		}

		private void doubleTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
			try {
				double.Parse(((TextBox)sender).Text);
			}
			catch(FormatException) {
				((TextBox)sender).ForeColor = Color.Red;
			}
		}
		
		private void doubleTextBox_Enter(object sender, EventArgs e) {
			((TextBox)sender).ResetForeColor();
		}
	}
}