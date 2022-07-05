using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechVNP.Model
{
    public class NganHangSelect
    {
        public List<ObjectSelect> HeThongs = null;
        public List<ObjectSelect> SoPhus = null;
        public NganHangSelect()
        {
            HeThongs = new List<ObjectSelect>();
            SoPhus = new List<ObjectSelect>();
        }
    }
}
