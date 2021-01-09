using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        public Rover(string[] CurrentPosition, string[] Instructions)
        {
            this.CurrentPosition = CurrentPosition;
            NewPosition = CurrentPosition;
            this.Instructions = Instructions;
            GetNewPosition();
        }
        #region Constants

        public string[] CurrentPosition { get; }

        public string[] NewPosition { get; }

        public string[] Instructions { get; }

        public string ErrDesc
        {
            get
            {
                switch (ErrCode)
                {
                    case 0:
                        return "Success";
                    case 1:
                        return "ERROR:Current Position length should be 3!!";
                    case 2:
                        return "ERROR:Current Position format should be (number,number,character)!!";
                    case 3:
                        return "ERROR:Instructions should be character list!!";
                    case 4:
                        return "ERROR:Instructions should include (L,R,M)!!";
                    case 5:
                        return "ERROR:Current Position character digit should include (N,E,S,W)!!";
                    default:
                        return null;
                }
            }
        }

        public decimal? ErrCode { get; private set; }

        readonly string Left = "L";
        readonly string Right = "R";
        readonly string Move = "M";
        readonly string North = "N";
        readonly string East = "E";
        readonly string South = "S";
        readonly string West = "W";

        #endregion
        #region Methods
        private decimal? InputsControl(string[] currentPosition, string[] instructions)
        {
            decimal? result = Decimal.Zero;
            if (currentPosition.Length != 3)
                return 1;
            else if (!int.TryParse(currentPosition[0], out _) || !int.TryParse(currentPosition[1], out int _) || int.TryParse(currentPosition[2], out int _))
                return 2;
            else if ((currentPosition[2] != North && currentPosition[2] != East && currentPosition[2] != South && currentPosition[2] != West))
                return 5;
            for (int i = 0; i < instructions.Length; i++)
            {
                if (int.TryParse(instructions[i], out int _))
                    return 3;
                else if ((instructions[i] != Left && instructions[i] != Right && instructions[i] != Move))
                    return 4;
            }
            return result;
        }

        private void GetNewPosition()
        {
            ErrCode = InputsControl(CurrentPosition, Instructions);
            if (ErrCode == 0)
                for (int indexOfInstructions = 0; indexOfInstructions < Instructions.Length; indexOfInstructions++)
                {
                    if (Instructions[indexOfInstructions] == Left || Instructions[indexOfInstructions] == Right)
                        NewPosition[2] = GetFace(Instructions[indexOfInstructions]);
                    else if (Instructions[indexOfInstructions] == Move)
                        Go();
                }
        }

        private string GetFace(string newOne)
        {
            string result = NewPosition[2];

            switch (NewPosition[2])
            {
                case "N":
                    {
                        if (newOne == Left)
                            result = West;
                        else if (newOne == Right)
                            result = East;

                    }
                    break;
                case "E":
                    {
                        if (newOne == Left)
                            result = North;
                        else if (newOne == Right)
                            result = South;

                    }
                    break;
                case "S":
                    {
                        if (newOne == Left)
                            result = East;
                        else if (newOne == Right)
                            result = West;

                    }
                    break;
                case "W":
                    {
                        if (newOne == Left)
                            result = South;
                        else if (newOne == Right)
                            result = North;

                    }
                    break;
            }


            return result;
        }

        private void Go()
        {
            int xLine = Convert.ToInt32(NewPosition[0]);
            int yLine = Convert.ToInt32(NewPosition[1]);
            string face = NewPosition[2];
            switch (face)
            {
                case "N":
                    yLine += 1;
                    break;
                case "E":
                    xLine += 1;
                    break;
                case "S":
                    yLine -= 1;
                    break;
                case "W":
                    xLine -= 1;
                    break;

            }
            NewPosition[0] = xLine.ToString();
            NewPosition[1] = yLine.ToString();

        }
        #endregion
    }
}
