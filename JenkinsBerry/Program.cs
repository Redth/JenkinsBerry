using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace JenkinsBerry
{
	class MainClass
	{
		public static void Main (string[] args)
		{			

            var colors = new List<Ledder.Color> ();

            for (int i = 0; i < 8; i++) {
                colors.Add (Ledder.Color.Red);
            }

            Stripper.StreamColors (colors);
		}

	}
}
