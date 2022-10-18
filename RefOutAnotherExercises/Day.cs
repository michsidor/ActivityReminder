using System;
using System.Collections;

namespace RefOutAnotherExercises
{
    public abstract class PrintDay
    {

        public void PrintDayName(string day)
        {
            Console.WriteLine($"This is your day - {day}");
        }

        public void DayActivities(IList activities)
        {
            foreach(var values in activities)
            {
                Console.WriteLine($"Todays activities: {activities}");
            }
        }

        public static void DayActivities(IList activities, IList hours)
        {
            for (int i = 0; i < activities.Count; i++)
            {
                Console.WriteLine($"{activities[i]} - {hours[i]}");
            }
        }

        public static void DayActivitieRaiting(IList activities, IList rating)
        {
           for(int i = 0; i < activities.Count; i++)
            {
                Console.WriteLine($"{activities[i]} - {rating[i]}");
            }
        }

        public void SleepHours(int hours)
        {
            if(hours > 6 && hours <= 8)
            {
                Console.WriteLine($"You have sleep {hours} hours. Thats perfect!");
            }
            if (hours > 8)
            {
                Console.WriteLine($"You have sleep {hours} hours. Thats to long! You do not need it");
            }
            if(hours < 6)
            {
                Console.WriteLine($"You have sleep {hours} hours. Thats too little!");
            }
        }

        public void Summary(Tuple<int,int> hoursActAndBrk, IList ratings)
        {
            float activityProportion    = (float)hoursActAndBrk.Item2 / (float)hoursActAndBrk.Item1;
            float tasksGradesProportion = 0;

            float pieces = 0;
            float total  = 0;

            foreach(var values in ratings)
            {
                total = total + (int)values;
                pieces++;
            }

            tasksGradesProportion = total / (pieces * 5);

            Console.WriteLine("Ile godzin pracy do godzin dnia: " + activityProportion   );
            Console.WriteLine("Srednia ocen za taski: "           + tasksGradesProportion);


        }
        

        

    }
}

