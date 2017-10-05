using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFRestServicePMD.Modelo
{
    [DataContract]
    public class HistorialNotificacionVM
    {
        [DataMember]
        public double ID { get; set; }

        [DataMember]
        public int EMBARAZADA_ID { get; set; }

        [DataMember]
        public DateTime FECHA_ENVIO { get; set; }

        [DataMember]
        public int NOTIFICACION_ID { get; set; }

        [DataMember]
        public bool ENVIADO { get; set; }

        [DataMember]
        public bool? RESPUESTA { get; set; }

        [DataMember]
        public string SEGUIMIENTO_ID { get; set; }

    }
}