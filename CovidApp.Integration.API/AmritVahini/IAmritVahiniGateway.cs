using CovidApp.Integration.AmritVahini;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Integration.API.AmritVahini
{
    public interface IAmritVahiniGateway
    {
        IList<AmritVahiniDataModel> GetBedData();
    }
}
