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
    public partial class FrmSV : Form
    {
        int id;
        private List<SV> ListSV = CSDL_OOP.Instance.GetAllSV();
        private List<LSH> ListLSH = CSDL_OOP.Instance.GetAllLSH();
        public FrmSV()
        {
            InitializeComponent();
            SetCBB();
        }
        void SetCBB()
        {
            cbSH.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach (LSH item in ListLSH)
            {
                cbSH.Items.Add(new CBBItem { Value = item.ID_Lop,Text = item.NameLop});
            }
            string[] prop = { "MSSV", "NameSV", "Gender", "NS", "ID_Lop" };
            foreach (string item in prop)
            {
                cbSort.Items.Add(item);
            }
        }
        void ShowDS()
        {
            dtgvSV.DataSource = ListSV;
            dtgvSV.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cbSH.SelectedItem.ToString() == "All") ShowDS();
            else
            {
                foreach (LSH item in ListLSH)
                {
                    if (cbSH.SelectedItem.ToString() == item.NameLop)
                    {
                        foreach (SV s in ListSV)
                        {
                            if(item.ID_Lop == s.ID_Lop)
                            {
                                dtgvSV.DataSource = CSDL_OOP.Instance.GetListSV(s.ID_Lop);
                            }
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cbSH.SelectedItem.ToString() == "All")
            {
                foreach (SV s in ListSV)
                {
                    if (txtSearch.Text == s.NameSV) id = s.ID_Lop;
                }
                dtgvSV.DataSource = CSDL_OOP.Instance.GetListSV(id, txtSearch.Text);
                dtgvSV.Show();
            }
            else
            {
                foreach (LSH ls in ListLSH)
                {
                    if (cbSH.SelectedItem.ToString() == ls.NameLop)
                    {
                        id = ls.ID_Lop;
                    }
                }
                dtgvSV.DataSource = CSDL_OOP.Instance.GetListSV(id, txtSearch.Text);
                dtgvSV.Show();
            }
        }
        void Add(SV a)
        {
            if (CSDL_OOP.Instance.AddNewSV(a, true))
            {
                dtgvSV.DataSource = null;
                dtgvSV.DataSource = ListSV;
                MessageBox.Show("Added Successfully");
            }
            else MessageBox.Show("Error");
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmDetailSV detail = new FrmDetailSV();
            detail.profile = new FrmDetailSV.MyDelegate(Add);
            detail.Show();
        }

        SV CellClick(DataGridViewRow row)
        {
            SV s = new SV();
            s.MSSV = row.Cells["MSSV"].Value.ToString();
            s.NameSV = row.Cells["NameSV"].Value.ToString();
            s.ID_Lop = (int)row.Cells["ID_Lop"].Value;
            s.Gender = Convert.ToBoolean(row.Cells["Gender"].Value);
            s.NS = Convert.ToDateTime(row.Cells["NS"].Value);
            return s;
        }
        void Edit(SV a)
        {
            DataGridViewRow row = dtgvSV.CurrentRow;
            SV i = new SV();
            i = CellClick(row);
            if (a.MSSV == i.MSSV && CSDL_OOP.Instance.AddNewSV(a, false))
            {
                dtgvSV.DataSource = null;
                dtgvSV.DataSource = ListSV;
                MessageBox.Show("Edit Successfully");
            }
            else MessageBox.Show("Error Edit");

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmDetailSV detail = new FrmDetailSV();
            DataGridViewRow row = dtgvSV.CurrentRow;
            if(row != null)
            {
                detail.BindingDataSV(row);
                detail.profile = new FrmDetailSV.MyDelegate(Edit);
                detail.Show();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dtgvSV.CurrentRow;
            if (row != null)
            {
                SV a = new SV();
                a = CellClick(row);
                DialogResult result = MessageBox.Show("Bạn có muốn xóa SV này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dtgvSV.DataSource = null;
                    CSDL_OOP.Instance.DeleteSV(a);
                    dtgvSV.DataSource = ListSV;
                    MessageBox.Show("Delete Successfully");
                }
            }

        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            dtgvSV.DataSource = null;
            string choose = cbSort.SelectedItem.ToString();
            string[] prop = { "MSSV", "NameSV", "Gender", "NS", "ID_Lop" };
            if (choose == prop[0]) ListSV.Sort((x, y) => x.MSSV.CompareTo(y.MSSV));
            if (choose == prop[1]) ListSV.Sort((x, y) => x.NameSV.CompareTo(y.NameSV));
            if (choose == prop[2]) ListSV.Sort((x, y) => x.Gender.CompareTo(y.Gender));
            if (choose == prop[3]) ListSV.Sort((x, y) => x.NS.CompareTo(y.NS));
            if (choose == prop[4]) ListSV.Sort((x, y) => x.ID_Lop.CompareTo(y.ID_Lop));
            dtgvSV.DataSource = ListSV;
            dtgvSV.Show();
        }


    }
}
