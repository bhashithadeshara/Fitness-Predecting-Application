using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessPersonal
{
    public partial class DateRangeDialogForm : Form
    {
        public DateTime SelectedStartDate { get; private set; }
        public DateTime SelectedEndDate { get; private set; }
        public DateRangeDialogForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedStartDate = dateTimePickerStartDate.Value;
            SelectedEndDate = dateTimePickerEndDate.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        
    }
}
