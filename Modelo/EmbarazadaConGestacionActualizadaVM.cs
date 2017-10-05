using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFRestServicePMD.Modelo
{
    [DataContract]
    public class EmbarazadaConGestacionActualizadaVM
    {
        [DataMember]
        public int? EMBARAZADA_ID { get; set; }

        [DataMember]
        public DateTime? FECHA_INSCRIPCION { get; set; }

        [DataMember]
        public short? MES_GESTACION { get; set; }

        [DataMember]
        public short? MES_GESTACION_ACTUAL { get; set; }

        [DataMember]
        public int? NOTIFICACION_ID { get; set; }

        [DataMember]
        public int? NRO_ORDEN { get; set; }

        [DataMember]
        public string MENSAJE { get; set; }

        [DataMember]
        public bool? REQUIERE_RESPUESTA { get; set; }

        [DataMember]
        public int? DNI { get; set; }

        [DataMember]
        public string TELEFONO { get; set; }

    }
}