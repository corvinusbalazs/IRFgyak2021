﻿
namespace MNB_SOAP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chartRateData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePickerTol = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerIG = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mehet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRateData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(528, 540);
            this.dataGridView1.TabIndex = 0;
            // 
            // chartRateData
            // 
            this.chartRateData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartRateData.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRateData.Legends.Add(legend2);
            this.chartRateData.Location = new System.Drawing.Point(563, 98);
            this.chartRateData.Name = "chartRateData";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartRateData.Series.Add(series2);
            this.chartRateData.Size = new System.Drawing.Size(494, 540);
            this.chartRateData.TabIndex = 1;
            this.chartRateData.Text = "chart1";
            // 
            // dateTimePickerTol
            // 
            this.dateTimePickerTol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerTol.Location = new System.Drawing.Point(35, 36);
            this.dateTimePickerTol.Name = "dateTimePickerTol";
            this.dateTimePickerTol.Size = new System.Drawing.Size(250, 22);
            this.dateTimePickerTol.TabIndex = 2;
            // 
            // dateTimePickerIG
            // 
            this.dateTimePickerIG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerIG.Location = new System.Drawing.Point(328, 36);
            this.dateTimePickerIG.Name = "dateTimePickerIG";
            this.dateTimePickerIG.Size = new System.Drawing.Size(250, 22);
            this.dateTimePickerIG.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "EUR",
            "USD"});
            this.comboBox1.Location = new System.Drawing.Point(241, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(129, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // mehet
            // 
            this.mehet.Location = new System.Drawing.Point(668, 36);
            this.mehet.Name = "mehet";
            this.mehet.Size = new System.Drawing.Size(187, 36);
            this.mehet.TabIndex = 5;
            this.mehet.Text = "button1";
            this.mehet.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 652);
            this.Controls.Add(this.mehet);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePickerIG);
            this.Controls.Add(this.dateTimePickerTol);
            this.Controls.Add(this.chartRateData);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRateData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRateData;
        private System.Windows.Forms.DateTimePicker dateTimePickerTol;
        private System.Windows.Forms.DateTimePicker dateTimePickerIG;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button mehet;
    }
}

