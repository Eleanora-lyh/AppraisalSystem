using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace VirusPro.Model
{
    //这里引入中间表的命名空间，告诉框架这是个多对多的关系
    [MiddleTable]
    public class PatientVirus : TopBasePoco
    {
        /*
         * 病一个patient可以感染多个virus，一个virus也可以被多个patient感染
         * 需要建立一个中间表 PatientVirus 
         */
        public Patient Patient { get; set; }

        public Guid PatientId { get; set; }

        public Virus Virus { get; set; }
        public Guid VirusId { get; set; }
    }
}
