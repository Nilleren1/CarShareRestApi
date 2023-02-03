﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShareRestApi.Models
{
    public partial class Account
    {
        public Account()
        {
            CarPoolings = new HashSet<CarPooling>();
            RentalCars = new HashSet<RentalCar>();
        }

        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(255)]
        public string UserAddress { get; set; }
        public int Phone { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [InverseProperty(nameof(CarPooling.Account))]
        public virtual ICollection<CarPooling> CarPoolings { get; set; }
        [InverseProperty(nameof(RentalCar.Account))]
        public virtual ICollection<RentalCar> RentalCars { get; set; }
    }
}