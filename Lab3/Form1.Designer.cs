namespace Lab3 {
	partial class Form1 {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.dataButton = new System.Windows.Forms.Button();
			this.dataComboBox = new System.Windows.Forms.ComboBox();
			this.xTextBox = new System.Windows.Forms.TextBox();
			this.CalculateButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.yTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			this.SuspendLayout();
			// 
			// chart
			// 
			chartArea1.Name = "ChartArea1";
			this.chart.ChartAreas.Add(chartArea1);
			legend1.Alignment = System.Drawing.StringAlignment.Center;
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend1.Name = "Legend1";
			this.chart.Legends.Add(legend1);
			this.chart.Location = new System.Drawing.Point(12, 39);
			this.chart.Name = "chart";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series1.Legend = "Legend1";
			series1.LegendText = "Исходная функция";
			series1.Name = "Source";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
			series2.Legend = "Legend1";
			series2.LegendText = "Набор данных";
			series2.Name = "Data";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series3.Legend = "Legend1";
			series3.LegendText = "Интерполированная функция";
			series3.Name = "Interpolated";
			series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			this.chart.Series.Add(series1);
			this.chart.Series.Add(series2);
			this.chart.Series.Add(series3);
			this.chart.Size = new System.Drawing.Size(602, 312);
			this.chart.TabIndex = 0;
			this.chart.Text = "chart1";
			// 
			// dataButton
			// 
			this.dataButton.Location = new System.Drawing.Point(265, 11);
			this.dataButton.Name = "dataButton";
			this.dataButton.Size = new System.Drawing.Size(81, 21);
			this.dataButton.TabIndex = 1;
			this.dataButton.Text = "Рассчитать";
			this.dataButton.UseVisualStyleBackColor = true;
			this.dataButton.Click += new System.EventHandler(this.dataButton_Click);
			// 
			// dataComboBox
			// 
			this.dataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dataComboBox.FormattingEnabled = true;
			this.dataComboBox.Location = new System.Drawing.Point(100, 12);
			this.dataComboBox.Name = "dataComboBox";
			this.dataComboBox.Size = new System.Drawing.Size(159, 21);
			this.dataComboBox.TabIndex = 2;
			// 
			// xTextBox
			// 
			this.xTextBox.Location = new System.Drawing.Point(394, 11);
			this.xTextBox.Name = "xTextBox";
			this.xTextBox.Size = new System.Drawing.Size(52, 20);
			this.xTextBox.TabIndex = 3;
			// 
			// CalculateButton
			// 
			this.CalculateButton.Location = new System.Drawing.Point(533, 11);
			this.CalculateButton.Name = "CalculateButton";
			this.CalculateButton.Size = new System.Drawing.Size(77, 20);
			this.CalculateButton.TabIndex = 4;
			this.CalculateButton.Text = "Рассчитать";
			this.CalculateButton.UseVisualStyleBackColor = true;
			this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Набор данных:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(371, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "X:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(452, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Y:";
			// 
			// yTextBox
			// 
			this.yTextBox.Location = new System.Drawing.Point(475, 11);
			this.yTextBox.Name = "yTextBox";
			this.yTextBox.ReadOnly = true;
			this.yTextBox.Size = new System.Drawing.Size(52, 20);
			this.yTextBox.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(626, 363);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.yTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CalculateButton);
			this.Controls.Add(this.xTextBox);
			this.Controls.Add(this.dataComboBox);
			this.Controls.Add(this.dataButton);
			this.Controls.Add(this.chart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Лаб3";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart;
		private System.Windows.Forms.Button dataButton;
		private System.Windows.Forms.ComboBox dataComboBox;
		private System.Windows.Forms.TextBox xTextBox;
		private System.Windows.Forms.Button CalculateButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox yTextBox;
	}
}

