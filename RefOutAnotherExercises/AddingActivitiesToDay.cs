using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RefOutAnotherExercises
{
    public class AddingActivitiesToDay : PrintDay
    {
        private readonly string _day;
        private const int _lenghtOfDay = 24;
        public AddingActivitiesToDay(string day)
        {
            _day = day;
            Console.WriteLine($"Lets start new day \t {_day}");
        }

        public Tuple<int,int> HowMuchHoursOfSleep()
        {
            int hoursOfSleeping = 0;
            Console.WriteLine("When have you go to sleep?");
            string sleep_start_string = Console.ReadLine();
            int sleep_start_int = Int32.Parse(sleep_start_string);
            
            Console.WriteLine("When have you woke up?");
            string sleep_end_string = Console.ReadLine();
            int sleep_end_int = Int32.Parse(sleep_end_string);

            if (sleep_end_int > sleep_start_int)
            {
                hoursOfSleeping = sleep_end_int - sleep_start_int;
            }
            else
            {
                hoursOfSleeping = (24 - sleep_start_int) + sleep_end_int;
            }
            Tuple<int, int> sleepInformation = new Tuple<int, int>(hoursOfSleeping, sleep_end_int);

            return sleepInformation;
        }

        public static void ActivitiesInDay(out IList listOne, out IList listTwo)
        {
            IList activityList = new List<string>();
            IList hoursList = new List<(string, string)>();
            StringBuilder finish = new StringBuilder(); // I do not want to allocate memory within making new activity
            bool result = false;

            while (result != true) // zakonczenie petli 
            {
                finish.Clear();
                Console.WriteLine("Write down name of activity");
                string activity = Console.ReadLine();
                finish.Append(activity);

                if (finish.CompareToCharacters("f")) // extension method
                {
                    Console.WriteLine("When you are going to sleep?");
                    string startSleep = Console.ReadLine();
                    int startSleepInt = Int32.Parse(startSleep);

                    Console.WriteLine("When you are going to get up?");
                    string finishSleep = Console.ReadLine();
                    int finishSleepInt = Int32.Parse(finishSleep);

                    activityList.Add("sleep");
                    hoursList.Add((startSleep, finishSleep)); ///////////////
                    break;
                }

                Console.WriteLine("When have you started this activity?");
                string start = Console.ReadLine();
                int startInt = Int32.Parse(start);

                Console.WriteLine("When have you finished this activity?");
                string end = Console.ReadLine();
                int endInt = Int32.Parse(end);


                activityList.Add(activity);
                hoursList.Add((start, end));
            }


            listOne = activityList;
            listTwo = hoursList;
        }

        public static IList ImportanceOfActivity(out IList rating, IList activityList)
        {
            rating = new List<int>();
            foreach (var values in activityList)
            {
                if (values.Equals(activityList[activityList.Count - 1]))
                {
                    Console.WriteLine($"{values} - How tired you were");
                    string gradeStr = Console.ReadLine();
                    int gradeInt = Int32.Parse(gradeStr);
                    rating.Add(gradeInt);

                }
                else
                {
                    Console.WriteLine($"{values} - How important this task was?");
                    string gradeStr = Console.ReadLine();
                    int gradeInt = Int32.Parse(gradeStr);
                    rating.Add(gradeInt);
                }
            }

            return rating;
        }

        public static Tuple<int,int> HoursOfBreak(List<(string, string)> hours, int startOfDay)
        {
            int hoursOfActivity = 0;
            int hoursInDay = 0;
            var query = hours.Select(item => item.Item1) // taking moment when i am going to sleep
                .TakeLast(1)
                .FirstOrDefault();

            if(Int32.Parse(query) - startOfDay >= 0)
            {
                hoursInDay = Int32.Parse(query) - startOfDay;
            }
            else
            {
                hoursInDay = (_lenghtOfDay - startOfDay) + Int32.Parse(query);
            }

            foreach (var values in hours)
            {
                if(Int32.Parse(values.Item2) < Int32.Parse(values.Item1)) // to do not get the propably hours of sleep
                {
                    Console.WriteLine("if" + values);
                    continue;
                }
                else
                {
                    if (values.Item1.Equals(query))
                    {
                        break;
                    }
                    else
                    {
                        hoursOfActivity = hoursOfActivity + (Int32.Parse(values.Item2) - Int32.Parse(values.Item1));
                    }
                }
            }

            return new Tuple<int, int>(hoursInDay, hoursOfActivity);
        }
    }
}

