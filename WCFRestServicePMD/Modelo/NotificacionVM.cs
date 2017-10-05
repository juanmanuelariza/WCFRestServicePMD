using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFRestServicePMD.Modelo
{
    [DataContract]
    public class NotificacionVM
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int NRO_ORDEN { get; set; }

        [DataMember]
        public string MENSAJE { get; set; }

        [DataMember]
        public short MES_GESTACION { get; set; }

        [DataMember]
        public bool REQUIERE_RESPUESTA { get; set; }

        [DataMember]
        public int? NOTIFICACION_ID_RESP_POS { get; set; }

        [DataMember]
        public int? NOTIFICACION_ID_RESP_NEG { get; set; }

        [DataMember]
        public bool? ES_RESPUESTA_DE_MENSAJE_ANTERIOR { get; set; }


    }
}