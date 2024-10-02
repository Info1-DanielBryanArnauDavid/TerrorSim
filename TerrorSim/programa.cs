using System;
using System.Collections.Generic;
using TerrorSim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Starting the program...");

            // Create waypoints
            Console.WriteLine("Creating waypoints...");
            Waypoint wp1 = new Waypoint(40.6413, -73.7781, 0);     // JFK Airport
            Waypoint wp2 = new Waypoint(51.4700, -0.4543, 10000);  // Heathrow Airport
            Waypoint wp3 = new Waypoint(48.3538, 11.7861, 10000);  // Munich Airport

            // Create a list of waypoints
            Console.WriteLine("Creating list of waypoints...");
            List<Waypoint> waypoints = new List<Waypoint> { wp1, wp2, wp3 };

            // Create a flight plan
            Console.WriteLine("Creating flight plan...");
            FlightPlan flightPlan = new FlightPlan("FL123", waypoints, 800); // 800 km/h speed

            // Display initial flight plan information
            Console.WriteLine("Displaying flight plan information...");
            Console.WriteLine($"Flight Number: {flightPlan.DameFlightNumber()}");
            Console.WriteLine($"Total Distance: {flightPlan.DameDistance():F2} km");
            Console.WriteLine($"Speed: {flightPlan.DameSpeed()} km/h");

            // Display waypoints
            Console.WriteLine("Displaying waypoints...");
            for (int i = 0; i < waypoints.Count; i++)
            {
                Waypoint wp = flightPlan.DameWaypoint(i);
                Console.WriteLine($"Waypoint {i + 1}: Lat {wp.DameLatitude():F4}, Lon {wp.DameLongitude():F4}, Alt {wp.DameAltitude():F0} m");
            }

            Console.WriteLine("Program completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
        finally
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}