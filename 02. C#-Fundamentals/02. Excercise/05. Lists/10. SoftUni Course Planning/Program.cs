using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                 .Split(", ")
                 .ToList();
            string command = Console.ReadLine();

            while (command != "course start")
            {
                string[] cmdArg = command.Split(":").ToArray();
                string firstCommand = cmdArg[0];
                string lessonTitle = cmdArg[1];

                if (firstCommand == "Add")
                {
                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Add(lessonTitle);
                    }
                }
                else if (firstCommand == "Insert")
                {
                    int index = int.Parse(cmdArg[2]);

                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Insert(index, lessonTitle);
                    }
                }
                else if (firstCommand == "Remove")
                {
                    lessons.Remove(lessonTitle);
                }
                else if (firstCommand == "Swap")
                {
                    string secondLessonTitle = cmdArg[2];

                    int indexOfFirstLesson = lessons.IndexOf(lessonTitle);
                    int indexOfSecondLesson = lessons.IndexOf(secondLessonTitle);

                    if (indexOfFirstLesson != -1 && indexOfSecondLesson != -1)
                    {
                        lessons[indexOfFirstLesson] = secondLessonTitle;
                        lessons[indexOfSecondLesson] = lessonTitle;

                        string firstLessonExcercise = $"{lessonTitle}-Exercise";
                        int indexOfFirstExcercise = indexOfFirstLesson + 1;

                        if (indexOfFirstLesson < lessons.Count && lessons[indexOfFirstExcercise] == firstLessonExcercise)
                        {
                            lessons.RemoveAt(indexOfFirstExcercise);
                            indexOfFirstExcercise = lessons.IndexOf(lessonTitle);
                            lessons.Insert(indexOfFirstExcercise, firstLessonExcercise);
                        }

                        string secondLessonEsxxercise = $"{secondLessonTitle}-Exercise";
                        int indexOfSecondExcercise = indexOfSecondLesson + 1 ;//oo

                        if (indexOfSecondExcercise < lessons.Count && lessons[indexOfSecondExcercise] == secondLessonEsxxercise)

                        {
                            lessons.RemoveAt(indexOfSecondLesson + 1);
                            indexOfSecondLesson = lessons.IndexOf(secondLessonTitle);
                            lessons.Insert(indexOfSecondLesson + 1, secondLessonEsxxercise);
                        }
                    }
                }
                else if (firstCommand == "Exercise")
                {
                    int index = lessons.IndexOf(lessonTitle);
                    string excerciese = $"{lessonTitle} - Exercise";

                    bool isThereAreLesson = lessons.Contains(lessonTitle);
                    bool isThereExercise = lessons.Contains(excerciese);

                    if (isThereAreLesson && !isThereExercise)
                    {
                        lessons.Insert(index + 1, excerciese);

                    }
                    else if (!isThereAreLesson)
                    {
                        lessons.Add(lessonTitle);
                        lessons.Add(excerciese);
                    }

                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}"); // i +1 за да не принти от 0
            }
        }
    }
}
