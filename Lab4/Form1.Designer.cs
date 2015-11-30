namespace Lab4 {
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
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.dataComboBox = new System.Windows.Forms.ComboBox();
			this.x0TextBox = new System.Windows.Forms.TextBox();
			this.solveButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.y0TextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.endTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.accuracyTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.yTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.calculateButton = new System.Windows.Forms.Button();
			this.xTextBox = new System.Windows.Forms.TextBox();
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
			this.chart.Location = new System.Drawing.Point(12, 79);
			this.chart.Name = "chart";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
			series1.Legend = "Legend1";
			series1.LegendText = "Решение";
			series1.Name = "Data";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series2.Legend = "Legend1";
			series2.LegendText = "Интерполированная функция";
			series2.Name = "Interpolated";
			series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			this.chart.Series.Add(series1);
			this.chart.Series.Add(series2);
			this.chart.Size = new System.Drawing.Size(500, 272);
			this.chart.TabIndex = 0;
			this.chart.Text = "chart1";
			// 
			// dataComboBox
			// 
			this.dataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dataComboBox.FormattingEnabled = true;
			this.dataComboBox.Location = new System.Drawing.Point(84, 12);
			this.dataComboBox.Name = "dataComboBox";
			this.dataComboBox.Size = new System.Drawing.Size(159, 21);
			this.dataComboBox.TabIndex = 2;
			// 
			// x0TextBox
			// 
			this.x0TextBox.Location = new System.Drawing.Point(41, 48);
			this.x0TextBox.Name = "x0TextBox";
			this.x0TextBox.Size = new System.Drawing.Size(52, 20);
			this.x0TextBox.TabIndex = 3;
			this.x0TextBox.Tag = "X0";
			this.x0TextBox.Enter += new System.EventHandler(this.doubleTextBox_Enter);
			this.x0TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.doubleTextBox_Validating);
			// 
			// solveButton
			// 
			this.solveButton.Location = new System.Drawing.Point(435, 48);
			this.solveButton.Name = "solveButton";
			this.solveButton.Size = new System.Drawing.Size(77, 20);
			this.solveButton.TabIndex = 4;
			this.solveButton.Text = "Рассчитать";
			this.solveButton.UseVisualStyleBackColor = true;
			this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Уравнение:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "X0:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(99, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(23, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Y0:";
			// 
			// y0TextBox
			// 
			this.y0TextBox.Location = new System.Drawing.Point(128, 48);
			this.y0TextBox.Name = "y0TextBox";
			this.y0TextBox.Size = new System.Drawing.Size(52, 20);
			this.y0TextBox.TabIndex = 7;
			this.y0TextBox.Tag = "Y0";
			this.y0TextBox.Enter += new System.EventHandler(this.doubleTextBox_Enter);
			this.y0TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.doubleTextBox_Validating);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(186, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Конец отрезка:";
			// 
			// endTextBox
			// 
			this.endTextBox.Location = new System.Drawing.Point(277, 48);
			this.endTextBox.Name = "endTextBox";
			this.endTextBox.Size = new System.Drawing.Size(52, 20);
			this.endTextBox.TabIndex = 11;
			this.endTextBox.Tag = "конец отрезка";
			this.endTextBox.Enter += new System.EventHandler(this.doubleTextBox_Enter);
			this.endTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.doubleTextBox_Validating);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(335, 51);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Шаги:";
			// 
			// accuracyTextBox
			// 
			this.accuracyTextBox.Location = new System.Drawing.Point(377, 48);
			this.accuracyTextBox.Name = "accuracyTextBox";
			this.accuracyTextBox.Size = new System.Drawing.Size(52, 20);
			this.accuracyTextBox.TabIndex = 13;
			this.accuracyTextBox.Tag = "шаги";
			this.accuracyTextBox.Enter += new System.EventHandler(this.doubleTextBox_Enter);
			this.accuracyTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.doubleTextBox_Validating);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(354, 14);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(17, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Y:";
			// 
			// yTextBox
			// 
			this.yTextBox.Location = new System.Drawing.Point(377, 11);
			this.yTextBox.Name = "yTextBox";
			this.yTextBox.ReadOnly = true;
			this.yTextBox.Size = new System.Drawing.Size(52, 20);
			this.yTextBox.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(273, 14);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(17, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "X:";
			// 
			// calculateButton
			// 
			this.calculateButton.Enabled = false;
			this.calculateButton.Location = new System.Drawing.Point(435, 11);
			this.calculateButton.Name = "calculateButton";
			this.calculateButton.Size = new System.Drawing.Size(77, 20);
			this.calculateButton.TabIndex = 15;
			this.calculateButton.Text = "Рассчитать";
			this.calculateButton.UseVisualStyleBackColor = true;
			this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
			// 
			// xTextBox
			// 
			this.xTextBox.Location = new System.Drawing.Point(296, 11);
			this.xTextBox.Name = "xTextBox";
			this.xTextBox.Size = new System.Drawing.Size(52, 20);
			this.xTextBox.TabIndex = 14;
			this.xTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.doubleTextBox_Validating);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 363);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.yTextBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.calculateButton);
			this.Controls.Add(this.xTextBox);
			this.Controls.Add(this.accuracyTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.endTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.y0TextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.solveButton);
			this.Controls.Add(this.x0TextBox);
			this.Controls.Add(this.dataComboBox);
			this.Controls.Add(this.chart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Лаб4";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart;
		private System.Windows.Forms.ComboBox dataComboBox;
		private System.Windows.Forms.TextBox x0TextBox;
		private System.Windows.Forms.Button solveButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox y0TextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox endTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox accuracyTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox yTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button calculateButton;
		private System.Windows.Forms.TextBox xTextBox;
	}
}

