using Newtonsoft.Json;
using System.Collections.Generic;

namespace RTSLabApp
{
    class CodingExercise
    {
        public int above { get; set; }
        public int below { get; set; }

        public CodingExercise()
        {
            above = 0;
            below = 0;
        }

        public static string aboveBelow(List<int> list, int compare)
        { 
            CodingExercise exercise = new CodingExercise();
            foreach(var item in list)
            {
                if(item > compare)
                {
                    exercise.above++;
                }
                else if(item < compare)
                {
                    exercise.below++;
                }
            }
            return JsonConvert.SerializeObject(exercise);
        }

        public static string stringRotation(string originalString, int rotationAmount)
        {
            for(int i = 0; i < rotationAmount; i++)
            {
                string lastChar = originalString.Substring(originalString.Length - 1);
                originalString = originalString.Remove(originalString.Length - 1);
                originalString = originalString.Insert(0, lastChar);
            }
            return originalString;
        }
    }
}