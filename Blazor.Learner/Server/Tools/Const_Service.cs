using System;


namespace BlazorTemplate.Models
{
   
    public static class DateTimeManipulator
    {
        public static string GetHourStrByMinute(int aminute)
        {
            if (aminute < 1)
            {
                return "0хв";
            }
            int ahour = Convert.ToInt32( Math.Floor(aminute / 60.0));
            int amin = aminute - ahour * 60;
            if (ahour > 0)
            {
                return String.Format("{0}г {1}хв", ahour, amin);
            }
            return String.Format("{0}хв",  amin);
        }
        public const string tmformat = "HH:mm";
        public const string dttmformat = "dd.MM.yyyy HH:mm";
        public const string dttmformatshort = "dd.MM HH:mm";
        public const string dtformat = "dd.MM.yyyy";
        public const string dttmformatfb = "MM\\/dd\\/yyyy HH:mm";//DateTime.Now.ToString(DateTimeManipulator.dttmformatfb));
        public const string dtformatfb = "MM\\/dd\\/yyyy";
        public const decimal onehour = 1 / 24;
        public const decimal onemin = 1/24/60;
        public const decimal onesec = 1 / 24 / 60/60;
    }

    public static class Constants
    {
        public const int IDUndefined = 0;
        public const int IDNotExists = -1;
        public const int ZERO = 0;
        public const int FACESIDE = 1;
        public const int BACKSIDE = 2;
       
        public const int CookiesExpiresDay = 10;
        public const string MONITOR10 = "1";
        public const string MONITOR21 = "2";
        public const string MONITOR21TS = "3";

       

        
        public const string NONEDATE = " Не вказано";


      
    }


    
}
