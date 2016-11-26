using Newtonsoft.Json;
using System;

namespace TunnelVision
{
	public class Location
	{
		string name {get; set;}
		string[] connectionNames {get; set;}
		double[] connectionDists {get; set;}
		enum Type		//Flag that can be used to filter Locations. Route pretty much means "nothing special". The rest are self-explanatory
		{
			Route,
			Dining,
			Study,
			Bathroom
		};
		Type type {get; set;}
		enum Transition		//Flag to filter Locations
		{
			Stairs,
			Elevator
		};
		Transition transition {get; set;}
		string buildingFloor {get; set;}
		public int xPos {get; set;}
		public int yPos {get; set;}

        //===============================================================================================

        [JsonConstructor]
        public Location()
            //Different constructor so the Json deserialization doesn't cause an infinite loop of creating Locations
        {

        }

        public Location(int x, int y)
		{
            xPos = x;
            yPos = y;
			connectionNames = new string[8];
			connectionDists = new double[8];
            LocationManagerInstance.manager.AddLocation(this);
		}

        //===============================================================================================

        public void SetConnections(int index, Location otherLocation, double distance)
		{
			//Connects this Location to otherLocation and otherLocation to this Location
			connectionNames[index] = otherLocation.name;
			connectionDists[index] = distance;

			otherLocation.connectionNames[Math.Abs(index-8)] = name;
			otherLocation.connectionDists[Math.Abs(index-8)] = distance;
		}

        //===============================================================================================
    }
}
