using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DateConversion
/// </summary>
public class DateConversion
{
	public DateConversion()
	{
		
	}

    public static string DateTimeToPersian(DateTime datetime)
    {
        if (datetime == new DateTime())
            return "";
        PersianCalendar pc = new PersianCalendar();

        return pc.GetYear(datetime).ToString() + "/" + pc.GetMonth(datetime).ToString() + "/" + pc.GetDayOfMonth(datetime).ToString();

    }
    public static string DateTimeToPersianDay(DateTime datetime)
    {
        if (datetime == new DateTime())
            return "";
        PersianCalendar pc = new PersianCalendar();
        switch (pc.GetDayOfWeek(datetime).ToString())
        {
            case "Monday":
                return "دوشنبه";
            case "Tuesday":
                return "سه شنبه";
            case "Wednesday":
                return "چهارشنبه";
            case "Thursday":
                return "پنج شنبه";
            case "Friday":
                return "جمعه";
            case "Saturday":
                return "شنبه";
            case "Sunday":
                return "یکشنبه";
            default:
                return "";
        }

    }
    public static DateTime PersianDateToDate(string datetime)
    {

        if (datetime == "")
            new DateTime();
        else
        {

            PersianCalendar pc = new PersianCalendar();
            int year = Convert.ToInt32(datetime.Split('/')[0]);
            int month = Convert.ToInt32(datetime.Split('/')[1]);
            int day = Convert.ToInt32(datetime.Split('/')[2]);

            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
        return new DateTime();
    }
    public static string GetMonthNames(int which)
    {
        switch (which)
        {
            case 1:
                return "فروردین";                
            case 2:
                return "اردیبهشت";
            case 3:
                return "خرداد";
            case 4:
                return "تیر";
            case 5:
                return "مرداد";
            case 6:
                return "شهریور";
            case 7:
                return "مهر";
            case 8:
                return "آبان";
            case 9:
                return "آذر";
            case 10:
                return "دی";
            case 11:
                return "بهمن";
            case 12:
                return "اسفند";
            default:
                return "";
        }
    }

    public static bool CompareDate(DateTime D1, DateTime D2, int Days)
    {
        if (Days > 0)
            if (D2.Ticks < D1.AddDays(Days).Ticks)
                return true;
            else return false;
        else if (Days < 0)
            if (D2.Ticks > D1.AddDays(Days).Ticks)
                return true;
            else return false;
        else
            if (DateConversion.DateTimeToPersian(D1) == DateConversion.DateTimeToPersian(D2))
                return true;
            else return false;
    }
}