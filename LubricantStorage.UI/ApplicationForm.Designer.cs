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
            label1 = new Label();
            Create = new Button();
            Get = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(167, 204);
            label1.Name = "label1";
            label1.Size = new Size(389, 179);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // Create
            // 
            Create.Location = new Point(84, 61);
            Create.Name = "Create";
            Create.Size = new Size(75, 23);
            Create.TabIndex = 1;
            Create.Text = "Создать";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_ClickAsync;
            // 
            // Get
            // 
            Get.Location = new Point(420, 61);
            Get.Name = "Get";
            Get.Size = new Size(75, 23);
            Get.TabIndex = 2;
            Get.Text = "Получить";
            Get.UseVisualStyleBackColor = true;
            Get.Click += Get_ClickAsync;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Get);
            Controls.Add(Create);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        public Button Create;
        private Button Get;
    }
}
