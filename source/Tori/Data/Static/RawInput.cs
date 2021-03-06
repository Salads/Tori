﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Soundboard.Data.Static;

namespace RawInput
{
	public static partial class RI
	{
		public static void RegisterDevices(IntPtr windowHandle)
		{
			RAWINPUTDEVICE[] devices = new RAWINPUTDEVICE[2];

			// FUTURE: Encapsulate these constants in a hashtable or something?

			// Mouse
			devices[0].usUsagePage = 0x01;
			devices[0].usUsage = 0x02;
			devices[0].dwFlags = RIDEV_INPUTSINK;
			devices[0].hwndTarget = windowHandle;

			// Keyboard
			devices[1].usUsagePage = 0x01;
			devices[1].usUsage = 0x06;
			devices[1].dwFlags = RIDEV_INPUTSINK;
			devices[1].hwndTarget = windowHandle;

			if(NativeMethods.RegisterRawInputDevices(devices, 2, Marshal.SizeOf(devices[0])))
			{
				Debug.WriteLine("Registered RawInput Devices.");
			}
			else
			{
				Debug.WriteLine("[ERROR] RawInput registration failed!");
			}
		}
	}
}
