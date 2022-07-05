using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using TechVNP.Business;
using TechVNP.Model;
namespace TechVNP
{
    public partial class Form1 : Form
    {
        ActionService actionService = null;
        List<ObjectSelect> HeThongSelects = null;
        List<ObjectSelect> SoPhuSelects = null;
        List<NganHangSelect> NganHangs = null;
        int CountHeThongSelect = 0;
        int CountSoPhuSelect = 0;
        public Form1()
        {
            NganHangs = new List<NganHangSelect>();
            actionService =new ActionService();
            HeThongSelects = new List<ObjectSelect>();
            SoPhuSelects = new List<ObjectSelect>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog(){Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true };
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                for(int i =0; i < dlg.FileNames.Count(); i++)
                {
                    CountHeThongSelect++;
                    ObjectSelect objectSelect = new ObjectSelect();
                    objectSelect.STT = CountHeThongSelect;
                    objectSelect.Name = dlg.SafeFileNames[i];
                    objectSelect.Path = dlg.FileNames[i];
                    objectSelect.IndexFilter = dlg.FilterIndex;
                    HeThongSelects.Add(objectSelect);
                    objectSelectBindingSource1.Add(objectSelect);
                }
                //get excel data
                // lấy dữ liệu từ dòng
                //var path = dlg.FileNames[0].ToString();
                //using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                //{
                //    IExcelDataReader reader;
                //    if (dlg.FilterIndex == 2)
                //    {
                //        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                //    }
                //    else
                //    {
                //        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                //    }
                //    var result = reader.AsDataSet();
                //    var tables = result.Tables.Cast<DataTable>();
                //    foreach (DataTable table in tables)
                //    {
                //        for (int i = 1; i < table.Rows.Count; i++){
                //        }

                //    }
                //    reader.Close();
                //}
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < dlg.FileNames.Count(); i++)
                {
                    CountSoPhuSelect++;
                    ObjectSelect objectSelect = new ObjectSelect();
                    objectSelect.STT = CountSoPhuSelect;
                    objectSelect.Name = dlg.SafeFileNames[i];
                    objectSelect.Path = dlg.FileNames[i];
                    objectSelect.IndexFilter = dlg.FilterIndex;
                    SoPhuSelects.Add(objectSelect);
                    objectSelectBindingSource.Add(objectSelect);
                }

                //List<SoPhuModel> soPhuModels = new List<SoPhuModel>();
                //foreach (var fileLocal in dlg.FileNames.ToList())
                //{
                //    using (var stream = File.Open(fileLocal.ToString(), FileMode.Open, FileAccess.Read))
                //    {
                //        IExcelDataReader reader;
                //        if (dlg.FilterIndex == 2)
                //        {
                //            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                //        }
                //        else
                //        {
                //            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                //        }
                //        var result = reader.AsDataSet();
                //        var tables = result.Tables.Cast<DataTable>();
                //        foreach (DataTable table in tables)
                //        {                            for (int i = 1; i < table.Rows.Count; i++)
                //            {
                //                //Console.WriteLine(i + ":" + table.Rows[i][1].ToString() + table.Rows[i][2].ToString() + table.Rows[i][6].ToString());
                //                var sp = new SoPhuModel()
                //                {
                //                    Stt = table.Rows[i][0].ToString(),
                //                    MaGD = table.Rows[i][1].ToString(),
                //                };
                //                soPhuModels.Add(sp);
                //            }

                //        }
                //        reader.Close();
                //    }
                //}
                //var js = new JavaScriptSerializer();
                //js.MaxJsonLength = Int32.MaxValue;
                //var soPhu =js.Serialize(soPhuModels);
                //var txtName = "huan.txt";
                //File.WriteAllText(txtName, soPhu);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(HeThongSelects.Count() > 0 && SoPhuSelects.Count() > 0)
            {
                button4.Enabled = false;
                NganHangSelect nganHang = new NganHangSelect();
                nganHang.HeThongs = HeThongSelects;
                nganHang.SoPhus = SoPhuSelects;
                NganHangs.Add(nganHang);
                var result = actionService.ReadDataOfAllExcel(NganHangs);
                if(result == true)
                {
                    panel1.Enabled = false;
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn đủ file excel!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            objectSelectBindingSource.Clear();
            objectSelectBindingSource1.Clear();
            HeThongSelects = new List<ObjectSelect>();
            SoPhuSelects = new List<ObjectSelect>();
            button4.Enabled = true;
        }

    }
}
