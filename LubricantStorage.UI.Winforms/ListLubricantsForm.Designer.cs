namespace LubricantStorage.UI
{
    partial class ListLubricantsForm
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
            Table = new DataGridView();
            LubricantName = new DataGridViewTextBoxColumn();
            KinematicViscosity40 = new DataGridViewTextBoxColumn();
            KinematicViscosity100 = new DataGridViewTextBoxColumn();
            ViscosityIndex = new DataGridViewTextBoxColumn();
            PourPoint = new DataGridViewTextBoxColumn();
            FlashPoint = new DataGridViewTextBoxColumn();
            EvaporationTemperature = new DataGridViewTextBoxColumn();
            Density = new DataGridViewTextBoxColumn();
            AcidNumber = new DataGridViewTextBoxColumn();
            BaseNumber = new DataGridViewTextBoxColumn();
            SulfatedAshContent = new DataGridViewTextBoxColumn();
            WaterContent = new DataGridViewTextBoxColumn();
            Contaminants = new DataGridViewTextBoxColumn();
            OxidativeStability = new DataGridViewTextBoxColumn();
            AdditiveComposition = new DataGridViewTextBoxColumn();
            MaterialCompatibility = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Table).BeginInit();
            SuspendLayout();
            // 
            // Table
            // 
            Table.AllowUserToAddRows = false;
            Table.AllowUserToDeleteRows = false;
            Table.AllowUserToResizeColumns = false;
            Table.AllowUserToResizeRows = false;
            Table.BackgroundColor = Color.White;
            Table.BorderStyle = BorderStyle.None;
            Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Table.Columns.AddRange(new DataGridViewColumn[] { LubricantName, KinematicViscosity40, KinematicViscosity100, ViscosityIndex, PourPoint, FlashPoint, EvaporationTemperature, Density, AcidNumber, BaseNumber, SulfatedAshContent, WaterContent, Contaminants, OxidativeStability, AdditiveComposition, MaterialCompatibility });
            Table.EditMode = DataGridViewEditMode.EditOnEnter;
            Table.Location = new Point(12, 15);
            Table.Margin = new Padding(3, 10, 3, 3);
            Table.Name = "Table";
            Table.ReadOnly = true;
            Table.ShowCellErrors = false;
            Table.ShowCellToolTips = false;
            Table.ShowEditingIcon = false;
            Table.ShowRowErrors = false;
            Table.Size = new Size(1647, 849);
            Table.TabIndex = 0;
            // 
            // LubricantName
            // 
            LubricantName.HeaderText = "Название";
            LubricantName.Name = "LubricantName";
            LubricantName.ReadOnly = true;
            // 
            // KinematicViscosity40
            // 
            KinematicViscosity40.HeaderText = "Вязкость при 40°C";
            KinematicViscosity40.Name = "KinematicViscosity40";
            KinematicViscosity40.ReadOnly = true;
            // 
            // KinematicViscosity100
            // 
            KinematicViscosity100.HeaderText = "Вязкость при 100°C";
            KinematicViscosity100.Name = "KinematicViscosity100";
            KinematicViscosity100.ReadOnly = true;
            // 
            // ViscosityIndex
            // 
            ViscosityIndex.HeaderText = "Индекс вязкости";
            ViscosityIndex.Name = "ViscosityIndex";
            ViscosityIndex.ReadOnly = true;
            // 
            // PourPoint
            // 
            PourPoint.HeaderText = "Температура застывания (°C)";
            PourPoint.Name = "PourPoint";
            PourPoint.ReadOnly = true;
            // 
            // FlashPoint
            // 
            FlashPoint.HeaderText = "Температура вспышки (°C)";
            FlashPoint.Name = "FlashPoint";
            FlashPoint.ReadOnly = true;
            // 
            // EvaporationTemperature
            // 
            EvaporationTemperature.HeaderText = "Температура испарения (°C)";
            EvaporationTemperature.Name = "EvaporationTemperature";
            EvaporationTemperature.ReadOnly = true;
            // 
            // Density
            // 
            Density.HeaderText = "Плотность при 15°C (г/см³)";
            Density.Name = "Density";
            Density.ReadOnly = true;
            // 
            // AcidNumber
            // 
            AcidNumber.HeaderText = "Кислотное число (TAN)";
            AcidNumber.Name = "AcidNumber";
            AcidNumber.ReadOnly = true;
            // 
            // BaseNumber
            // 
            BaseNumber.HeaderText = "Щелочное число (TBN)";
            BaseNumber.Name = "BaseNumber";
            BaseNumber.ReadOnly = true;
            // 
            // SulfatedAshContent
            // 
            SulfatedAshContent.HeaderText = "Сульфатная зольность (%)";
            SulfatedAshContent.Name = "SulfatedAshContent";
            SulfatedAshContent.ReadOnly = true;
            // 
            // WaterContent
            // 
            WaterContent.HeaderText = "Содержание воды(%)";
            WaterContent.Name = "WaterContent";
            WaterContent.ReadOnly = true;
            // 
            // Contaminants
            // 
            Contaminants.HeaderText = "Содержание загрязнений (%)";
            Contaminants.Name = "Contaminants";
            Contaminants.ReadOnly = true;
            // 
            // OxidativeStability
            // 
            OxidativeStability.HeaderText = "Окислительная стабильность";
            OxidativeStability.Name = "OxidativeStability";
            OxidativeStability.ReadOnly = true;
            // 
            // AdditiveComposition
            // 
            AdditiveComposition.HeaderText = "Аддитивный состав";
            AdditiveComposition.Name = "AdditiveComposition";
            AdditiveComposition.ReadOnly = true;
            // 
            // MaterialCompatibility
            // 
            MaterialCompatibility.HeaderText = "Совместимость с материалами";
            MaterialCompatibility.Name = "MaterialCompatibility";
            MaterialCompatibility.ReadOnly = true;
            // 
            // ListLubricantsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1671, 876);
            Controls.Add(Table);
            Name = "ListLubricantsForm";
            Load += ListLubricantsForm_Load;
            ((System.ComponentModel.ISupportInitialize)Table).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Table;
        private DataGridViewTextBoxColumn LubricantName;
        private DataGridViewTextBoxColumn KinematicViscosity40;
        private DataGridViewTextBoxColumn KinematicViscosity100;
        private DataGridViewTextBoxColumn ViscosityIndex;
        private DataGridViewTextBoxColumn PourPoint;
        private DataGridViewTextBoxColumn FlashPoint;
        private DataGridViewTextBoxColumn EvaporationTemperature;
        private DataGridViewTextBoxColumn Density;
        private DataGridViewTextBoxColumn AcidNumber;
        private DataGridViewTextBoxColumn BaseNumber;
        private DataGridViewTextBoxColumn SulfatedAshContent;
        private DataGridViewTextBoxColumn WaterContent;
        private DataGridViewTextBoxColumn Contaminants;
        private DataGridViewTextBoxColumn OxidativeStability;
        private DataGridViewTextBoxColumn AdditiveComposition;
        private DataGridViewTextBoxColumn MaterialCompatibility;
    }
}