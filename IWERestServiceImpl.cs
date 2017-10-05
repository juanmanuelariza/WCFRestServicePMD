using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFRestServicePMD.Modelo;

namespace WCFRestServicePMD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWERestServiceImpl" in both code and config file together.
    [ServiceContract]
    public interface IWERestServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "xml/{id}")] 
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string JSONData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ExisteEmbarazada/{dni}")]
        bool ExisteEmbarazada(string dni);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ObtenerEmbarazada/{dni}")]
        EmbarazadaVM ObtenerEmbarazada(string dni);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ObtenerEmbarazadaLista/{*optparam}")]
        List<EmbarazadaVM> ObtenerEmbarazadaLista(string optparam);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ObtenerEmbarazadaListaConGestacionActualizada/{*optparam}")]
        List<EmbarazadaConGestacionActualizadaVM> ObtenerEmbarazadaListaConGestacionActualizada(string optparam);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "InsertarNuevoRegistroHistorialDeNotificacion/{embarazada_id}/{notificacion_id}/{respuesta}/{seguimiento_id}")]
        bool InsertarNuevoRegistroHistorialDeNotificacion(string embarazada_id, string notificacion_id, string respuesta, string seguimiento_id);
        //int embarazada_id, int notificacion_id, bool? respuesta, string seguimiento_id

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ObtenerHistorialNotificacionPorIDdeSeguimiento/{seguimiento_id}")]
        HistorialNotificacionVM ObtenerHistorialNotificacionPorIDdeSeguimiento(string seguimiento_id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ObtenerNotificacionPorID/{id}")]
        NotificacionVM ObtenerNotificacionPorID(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ObtenerNotificacionPorID/{*optparam}")]
        List<RespuestaVM> ObtenerListaDeRespuestas(string optparam);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ActualizarEstadoDeRespuesta/{id}")]
        bool ActualizarEstadoDeRespuesta(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ActualizarHistorialDeNotificacion/{seguimiento_id}/{respuesta}")]
        bool ActualizarHistorialDeNotificacion(string seguimiento_id, string respuesta);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "RecepcionNotificacion/{*mensaje}")]
        bool RecepcionNotificacion(string mensaje);
        
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "RecepcionNuevoSMS")]
        Stream RecepcionNuevoSMS(Stream request);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "EstadoDelServicio/{*mensaje}")]
        bool EstadoDelServicio(string mensaje);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "EstadoDelServicio/{mensaje}/{telefono}")]
        string EnviarSMS(string mensaje, string telefono);
    }
}
