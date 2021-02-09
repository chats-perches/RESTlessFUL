using System;

namespace RestFul
{

        /*
         THIS CLASS IS PART of the boiler-plate code, when you create a fresh ASP .NET core app
        that's wired to an Angular Front-end application
        THIS ARTIFACT is vestigial structure of the project & have been left behind for the sake of studying the structure
        For this studio this class and the code is inoperative vis-a-vis the DATABASE & the FRONT-END Angular application
         */

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
