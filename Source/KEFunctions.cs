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

namespace ModuleKELights
{
    public static class KEFunctions
    {
        public static Part GetResourcePart(Vessel v, string resourceName)
        {
            foreach (Part mypart in v.parts)
            {
                if (mypart.Resources.Contains(resourceName))
                {
                    return mypart;
                }
            }
            return null;
        }

        public static int GetResourceID(this Part part, string resourceName)
        {
            PartResourceDefinition resource = PartResourceLibrary.Instance.GetDefinition(resourceName);
            return resource.id;
        }

        public static double GetVesselResourceAmount(Vessel v, string resourceName)
        {
            PartResourceDefinition resource = PartResourceLibrary.Instance.GetDefinition(resourceName);
            double amount = 0.0f;
            foreach (Part mypart in v.parts)
            {
                if (mypart.Resources.Contains(resourceName))
                {
                    amount += GetPartResourceAmount(mypart, resourceName);
                }
            }
            return amount;
        }

        public static double GetVesselResourceMax(Vessel v, string resourceName)
        {
            PartResourceDefinition resource = PartResourceLibrary.Instance.GetDefinition(resourceName);
            double amount = 0.0f;
            foreach (Part mypart in v.parts)
            {
                if (mypart.Resources.Contains(resourceName))
                {
                    amount += GetPartResourceMax(mypart, resourceName);
                }
            }
            return amount;
        }

        public static double GetPartResourceAmount(this Part part, string resourceName)
        {
            PartResourceDefinition resource = PartResourceLibrary.Instance.GetDefinition(resourceName);
            double amount = 0.0f;
            if (part.Resources.Contains(resource.id))
            {
                amount = part.Resources.Get(resource.id).amount;
            }
            return amount;
        }

        public static double GetPartResourceMax(this Part part, string resourceName)
        {
            PartResourceDefinition resource = PartResourceLibrary.Instance.GetDefinition(resourceName);
            double amount = 0.0f;
            if (part.Resources.Contains(resource.id))
            {
                amount = part.Resources.Get(resource.id).maxAmount;
            }
            return amount;
        }
    }
}
