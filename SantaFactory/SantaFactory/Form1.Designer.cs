
namespace SantaFactory
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
            this.components = new System.ComponentModel.Container();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SelectCar = new System.Windows.Forms.Button();
            this.SelectBall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(-1, 246);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(803, 207);
            this.mainPanel.TabIndex = 0;
            // 
            // SelectCar
            // 
            this.SelectCar.Location = new System.Drawing.Point(12, 12);
            this.SelectCar.Name = "SelectCar";
            this.SelectCar.Size = new System.Drawing.Size(130, 65);
            this.SelectCar.TabIndex = 1;
            this.SelectCar.Text = "Car";
            this.SelectCar.UseVisualStyleBackColor = true;
            this.SelectCar.Click += new System.EventHandler(this.SelectCar_Click);
            // 
            // SelectBall
            // 
            this.SelectBall.Location = new System.Drawing.Point(158, 12);
            this.SelectBall.Name = "SelectBall";
            this.SelectBall.Size = new System.Drawing.Size(134, 65);
            this.SelectBall.TabIndex = 2;
            this.SelectBall.Text = "Ball";
            this.SelectBall.UseVisualStyleBackColor = true;
            this.SelectBall.Click += new System.EventHandler(this.SelectBall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coming next:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectBall);
            this.Controls.Add(this.SelectCar);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button SelectCar;
        private System.Windows.Forms.Button SelectBall;
        private System.Windows.Forms.Label label1;
    }
}

