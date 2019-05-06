using MealSaver.Models.Entities;
using MealSaver.Models.ViewModels.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealSaver.Models
{
    public class InfoService
    {
        private readonly FoodObjContext foodObjContext;
        public InfoService(FoodObjContext foodObjContext)
        {
            this.foodObjContext = foodObjContext;
        }
        List<InfoAboutVM> founders = new List<InfoAboutVM>
        {
            new InfoAboutVM{ Id = 1, Image = "/images/HenrikCheng.jpg", Name = "Henrik Cheng", Description = "Henrik har en bakgrund från sjukvården med läkarexamen från Karolinska Institutet och yrkeserfarenhet efter AT-tjänstgöring. Läkaryrket har format Henrik till en person som är effektiv i sitt arbete och givit honom vana att arbeta i team. Henrik har ett stort intresse för IT, problemlösning och programmering. Han är alltid intresserad av att lära sig nya saker och utvecklas. Genom Academy vill Henrik utvecklas i en ny riktning som utvecklare och bidra med sin problemlösningsförmåga, kreativitet samt positiva energi." },
            new InfoAboutVM{ Id = 2, Image = "/images/elin.jpg", Name = "Elin Strandberg", Description = "Elin är en fysioterapeut med en masterexamen i folkhälsovetenskap. Tidigare arbete med verksamhetskoordinering, statistikbearbetning och forskning gör att hon tar sig an nya utmaningar på ett analytiskt, strukturerat och kreativt sätt. Tack vare erfarenheter av kundsupport, sjukvård och kommunal service har hon även utvecklat stor social kompetens samt förståelse för människor. Intresset för programmering väcktes när Elin arbetade med webbtillgänglighet. Nu ser hon framemot en karriär inom IT-branschen där hon vill bidra till att utveckla användarvänliga digitala lösningar från grunden." },
            new InfoAboutVM{ Id = 3, Image = "/images/HenrikNF.jpg", Name = "Henrik Norlin Frisemo", Description = "Henrik har en kandidatexamen inom medicinsk biologi och har studerat kurser på masternivå vid Linköpings universitet. Han trivdes med att samarbeta inom olika projektformer då kurserna ofta drevs i projekt med fokus på problemlösning. Henrik arbetade tidigare som manager på en pub, ett yrke som han tyckte mycket om eftersom han fick arbeta med service och kundbemötande. I denna yrkesroll fick han utmana sig själv och hitta effektiva lösningar. Han är social, nyfiken och har ett stort IT- samt teknikintresse. Genom Academy får han nu möjlighet att förvandla sin hobby till en karriär." },
        };

        internal async Task AddContactFormToDBAsync(InfoContactVM infoContactVM)
        {
            await foodObjContext.ContactForm.AddAsync(new ContactForm {
                Email = infoContactVM.Email,
                Name = infoContactVM.Name,
                Question = infoContactVM.Description
            });
            await foodObjContext.SaveChangesAsync();
        }

        public InfoAboutVM[] GetallFounders()
        {
            return founders
                .Select(o => new InfoAboutVM { Id = o.Id, Name = o.Name, Description = o.Description, Image = o.Image })
                .ToArray();
        }
    }
}
