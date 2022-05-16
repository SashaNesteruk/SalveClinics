using CsvHelper;
using CsvHelper.Configuration;
using SalveClinics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics
{
    public static class DatabaseSeeder
    {
        public static List<Clinic> SeedClinics(string fileName)
        {
            var clinics = new List<Clinic>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, config))
            {
                clinics.AddRange(csv.GetRecords<Clinic>().ToArray());
            }

            return clinics;
        }

        public static List<Patient> SeedPatients(string fileName)
        {
            var patients = new List<Patient>();

            TextReader reader = new StreamReader(fileName);
            CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            csvReader.Read();
            csvReader.ReadHeader();
            while (csvReader.Read())
            {
                var patient = new Patient()
                {
                    PatientNumber = csvReader.GetField<int>("id"),
                    ClinicId = csvReader.GetField<int>("clinic_id"),
                    DateOfBirth = csvReader.GetField<string>("date_of_birth"),
                    FirstName = csvReader.GetField<string>("first_name"),
                    LastName = csvReader.GetField<string>("last_name")
                };
                patients.Add(patient);
            }
            return patients;
        }
    }
}
