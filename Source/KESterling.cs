/*
	This file is part of Kerbal Electric /L Unleashed
		© 2018-21 Lisias T : http://lisias.net <support@lisias.net>
		© 2018 Fengist

	Kerbal Electric /L Unleashed is licensed as follows:

		* CC-BY-NC-SA 4.0i : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Kerbal Electric /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

*/
using System;

namespace ModuleKELights
{
    class KESterlingEngine : PartModule
    {
        [KSPField]
        public string resourceName = null;

        [KSPField]
        public double resourceAmt = 0.001f;

        [KSPField]
        public bool actRad = false;

        [KSPField(guiActive = true, guiName = "Electric Charge")]
        public double transAmt = 0.0;

        public void FixedUpdate()
        {
            if (!HighLogic.LoadedSceneIsFlight)
            {
                return;
            }
            double kw = Math.Abs(this.part.thermalRadiationFlux);
            Part rPart = KEFunctions.GetResourcePart(FlightGlobals.ActiveVessel, resourceName);
            if (rPart != null)
            {
                int id = KEFunctions.GetResourceID(rPart, resourceName);
                double rTotal = KEFunctions.GetVesselResourceAmount(FlightGlobals.ActiveVessel, resourceName);
                double rMax = KEFunctions.GetVesselResourceMax(FlightGlobals.ActiveVessel, resourceName);
                transAmt = resourceAmt * kw;
                if (actRad == true) // look for active radiator
                {
                    for (int i = this.part.Modules.Count - 1; i >= 0; --i)
                    {
                        PartModule M = this.part.Modules[i];
                        if (M is ModuleActiveRadiator)
                        {
                            if ((M as ModuleActiveRadiator).IsCooling)
                            {
                                rPart.TransferResource(id, transAmt);
                            }
                        }
                    }
                }
                else
                {
                    rPart.TransferResource(id, transAmt);
                }
            }
        }
    }
}
