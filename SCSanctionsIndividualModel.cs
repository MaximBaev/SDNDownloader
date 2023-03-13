namespace SDNDownloader;

public class SCSanctionsIndividualModel
{
    public string dataId;
    public string firstName;
    public string secondName;
    public string? thirdName;
    public string? unListType;
    public string? referenceNumber;
    public string? listedOn;
    public string? comment;
    public List<Designation> designations;
    public List<Nationality> nationalities;
    public List<ListType> listTypes;
    public List<LastDayUpdated> lastDayUpdated;
    public List<Alias> aliases;
    public List<Address> addresses;
    public List<DateOfBirth> datesOfBirth;
    public List<PlaceOfBirth> placesOfBirth;
    public List<Document> documents;

    public SCSanctionsIndividualModel()
    {
        designations = new List<Designation>();
        nationalities = new List<Nationality>();
        listTypes = new List<ListType>();
        lastDayUpdated = new List<LastDayUpdated>();
        aliases = new List<Alias>();
        addresses = new List<Address>();
        datesOfBirth = new List<DateOfBirth>();
        placesOfBirth = new List<PlaceOfBirth>();
        documents = new List<Document>();
    }
}

public class Designation
{
    public string value;

    public Designation(string _value)
    {
        value = _value;
    }
}

public class Nationality
{
    public string value;

    public Nationality(string value)
    {
        this.value = value;
    }
}

public class ListType
{
    public string value;

    public ListType(string value)
    {
        this.value = value;
    }
}

public class LastDayUpdated
{
    public string value;

    public LastDayUpdated(string value)
    {
        this.value = value;
    }
}

public class Alias
{
    public string quality;
    public string aliasName;

    public Alias(string quality, string aliasName)
    {
        this.quality = quality;
        this.aliasName = aliasName;
    }

    public Alias()
    {
        
    }
}

public class Address
{
    public string stateProvince;
    public string street;
    public string city;
    public string country;
    public string note;

    public Address(string stateProvince, string street, string city, string country, string note)
    {
        this.stateProvince = stateProvince;
        this.street = street;
        this.city = city;
        this.country = country;
        this.note = note;
    }

    public Address()
    {
        
    }
}

public class DateOfBirth
{
    public string typeOfDate;
    public string date;

    public DateOfBirth(string typeOfDate, string date)
    {
        this.typeOfDate = typeOfDate;
        this.date = date;
    }

    public DateOfBirth()
    {
        
    }
}

public class PlaceOfBirth
{
    public string city;
    public string stateProvince;
    public string country;

    public PlaceOfBirth(string city, string stateProvince, string country)
    {
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public PlaceOfBirth()
    {
        
    }
}

public class Document
{
    public string typeOfDocument;
    public string number;
    public string issuingCountry;
    public string note;

    public Document(string typeOfDocument, string number, string issuingCountry, string note)
    {
        this.typeOfDocument = typeOfDocument;
        this.number = number;
        this.issuingCountry = issuingCountry;
        this.note = note;
    }

    public Document()
    {
        
    }
}