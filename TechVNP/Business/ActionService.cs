using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechVNP.Model;

namespace TechVNP.Business
{
    public class ActionService
    {
        public bool ReadDataOfAllExcel(List<NganHangSelect> nganHangs)
        {
            foreach(var nganHang in nganHangs)
            {
                //var listSoPhu =ReadingExcelSoPhu(nganHang.SoPhus);
                //var listHeThong =ReadingExcelHeThong(nganHang.HeThongs);
            }
            return true;
        }
        public List<SoPhuModel> ReadingExcelSoPhu(List<ObjectSelect> soPhus)
        {
            List<SoPhuModel> soPhuModels = new List<SoPhuModel>();
            foreach (var sophu in soPhus)
            {
                using (var stream = File.Open(sophu.Path, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader reader;
                    if (sophu.IndexFilter == 2)
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
                        for (int i = 1; i < table.Rows.Count; i++)
                        {
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
            return soPhuModels;
        }

        public List<HeThongModel> ReadingExcelHeThong(List<ObjectSelect> soPhus)
        {
            List<HeThongModel> heThongModels = new List<HeThongModel>();

            return heThongModels;
        }
    }
}
