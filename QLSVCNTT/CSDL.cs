using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSVCNTT
{
    class CSDL
    {
        public DataTable DTSV { get; set; }
        public DataTable DTLSH { get; set; }
        public static CSDL Instance
        {
            get {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set {}
        }

        private static CSDL _Instance;
        public CSDL()
        {
            DTSV = new DataTable();
            DataColumn[] datas = new DataColumn[]
            {
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("NameSV",typeof(string)),
                new DataColumn("Gender",typeof(bool)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("ID_Lop",typeof(int)),
            };
            DTSV.Columns.AddRange(datas);
            string date = DateTime.Now.ToString().Split(' ')[0];
            DataRow dr = DTSV.NewRow();
            dr["MSSV"] = "101";
            dr["NameSV"] = "LHQ";
            dr["Gender"] = true;
            dr["NS"] = date;
            dr["ID_Lop"] = 1;
            DTSV.Rows.Add(dr);
            DataRow dr1 = DTSV.NewRow();
            dr1["MSSV"] = "102";
            dr1["NameSV"] = "LHD";
            dr1["Gender"] = true;
            dr1["NS"] = date;
            dr1["ID_Lop"] = 2;
            DTSV.Rows.Add(dr1);
            DataRow dr2 = DTSV.NewRow();
            dr2["MSSV"] = "103";
            dr2["NameSV"] = "LHN";
            dr2["Gender"] = false;
            dr2["NS"] = date;
            dr2["ID_Lop"] = 3;
            DTSV.Rows.Add(dr2);
            DataRow dr3 = DTSV.NewRow();
            dr3["MSSV"] = "104";
            dr3["NameSV"] = "LHX";
            dr3["Gender"] = false;
            dr3["NS"] = date;
            dr3["ID_Lop"] = 3;
            DTSV.Rows.Add(dr3);
            DataRow dr4 = DTSV.NewRow();
            dr4["MSSV"] = "105";
            dr4["NameSV"] = "LHA";
            dr4["Gender"] = true;
            dr4["NS"] = date;
            dr4["ID_Lop"] = 2;
            DTSV.Rows.Add(dr4);


            //LOP SH
            DTLSH = new DataTable();
            DTLSH.Columns.AddRange(new DataColumn[]{
                new DataColumn("ID_Lop",typeof(int)),
                new DataColumn("NameLop",typeof(string))
            });
            DataRow ls = DTLSH.NewRow();
            ls["ID_Lop"] = 1;
            ls["NameLop"] = "19TCLC_DT3";
            DTLSH.Rows.Add(ls);
            DataRow ls1 = DTLSH.NewRow();
            ls1["ID_Lop"] = 2;
            ls1["NameLop"] = "19TCLC_DT4";
            DTLSH.Rows.Add(ls1);
            DataRow ls2 = DTLSH.NewRow();
            ls2["ID_Lop"] = 3;
            ls2["NameLop"] = "19TCLC_DT5";
            DTLSH.Rows.Add(ls2);
        }
        public void AddNewRow(SV a)
        {
            DataRow b = DTSV.NewRow();
            b["MSSV"] = a.MSSV;
            b["NameSV"] = a.NameSV;
            b["Gender"] = a.Gender;
            b["ID_Lop"] = a.ID_Lop;
            b["NS"] = a.NS.ToString().Split(' ')[0];
            DTSV.Rows.Add(b);
        }
        public void EditRow(SV a)
        {
            foreach (DataRow item in Instance.DTSV.Rows)
            {
                if(item["MSSV"].ToString() == a.MSSV)
                {
                    item["NameSV"] = a.NameSV;
                    item["NS"] = a.NS.ToString().Split(' ')[0];
                    item["Gender"] = a.Gender;
                    item["ID_Lop"] = a.ID_Lop;
                }
            }
        }
        public void DeleteRow(SV a)
        {
            foreach (DataRow item in Instance.DTSV.Rows)
            {
                if (item["MSSV"].ToString() == a.MSSV)
                {
                    Instance.DTSV.Rows.Remove(item);
                    break;
                }
            }

        }

    }
}
