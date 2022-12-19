using RazorPagesCase.Models;
//SR Model fields: //number, Issue, FQR, POD, Age, SMEed

namespace RazorPagesCase.Services;

public static class TransferService
{

    static List<SR> SRs {get;}
    static int nextId = 3;

    static TransferService()
    {
        SRs=new List<SR>
        {
            new SR{number=1, Issue="cannot login into org", IsFQRdone =true, POD =POD.PowerApps,Age = 67, IsSMEReviewed =IsSME.False},
            new SR{number=2, Issue="configuring CRM client for outlook", IsFQRdone =true, POD =POD.Clients, Age = 4, IsSMEReviewed =IsSME.False}
        };
    }

    public static List<SR> GetAll()=> SRs;

    public static SR? Get(int id) => SRs.FirstOrDefault(c =>c.Id==id);

    public static void Add(SR SR)
    {
        SR.Id= nextId++;
        SRs.Add(SR);
    }

    public static void Delete(int id)
    {
        var SR=Get(id);
        if (SR is null)
            return;
        
        SRs.Remove(SR);
    
    }

    public static void Update(SR SR)
    {
        var index=SRs.FindIndex(c => c.Id==SR.Id);
        if (index==-1)
         return;
        
        SRs[index]=SR;
    }


}