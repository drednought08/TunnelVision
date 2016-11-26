using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TunnelVision
{
    public class LocationManager
    {
        static List<Location> locList = new List<Location>();
        public static readonly string storageDir = "C:\\Users\\Eric\\Desktop"; //Debug path, edit as necessary
        //public static readonly string storageDir = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, "TunnelVision");  //File path of storage directory
        public static readonly string master = "LocMasterList.json";     //File name of the serialized master list
        public static readonly string masterPath = Path.Combine(storageDir, master);

        //======================================================================================

        public LocationManager()
        {
            if (!Directory.Exists(storageDir))
            {
                Directory.CreateDirectory(storageDir);
            }

            if(!File.Exists(masterPath))
            {
                SerializeLocationList(new List<Location>());
            }
            
        }

        //======================================================================================

        public List<Location> GetLocations()
            //Get serialized master list and return deserialized version
        {
            string locString = File.ReadAllText(masterPath);
            return JsonConvert.DeserializeObject<List<Location>>(locString);
        }

        //======================================================================================

        public void AddLocation(Location loc)
            //Add Location to master list and reserialize
        {
            locList = GetLocations();
            locList.Add(loc);
            SerializeLocationList(locList);
        }

        //======================================================================================

        public void SerializeLocationList(List<Location> list)
            //Serialize the list of locations and create/overwrite the list in the storage directory
        {
            string locationList = JsonConvert.SerializeObject(list);
            File.WriteAllText(masterPath, locationList);
        }

        public void ClearLocationList()
        {
            SerializeLocationList(new List<Location>());
        }
    }

    //######################################################################################

    public class LocationManagerInstance : LocationManager
    {
        public static readonly LocationManager manager = new LocationManager();
    }
}