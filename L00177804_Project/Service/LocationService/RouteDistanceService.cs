using L00177804_Project.Models.RouteModel;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace L00177804_Project.Service.LocationService
{
    public class RouteDistanceService
    {
        // Inatialize http client
        private readonly HttpClient _client = new();

   
        private RouteData items = new();


        public async Task<RouteData> GetRouteDistanceAsync(string origin, string dest)
        {
            try
            {
                string fullUrl = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={origin}&destinations={dest}&key=AIzaSyDs7Eq7iXI1U4e8bX_pWq-AW9-nA0U8znc";
                // pass url and return response as a stream
                var response = await _client.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<RouteData>(jsonString);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Address line might be missing"+e.Message);
            }
            return items;
        }
    }
}
