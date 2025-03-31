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
            AddLubricantButton.BackColor = Color.White;
            AddLubricantButton.FlatStyle = FlatStyle.Popup;
            AddLubricantButton.Font = new Font("Segoe UI", 12F);
            AddLubricantButton.ForeColor = Color.White;
            AddLubricantButton.Image = Properties.Resources.MainBackground1;
            AddLubricantButton.ImageAlign = ContentAlignment.BottomCenter;
            AddLubricantButton.Location = new Point(32, 263);
            AddLubricantButton.Name = "AddLubricantButton";
            AddLubricantButton.Size = new Size(303, 56);
            AddLubricantButton.TabIndex = 5;
            AddLubricantButton.Text = "Добавить масло в систему";
            AddLubricantButton.UseVisualStyleBackColor = false;
            AddLubricantButton.Click += AddLubricant_Click;
            // 
            // ListLubricants
            // 
            ListLubricants.BackColor = Color.White;
            ListLubricants.FlatStyle = FlatStyle.Popup;
            ListLubricants.Font = new Font("Segoe UI", 12F);
            ListLubricants.ForeColor = Color.White;
            ListLubricants.Image = Properties.Resources.MainBackground1;
            ListLubricants.ImageAlign = ContentAlignment.BottomCenter;
            ListLubricants.Location = new Point(32, 183);
            ListLubricants.Name = "ListLubricants";
            ListLubricants.Size = new Size(303, 56);
            ListLubricants.TabIndex = 3;
            ListLubricants.Text = "Список масел";
            ListLubricants.UseVisualStyleBackColor = false;
            ListLubricants.Click += ListLubricants_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.Designer;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(784, 441);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14F);
            label1.ForeColor = Color.FromArgb(128, 255, 128);
            label1.Image = Properties.Resources.MainBackground1;
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(32, 9);
            label1.Name = "label1";
            label1.Size = new Size(718, 53);
            label1.TabIndex = 5;
            label1.Text = "Система хранения смазочных материалов";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ApplicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(784, 441);
            Controls.Add(ListLubricants);
            Controls.Add(AddLubricantButton);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            MaximumSize = new Size(800, 480);
            Name = "ApplicationForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Система хранения смазочных материалов";
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
