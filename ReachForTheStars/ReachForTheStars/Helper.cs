using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReachForTheStars
{
    public class Helper
    {

        public static void ReplaceInIntList(List<int> list, int index, int newVal)
        {
            list.RemoveAt(index);
            list.Insert(index, newVal);
        }


        public static int BobUpAndDown(int origY, int maxDist, int currY, int swayOffset)
        {
            if (currY < origY - maxDist || currY > origY + maxDist)
                swayOffset *= -1;

            return swayOffset;
        }

        public static double StraightLineDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public static double GetRotation(double startingAngle, int x1, int y1, int x2, int y2)
        {
            double rotation = Math.Acos((x1-x2)/StraightLineDistance(x1,y1,x2,y2));

            if (y2 > y1)
                rotation *= -1;

            return rotation + Math.Abs(Math.PI - startingAngle);

            /*
            double rotation = Math.Atan(1.0 * y2 / y1);

            if (x2 < x1)
                rotation = Math.PI - rotation;

            if (y2 < y1)
                rotation *= -1;

            return rotation + startingAngle;
             * */
        }


        public static String GetFirstButtonPressCommand(List<Button> buttonList, int x, int y)
        {
            bool found = false;
            String command = "";
            foreach (Button button in buttonList)
                if (button.IsPressed(x, y))
                {
                    if (!found)
                    {
                        command = button.commandText;
                        found = true;
                    }
                }   
                   
            return command;
        }

    }
}
