using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using UnitTests.PixService;
using System.ServiceModel;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void PatientWithoutRequiredFields()
        {
            string correctResult = "Неверно заполнены данные пациента";
            PixServiceClient client = new PixServiceClient();
            try
            {
                client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", new PatientDto());
                NUnit.Framework.Assert.Fail();
            } 
            catch (Exception ex)
            {
                NUnit.Framework.Assert.AreEqual(ex.Message, correctResult);
            }
            client.Close();
        }

        [Test]
        public void AddPatienWithIllegalGuid()
        {
            PixServiceClient client = new PixServiceClient();
            string correctResult = "Неправильный идентификатор системы";
            try
            {
                client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46B", "1.2.643.5.1.13.3.25.78.118", new PatientDto());
                NUnit.Framework.Assert.Fail();
            }
            catch (Exception ex)
            {
                NUnit.Framework.Assert.AreEqual(ex.Message, correctResult);
            }
            client.Close();
        }
        [Test]
        public void addExample()
        {
            var rnd = new System.Random(DateTime.Now.GetHashCode());
            using (var service = new PixServiceClient())
            {
                service.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", new PatientDto
                {
                    IdPatientMis = rnd.Next().ToString(),
                    FamilyName = "165",
                    GivenName = "1651",
                    Sex = 1,
                    BirthDate = DateTime.Now,
                    Documents = new DocumentDto[]
                    {
                        new DocumentDto
                        {
                            DocS = "5465",
                            DocN = "6546",
                            ProviderName = "6546",
                            IdDocumentType = 223
                        },
                    },
                });
            }
            //string guid = "8CDE415D-FAB7-4809-AA37-8CDD70B1B46C";
            //string xmlns = "1.2.643.5.1.13.3.25.78.118";
            //PatientDto patient = new PatientDto();
            //AddressDto address1 = new AddressDto();
            //address1.Appartment = "1000";
            //address1.Building = "454";
            //address1.City = "0100000000000";
            //address1.GeoData = "3.072812,-79.040128";
            //address1.IdAddressType = 2;
            //address1.PostalCode = 454100;
            //address1.Street = "01000001000000100";
            //address1.StringAddress = "454100, город Челябинск, ул. Ленина, дом 454, квартира 1000";
            //AddressDto address2 = new AddressDto();
            //address2.Appartment = "002";
            //address2.Building = "202";
            //address2.City = "0100000000000";
            //address2.GeoData = "43.072812,-79.040128";
            //address2.IdAddressType = 8;
            //address2.PostalCode = 198000;
            //address2.Street = "01000001000000100";
            //address2.StringAddress = "198000, город Санкт-Петербург, ул. Ленина, дом 202, квартира 002";
            //AddressDto[] adrs = new AddressDto[2] {address1, address2};
            //patient.Addresses = adrs;
            //patient.BirthDate = new DateTime(1972, 11, 29);
            //BirthPlaceDto birthPlace = new BirthPlaceDto();
            //birthPlace.City = "Москва";
            //birthPlace.Country = "Россия";
            //birthPlace.Region = "Московская область";
            //patient.BirthPlace = birthPlace;
            //ContactDto contact1 = new ContactDto();
            //contact1.ContactValue = "8-111-111-11-11";
            //contact1.IdContactType = 1;
            //ContactDto contact2 = new ContactDto();
            //contact2.ContactValue = "111-11-11";
            //contact2.IdContactType = 2;
            //ContactDto[] conts = new ContactDto[2] {contact1, contact2};
            //patient.Contacts = conts;
            //DocumentDto document1 = new DocumentDto();
            //document1.DocN = "59165576238";
            //document1.DocS = "";
            //document1.DocumentName = "";
            //document1.IdDocumentType = 223;
            //document1.IssuedDate = new DateTime (2010, 12, 22);
            //document1.ProviderName = "ПФР";
            //DocumentDto document2 = new DocumentDto();
            //document2.DocN = "88885916";
            //document2.DocS = "4444";
            //document2.IdDocumentType = 14;
            //document2.IssuedDate = new DateTime(2010, 12, 22);
            //document2.ProviderName = "УФМС";
            //document2.RegionCode = "078";
            //DocumentDto document3 = new DocumentDto();
            //document3.DocN = "225916";
            //document3.DocS = "AA";
            //document3.ExpiredDate = new DateTime(2020, 01, 01);
            //document3.IdDocumentType = 226;
            //document3.IdProvider = 23807;
            //document3.IssuedDate = new DateTime(2010, 12, 22);
            //document3.ProviderName = "ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ \"МУНИЦИПАЛЬНАЯ СТРАХОВАЯ КОМПАНИЯ Г.КРАСНОДАРА - МЕДИЦИНА\"";
            //document3.RegionCode = "078";
            //DocumentDto document4 = new DocumentDto();
            //document4.DocN = "1212121212125916";
            //document4.DocS = "";
            //document4.DocumentName = "";
            //document4.ExpiredDate = new DateTime(2020, 01, 01);
            //document4.IdDocumentType = 228;
            //document4.IdProvider = 23807;
            //document4.IssuedDate = new DateTime(2010, 12, 22);
            //document4.ProviderName = "ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ \"МУНИЦИПАЛЬНАЯ СТРАХОВАЯ КОМПАНИЯ Г.КРАСНОДАРА - МЕДИЦИНА\"";
            //document4.RegionCode = "078";
            //DocumentDto[] docs = new DocumentDto[4] {document1, document2, document3, document4};
            //patient.Documents = docs;
            //patient.FamilyName = "Сидоров";
            //patient.GivenName = "Данила";
            //patient.IdBloodType = 8;
            //patient.IdLivingAreaType = 2;
            //patient.IdPatientMis = "IdentificatorOfPatient";
            //JobDto job = new JobDto();
            //job.CompanyName = "ООО Вкусный Апельсин";
            //job.DateEnd = new DateTime(2100, 01, 01);
            //job.DateStart = new DateTime(1900, 01, 01);
            //job.OgrnCode = "1234567890123";
            //job.Position = "кассир";
            //job.Sphere = "Обслуживание";
            //patient.Job = job;
            //patient.MiddleName = "Викторович";
            //PrivilegeDto privilage = new PrivilegeDto();
            //privilage.DateEnd = new DateTime(2020, 02, 02);
            //privilage.DateStart = new DateTime(2010, 01, 01);
            //privilage.IdPrivilegeType = 10;
            //patient.Privilege = privilage;
            //patient.Sex = 3;
            //patient.SocialGroup = 4;
            //patient.SocialStatus = 26;
            //PixServiceClient client = new PixServiceClient();
            //client.AddPatient(guid, xmlns, patient);
        }
        [Test]
        public void PatientWithRequiredFields()
        {
            //FaultException ex = FaultException();
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "Петров";
            patient.GivenName = "Иван";
            patient.Sex = 3;
            patient.BirthDate = new DateTime(1995, 8, 2);
            client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
            client.Close();
        }
        [Test]
        public void PatientWithSerialDocument()
        {
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "165";
            patient.GivenName = "1651";
            patient.Sex = 1;
            patient.BirthDate = DateTime.Now;            
            DocumentDto document = new DocumentDto();
            document.DocS = "5465";
            document.DocN = "111-111-111 11";
            document.ProviderName = "6546";
            document.IdDocumentType = 223;
            DocumentDto[] docs = new DocumentDto[1] { document };
            patient.Documents = docs;
            client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
            client.Close();
        }
        [Test]
        public void PatientWithIllegalSerialDocument()
        {
            string correctResult = "Параметр DocN контейнера Documents заполнен некорректно";
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "165";
            patient.GivenName = "1651";
            patient.Sex = 1;
            patient.BirthDate = DateTime.Now;
            DocumentDto document = new DocumentDto();
            document.DocS = "5465";
            document.DocN = "111-111-111 112345";
            document.ProviderName = "6546";
            document.IdDocumentType = 223;
            DocumentDto[] docs = new DocumentDto[1] { document };
            patient.Documents = docs;
            try
            {
                client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
                NUnit.Framework.Assert.Fail();
            }
            catch (Exception ex)
            {
                NUnit.Framework.Assert.AreEqual(ex.Message, correctResult);
            }
            client.Close();
        }
        [Test]
        public void ReAddPatient()
        {
            string correctResult = "Попытка повторного добавления пациента";
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "165";
            patient.GivenName = "1651";
            patient.Sex = 1;
            patient.BirthDate = DateTime.Now;
            DocumentDto document = new DocumentDto();
            document.DocS = "5465";
            document.DocN = "111-111-111 11";
            document.ProviderName = "6546";
            document.IdDocumentType = 223;
            DocumentDto[] docs = new DocumentDto[1] { document };
            patient.Documents = docs;
            client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
            try
            {
                client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
                NUnit.Framework.Assert.Fail();
            }
            catch(Exception ex)
            {
                NUnit.Framework.Assert.AreEqual(ex.Message, correctResult);
            }
            client.Close();
        }
        [Test]
        public void PatientWithBirthPlace()
        {
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "165";
            patient.GivenName = "1651";
            patient.Sex = 1;
            patient.BirthDate = DateTime.Now;
            DocumentDto document = new DocumentDto();
            document.DocS = "5465";
            document.DocN = "111-111-111 11";
            document.ProviderName = "6546";
            document.IdDocumentType = 223;
            DocumentDto[] docs = new DocumentDto[1] { document };
            patient.Documents = docs;
            BirthPlaceDto birthPlace = new BirthPlaceDto();
            birthPlace.Country = "Russia";
            birthPlace.Region = "Center";
            birthPlace.City = "Voronez";
            patient.BirthPlace = birthPlace;
            client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
            client.Close();
        }
        [Test]
        public void PatientWithIncorrectSex()
        {
            string correctResult = "Параметр Sex контейнера Patient заполнен некорректно";
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "165";
            patient.GivenName = "1651";
            patient.Sex = 144;
            patient.BirthDate = DateTime.Now;
            DocumentDto document = new DocumentDto();
            document.DocS = "5465";
            document.DocN = "111-111-111 11";
            document.ProviderName = "6546";
            document.IdDocumentType = 223;
            DocumentDto[] docs = new DocumentDto[1] { document };
            patient.Documents = docs;
            try
            {
                client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
                NUnit.Framework.Assert.Fail();
            }
            catch (Exception ex)
            {
                NUnit.Framework.Assert.AreEqual(ex.Message, correctResult);
            }
            client.Close();
        }
        [Test]
        public void PatientWithPrivilege()
        {
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "165";
            patient.GivenName = "1651";
            patient.Sex = 1;
            patient.BirthDate = DateTime.Now;
            DocumentDto document = new DocumentDto();
            document.DocS = "5465";
            document.DocN = "111-111-111 11";
            document.ProviderName = "6546";
            document.IdDocumentType = 223;
            DocumentDto[] docs = new DocumentDto[1] { document };
            patient.Documents = docs;
            PrivilegeDto privilage = new PrivilegeDto();
            privilage.DateStart = new DateTime(1996, 9, 13);
            privilage.DateEnd = new DateTime(2005, 7, 14);
            privilage.IdPrivilegeType = 4;
            patient.Privilege = privilage;
            client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
            client.Close();
        }
        [Test]
        public void IncorrectPrivilageTime()
        {
            string correctResult = "Значение параметра DateStart не может быть больше значения параметра DateEnd контейнера Privilege";
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "165";
            patient.GivenName = "1651";
            patient.Sex = 1;
            patient.BirthDate = DateTime.Now;
            DocumentDto document = new DocumentDto();
            document.DocS = "5465";
            document.DocN = "111-111-111 11";
            document.ProviderName = "6546";
            document.IdDocumentType = 223;
            DocumentDto[] docs = new DocumentDto[1] { document };
            patient.Documents = docs;
            PrivilegeDto privilage = new PrivilegeDto();
            privilage.DateStart = new DateTime(2005, 9, 13);
            privilage.DateEnd = new DateTime(1996, 7, 14);
            privilage.IdPrivilegeType = 4;
            patient.Privilege = privilage;
            try
            {
                client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
                NUnit.Framework.Assert.Fail();
            }
            catch (Exception ex)
            {
                NUnit.Framework.Assert.AreEqual(ex.Message, correctResult);
            }
            client.Close();
        }
        [Test]
        public void FullPatient()
        {
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = new Random(DateTime.Now.GetHashCode()).Next().ToString();
            patient.FamilyName = "165";
            patient.GivenName = "1651";
            patient.Sex = 1;
            patient.BirthDate = DateTime.Now;
            DocumentDto document = new DocumentDto();
            document.DocS = "5465";
            document.DocN = "111-111-111 11";
            document.ProviderName = "6546";
            document.IdDocumentType = 223;
            AddressDto address = new AddressDto();
            address.IdAddressType = 1;
            address.StringAddress = "MyAddress";
            address.Street = "Street";
            address.Building = "House";
            address.City = "Sity";
            address.Appartment = "Appartament";
            address.PostalCode = 123456;
            address.GeoData = "Geodata";
            BirthPlaceDto birthplace = new BirthPlaceDto();
            birthplace.Country = "Country";
            birthplace.City = "City";
            birthplace.Region = "Region";
            ContactDto contact = new ContactDto();
            contact.IdContactType = 1;
            contact.ContactValue = "123456789";
            JobDto job = new JobDto();
            job.OgrnCode = "code";
            job.CompanyName = "name";
            job.Sphere = "sphere";
            job.Position = "Position";
            job.DateStart = new DateTime(1998, 1, 1);
            job.DateEnd = new DateTime(2009, 9, 1);
            PrivilegeDto privilage = new PrivilegeDto();
            privilage.DateStart = new DateTime(1996, 9, 13);
            privilage.DateEnd = new DateTime(2005, 7, 14);
            privilage.IdPrivilegeType = 4;
            DocumentDto[] docs = new DocumentDto[1] { document };
            AddressDto[] adrs = new AddressDto[1] { address };
            ContactDto[] cnts = new ContactDto[1] { contact };
            patient.Documents = docs;
            patient.Addresses = adrs;
            patient.BirthPlace = birthplace;
            patient.Contacts = cnts;
            patient.Job = job;
            patient.Privilege = privilage;
            client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
        }
    }
}
