using Microsoft.VisualBasic;
using System.Collections;

namespace CSVTEST
{
    public class Converter
        {
            public static bool ValidateFileInfo(String file)
            {
                if (file == "")
                {
                    //MessageBox.Show("There is no file Specified!");
                    return false;
                }

                if (!File.Exists(file))
                {
                    //MessageBox.Show("There is no file Specified!");
                    return false;
                }

                return true;
            }

            public static Dictionary<int, People> ParseFromCSV(String file)
            {
                StreamReader reader = new StreamReader(file);
                ArrayList lines = new ArrayList();
                Hashtable data = new Hashtable();
                var startPosition = 0;
                var currentPosition = 0;
                var foundQuote = false;
                var index = 0;
                var line = reader.ReadToEnd();
                var str = "";
                Dictionary<int, People> devList = new Dictionary<int, People>();

                try
                {
                    foreach (var cell in line)
                    {
                        currentPosition += 1;
                        switch ((int)cell)
                        {
                            case 34:
                                foundQuote = !foundQuote;
                                break;
                            case 13:
                            case 10:
                                if (!foundQuote)
                                {
                                    str = line.Substring(startPosition, (currentPosition - startPosition - 1));
                                    if (str.StartsWith((char)34) && str.EndsWith((char)34))
                                        str = str.Substring(1, str.Length - 2);

                                    if (str.Length > 0)
                                    {
                                        data.Add(index, str);
                                        lines.Add(data);
                                        startPosition = currentPosition;
                                        index = 0;
                                        data = new Hashtable();
                                    }
                                }
                                break;
                            case 44:
                                if (!foundQuote)
                                {
                                    str = line.Substring(startPosition, (currentPosition - startPosition - 1));
                                    if (str.StartsWith((char)10))
                                        str = str.Substring(1);
                                    if (str.StartsWith((char)34) && str.EndsWith((char)34))
                                        str = str.Substring(1, str.Length - 2);

                                    data.Add(index, str);
                                    index += 1;
                                    startPosition = currentPosition;

                                }
                                break;
                        }
                    }
                    int trueCount = 0;
                    foreach (Hashtable dataHash in lines)
                    {
                    People newDevs = new People();
                        var code = (dataHash[0] != null) ? dataHash[0].ToString() : "";
                          

                        if (code.Length > 0 && code.ToLower() != "first_name")
                        {
                            trueCount++;
                            var firstname = (dataHash[1] != null) ? dataHash[1].ToString() : "";
                            var lastname = (dataHash[2] != null) ? dataHash[2].ToString() : "";
                            var jobtitle = (dataHash[3] != null) ? dataHash[3].ToString() : "";
                            var email = (dataHash[4] != null) ? dataHash[4].ToString() : "";
                            var department = (dataHash[5] != null) ? dataHash[5].ToString() : "";
                            var contactType = (dataHash[6] != null) ? dataHash[6].ToString() : "";
                            var company = (dataHash[7] != null) ? dataHash[7].ToString() : "";
                            var businessNumber = (dataHash[8] != null) ? dataHash[8].ToString() : "";
                            var streetAddress = (dataHash[9] != null) ? dataHash[9].ToString() : "";
                            var city = (dataHash[10] != null) ? dataHash[10].ToString() : "";
                            var postcode = (dataHash[11] != null) ? dataHash[11].ToString() : "";
                            var country = (dataHash[12] != null) ? dataHash[12].ToString() : "";
                          
                            newDevs.first_name = firstname;
                            newDevs.last_name = lastname;
                            newDevs.job_title = jobtitle;
                            newDevs.email_address = email;
                            newDevs.department = department;
                            newDevs.contact_type = contactType;
                            newDevs.department = department;
                            newDevs.company_name = company;
                            newDevs.business_phone = businessNumber;
                            newDevs.street = streetAddress;
                            newDevs.city = city;
                            newDevs.postcode = postcode;
                            newDevs.country = country;


                        devList.Add(trueCount, newDevs);
                        }

                    }
                    return devList;
                }
                catch (Exception ex)
                {
                //MessageBox.Show(ex.message)
                    Console.WriteLine("There was an error parsing csv: " + ex.Message);
                    return new Dictionary<int, People>(); ;
                }

            }
        }
        public class People : CollectionBase
        {
            private string firstName;
            private string lastName;
            private string jobTitle;
            private string emailAddress;
            private string departmentName;
            private string contractType;
            private string companyName;
            private string businessPhone;
            private string streetAddress;
            private string streetAddress2;
            private string cityAddress;
            private string postcodeAddress;
            private string countryAddress;          

            public int Add(People value)
            {
                return List.Add(value);
            }
            public int IndexOf(int value)
            {
                return List.IndexOf(value);
            }

            public string first_name
            {
                get { return firstName; }
                set { firstName = value; }
            }
            public string last_name
            {
                get { return lastName; }
                set { lastName = value; }
            }
            public string job_title
            {
                get { return jobTitle; }
                set { jobTitle = value; }
            }
            public string email_address
            {
                get { return emailAddress; }
                set { emailAddress = value; }
            }
            public string department
            {
                get { return departmentName; }
                set { departmentName = value; }
            }
            public string contact_type
            {
                get { return contractType; }
                set { contractType = value; }
            }
            public string company_name
            {
                get { return companyName; }
                set { companyName = value; }
            }
            public string business_phone
            {
                get { return businessPhone; }
                set { businessPhone = value; }
            }
            public string street
            {
                get { return streetAddress; }
                set { streetAddress = value; }
            }
            public string street2
            {
                get { return streetAddress2; }
                set { streetAddress2 = value; }
            }
            public string city
            {
                get { return cityAddress; }
                set { cityAddress = value; }
            }
            public string postcode
            {
                get { return postcodeAddress; }
                set { postcodeAddress = value; }
            }
            public string country
            {
                get { return countryAddress; }
                set { countryAddress = value; }
            }
    }
    }

