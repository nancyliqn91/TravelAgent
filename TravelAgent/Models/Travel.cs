using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelAgent.Models
{
  public class Travel
  {
    public int TravelId { get; set; }
    public string Destination { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Review { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }

    public static List<Travel> GetTravels()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      
      List<Travel> travelList = JsonConvert.DeserializeObject<List<Travel>>(jsonResponse.ToString());

      return travelList;
    }

    public static Travel GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Travel travel = JsonConvert.DeserializeObject<Travel>(jsonResponse.ToString());

      return travel;
    }

    public static void Post(Travel travel)
    {
      string jsonTravel = JsonConvert.SerializeObject(travel);
      ApiHelper.Post(jsonTravel);
    }

    public static void Put(Travel travel)
    {
      string jsonTravel = JsonConvert.SerializeObject(travel);
      ApiHelper.Put(travel.TravelId, jsonTravel);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }

    
  }
}