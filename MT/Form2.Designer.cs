namespace MT
{
    partial class Form2
    {
        private static int Form2Size0 = 800;
        private static double coef = 1.2;
        private static int Form2Size1 = (int)(Form2Size0 * coef);
        private static int ButtonCount = 8;
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            label1 = new Label();
            label2 = new Label();
            button9 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLightLight;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.Location = new Point(0, 700);
            button1.Name = "button1";
            button1.Size = new Size(80, 100);
            button1.TabIndex = 0;
            button1.Text = "A";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(80, 700);
            button2.Name = "button2";
            button2.Size = new Size(80, 100);
            button2.TabIndex = 1;
            button2.Text = "S";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(160, 700);
            button3.Name = "button3";
            button3.Size = new Size(80, 100);
            button3.TabIndex = 0;
            button3.Text = "D";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(240, 700);
            button4.Name = "button4";
            button4.Size = new Size(80, 100);
            button4.TabIndex = 1;
            button4.Text = "F";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(320, 700);
            button5.Name = "button5";
            button5.Size = new Size(80, 100);
            button5.TabIndex = 0;
            button5.Text = "G";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(400, 700);
            button6.Name = "button6";
            button6.Size = new Size(80, 100);
            button6.TabIndex = 1;
            button6.Text = "H";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(480, 700);
            button7.Name = "button7";
            button7.Size = new Size(80, 100);
            button7.TabIndex = 0;
            button7.Text = "J";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(560, 700);
            button8.Name = "button8";
            button8.Size = new Size(80, 100);
            button8.TabIndex = 1;
            button8.Text = "K";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(180, 253);
            label1.Name = "label1";
            label1.Size = new Size(300, 62);
            label1.TabIndex = 2;
            label1.Text = "Ваши очки!!!";
            label1.Visible = false;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(272, 357);
            label2.Name = "label2";
            label2.Size = new Size(89, 54);
            label2.TabIndex = 3;
            label2.Text = "100";
            label2.Visible = false;
            // 
            // button9
            // 
            button9.Location = new Point(160, 598);
            button9.Name = "button9";
            button9.Size = new Size(335, 77);
            button9.TabIndex = 4;
            button9.Text = "Main menu";
            button9.UseVisualStyleBackColor = true;
            button9.Visible = false;
            button9.Click += button9_Click;
            // 
            // Form2
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(644, 799);
            Controls.Add(button9);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button8);
            Controls.Add(button4);
            Controls.Add(button7);
            Controls.Add(button3);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button5);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
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
        private Label label1;
        private Label label2;
        private Button button9;
    }
}