using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Common.Constants
{
    public class Messages
    {
        //Common
        public const string OperationSuccessful = "Operation Successful";
        public const string InvalidInput = "Invalid Input";
        public const string ErrorOccured = "Error occured";
        //Vaccination
        public const string NoVaccinationCentreFound = "No Vaccinination Centres found";
        //Ambulance
        public const string NoAmbulanceFound = "No Ambulance found";
        //Master
        public const string NoCityFound = "No City found";
        public const string NoLocationFound = "Error occured while fetching Location";
        //HospitalBed
        public const string NoHospitalBedsFound = "No Hospital Beds found";
        //Medicine
        public const string NoMedicinesEquipmentsFound = "No Medicinces/Equipments Found";
        public const string NoMedicalShopsFound = "No Medical Shops found having stock of this medicine";
        //Oxygen
        public const string NoOxygenFound = "No Oxygen found";
    }
}
