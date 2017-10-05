using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFRestServicePMD.Modelo
{
    [DataContract]
    public class EmbarazadaVM
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int DNI { get; set; }

        [DataMember]
        public DateTime FECHA_INSCRIPCION { get; set; }

        [DataMember]
        public short MES_GESTACION { get; set; }

        [DataMember]
        public string TELEFONO { get; set; }

    }
}