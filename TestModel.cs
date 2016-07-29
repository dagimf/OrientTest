using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orient.Client;

namespace OrientTest
{
    public class TestModel
    {
        public TestModel()
        {
            DecimalDictionaryTest = new Dictionary<string, decimal>();
            DecimalListTest = new List<decimal>();
        }
        public decimal  DecimalTest { get; set; }
        public Dictionary<string, decimal> DecimalDictionaryTest { get; set; }
        public List<decimal> DecimalListTest { get; set; }
    }



}
