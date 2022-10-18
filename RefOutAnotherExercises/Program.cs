using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RefOutAnotherExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            IList rating = new List<int>();
            IList activityList = new List<string>();
            IList hoursList = new List<(string, string)>();
            int goToSleep;
            Tuple<int, int> hoursOfBreaks;

            AddingActivitiesToDay addingActivities = new AddingActivitiesToDay("Poniedzialek");
            Tuple<int, int> sleepInformation = addingActivities.HowMuchHoursOfSleep();
            addingActivities.SleepHours(sleepInformation.Item1);
            AddingActivitiesToDay.ActivitiesInDay(out activityList, out hoursList);
            AddingActivitiesToDay.ImportanceOfActivity(out rating, activityList);

            Console.WriteLine("Activities");
            AddingActivitiesToDay.DayActivities(activityList, hoursList);
            Console.WriteLine("Ratings");
            AddingActivitiesToDay.DayActivitieRaiting(activityList, rating);

            hoursOfBreaks = AddingActivitiesToDay.HoursOfBreak((List<(string, string)>)hoursList, sleepInformation.Item2);

            addingActivities.Summary(hoursOfBreaks, rating);
        }
    }
}
