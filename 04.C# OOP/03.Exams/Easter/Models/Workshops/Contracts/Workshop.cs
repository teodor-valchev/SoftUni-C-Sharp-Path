using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Workshops.Contracts
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {

            if (bunny.Energy > 0)
            {
                foreach (var dye in bunny.Dyes)
                {
                    if (!dye.IsFinished())
                    {
                        while (!egg.IsDone() && bunny.Energy > 0 && !dye.IsFinished())
                        {

                            bunny.Work();
                            dye.Use();
                            egg.GetColored();
                        }
                    }
                }
            }

        }
    }
}
