
namespace BaseSim2021
{
    partial class ChangePolitics
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
            this.politicsSlider = new System.Windows.Forms.TrackBar();
            this.politicsNumericUp = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.politicsSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.politicsNumericUp)).BeginInit();
            this.SuspendLayout();
            // 
            // politicsSlider
            // 
            this.politicsSlider.Location = new System.Drawing.Point(51, 76);
            this.politicsSlider.Maximum = 100;
            this.politicsSlider.Minimum = 1;
            this.politicsSlider.Name = "politicsSlider";
            this.politicsSlider.Size = new System.Drawing.Size(159, 45);
            this.politicsSlider.TabIndex = 0;
            this.politicsSlider.Value = 1;
            this.politicsSlider.Scroll += new System.EventHandler(this.politicsSlider_Scroll);
            // 
            // politicsNumericUp
            // 
            this.politicsNumericUp.Location = new System.Drawing.Point(105, 124);
            this.politicsNumericUp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.politicsNumericUp.Name = "politicsNumericUp";
            this.politicsNumericUp.Size = new System.Drawing.Size(49, 20);
            this.politicsNumericUp.TabIndex = 1;
            this.politicsNumericUp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.politicsNumericUp.ValueChanged += new System.EventHandler(this.politicsNumericUp_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "100";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(135, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "CANCEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(37, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangePolitics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 229);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.politicsNumericUp);
            this.Controls.Add(this.politicsSlider);
            this.Name = "ChangePolitics";
            this.Text = "ChangePolitics";
            ((System.ComponentModel.ISupportInitialize)(this.politicsSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.politicsNumericUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar politicsSlider;
        private System.Windows.Forms.NumericUpDown politicsNumericUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}