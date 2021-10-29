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
using UnityEngine;

namespace ModuleKELights
{
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	internal class Startup:MonoBehaviour
	{
		private void Start()
		{
			Log.force("Version {0}", Version.Text);

			try
			{
				KSPe.Util.Installation.Check<Startup>("KerbalElectric", "Kerbal Electric", null);
			}
			catch (KSPe.Util.InstallmentException e)
			{
				Log.error(e, this);
				KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
			}
		}
	}
}
