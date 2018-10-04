namespace CodeWars.HelpYourGranny
{
    using System;
    using System.Linq;
    using System.Collections;
    public class Tour
    {
        public static int tour(string[] arrFriends, string[][] ftwns, Hashtable h)
        {
            var travelledDistance = 0.0;
            var travelFrom = "Home";
            var travelTo = "";
            for (var i = 0; i < arrFriends.Length; i++)
            {
                var friendLiveInTown = ftwns.FirstOrDefault(t => t[0] == arrFriends[i]);
                if (friendLiveInTown != null)
                {
                    travelTo = friendLiveInTown[1];
                    var distanceFromHomeToDestination = (double) h[travelTo];
                    if (i == 0)
                        travelledDistance += distanceFromHomeToDestination;
                    else
                    {
                        var distanceFromHomeToDeparture = (double) h[travelFrom];
                        travelledDistance += Math.Sqrt(Math.Pow(distanceFromHomeToDestination,2) - Math.Pow(distanceFromHomeToDeparture,2));
                    }
                    travelFrom = travelTo;
                }
            }
            travelledDistance += (double) h[travelTo];
            var result = (int)Math.Floor(travelledDistance);
            return result;
        }
    }
}
