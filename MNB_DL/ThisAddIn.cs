using System;
using System.Xml;
using System.Net;
using System.IO;

namespace MNB_DL
{
    public partial class ThisAddIn
    {


        public void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        public static String CallWebService()
        {
            var _url = "http://www.mnb.hu/arfolyamok.asmx?Wsdl";
            var _action = "http://www.mnb.hu/webservices/MNBArfolyamServiceSoap/GetExchangeRates";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }
            return soapResult;
        }
        public static String CallUnitsWebService()
        {
            var _url = "http://www.mnb.hu/arfolyamok.asmx?Wsdl";
            var _action = "http://www.mnb.hu/webservices/MNBArfolyamServiceSoap/GetCurrencyUnits";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelopeForUnits();
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            asyncResult.AsyncWaitHandle.WaitOne();

            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }
            return soapResult;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            string currYear = DateTime.Now.ToString("yyyy");
            string currDate = DateTime.Now.ToString("yyyy-MM-dd");
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://www.mnb.hu/webservices/""><soapenv:Header/><soapenv:Body><web:GetExchangeRates><web:startDate>"+currYear+"-01-01</web:startDate><web:endDate>"+currDate+ "</web:endDate><web:currencyNames>HUF,EUR,AUD,BGN,BRL,CAD,CHF,CNY,CZK,DKK,GBP,HKD,HRK,IDR,ILS,INR,ISK,JPY,KRW,MXN,MYR,NOK,NZD,PHP,PLN,RON,RSD,RUB,SEK,SGD,THB,TRY,UAH,USD,ZAR,ATS,AUP,BEF,BGL,CYN,CSD,CSK,DDM,DEM,EEK,EGP,ESP,FIM,FRF,GHP,GRD,IEP,ITL,KPW,KWD,LBP,LTL,LUF,LVL,MNT,NLG,OAL,OBL,OFR,ORB,PKR,PTE,ROL,SDP,SIT,SKK,SUR,VND,XEU,XTR,YUD</web:currencyNames></web:GetExchangeRates></soapenv:Body></soapenv:Envelope>");
            return soapEnvelopeDocument;
        }

        private static XmlDocument CreateSoapEnvelopeForUnits()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://www.mnb.hu/webservices/""><soapenv:Header/><soapenv:Body><web:GetCurrencyUnits><web:currencyNames>HUF,EUR,AUD,BGN,BRL,CAD,CHF,CNY,CZK,DKK,GBP,HKD,HRK,IDR,ILS,INR,ISK,JPY,KRW,MXN,MYR,NOK,NZD,PHP,PLN,RON,RSD,RUB,SEK,SGD,THB,TRY,UAH,USD,ZAR,ATS,AUP,BEF,BGL,CYN,CSD,CSK,DDM,DEM,EEK,EGP,ESP,FIM,FRF,GHP,GRD,IEP,ITL,KPW,KWD,LBP,LTL,LUF,LVL,MNT,NLG,OAL,OBL,OFR,ORB,PKR,PTE,ROL,SDP,SIT,SKK,SUR,VND,XEU,XTR,YUD</web:currencyNames></web:GetCurrencyUnits></soapenv:Body></soapenv:Envelope>");
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
