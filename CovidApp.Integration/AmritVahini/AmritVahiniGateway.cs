using CovidApp.Integration.API.AmritVahini;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Integration.AmritVahini
{
    public class AmritVahiniGateway : IAmritVahiniGateway
    {
        readonly ILogger<AmritVahiniGateway> logger;
        private const string baseUrl = "http://amritvahini.in/DashBoardHospitalDetails.aspx?Districtcode=3421&HType=0";

        public AmritVahiniGateway(ILogger<AmritVahiniGateway> logger)
        {
            this.logger = logger;
        }

        public IList<AmritVahiniDataModel> GetBedData()
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(baseUrl);
                var myTable = document.DocumentNode
                                      .Descendants("table")
                                      .Where(t => t.Attributes["id"].Value == "ContentPlaceHolder1_DGV_ItemMaster")
                                      .FirstOrDefault();
                int j = 0;
                var hospitalBeds = new List<AmritVahiniDataModel>();
                foreach (var i in myTable.Descendants("tr"))
                {
                    if (j == 0)
                    {
                        j++;
                        continue;
                    }
                    var tds = i.SelectNodes("td");
                    hospitalBeds.Add(new AmritVahiniDataModel
                    {
                        HospitalName = tds[1].InnerText.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Trim(),
                        WithoutOxygen = tds[2].InnerText.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim(),
                        WithOxygen = tds[3].InnerText.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim(' '),
                        IcuWithoutVentilator = tds[4].InnerText.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim(),
                        IcuWithVentilator = tds[5].InnerText.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim(),
                        UpdatedOn = tds[6].InnerText.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Trim()
                    });
                }
                return hospitalBeds;
            }
            catch(Exception ex)
            {
                logger.LogError("Failed to Get Hospital Beds Data from AV", ex);
                return null;
            }
        }
    }
}
