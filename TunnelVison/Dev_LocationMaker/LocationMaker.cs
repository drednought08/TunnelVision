using System.Collections.Generic;
using System.Drawing;
using TunnelVision;


namespace Dev_LocationMaker
{
    public class LocationMaker
	{
        //private string storageDir = LocationManager.storageDir;

        //======================================================================================

        public LocationMaker()
		{
			
		}

        //======================================================================================

        public void CreateLocation(int x, int y)
        {
            Location location = new Location(x, y);
            //LocationManagerInstance.manager.AddLocation(location);
        }

        //======================================================================================

        public void MarkLocations(Graphics g)
        {
            Pen locationPen = new Pen(Color.Red, 1);
            List<Location> locations = LocationManagerInstance.manager.GetLocations();
            if (locations.Count > 0)
            {
                foreach (Location location in LocationManagerInstance.manager.GetLocations())
                {
                    Point coords = new Point(location.xPos, location.yPos);
                    Point upLeft = new Point(coords.X - 5, coords.Y - 5);
                    Point downRight = new Point(coords.X + 5, coords.Y + 5);
                    Point downLeft = new Point(coords.X - 5, coords.Y + 5);
                    Point upRight = new Point(coords.X + 5, coords.Y - 5);

                    g.DrawLine(locationPen, upLeft, downRight);
                    g.DrawLine(locationPen, downLeft, upRight);

                }
            }  
        }
	}

    //######################################################################################

    public class LocationMakerInstance : LocationMaker
    {
        public static readonly LocationMaker maker = new LocationMaker();
    }
}
