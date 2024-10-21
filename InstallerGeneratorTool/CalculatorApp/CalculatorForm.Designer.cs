namespace CalculatorApp
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            display = new TextBox();
            button17 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(97, 133);
            button1.Name = "button1";
            button1.Size = new Size(75, 41);
            button1.TabIndex = 0;
            button1.Text = "7";
            button1.UseVisualStyleBackColor = true;
            button1.Click += NumberButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(168, 133);
            button2.Name = "button2";
            button2.Size = new Size(75, 41);
            button2.TabIndex = 1;
            button2.Text = "8";
            button2.UseVisualStyleBackColor = true;
            button2.Click += NumberButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(240, 133);
            button3.Name = "button3";
            button3.Size = new Size(75, 41);
            button3.TabIndex = 2;
            button3.Text = "9";
            button3.UseVisualStyleBackColor = true;
            button3.Click += NumberButton_Click;
            // 
            // button4
            // 
            button4.Location = new Point(97, 168);
            button4.Name = "button4";
            button4.Size = new Size(75, 41);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += NumberButton_Click;
            // 
            // button5
            // 
            button5.Location = new Point(97, 242);
            button5.Name = "button5";
            button5.Size = new Size(75, 41);
            button5.TabIndex = 4;
            button5.Text = "Back";
            button5.UseVisualStyleBackColor = true;
            button5.Click += BackspaceButton_Click;
            // 
            // button6
            // 
            button6.Location = new Point(240, 205);
            button6.Name = "button6";
            button6.Size = new Size(75, 41);
            button6.TabIndex = 5;
            button6.Text = "3";
            button6.UseVisualStyleBackColor = true;
            button6.Click += NumberButton_Click;
            // 
            // button7
            // 
            button7.Location = new Point(168, 205);
            button7.Name = "button7";
            button7.Size = new Size(75, 41);
            button7.TabIndex = 6;
            button7.Text = "2";
            button7.UseVisualStyleBackColor = true;
            button7.Click += NumberButton_Click;
            // 
            // button8
            // 
            button8.Location = new Point(97, 205);
            button8.Name = "button8";
            button8.Size = new Size(75, 41);
            button8.TabIndex = 7;
            button8.Text = "1";
            button8.UseVisualStyleBackColor = true;
            button8.Click += NumberButton_Click;
            // 
            // button9
            // 
            button9.Location = new Point(240, 168);
            button9.Name = "button9";
            button9.Size = new Size(75, 41);
            button9.TabIndex = 8;
            button9.Text = "6";
            button9.UseVisualStyleBackColor = true;
            button9.Click += NumberButton_Click;
            // 
            // button10
            // 
            button10.Location = new Point(168, 168);
            button10.Name = "button10";
            button10.Size = new Size(75, 41);
            button10.TabIndex = 9;
            button10.Text = "5";
            button10.UseVisualStyleBackColor = true;
            button10.Click += NumberButton_Click;
            // 
            // button11
            // 
            button11.Location = new Point(168, 242);
            button11.Name = "button11";
            button11.Size = new Size(75, 41);
            button11.TabIndex = 10;
            button11.Text = "0";
            button11.UseVisualStyleBackColor = true;
            button11.Click += NumberButton_Click;
            // 
            // button12
            // 
            button12.Location = new Point(240, 242);
            button12.Name = "button12";
            button12.Size = new Size(75, 41);
            button12.TabIndex = 11;
            button12.Text = ".";
            button12.UseVisualStyleBackColor = true;
            button12.Click += NumberButton_Click;
            // 
            // button13
            // 
            button13.Location = new Point(309, 133);
            button13.Name = "button13";
            button13.Size = new Size(75, 41);
            button13.TabIndex = 12;
            button13.Text = "/";
            button13.UseVisualStyleBackColor = true;
            button13.Click += OperatorButton_Click;
            // 
            // button14
            // 
            button14.Location = new Point(309, 168);
            button14.Name = "button14";
            button14.Size = new Size(75, 41);
            button14.TabIndex = 13;
            button14.Text = "*";
            button14.UseVisualStyleBackColor = true;
            button14.Click += OperatorButton_Click;
            // 
            // button15
            // 
            button15.Location = new Point(309, 205);
            button15.Name = "button15";
            button15.Size = new Size(75, 41);
            button15.TabIndex = 14;
            button15.Text = "+";
            button15.UseVisualStyleBackColor = true;
            button15.Click += OperatorButton_Click;
            // 
            // button16
            // 
            button16.Location = new Point(309, 242);
            button16.Name = "button16";
            button16.Size = new Size(75, 41);
            button16.TabIndex = 15;
            button16.Text = "-";
            button16.UseVisualStyleBackColor = true;
            button16.Click += OperatorButton_Click;
            // 
            // display
            // 
            display.AcceptsReturn = true;
            display.Location = new Point(97, 83);
            display.Name = "display";
            display.Size = new Size(287, 23);
            display.TabIndex = 16;
            // 
            // button17
            // 
            button17.Location = new Point(310, 307);
            button17.Name = "button17";
            button17.Size = new Size(75, 23);
            button17.TabIndex = 17;
            button17.Text = "Equals";
            button17.UseVisualStyleBackColor = true;
            button17.Click += EqualsButton_Click;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(button17);
            Controls.Add(display);
            Controls.Add(button16);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "CalculatorForm";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private TextBox display;
        private Button button17;
    }
}