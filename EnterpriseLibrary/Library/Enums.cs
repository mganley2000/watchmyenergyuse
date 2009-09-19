using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Energy.Library
{
    /// <summary>
    /// Library Enumerations
    /// </summary>
    public class Enums
    {
        public enum Interval
        {
            TwoSecond = 0,
            OneMinute = 1,
            FiveMinute = 2,
            FifteenMinute = 3,
            ThirtyMinute = 4,
            Hourly = 5,
            Daily = 6
        }

        public enum MeterType
        {
            maxstream_zigbee_1 = 0
        }

        public enum RateType
        {
            Flat = 0,
            TimeOfUse = 1
        }

        public enum UnitOfMeasure
        {
            kWh = 0,
            kW = 1
        }

        public enum SelectChart
        {
            DailyEnergy = 0,
            HourlyEnergy = 1,
            DailyCost = 2
        }

        public enum SelectDate
        {
            CurrentMonth = 0,
            Months3 = 1,
            Months6 = 2,
            Months12 = 3,
            Days10 = 4
        }

        public enum TimeOfUse
        {
            None = 0,
            OffPeak = 1,
            Peak = 2
        }

        public enum Season
        {
            None = 0,
            Summer = 1,
            Winter = 2
        }

        public enum WeekdayWeekend
        {
            Weekday = 0,
            Weekend = 1
        }
    }
}
