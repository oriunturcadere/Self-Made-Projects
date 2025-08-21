namespace Simple_Calc
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Back = new System.Windows.Forms.Button();
            this.Forward = new System.Windows.Forms.Button();
            this.Multiply = new System.Windows.Forms.Button();
            this.Subtract = new System.Windows.Forms.Button();
            this.Divide = new System.Windows.Forms.Button();
            this.Square = new System.Windows.Forms.Button();
            this.Cube = new System.Windows.Forms.Button();
            this.Sqr = new System.Windows.Forms.Button();
            this.Rooting = new System.Windows.Forms.Button();
            this.Power = new System.Windows.Forms.Button();
            this.Decimal = new System.Windows.Forms.CheckBox();
            this.BigInt = new System.Windows.Forms.CheckBox();
            this.GCD = new System.Windows.Forms.Button();
            this.LCM = new System.Windows.Forms.Button();
            this.Factorial = new System.Windows.Forms.Button();
            this.Prime = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Infn = new System.Windows.Forms.CheckBox();
            this.Inf = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label2.Location = new System.Drawing.Point(12, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Y:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(55)))), ((int)(((byte)(50)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBox1.Location = new System.Drawing.Point(68, 115);
            this.textBox1.MaxLength = 2147483647;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(642, 54);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(55)))), ((int)(((byte)(50)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBox2.Location = new System.Drawing.Point(68, 195);
            this.textBox2.MaxLength = 2147483647;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(642, 54);
            this.textBox2.TabIndex = 1;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Add.Location = new System.Drawing.Point(68, 383);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(260, 104);
            this.Add.TabIndex = 2;
            this.Add.Text = "X+Y";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(749, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(204)))), ((int)(((byte)(134)))));
            this.textBox3.Location = new System.Drawing.Point(68, 12);
            this.textBox3.MaxLength = 2147483647;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(642, 97);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(244)))), ((int)(((byte)(210)))));
            this.Back.Location = new System.Drawing.Point(680, 295);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(111, 68);
            this.Back.TabIndex = 5;
            this.Back.Text = "<";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Forward
            // 
            this.Forward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.Forward.FlatAppearance.BorderSize = 0;
            this.Forward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Forward.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Forward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(244)))), ((int)(((byte)(210)))));
            this.Forward.Location = new System.Drawing.Point(797, 295);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(111, 68);
            this.Forward.TabIndex = 5;
            this.Forward.Text = ">";
            this.Forward.UseVisualStyleBackColor = false;
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // Multiply
            // 
            this.Multiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Multiply.FlatAppearance.BorderSize = 0;
            this.Multiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Multiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Multiply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Multiply.Location = new System.Drawing.Point(358, 383);
            this.Multiply.Name = "Multiply";
            this.Multiply.Size = new System.Drawing.Size(260, 104);
            this.Multiply.TabIndex = 2;
            this.Multiply.Text = "X*Y";
            this.Multiply.UseVisualStyleBackColor = false;
            this.Multiply.Click += new System.EventHandler(this.Multiply_Click);
            // 
            // Subtract
            // 
            this.Subtract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Subtract.FlatAppearance.BorderSize = 0;
            this.Subtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Subtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Subtract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Subtract.Location = new System.Drawing.Point(68, 517);
            this.Subtract.Name = "Subtract";
            this.Subtract.Size = new System.Drawing.Size(260, 104);
            this.Subtract.TabIndex = 2;
            this.Subtract.Text = "X-Y";
            this.Subtract.UseVisualStyleBackColor = false;
            this.Subtract.Click += new System.EventHandler(this.Subtract_Click);
            // 
            // Divide
            // 
            this.Divide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Divide.FlatAppearance.BorderSize = 0;
            this.Divide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Divide.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Divide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Divide.Location = new System.Drawing.Point(358, 517);
            this.Divide.Name = "Divide";
            this.Divide.Size = new System.Drawing.Size(260, 104);
            this.Divide.TabIndex = 2;
            this.Divide.Text = "X/Y";
            this.Divide.UseVisualStyleBackColor = false;
            this.Divide.Click += new System.EventHandler(this.Divide_Click);
            // 
            // Square
            // 
            this.Square.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Square.FlatAppearance.BorderSize = 0;
            this.Square.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Square.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Square.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Square.Location = new System.Drawing.Point(68, 651);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(260, 104);
            this.Square.TabIndex = 2;
            this.Square.Text = "X^2";
            this.Square.UseVisualStyleBackColor = false;
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Cube
            // 
            this.Cube.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Cube.FlatAppearance.BorderSize = 0;
            this.Cube.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cube.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Cube.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Cube.Location = new System.Drawing.Point(358, 651);
            this.Cube.Name = "Cube";
            this.Cube.Size = new System.Drawing.Size(260, 104);
            this.Cube.TabIndex = 2;
            this.Cube.Text = "X^3";
            this.Cube.UseVisualStyleBackColor = false;
            this.Cube.Click += new System.EventHandler(this.Cube_Click);
            // 
            // Sqr
            // 
            this.Sqr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Sqr.FlatAppearance.BorderSize = 0;
            this.Sqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sqr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Sqr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Sqr.Location = new System.Drawing.Point(68, 782);
            this.Sqr.Name = "Sqr";
            this.Sqr.Size = new System.Drawing.Size(260, 104);
            this.Sqr.TabIndex = 2;
            this.Sqr.Text = "²√X";
            this.Sqr.UseVisualStyleBackColor = false;
            this.Sqr.Click += new System.EventHandler(this.Sqr_Click);
            // 
            // Rooting
            // 
            this.Rooting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Rooting.FlatAppearance.BorderSize = 0;
            this.Rooting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Rooting.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Rooting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Rooting.Location = new System.Drawing.Point(358, 782);
            this.Rooting.Name = "Rooting";
            this.Rooting.Size = new System.Drawing.Size(260, 104);
            this.Rooting.TabIndex = 2;
            this.Rooting.Text = "ʸ√X";
            this.Rooting.UseVisualStyleBackColor = false;
            this.Rooting.Click += new System.EventHandler(this.Rooting_Click);
            // 
            // Power
            // 
            this.Power.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Power.FlatAppearance.BorderSize = 0;
            this.Power.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Power.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Power.Location = new System.Drawing.Point(648, 651);
            this.Power.Name = "Power";
            this.Power.Size = new System.Drawing.Size(260, 104);
            this.Power.TabIndex = 2;
            this.Power.Text = "X^Y";
            this.Power.UseVisualStyleBackColor = false;
            this.Power.Click += new System.EventHandler(this.Power_Click);
            // 
            // Decimal
            // 
            this.Decimal.AutoSize = true;
            this.Decimal.Checked = true;
            this.Decimal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Decimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.Decimal.Location = new System.Drawing.Point(68, 255);
            this.Decimal.Name = "Decimal";
            this.Decimal.Size = new System.Drawing.Size(114, 34);
            this.Decimal.TabIndex = 6;
            this.Decimal.Text = "Decimal";
            this.Decimal.UseVisualStyleBackColor = true;
            this.Decimal.CheckedChanged += new System.EventHandler(this.Decimal_CheckedChanged);
            // 
            // BigInt
            // 
            this.BigInt.AutoSize = true;
            this.BigInt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.BigInt.Location = new System.Drawing.Point(68, 295);
            this.BigInt.Name = "BigInt";
            this.BigInt.Size = new System.Drawing.Size(134, 34);
            this.BigInt.TabIndex = 6;
            this.BigInt.Text = "BigInteger";
            this.BigInt.UseVisualStyleBackColor = true;
            this.BigInt.CheckedChanged += new System.EventHandler(this.BigInt_CheckedChanged);
            // 
            // GCD
            // 
            this.GCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.GCD.FlatAppearance.BorderSize = 0;
            this.GCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.GCD.Location = new System.Drawing.Point(648, 383);
            this.GCD.Name = "GCD";
            this.GCD.Size = new System.Drawing.Size(260, 104);
            this.GCD.TabIndex = 2;
            this.GCD.Text = "GCD";
            this.GCD.UseVisualStyleBackColor = false;
            this.GCD.Click += new System.EventHandler(this.GCD_Click);
            // 
            // LCM
            // 
            this.LCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.LCM.FlatAppearance.BorderSize = 0;
            this.LCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LCM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.LCM.Location = new System.Drawing.Point(648, 517);
            this.LCM.Name = "LCM";
            this.LCM.Size = new System.Drawing.Size(260, 104);
            this.LCM.TabIndex = 2;
            this.LCM.Text = "LCM";
            this.LCM.UseVisualStyleBackColor = false;
            this.LCM.Click += new System.EventHandler(this.LCM_Click);
            // 
            // Factorial
            // 
            this.Factorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Factorial.FlatAppearance.BorderSize = 0;
            this.Factorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Factorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Factorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Factorial.Location = new System.Drawing.Point(648, 782);
            this.Factorial.Name = "Factorial";
            this.Factorial.Size = new System.Drawing.Size(260, 104);
            this.Factorial.TabIndex = 2;
            this.Factorial.Text = "X!";
            this.Factorial.UseVisualStyleBackColor = false;
            this.Factorial.Click += new System.EventHandler(this.Factorial_Click);
            // 
            // Prime
            // 
            this.Prime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(46)))));
            this.Prime.FlatAppearance.BorderSize = 0;
            this.Prime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Prime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Prime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(235)))), ((int)(((byte)(150)))));
            this.Prime.Location = new System.Drawing.Point(68, 905);
            this.Prime.Name = "Prime";
            this.Prime.Size = new System.Drawing.Size(840, 104);
            this.Prime.TabIndex = 2;
            this.Prime.Text = "X == Prime?";
            this.Prime.UseVisualStyleBackColor = false;
            this.Prime.Click += new System.EventHandler(this.Prime_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(46)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(223)))), ((int)(((byte)(122)))));
            this.button1.Location = new System.Drawing.Point(914, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 626);
            this.button1.TabIndex = 2;
            this.button1.Text = "New Instance";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.New_Click);
            // 
            // Infn
            // 
            this.Infn.AutoSize = true;
            this.Infn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.Infn.Location = new System.Drawing.Point(68, 335);
            this.Infn.Name = "Infn";
            this.Infn.Size = new System.Drawing.Size(115, 34);
            this.Infn.TabIndex = 6;
            this.Infn.Text = "InfiNum";
            this.Infn.UseVisualStyleBackColor = true;
            this.Infn.CheckedChanged += new System.EventHandler(this.Infn_CheckedChanged);
            // 
            // Inf
            // 
            this.Inf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(45)))), ((int)(((byte)(69)))));
            this.Inf.FlatAppearance.BorderSize = 0;
            this.Inf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Inf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Inf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(160)))), ((int)(((byte)(198)))));
            this.Inf.Location = new System.Drawing.Point(1035, 317);
            this.Inf.Name = "Inf";
            this.Inf.Size = new System.Drawing.Size(60, 60);
            this.Inf.TabIndex = 2;
            this.Inf.Text = "Info";
            this.Inf.UseVisualStyleBackColor = false;
            this.Inf.Click += new System.EventHandler(this.Inf_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(771, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(335, 123);
            this.button3.TabIndex = 7;
            this.button3.Text = "Number ╠MÆ╣ (99.999_999_999_999 ^ 99_999)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1109, 1044);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Inf);
            this.Controls.Add(this.Infn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Prime);
            this.Controls.Add(this.Factorial);
            this.Controls.Add(this.LCM);
            this.Controls.Add(this.GCD);
            this.Controls.Add(this.BigInt);
            this.Controls.Add(this.Decimal);
            this.Controls.Add(this.Power);
            this.Controls.Add(this.Rooting);
            this.Controls.Add(this.Sqr);
            this.Controls.Add(this.Cube);
            this.Controls.Add(this.Square);
            this.Controls.Add(this.Divide);
            this.Controls.Add(this.Subtract);
            this.Controls.Add(this.Multiply);
            this.Controls.Add(this.Forward);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Simple Calc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Forward;
        private System.Windows.Forms.Button Multiply;
        private System.Windows.Forms.Button Subtract;
        private System.Windows.Forms.Button Divide;
        private System.Windows.Forms.Button Square;
        private System.Windows.Forms.Button Cube;
        private System.Windows.Forms.Button Sqr;
        private System.Windows.Forms.Button Rooting;
        private System.Windows.Forms.Button Power;
        private System.Windows.Forms.CheckBox Decimal;
        private System.Windows.Forms.CheckBox BigInt;
        private System.Windows.Forms.Button GCD;
        private System.Windows.Forms.Button LCM;
        private System.Windows.Forms.Button Factorial;
        private System.Windows.Forms.Button Prime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox Infn;
        private System.Windows.Forms.Button Inf;
        private System.Windows.Forms.Button button3;
    }
}

