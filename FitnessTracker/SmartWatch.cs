using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Smartwatch
{
    public enum ActivityType
    {
        Biking,
        Running,
        Walking
    }

    public class Activity
    {
        public static Activity Biking = new Activity("Biking", 48);
        public static Activity Running = new Activity("Running", 110);
        public static Activity Walking = new Activity("Walking", 80);

        public string Name { get; set; }
        private int AverageLossPerMile { get; set; }

        public Activity(string name, int averageCalorieLossPerMile)
        {
            this.Name = name;
            this.AverageLossPerMile = averageCalorieLossPerMile;
        }

        /// This is a calculated caloric loss based on the distance travelled and the average loss per actvitiy
        public int CaloriesLost(int distanceInMiles)
        {
            return distanceInMiles * AverageLossPerMile;
        }
    }

    public class ActivityLogGenerator
    {
        public static void GenerateActivityLog(string filename, int entryAmount)
        {
            // Dictionary Map that maps Enum values to a Tuple that contains the Activity that Enum represents
            // As well as the lower and upper (non-inclusive) bounds of how many miles can be traveled
            var allActivityInformation = new Dictionary<ActivityType, Tuple<Activity, int, int>>
            {
                [ActivityType.Walking] = Tuple.Create(Activity.Walking, 1, 6),
                [ActivityType.Running] = Tuple.Create(Activity.Running, 1, 21),
                [ActivityType.Biking] = Tuple.Create(Activity.Biking, 1, 31)
            };

            var rand = new Random();
            var activities = Enum.GetNames(typeof(ActivityType));

            var activityData = new List<string>();
            for (int i = 0; i < entryAmount; i++)
            {
                var activityType = (ActivityType)rand.Next(activities.Length);
                var activityInfo = allActivityInformation[activityType];

                var activity = activityInfo.Item1;
                var distanceMoved = rand.Next(activityInfo.Item2, activityInfo.Item3);

                activityData.Add($"{activity.Name},{activity.CaloriesLost(distanceMoved)},{distanceMoved}");
            }
            File.WriteAllLines(filename, activityData);
        }
    }

    public class SmartWatch
    {
        public SmartWatch()
        {
            ActivityLogGenerator.GenerateActivityLog("fitness_data.csv", 120);
        }

    }

    public static class CSVConverter
    {

        public static void AddToActivities(ObservableCollection<CSVActivity> activities, out ObservableCollection<CSVActivity> activityOutput)
        {
            Regex rr = new Regex(@"(w\+),(d+),(d+)");
            activityOutput = activities;
            string placeholder = /*await*/ GetStringFromFile()/*.Result*/;
            //while ()
            //{
            Match stuff = rr.Match(placeholder);
            activityOutput.Add(new CSVActivity(stuff.Value, 2, 2));
            placeholder = GetStringFromFile()/*.Result*/;
            //}

            
        }

        private static /*async Task<string>*/ string GetStringFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader("D:\\Pro100\\FitnessTracker\\fitness-gurus\\FitnessTracker\\bin\\Debug\\fitness_data.csv"))
                {
                    return /*await*/ sr.ReadLine/*Async*/();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Broke " + e.Message);
            }
            return null;


        }
    }

    public class CSVActivity
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int Calories { get; set; }
        public int Distance { get; set; }

        public CSVActivity(string ActivityType, int Calories, int Distance)
        {
            Date = System.DateTime.Today;
            this.Type = ActivityType;
            this.Calories = Calories;
            this.Distance = Distance;
        }
    }
}