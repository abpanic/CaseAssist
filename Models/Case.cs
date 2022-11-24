using System.ComponentModel.DataAnnotations;

namespace RazorPagesCase.Models;

public class SR
{
    
    public int Id {get; set;}   
    [Required]
    public int number {get; set;}            
    public string? Issue {get;set;}
    public bool IsFQRdone {get;set;}        
    public POD POD {get;set;}
    public IsSME IsSMEReviewed {get;set;}
    
    [Range(0.1, 999)]
    public decimal Age {get;set;}    
    

}
public enum POD{PowerApps, Clients, Apps, Platform}
public enum IsFQRdone{True, False}
public enum IsSME{True, False}

    //Id,number, Issue, FQR, POD, Age, SMEed