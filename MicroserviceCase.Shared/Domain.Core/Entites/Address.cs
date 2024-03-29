﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceCase.Shared.Domain.Core.Entites
{
    public class Address : ValueObject
    {
        public Address(string addressLine, string city, string country, int cityCode)
        {
            AddressLine = addressLine;
            City = city;
            Country = country;
            CityCode = cityCode;
        }

        [Required]
        [Column("AddressLine")]
        public string AddressLine { get; set; }
        [Required]
        [Column("City")]
        public string City { get; set; }
        [Required]
        [Column("Country")]
        public string Country { get; set; }
        [Required]
        [Column("CityCode")]
        public int CityCode { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return AddressLine;
            yield return City;
            yield return Country;
            yield return CityCode;
        }
    }
}
