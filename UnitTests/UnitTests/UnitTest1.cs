using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using UnitTests.PixService;

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
        public void PatientWithRequiredFields()
        {
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.GivenName = "Ivan";
            patient.Sex = 1;
            patient.BirthDate = new DateTime(1995, 4, 12, 13, 33, 11);
            client.AddPatient("8CDE415D-FAB7-4809-AA37-8CDD70B1B46C", "1.2.643.5.1.13.3.25.78.118", patient);
            client.Close();
        }
        [Test]
        public void PatientWithSerialDocument()
        {
            PixServiceClient client = new PixServiceClient();
            PatientDto patient = new PatientDto();
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.GivenName = "Ivan";
            patient.Sex = 1;
            patient.BirthDate = new DateTime(1995, 4, 12, 13, 33, 11);
            DocumentDto document = new DocumentDto();
            document.IdDocumentType = 14;
            document.DocS = "1111 111111";
            document.DocN = "111-111-111 11";
            document.ProviderName = "UFMS Sity";
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
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.GivenName = "Ivan";
            patient.Sex = 1;
            patient.BirthDate = new DateTime(1995, 4, 12, 13, 33, 11);
            DocumentDto document = new DocumentDto();
            document.IdDocumentType = 14;
            document.DocS = "1111 111111";
            document.DocN = "111-111-111 11234";
            document.ProviderName = "UFMS Sity";
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
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.GivenName = "Ivan";
            patient.Sex = 1;
            patient.BirthDate = new DateTime(1995, 4, 12, 13, 33, 11);
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
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.GivenName = "Ivan";
            patient.Sex = 1;
            patient.BirthDate = new DateTime(1995, 4, 12, 13, 33, 11);
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
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.GivenName = "Ivan";
            patient.Sex = 144;
            patient.BirthDate = new DateTime(1995, 4, 12, 13, 33, 11);
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
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.GivenName = "Ivan";
            patient.Sex = 1;
            patient.BirthDate = new DateTime(1995, 4, 12, 13, 33, 11);
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
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.GivenName = "Ivan";
            patient.Sex = 1;
            patient.BirthDate = new DateTime(1995, 4, 12, 13, 33, 11);
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
            patient.IdPatientMis = "123";
            patient.FamilyName = "Petrov";
            patient.MiddleName = "Vasilevich";
            patient.GivenName = "Ivan";
            patient.Sex = 1;
            patient.BirthDate = new DateTime(1995, 8, 2);
            patient.IdBloodType = 1;
            patient.IdLivingAreaType = 1;
            patient.SocialStatus = 1;
            patient.SocialGroup = 2;
            DocumentDto document = new DocumentDto();
            document.IdDocumentType = 14;
            document.DocS = "1111 111111";
            document.DocN = "111-111-111 11234";
            document.ExpiredDate = new DateTime(1992, 4, 12);
            document.IssuedDate = new DateTime(2018, 3, 3);
            document.IdProvider = 1;
            document.ProviderName = "UFMS Sity";
            document.RegionCode = "1";
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
