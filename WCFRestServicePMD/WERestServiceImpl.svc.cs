using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using WCFRestServicePMD.Datos;
using WCFRestServicePMD.Modelo;

namespace WCFRestServicePMD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WERestServiceImpl" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WERestServiceImpl.svc or WERestServiceImpl.svc.cs at the Solution Explorer and start debugging.
    public class WERestServiceImpl : IWERestServiceImpl
    {
        #region IRestServiceImpl Members

        public string XMLData(string id)
        {
            return "You requested product " + id;
        }

        public string JSONData(string id)
        {
            return "You requested product " + id;
        }

        public bool ExisteEmbarazada(string dni)
        {
            try
            {
                bool retValue = false;
                int pamar0 = Convert.ToInt32(dni);

                ProgMilDiasEntities datos = new ProgMilDiasEntities();
                retValue = datos.getExisteEmbarazada(pamar0).FirstOrDefault().Value;

                Logger.log("Exec ExisteEmbarazada() OK. Registro: OK");
                return retValue;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                return false;
            }
        }

        public EmbarazadaVM ObtenerEmbarazada(string dni)
        {
            try
            {
                int param0 = Convert.ToInt32(dni);
                EmbarazadaVM objEmbarazada = new EmbarazadaVM();
                getEmbarazada_Result newObj = new getEmbarazada_Result();

                ProgMilDiasEntities datos = new ProgMilDiasEntities();

                newObj = datos.getEmbarazada(param0).FirstOrDefault();

                objEmbarazada.ID = newObj.ID;
                objEmbarazada.DNI = newObj.DNI;
                objEmbarazada.FECHA_INSCRIPCION = newObj.FECHA_INSCRIPCION;
                objEmbarazada.MES_GESTACION = newObj.MES_GESTACION;
                objEmbarazada.TELEFONO = newObj.TELEFONO;

                Logger.log("Exec ObtenerEmbarazada() OK. Registro: DNI(" + objEmbarazada.DNI.ToString() + ")");
                return objEmbarazada;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                EmbarazadaVM objEmbarazada = new EmbarazadaVM();
                return objEmbarazada;
            }
        }

        public List<EmbarazadaVM> ObtenerEmbarazadaLista(string optParam)
        {
            try
            {
                List<EmbarazadaVM> colListaEmbarazadas = new List<EmbarazadaVM>();
                List<getEmbarazadaLista_Result> colAuxiliarE = new List<getEmbarazadaLista_Result>();

                EmbarazadaVM objEmbarazada;
                ProgMilDiasEntities datos = new ProgMilDiasEntities();

                colAuxiliarE = datos.getEmbarazadaLista().ToList();

                foreach (getEmbarazadaLista_Result item in colAuxiliarE)
                {
                    objEmbarazada = new EmbarazadaVM();
                    objEmbarazada.ID = item.ID;
                    objEmbarazada.DNI = item.DNI;
                    objEmbarazada.FECHA_INSCRIPCION = item.FECHA_INSCRIPCION;
                    objEmbarazada.MES_GESTACION = item.MES_GESTACION;
                    objEmbarazada.TELEFONO = item.TELEFONO;
                    colListaEmbarazadas.Add(objEmbarazada);
                }

                Logger.log("Exec ObtenerEmbarazadaLista() OK. Registros: " + colListaEmbarazadas.Count.ToString());
                //return Serialize<List<EmbarazadaVM>>(colListaEmbarazadas);
                return colListaEmbarazadas;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                List<EmbarazadaVM> colListaEmbarazadas = new List<EmbarazadaVM>();
                //return Serialize<List<EmbarazadaVM>>(colListaEmbarazadas); ;
                return colListaEmbarazadas;
            }
        }



        public List<EmbarazadaConGestacionActualizadaVM> ObtenerEmbarazadaListaConGestacionActualizada(string requiere_respuesta)
        {
            //bool? requiere_respuesta
            try
            {
                bool param0;
                bool result = bool.TryParse(requiere_respuesta, out result);
                if (result)
                    param0 = Convert.ToBoolean(result);
                else
                    param0 = false;
                List<EmbarazadaConGestacionActualizadaVM> colListaEmbarazada = new List<EmbarazadaConGestacionActualizadaVM>();
                List<getEmbarazadaListaConGestacionActualizada_Result> colAuxiliarE = new List<getEmbarazadaListaConGestacionActualizada_Result>();
                EmbarazadaConGestacionActualizadaVM objEmbarazada;

                ProgMilDiasEntities datos = new ProgMilDiasEntities();
                colAuxiliarE = datos.getEmbarazadaListaConGestacionActualizada(param0).ToList();

                foreach (getEmbarazadaListaConGestacionActualizada_Result item in colAuxiliarE)
                {
                    objEmbarazada = new EmbarazadaConGestacionActualizadaVM();
                    objEmbarazada.EMBARAZADA_ID = item.EMBARAZADA_ID;
                    objEmbarazada.FECHA_INSCRIPCION = item.FECHA_INSCRIPCION;
                    objEmbarazada.MES_GESTACION = item.MES_GESTACION;
                    objEmbarazada.MES_GESTACION_ACTUAL = item.MES_GESTACION_ACTUAL;
                    objEmbarazada.NOTIFICACION_ID = item.NOTIFICACION_ID;
                    objEmbarazada.NRO_ORDEN = item.NRO_ORDEN;
                    objEmbarazada.MENSAJE = item.MENSAJE;
                    objEmbarazada.REQUIERE_RESPUESTA = item.REQUIERE_RESPUESTA;
                    objEmbarazada.DNI = item.DNI;
                    objEmbarazada.TELEFONO = item.TELEFONO;
                    colListaEmbarazada.Add(objEmbarazada);
                }

                Logger.log("Exec ObtenerEmbarazadaListaConGestacionActualizada() OK. Registros: " + colListaEmbarazada.Count.ToString());
                return colListaEmbarazada;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                List<EmbarazadaConGestacionActualizadaVM> colListaEmbarazada = new List<EmbarazadaConGestacionActualizadaVM>();
                return colListaEmbarazada;
            }
        }

        public bool InsertarNuevoRegistroHistorialDeNotificacion(string embarazada_id, string notificacion_id, string respuesta, string seguimiento_id)
        {
            //int embarazada_id, int notificacion_id, bool? respuesta, string seguimiento_id
            try
            {
                bool result = bool.TryParse(respuesta, out result);
                int param0 = Convert.ToInt32(embarazada_id);
                int param1 = Convert.ToInt32(notificacion_id);
                bool param2;
                string param3 = seguimiento_id;
                if (result)
                    param2 = Convert.ToBoolean(respuesta);
                else
                    param2 = false;
                
                ProgMilDiasEntities datos = new ProgMilDiasEntities();
                datos.insertNuevoRegistroHistorialNotificacion(param0, param1, param2, param3);

                Logger.log("Exec InsertarNuevoRegistroHistorialDeNotificacion() OK. Registro -> EmbarazadaID: " + embarazada_id.ToString() + " NotificacionID: " + notificacion_id.ToString());
                return true;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                return false;
            }
        }

        public HistorialNotificacionVM ObtenerHistorialNotificacionPorIDdeSeguimiento(string seguimiento_id)
        {
            try
            {
                ProgMilDiasEntities datos = new ProgMilDiasEntities();
                HistorialNotificacionVM objNotificacion = new HistorialNotificacionVM();
                getHistorialNotificacionPorSeguimientoID_Result objAux = new getHistorialNotificacionPorSeguimientoID_Result();

                objAux = datos.getHistorialNotificacionPorSeguimientoID(seguimiento_id).FirstOrDefault();

                if (objAux != null)
                {
                    objNotificacion.ID = objAux.ID;
                    objNotificacion.EMBARAZADA_ID = objAux.EMBARAZADA_ID;
                    objNotificacion.ENVIADO = objAux.ENVIADO;
                    objNotificacion.FECHA_ENVIO = objAux.FECHA_ENVIO;
                    objNotificacion.NOTIFICACION_ID = objAux.NOTIFICACION_ID;
                    objNotificacion.RESPUESTA = objAux.RESPUESTA;
                    objNotificacion.SEGUIMIENTO_ID = objAux.SEGUIMIENTO_ID;
                }

                return objNotificacion;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                return new HistorialNotificacionVM();
            }
        }

        public NotificacionVM ObtenerNotificacionPorID(string id)
        {
            //int id
            try
            {
                long param0 = Convert.ToInt64(id);
                NotificacionVM objNotificacion = new NotificacionVM();
                ProgMilDiasEntities datos = new ProgMilDiasEntities();

                getNotificacionPorID_Result objAux = datos.getNotificacionPorID(param0).FirstOrDefault();

                if (objAux != null)
                {
                    objNotificacion.ES_RESPUESTA_DE_MENSAJE_ANTERIOR = objAux.ES_RESPUESTA_DE_MENSAJE_ANTERIOR;
                    objNotificacion.ID = objAux.ID;
                    objNotificacion.MENSAJE = objAux.MENSAJE;
                    objNotificacion.MES_GESTACION = objAux.MES_GESTACION;
                    objNotificacion.NOTIFICACION_ID_RESP_NEG = objAux.NOTIFICACION_ID_RESP_NEG;
                    objNotificacion.NOTIFICACION_ID_RESP_POS = objAux.NOTIFICACION_ID_RESP_POS;
                    objNotificacion.NRO_ORDEN = objAux.NRO_ORDEN;
                    objNotificacion.REQUIERE_RESPUESTA = objAux.REQUIERE_RESPUESTA;
                }

                return objNotificacion;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                return new NotificacionVM();
            }
        }

        public List<RespuestaVM> ObtenerListaDeRespuestas(string optParam)
        {
            try
            {
                ProgMilDiasEntities datos = new ProgMilDiasEntities();
                List<RespuestaVM> colNuevasRespuestas = new List<RespuestaVM>();
                RespuestaVM objRespuesta;
                List<getListaDeRespuestas_Result> colRespuestasDB = new List<getListaDeRespuestas_Result>();

                colRespuestasDB = datos.getListaDeRespuestas().ToList();

                if (colRespuestasDB.Count > 0)
                {
                    foreach (getListaDeRespuestas_Result item in colRespuestasDB)
                    {
                        objRespuesta = new RespuestaVM();
                        objRespuesta.FECHA_LECTURA_REGISTRO = item.FECHA_LECTURA_REGISTRO;
                        objRespuesta.FECHA_RECEPCION_DE_RESPUESTA = item.FECHA_RECEPCION_DE_RESPUESTA;
                        objRespuesta.ID = item.ID;
                        objRespuesta.REGISTRO_LEIDO = item.REGISTRO_LEIDO;
                        objRespuesta.RESPUESTA = item.RESPUESTA;
                        objRespuesta.SEGUIMIENTO_ID = item.SEGUIMIENTO_ID;

                        colNuevasRespuestas.Add(objRespuesta);
                    }
                }

                return colNuevasRespuestas;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                return new List<RespuestaVM>();
            }
        }

        public bool ActualizarEstadoDeRespuesta(string id)
        {
            //long id
            try
            {
                long param0 = Convert.ToInt64(id);
                ProgMilDiasEntities datos = new ProgMilDiasEntities();

                actualizarEstadoDeRespuesta_Result objRespuesta = datos.actualizarEstadoDeRespuesta(param0).FirstOrDefault();

                return objRespuesta.ACTUALIZADO.Value;

            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                return false;
            }
        }

        public bool ActualizarHistorialDeNotificacion(string seguimiento_id, string respuesta)
        {
            try
            {
                string param0 = seguimiento_id;
                string param1 = respuesta;
                bool res;
                ProgMilDiasEntities datos = new ProgMilDiasEntities();

                res = datos.actualizarHistorialDeNotificacion(param0, param1).FirstOrDefault().Value;

                return res;
            }
            catch (Exception e)
            {
                SetHttpStatusError();
                Logger.log(e.Message);
                return false;
            }
        }

        public bool RecepcionNotificacion(string mensaje)
        {
            return true;
        }

        public Stream RecepcionNuevoSMS(Stream request)
        {
            StreamReader reader = new StreamReader(request);
            string text = "EchoServer received: " + reader.ReadToEnd();
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            MemoryStream ms = new MemoryStream(encoding.GetBytes(text));
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return ms;

            //try
            //{

            //    //ProgMilDiasEntities db = new ProgMilDiasEntities();
            //    //logMensajes log = new logMensajes();
            //    //log.Fecha = DateTime.Now;
            //    //log.Mensaje = mensaje;
            //    //log.Origen = "RecepcionNuevoSMS";

            //    //db.logMensajes.Add(log);
            //    //db.SaveChanges();
            //    //return true;
            //}
            //catch (Exception e)
            //{
            //    //SetHttpStatusError();
            //    //Logger.log(e.Message);
            //    //return false;
            //}
        }

        public bool EstadoDelServicio(string mensaje)
        {
            return true;
        }

        public string EnviarSMS(string mensaje, string telefono)
        {
            string ret = "";

            return ret;
        }

        #endregion

        #region functions
        private string Serialize<T>(T instance)
        {
            var data = new StringBuilder();
            var serializer = new DataContractSerializer(instance.GetType());

            using (var writer = XmlWriter.Create(data))
            {
                serializer.WriteObject(writer, instance);
                writer.Flush();

                return data.ToString();
            }
        }

        private void SetHttpStatusError()
        {
            OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
            response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            response.StatusDescription = "A unexpected error occurred!";
        }
        #endregion
    }
}
