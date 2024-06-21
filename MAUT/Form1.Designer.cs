namespace MAUT
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
            treeView1 = new TreeView();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            button4 = new Button();
            groupBox1 = new GroupBox();
            button5 = new Button();
            textBox4 = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            izbrisiAlternativaButton = new Button();
            dodajAlternativaButton = new Button();
            textBox3 = new TextBox();
            label4 = new Label();
            listBox1 = new ListBox();
            openFileDialog1 = new OpenFileDialog();
            button6 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(18, 79);
            treeView1.Margin = new Padding(3, 4, 3, 4);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(271, 529);
            treeView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 28);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 1;
            label1.Text = "Problem odločanja: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(166, 24);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 27);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(286, 24);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 3;
            button1.Text = "Izberi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(297, 115);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(262, 27);
            textBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(286, 79);
            label2.Name = "label2";
            label2.Size = new Size(279, 20);
            label2.TabIndex = 5;
            label2.Text = "Dodaj parameter pod izbrani parameter:";
            // 
            // button2
            // 
            button2.Location = new Point(297, 150);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(262, 31);
            button2.TabIndex = 6;
            button2.Text = "Dodaj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(295, 189);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(264, 31);
            button3.TabIndex = 7;
            button3.Text = "Izbriši";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(297, 577);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(267, 31);
            button4.TabIndex = 10;
            button4.Text = "Funkcije koristnosti";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(treeView1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(565, 617);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hierarhični model";
            // 
            // button5
            // 
            button5.Location = new Point(297, 308);
            button5.Name = "button5";
            button5.Size = new Size(262, 29);
            button5.TabIndex = 13;
            button5.Text = "Dodaj";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(297, 275);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(262, 27);
            textBox4.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(297, 252);
            label3.Name = "label3";
            label3.Size = new Size(232, 20);
            label3.TabIndex = 11;
            label3.Text = "Dodaj utež izbranemu parametru:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(izbrisiAlternativaButton);
            groupBox2.Controls.Add(dodajAlternativaButton);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(listBox1);
            groupBox2.Location = new Point(595, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(355, 564);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Alternative";
            // 
            // izbrisiAlternativaButton
            // 
            izbrisiAlternativaButton.Location = new Point(151, 125);
            izbrisiAlternativaButton.Margin = new Padding(3, 4, 3, 4);
            izbrisiAlternativaButton.Name = "izbrisiAlternativaButton";
            izbrisiAlternativaButton.Size = new Size(198, 31);
            izbrisiAlternativaButton.TabIndex = 4;
            izbrisiAlternativaButton.Text = "Izbriši";
            izbrisiAlternativaButton.UseVisualStyleBackColor = true;
            izbrisiAlternativaButton.Click += izbrisiAlternativaButton_Click;
            // 
            // dodajAlternativaButton
            // 
            dodajAlternativaButton.Location = new Point(151, 87);
            dodajAlternativaButton.Margin = new Padding(3, 4, 3, 4);
            dodajAlternativaButton.Name = "dodajAlternativaButton";
            dodajAlternativaButton.Size = new Size(198, 31);
            dodajAlternativaButton.TabIndex = 3;
            dodajAlternativaButton.Text = "Dodaj";
            dodajAlternativaButton.UseVisualStyleBackColor = true;
            dodajAlternativaButton.Click += dodajAlternativaButton_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(151, 48);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(197, 27);
            textBox3.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(151, 24);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 1;
            label4.Text = "Alternative:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(7, 24);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(137, 524);
            listBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button6
            // 
            button6.Location = new Point(297, 343);
            button6.Name = "button6";
            button6.Size = new Size(262, 29);
            button6.TabIndex = 14;
            button6.Text = "Odstrani utež";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 648);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private Label label2;
        private Button button2;
        private Button button3;
        private SaveFileDialog saveFileDialog1;
        private Button button4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button izbrisiAlternativaButton;
        private Button dodajAlternativaButton;
        private TextBox textBox3;
        private Label label4;
        private ListBox listBox1;
        private OpenFileDialog openFileDialog1;
        private Button button5;
        private TextBox textBox4;
        private Label label3;
        private Button button6;
    }
}