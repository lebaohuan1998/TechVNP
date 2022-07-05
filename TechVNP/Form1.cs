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
using TechVNP.Model;
namespace TechVNP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog(){Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true };
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileNames = dlg.SafeFileNames;
                //this.richTextBox1.Text = String.IsNullOrEmpty(this.richTextBox1.Text) ? this.richTextBox1.Text + string.Join("\r\n", fileNames)
                //                         : this.richTextBox1.Text + "\r\n" + string.Join("\r\n", fileNames);
                //get excel data
                // lấy dữ liệu từ dòng
                var path = dlg.FileNames[0].ToString();
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                    IExcelDataReader reader;
                    if (dlg.FilterIndex == 2)
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    var result = reader.AsDataSet();
                    var tables = result.Tables.Cast<DataTable>();
                    foreach (DataTable table in tables)
                    {
                        for (int i = 1; i < table.Rows.Count; i++){
                        }

                    }
                    reader.Close();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileNames = dlg.SafeFileNames;
                //this.richTextBox2.Text = String.IsNullOrEmpty(this.richTextBox2.Text) ? this.richTextBox2.Text + string.Join("\r\n", fileNames)
                //                         : this.richTextBox2.Text + "\r\n" + string.Join("\r\n", fileNames);

                List<SoPhuModel> soPhuModels = new List<SoPhuModel>();
                foreach (var fileLocal in dlg.FileNames.ToList())
                {
                    using (var stream = File.Open(fileLocal.ToString(), FileMode.Open, FileAccess.Read))
                    {
                        // Auto-detect format, supports:
                        //  - Binary Excel files (2.0-2003 format; *.xls)
                        //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                        IExcelDataReader reader;
                        if (dlg.FilterIndex == 2)
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
                        var result = reader.AsDataSet();
                        var tables = result.Tables.Cast<DataTable>();
                        foreach (DataTable table in tables)
                        {                            for (int i = 1; i < table.Rows.Count; i++)
                            {
                                //Console.WriteLine(i + ":" + table.Rows[i][1].ToString() + table.Rows[i][2].ToString() + table.Rows[i][6].ToString());
                                var sp = new SoPhuModel()
                                {
                                    Stt = table.Rows[i][0].ToString(),
                                    MaGD = table.Rows[i][1].ToString(),
                                };
                                soPhuModels.Add(sp);
                            }

                        }
                        reader.Close();
                    }
                }
                var js = new JavaScriptSerializer();
                js.MaxJsonLength = Int32.MaxValue;
                var soPhu =js.Serialize(soPhuModels);
                var txtName = "huan.txt";
                File.WriteAllText(txtName, soPhu);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
