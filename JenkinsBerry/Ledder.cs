using System;
using System.Threading;
using RaspberryPiDotNet;

namespace JenkinsBerry
{
    public static class Ledder
    {
        public enum Color {
            Green,
            Orange,
            Red
        }

        static GPIOPins[] pinMapping = new GPIOPins[] {
            GPIOPins.V2_GPIO_17,
            GPIOPins.V2_GPIO_27,
            GPIOPins.V2_GPIO_22,
        };

        public static void FlashLed (Color color, int times = 3)
        {
            var pin = pinMapping [(int)color];
            for (int i = 0; i < times; i++) {
                GPIO.Write (pin, true);
                Thread.Sleep (500);
                GPIO.Write (pin, false);
                Thread.Sleep (500);
            }
        }

        public static void TurnOn (Color color)
        {
            var pin = pinMapping [(int)color];
            GPIO.Write (pin, false);
        }

        public static void TurnAllColorOff ()
        {
            foreach (var pin in pinMapping)
                GPIO.Write (pin, true);
        }
    }
}
