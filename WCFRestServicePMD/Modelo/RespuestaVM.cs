using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFRestServicePMD.Modelo
{
    [DataContract]
    public class RespuestaVM
    {
        [DataMember]
        public double ID { get; set; }

        [DataMember]
        public string SEGUIMIENTO_ID { get; set; }

        [DataMember]
        public string RESPUESTA { get; set; }

        [DataMember]
        public DateTime FECHA_RECEPCION_DE_RESPUESTA { get; set; }

        [DataMember]
        public bool REGISTRO_LEIDO { get; set; }

        [DataMember]
        public DateTime? FECHA_LECTURA_REGISTRO { get; set; }

    }
}