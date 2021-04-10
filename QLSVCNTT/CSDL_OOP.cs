using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSVCNTT
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;

        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CSDL_OOP();
                return _Instance;
            }
            private set { }
        }
        private List<SV> ListSV { get; set; }
        private List<LSH> ListLSH { get; set; }

        public List<SV> GetAllSV()
        {
            if (ListSV != null) ListSV.Clear();
            else ListSV = new List<SV>();
            foreach (DataRow item in CSDL.Instance.DTSV.Rows)
            {
                SV s = new SV();
                s.MSSV = item["MSSV"].ToString();
                s.NameSV = item["NameSV"].ToString();
                s.NS = Convert.ToDateTime(item["NS"]);
                s.Gender = Convert.ToBoolean(item["Gender"]);
                s.ID_Lop = (int)(item["ID_Lop"]);
                ListSV.Add(s);
            }
            return ListSV;
        }
        public List<LSH> GetAllLSH()
        {
            if (ListLSH != null) ListLSH.Clear();
            else ListLSH = new List<LSH>();
            foreach (DataRow item in CSDL.Instance.DTLSH.Rows)
            {
                LSH ls = new LSH();
                ls.ID_Lop = (int)item["ID_Lop"];
                ls.NameLop = item["NameLop"].ToString();
                ListLSH.Add(ls);
            }
            return ListLSH;
        }
        public SV GetSV(DataRow row)
        {
            SV a = new SV();
            DataTable dt = CSDL.Instance.DTSV;
            foreach (DataRow item in dt.Rows)
            {
                if(row == item)
                {
                    a.MSSV = item["MSSV"].ToString();
                    a.NameSV = item["NameSV"].ToString();
                    a.Gender = Convert.ToBoolean(item["Gender"]);
                    a.NS = Convert.ToDateTime(item["NS"]);
                    a.ID_Lop = (int)(item["ID_Lop"]);
                }

            }
            return a;
        }
        public LSH GetLSH(DataRow i)
        {
            LSH ls = new LSH();
            foreach (DataRow item in CSDL.Instance.DTLSH.Rows)
            {
                if (item == i)
                {
                    ls.ID_Lop = (int)item["ID_Lop"];
                    ls.NameLop = item["NameLop"].ToString();
                }
            }
            return ls;

        }
        public List<SV> GetListSV(int ID_Lop, string Name)
        {
            List<SV> s = new List<SV>();
            DataTable dt = CSDL.Instance.DTSV;
            foreach (DataRow item in dt.Rows)
            {
                if((int)item["ID_Lop"] == ID_Lop && item["NameSV"].ToString() == Name)
                {
                    SV a = new SV();
                    a.MSSV = item["MSSV"].ToString();
                    a.NameSV = item["NameSV"].ToString();
                    a.Gender = Convert.ToBoolean(item["Gender"]);
                    a.NS = Convert.ToDateTime(item["NS"]);
                    a.ID_Lop = (int)(item["ID_Lop"]);
                    s.Add(a);
                }
            }
            return s;
        }
        public List<SV> GetListSV(int ID_Lop)
        {
            List<SV> s = new List<SV>();
            DataTable dt = CSDL.Instance.DTSV;
            foreach (DataRow item in dt.Rows)
            {
                if ((int)item["ID_Lop"] == ID_Lop)
                {
                    SV a = new SV();
                    a.MSSV = item["MSSV"].ToString();
                    a.NameSV = item["NameSV"].ToString();
                    a.Gender = Convert.ToBoolean(item["Gender"]);
                    a.NS = Convert.ToDateTime(item["NS"]);
                    a.ID_Lop = (int)(item["ID_Lop"]);
                    s.Add(a);
                }
            }
            return s;
        }
        public bool checkMSSV(string a)
        {
            foreach (SV i in ListSV)
            {
                if (i.MSSV == a) return false;
            }
            return true;
        }
        public bool AddNewSV(SV sv, bool isAdd)
        {
            if (isAdd)
            {
                if (checkMSSV(sv.MSSV))
                {
                    CSDL.Instance.AddNewRow(sv);
                    Instance.GetAllSV();
                    return true;
                }
                return false;
            }
            else
            {
                CSDL.Instance.EditRow(sv);
                Instance.GetAllSV();
                return true;
            }
        }
        public void DeleteSV(SV sv)
        {
            CSDL.Instance.DeleteRow(sv);
            Instance.GetAllSV();
        }
    }
}
