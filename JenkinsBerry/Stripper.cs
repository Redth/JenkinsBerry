using System;
using System.Linq;
using System.Collections.Generic;
using RaspberryPiDotNet;

namespace JenkinsBerry
{
	public class Stripper
	{
		static readonly byte[] Red = new byte[] { 0, 0, 0xFF };
		static readonly byte[] Orange = new byte[] { 0xFF, 0, 0 };
		static readonly byte[] Green = new byte[] { 0, 0xFF, 0 };

		public static void StreamColors (IEnumerable<Ledder.Color> colors)
		{
			GPIOMem.BeginSpi (GPIOMem.ChipSelect.CsNone, 128);
			var bytes = colors.SelectMany (c => BytesForColor (c)).ToArray ();
			GPIOMem.SendBytes (bytes);
		}

		static IEnumerable<byte> BytesForColor (Ledder.Color c)
		{
			switch (c) {
			case Ledder.Color.Green:
				return Green;
			case Ledder.Color.Orange:
				return Orange;
			default:
				return Red;
			}
		}
	}
}

