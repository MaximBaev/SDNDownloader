using System.Net;
using System.Xml;
using SDNDownloader;

const string urlFilePath = "/URLs.txt";
string linksFilePath = Environment.CurrentDirectory + urlFilePath;

string[] links = File.ReadAllLines(linksFilePath);
string[] linksWithoutFirst = links[1..links.Length];
int i = 1;
string filesDirectory = Environment.CurrentDirectory +"/files";

DirectoryInfo dirInfo = new DirectoryInfo(filesDirectory);
if (!dirInfo.Exists)
{
    dirInfo.Create();
}
foreach (string link in linksWithoutFirst)
{
    Console.WriteLine($"Start download {i} file");
    string filePath = filesDirectory + '/' + i.ToString() + ".xml";
    using (var client = new WebClient())
    {
        client.DownloadFile(link, filePath);
    }
    Console.WriteLine($"{i} file is downloaded");
    i++;
}
// 0 file need parse and take xml urls for download
string fileOne = filesDirectory + "/1.xml";
XmlDocument xmlDoc = new XmlDocument();
xmlDoc.LoadXml(File.ReadAllText(fileOne));
XmlNodeList individuals = xmlDoc.GetElementsByTagName("INDIVIDUAL");
List<SCSanctionsIndividualModel> firstFileData = new List<SCSanctionsIndividualModel>();
foreach (XmlNode individual in individuals)
{
    SCSanctionsIndividualModel model = new SCSanctionsIndividualModel();
    model.dataId = individual["DATAID"].InnerText;
    model.firstName = individual["FIRST_NAME"].InnerText;
    try
    {
        model.secondName = individual["SECOND_NAME"].InnerText;
    }
    catch
    {
        
    }
    try
    {
        model.thirdName = individual["THIRD_NAME"].InnerText;
    }
    catch
    {
        
    }
    model.unListType = individual["UN_LIST_TYPE"].InnerText;
    model.referenceNumber = individual["REFERENCE_NUMBER"].InnerText;
    model.listedOn = individual["LISTED_ON"].InnerText;
    model.comment = individual["COMMENTS1"].InnerText;
    try
    {
        foreach (XmlNode values in individual["DESIGNATION"].GetElementsByTagName("VALUE"))
        {
            model.designations.Add(new Designation(values.InnerText));
        }
    }
    catch
    {
        
    }
    
    try
    {
        foreach (XmlNode values in individual["NATIONALITY"].GetElementsByTagName("VALUE"))
        {
            model.nationalities.Add(new Nationality(values.InnerText));
        }
    }catch
    {
        
    }
    
    try
    {
        foreach (XmlNode values in individual["LIST_TYPE"].GetElementsByTagName("VALUE"))
        {
            model.listTypes.Add(new ListType(values.InnerText));
        }
    }catch
    {
        
    }
    
    try
    {
        foreach (XmlNode values in individual["LAST_DAY_UPDATED"].GetElementsByTagName("VALUE"))
        {
            model.lastDayUpdated.Add(new LastDayUpdated(values.InnerText));
        }
    }catch
    {
        
    }
    
    var aliases = individual.SelectNodes("INDIVIDUAL_ALIAS");
    if (aliases != null)
    {
        foreach (XmlNode alias in aliases)
        {
            Alias tmp = new Alias();
            try
            {
                tmp.aliasName = alias["ALIAS_NAME"].InnerText;
            }
            catch{}

            try
            {
                tmp.quality = alias["QUALITY"].InnerText;                
            } catch{}
            model.aliases.Add(tmp);
        }        
    }
    
    var addresses = individual.SelectNodes("INDIVIDUAL_ADDRESS");
    if (addresses != null)
    {
        foreach (XmlNode address in addresses)
        {
            Address tmp = new Address();
            try
            {
                tmp.city = address["CITY"].InnerText;                
            } catch{}
            try
            {
                tmp.country = address["COUNTRY"].InnerText;          
            } catch{}
            try
            {
                tmp.note = address["NOTE"].InnerText;          
            } catch{}
            try
            {
                tmp.street = address["STREET"].InnerText;            
            } catch{}
            try
            {
                tmp.stateProvince = address["STATE_PROVINCE"].InnerText;              
            } catch{}
            model.addresses.Add(tmp);
        }        
    }

    var datesOfBirth = individual.SelectNodes("INDIVIDUAL_DATE_OF_BIRTH");
    if (datesOfBirth != null)
    {
        foreach (XmlNode dateOfBitrh in datesOfBirth)
        {
            DateOfBirth tmp = new DateOfBirth();
            try
            {
                tmp.typeOfDate = dateOfBitrh["TYPE_OF_DATE"].InnerText;            
            }catch{}
            try
            {
                tmp.date = dateOfBitrh["DATE"].InnerText;            
            }catch{}
            model.datesOfBirth.Add(tmp);
        }        
    }
    
    var placesOfBirth = individual.SelectNodes("INDIVIDUAL_PLACE_OF_BIRTH");
    if (placesOfBirth != null)
    {
        foreach (XmlNode placeOfBirth in placesOfBirth)
        {
            PlaceOfBirth tmp = new PlaceOfBirth();
            try
            {
                tmp.city = placeOfBirth["CITY"].InnerText;                
            } catch{}
            try
            {
                tmp.country = placeOfBirth["COUNTRY"].InnerText;          
            } catch{}
            try
            {
                tmp.stateProvince = placeOfBirth["STATE_PROVINCE"].InnerText;              
            } catch{}
            model.placesOfBirth.Add(tmp);
        }        
    }
    
    var documents = individual.SelectNodes("INDIVIDUAL_DOCUMENT");
    if (documents != null)
    {
        foreach (XmlNode document in documents)
        {
            Document tmp = new Document();
            try
            {
                tmp.note = document["NOTE"].InnerText;                
            } catch{}
            try
            {
                tmp.typeOfDocument = document["TYPE_OF_DOCUMENT"].InnerText;          
            } catch{}
            try
            {
                tmp.number = document["NUMBER"].InnerText;              
            } catch{}
            try
            {
                tmp.issuingCountry = document["ISSUING_COUNTRY"].InnerText;                
            } catch{}
            model.documents.Add(tmp);
        }        
    }
    
    firstFileData.Add(model);
}
Console.WriteLine("done");
