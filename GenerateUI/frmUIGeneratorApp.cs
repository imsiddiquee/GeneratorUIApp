using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateUI
{
    public partial class frmUIGeneratorApp : Form
    {
        public List<ModelProperty> _modelProperties { get; set; }
        public frmUIGeneratorApp()
        {
            InitializeComponent();
            _modelProperties = new List<ModelProperty>();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int counter = 1;

            foreach (DataGridViewRow row in dgvUIModel.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                ModelProperty modelProperty = new ModelProperty
                {
                    OrderId = counter,
                    FilePath = txtFilePath.Text,
                    ModelName = txtModelName.Text,
                    ModelDataType = row.Cells[0].Value.ToString(),
                    ModelPropertyName = row.Cells[1].Value.ToString(),
                    UIType = row.Cells[2].Value.ToString(),
                    DdlDisplayText = row.Cells[1].Value.ToString(),
                    DdlDisplayValue = row.Cells[1].Value.ToString()
                };
                counter++;

                _modelProperties.Add(modelProperty);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = string.Empty;
            txtModelName.Text = string.Empty;
            dgvUIModel.Rows.Clear();
            dgvUIModel.Refresh();
        }

        private void dgvUIModel_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                switch (e.ColumnIndex.ToString())
                {
                    case "0":
                    case "2":
                        dgvUIModel.Cursor = Cursors.Hand;
                        break;

                    default: dgvUIModel.Cursor = Cursors.Default; break;
                }
            }
        }
    }

    public class ModelProperty
    {
        public int OrderId { get; set; }
        public string FilePath { get; set; }
        public string ModelName { get; set; }
        public string ModelDataType { get; set; }
        public string ModelPropertyName { get; set; }
        public string UIType { get; set; }
        public string DdlDisplayText { get; set; }
        public string DdlDisplayValue { get; set; }
    }
}
