using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVCNTT
{
    public partial class FrmDetailSV : Form
    {
        public delegate void MyDelegate(SV s);
        public MyDelegate profile { get; set; }
        public FrmDetailSV()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            foreach (LSH i in CSDL_OOP.Instance.GetAllLSH())
            {
                cbLSH.Items.Add(new CBBItem { Value = i.ID_Lop, Text = i.NameLop });
            }
        }
        int GetID()
        {
            int index = 0;
            foreach (CBBItem item in cbLSH.Items)
            {
                if (item.Value == ((CBBItem)(cbLSH.SelectedItem)).Value) index = item.Value;
            }
            return index;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            SV sv = new SV();
            sv.MSSV = txtMSSV.Text;
            sv.NameSV = txtName.Text;
            sv.Gender = rdNam.Checked;
            sv.ID_Lop = GetID();
            sv.NS = Convert.ToDateTime(datepicker.Value);
            profile(sv);
        }
        public void BindingDataSV(DataGridViewRow r)
        {
            bool check = false;
            txtMSSV.Text = (r.Cells["MSSV"].Value).ToString();
            txtName.Text = (r.Cells["NameSV"].Value).ToString();
            foreach (CBBItem i in cbLSH.Items)
            {
                if ((int)(r.Cells["ID_Lop"].Value) == i.Value) cbLSH.SelectedItem = i;
            }
            if (Convert.ToBoolean(r.Cells["Gender"].Value)) check = true;
            if (check == true) rdNam.Checked = true;
            else rdNu.Checked = true;
            datepicker.Value = Convert.ToDateTime(r.Cells["NS"].Value);
        }
    }
}
