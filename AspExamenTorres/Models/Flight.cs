﻿using System;
using System.Collections.Generic;
using System.Text;

   public  class Flight
    {
    private Airline _airline;
    private City _arrivalCity;
    private DateTime _arrivalTime;
    private DateTime _date;
    private City _departureCity;
    private DateTime _departureTime;
    private int _id;
    private FlightStatus _status;

    public Airline Airline
    {
        get { return _airline; }
        set { _airline = value; }
    }

    public City ArrivalCity
    {
        get { return _arrivalCity; }
        set { _arrivalCity = value; }
    }

    public DateTime ArrivalTime
    {
        get { return _arrivalTime; }
        set { _arrivalTime = value; }
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public City DepartureCity
    {
        get { return _departureCity; }
        set { _departureCity = value; }
    }

    public DateTime DepartureTime
    {
        get { return _departureTime; }
        set { _departureTime = value; }
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public FlightStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }






    public Flight()
    {
        _airline = new Airline();
        _arrivalCity = new City();
        _arrivalTime = new DateTime();
        _date = new DateTime();
        _departureCity = new City();
        _departureTime = new DateTime();
        _id = 0;
        _status = FlightStatus.Boarding;
    }




}

