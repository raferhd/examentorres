using System;
using System.Collections.Generic;
using System.Text;


   public class Airline
    {

    private string _id;
    private string _name;


    public string Id
    {
        get{ return _id; }
        set { value = _id; }
    }
    public string Name
    {
        get { return _name; }
        set { value = _name; }
    }

    public Airline()
    {
        _id = "";
        _name = "";
    }

    public Airline(string id,string name)
    {
        _id = id;
        _name = name;
    }

    }

