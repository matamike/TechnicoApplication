﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TechnicoApplication.Models;

public class Repair{
    [Key]public int Id { get; private set; }
    public DateTime ScheduledRepairDate {get; set;}
    public string? Description { get; set; } = string.Empty;
    public Property? property { get; set; } = null; 
    public RepairStatus Status{get; set;}
    public RepairType RType { get; set;}
    public Owner? owner { get; set; } = null;
    [Precision(8, 2)] public decimal Cost { get; set; }

    public override string ToString(){
        return $"====================== \n" +
               $" Repair Date: {ScheduledRepairDate.ToString()} \n" +
               $" Repair Cost: {Cost} \n" +
               $" Repair Description: {Description} \n" +
               $" Repair Type: {RType} \n" +
               $" Repair Status: {Status} \n" +
               $"====================== \n";
    }
}
