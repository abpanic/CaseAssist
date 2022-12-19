using RazorPagesCase.Models;
//SR Model fields: //number, Issue, FQR, POD, Age, SMEed

namespace RazorPagesCase.Services;

public static class TransferService
{

    static List<SR> SRs {get;}
    static int nextnumber = 3;

    static TransferService()
    {
        SRs=new List<SR>
        {
            new SR{number=Guid.NewGuid(), Issue="cannot login into org", IsFQRdone =true, POD =POD.PowerApps,Age = 67, IsSMEReviewed =IsSME.False},
            new SR{number=Guid.NewGuid(), Issue="configuring CRM client for outlook", IsFQRdone =true, POD =POD.Clients, Age = 4, IsSMEReviewed =IsSME.False}
        };
    }

    public static List<SR> GetAll()=> SRs;

    public static SR? Get(int number) => SRs.FirstOrDefault(c =>c.number==number);

    public static void Add(SR SR)
    {
        SR.number= nextnumber++;
        SRs.Add(SR);
    }

    public static void Delete(int number)
    {
        var SR=Get(number);
        if (SR is null)
            return;
        
        SRs.Remove(SR);
    
    }

    public static void Update(SR SR)
    {
        var index=SRs.FindIndex(c => c.number==SR.number);
        if (index==-1)
         return;
        
        SRs[index]=SR;
    }


}