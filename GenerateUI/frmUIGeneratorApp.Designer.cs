namespace GenerateUI
{
    partial class frmUIGeneratorApp
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvUIModel = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.ModelDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ModelPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UIType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DdlDisplayText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DdlDisplayValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUIModel)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClear);
            this.splitContainer1.Panel2.Controls.Add(this.btnGenerate);
            this.splitContainer1.Size = new System.Drawing.Size(953, 627);
            this.splitContainer1.SplitterDistance = 562;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtModelName);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtFilePath);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvUIModel);
            this.splitContainer2.Size = new System.Drawing.Size(953, 562);
            this.splitContainer2.SplitterDistance = 82;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(125, 46);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(350, 20);
            this.txtModelName.TabIndex = 3;
            this.txtModelName.Text = "BaseControl";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model Name : ";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(125, 13);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(350, 20);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.Text = "F:\\Demo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path : ";
            // 
            // dgvUIModel
            // 
            this.dgvUIModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUIModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModelDataType,
            this.ModelPropertyName,
            this.DisplayLabel,
            this.UIType,
            this.DdlDisplayText,
            this.DdlDisplayValue});
            this.dgvUIModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUIModel.Location = new System.Drawing.Point(0, 0);
            this.dgvUIModel.Name = "dgvUIModel";
            this.dgvUIModel.Size = new System.Drawing.Size(953, 476);
            this.dgvUIModel.TabIndex = 0;
            this.dgvUIModel.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUIModel_CellMouseEnter);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(855, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(754, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ModelDataType
            // 
            this.ModelDataType.DataPropertyName = "ModelDataType";
            this.ModelDataType.HeaderText = "ModelDataType";
            this.ModelDataType.Items.AddRange(new object[] {
            "string",
            "number",
            "boolean",
            "Date"});
            this.ModelDataType.Name = "ModelDataType";
            this.ModelDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ModelDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ModelDataType.Width = 120;
            // 
            // ModelPropertyName
            // 
            this.ModelPropertyName.DataPropertyName = "ModelPropertyName";
            this.ModelPropertyName.HeaderText = "ModelPropertyName";
            this.ModelPropertyName.Name = "ModelPropertyName";
            this.ModelPropertyName.Width = 150;
            // 
            // DisplayLabel
            // 
            this.DisplayLabel.DataPropertyName = "DisplayLabel";
            this.DisplayLabel.HeaderText = "DisplayLabel";
            this.DisplayLabel.Name = "DisplayLabel";
            // 
            // UIType
            // 
            this.UIType.DataPropertyName = "UIType";
            this.UIType.HeaderText = "UIType";
            this.UIType.Items.AddRange(new object[] {
            "text",
            "password",
            "number",
            "checkbox",
            "radio",
            "dropdown",
            "date"});
            this.UIType.Name = "UIType";
            this.UIType.Width = 200;
            // 
            // DdlDisplayText
            // 
            this.DdlDisplayText.DataPropertyName = "DdlDisplayText";
            this.DdlDisplayText.HeaderText = "DdlDisplayText";
            this.DdlDisplayText.Name = "DdlDisplayText";
            this.DdlDisplayText.Width = 150;
            // 
            // DdlDisplayValue
            // 
            this.DdlDisplayValue.DataPropertyName = "DdlDisplayValue";
            this.DdlDisplayValue.HeaderText = "DdlDisplayValue";
            this.DdlDisplayValue.Name = "DdlDisplayValue";
            this.DdlDisplayValue.Width = 150;
            // 
            // frmUIGeneratorApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 627);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmUIGeneratorApp";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUIModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUIModel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ModelDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelPropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayLabel;
        private System.Windows.Forms.DataGridViewComboBoxColumn UIType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DdlDisplayText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DdlDisplayValue;
    }
}

