using System;
using System.Collections.Generic;
using System.Text;
using System.Data; //NEEDED FOR CONNECTION
using System.Data.SqlClient; //NEEDED FOR CONNECTION

public class City
    {
    #region Atributos
    
    private string _id;
    private string _name;
    #endregion


    #region Propiedades
    
    public string Id
    {
        get { return _id; }
        set { value = _id; }

    }
   
    public string Name
    {
        get { return _name; }
        set { value = _name; }
    }

    #endregion


    #region Constructores

    public  City()
    {
        _id = "";
        _name = "";

    }

    public City(string id, string name)
    {
        _id = id;
        _name = name;
    }


    public City(string id)
    {
        //query
        string query = @"select id, name from cities where id = @ID";
        //command
        SqlCommand command = new SqlCommand(query);
        //parameters
        command.Parameters.AddWithValue("@ID", id);
        //execute query
        DataTable table = SqlServerConnection.ExecuteQuery(command);
        //check if data is found
        if (table.Rows.Count > 0)
        {
            DataRow row = table.Rows[0];
            //read columns
            _id = id;
            _name = (string)row["name"];
        }
    }
    #region instanciamos los metodos
    public List<Flight> GetArrivals()
    {
        List<Flight> list = new List<Flight>();
        //query
        string query = "select f.id, f.airlineId, a.name as airlineName, date, f.departureCityId, dc.name as departureCity, f.departureTime,  f.arrivalCityId, ac.name as arrivalCity, f.arrivalTime, f.status from flights as f  join airlines as a on f.airlineId = a.id join cities as dc on f.departureCityId = dc.id join cities as ac on f.arrivalCityId = ac.id where f.arrivalCityId = @ID order by f.departureTime";
        //command
        SqlCommand command = new SqlCommand(query);
        //parameters
        command.Parameters.AddWithValue("@ID", _id);
        //execute query
        DataTable table = SqlServerConnection.ExecuteQuery(command);
        //check if data is found
        foreach (DataRow row in table.Rows)
        {
            //read columns
            int id = (int)row["id"];
            string airlineId = (string)row["airlineId"];
            string airlineName = (string)row["airlineName"];
            DateTime date = (DateTime)row["date"];
            string departureCityId = (string)row["departureCityId"];
            string departureCityName = (string)row["departureCity"];
            DateTime departureTime = Convert.ToDateTime(row["departureTime"].ToString());
            string arrivalCityId = (string)row["arrivalCityId"];
            string arrivalCityName = (string)row["arrivalCity"];
            DateTime arrivalTime = Convert.ToDateTime(row["arrivalTime"].ToString());
            FlightStatus status = (FlightStatus)row["status"];

            Airline airline = new Airline(airlineId, airlineName);
            City departureCity = new City(departureCityId, departureCityName);
            City arrivalCity = new City(arrivalCityId, arrivalCityName);

            Flight f = new Flight();
            f.Airline = airline;
            f.ArrivalCity = arrivalCity;
            f.ArrivalTime = arrivalTime;
            f.Date = date;
            f.DepartureCity = departureCity;
            f.DepartureTime = departureTime;
            f.Id = id;
            f.Status = status;

            list.Add(f);
        }

        return list;
    }

    public List<Flight> GetDepartures()
    {
        List<Flight> list = new List<Flight>();
        //query
        string query = @"select f.id, f.airlineId, a.name as airlineName, date, f.departureCityId, dc.name as departureCity, f.departureTime, 
                        f.arrivalCityId, ac.name as arrivalCity, f.arrivalTime, f.status
                        from flights as f 
                        join airlines as a on f.airlineId = a.id
                        join cities as dc on f.departureCityId = dc.id
                        join cities as ac on f.arrivalCityId = ac.id
                        where f.departureCityId = @ID
                        order by f.departureTime";
        //command
        SqlCommand command = new SqlCommand(query);
        //parameters
        command.Parameters.AddWithValue("@ID", _id);
        //execute query
        DataTable table = SqlServerConnection.ExecuteQuery(command);
        //check if data is found
        foreach (DataRow row in table.Rows)
        {
            //read columns
            int id = (int)row["id"];
            string airlineId = (string)row["airlineId"];
            string airlineName = (string)row["airlineName"];
            DateTime date = (DateTime)row["date"];
            string departureCityId = (string)row["departureCityId"];
            string departureCityName = (string)row["departureCity"];
            DateTime departureTime = Convert.ToDateTime(row["departureTime"].ToString());
            string arrivalCityId = (string)row["arrivalCityId"];
            string arrivalCityName = (string)row["arrivalCity"];
            DateTime arrivalTime = Convert.ToDateTime(row["arrivalTime"].ToString());
            FlightStatus status = (FlightStatus)row["status"];
            //Console.WriteLine("status: " + status);
            Airline airline = new Airline(airlineId, airlineName);
            //Console.WriteLine(airlineName);
            City departureCity = new City(departureCityId, departureCityName);
            City arrivalCity = new City(arrivalCityId, arrivalCityName);

            Flight f = new Flight();
            f.Airline = airline;
            f.ArrivalCity = arrivalCity;
            f.ArrivalTime = arrivalTime;
            f.Date = date;
            f.DepartureCity = departureCity;
            f.DepartureTime = departureTime;
            f.Id = id;
            f.Status = status;

            list.Add(f);
        }

        return list;
    }
    #endregion
    public override string ToString()
    {
        return Name;
    }
}


    #endregion


