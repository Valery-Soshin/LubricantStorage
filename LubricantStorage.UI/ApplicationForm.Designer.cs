namespace LubricantStorage.UI
{
    partial class ApplicationForm
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
            AddLubricantButton = new Button();
            ListLubricants = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // AddLubricantButton
            // 
            AddLubricantButton.BackColor = Color.Transparent;
            AddLubricantButton.Font = new Font("Segoe UI", 12F);
            AddLubricantButton.Location = new Point(32, 237);
            AddLubricantButton.Name = "AddLubricantButton";
            AddLubricantButton.Size = new Size(259, 50);
            AddLubricantButton.TabIndex = 5;
            AddLubricantButton.Text = "Добавить масло в систему";
            AddLubricantButton.UseVisualStyleBackColor = false;
            AddLubricantButton.Click += AddLubricant_Click;
            // 
            // ListLubricants
            // 
            ListLubricants.BackColor = Color.Transparent;
            ListLubricants.Font = new Font("Segoe UI", 12F);
            ListLubricants.Location = new Point(32, 171);
            ListLubricants.Name = "ListLubricants";
            ListLubricants.Size = new Size(259, 50);
            ListLubricants.TabIndex = 3;
            ListLubricants.Text = "Список масел";
            ListLubricants.UseVisualStyleBackColor = false;
            ListLubricants.Click += ListLubricants_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.ImageLocation = "https://vestivrn.ru/i/3d/3d4a7718f6a8735f768bfc8fed757ef2.jpg";
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 450);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(32, 23);
            label1.Name = "label1";
            label1.Size = new Size(493, 43);
            label1.TabIndex = 5;
            label1.Text = "Система хранения смазочных материалов";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ApplicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(800, 450);
            Controls.Add(ListLubricants);
            Controls.Add(AddLubricantButton);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "ApplicationForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button AddLubricantButton;
        private Button ListLubricants;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
