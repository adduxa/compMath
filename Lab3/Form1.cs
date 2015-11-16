using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab3 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			dataComboBox.Items.AddRange(Program.DataList.Select(data => data.Name).ToArray());
			dataComboBox.SelectedIndex = 0;
			dataButton_Click(sender, e);
		}

		private void dataButton_Click(object sender, EventArgs e) {
			chart.Series.FindByName("Data").Points.Clear();
			Program.DataList[dataComboBox.SelectedIndex].Points.ForEach(point => chart.Series.FindByName("Data").Points.Add(point));

			chart.Series.FindByName("Source").Points.Clear();
			Program.DataList[dataComboBox.SelectedIndex].SourcePoints.ForEach(point => chart.Series.FindByName("Source").Points.Add(point));

			chart.Series.FindByName("Interpolated").Points.Clear();
			Program.DataList[dataComboBox.SelectedIndex].InterpolatedPoints.ForEach(point => chart.Series.FindByName("Interpolated").Points.Add(point));
		}

		private void CalculateButton_Click(object sender, EventArgs e) {
			try {
				yTextBox.Text = Program.DataList[dataComboBox.SelectedIndex].Interpolate(double.Parse(xTextBox.Text)).ToString();
			}
			catch(FormatException) {
				yTextBox.Text = "ERROR";
			}
		}
	}
}