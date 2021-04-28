using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Service
{
    public class GeneralViewModelService
    {
        public GeneralViewModel GetGeneralViewModel(IDataContext dataContext)
        {
            var generalViewModel = new GeneralViewModel();

            var klasyfikacjaProduktu = dataContext.KlasyfikacjaProduktu.ToList();
            var ofertyProduktu = dataContext.Oferta_Produktu.ToList();

            foreach (var singleKlasyfikacjaProduktu in klasyfikacjaProduktu)
            {
                var produkty = dataContext.Produkt.Where(p => p.Id_KlasyfikacjiProduktu == singleKlasyfikacjaProduktu.Id).ToList();
                var podGrupyProduktu = produkty.Select(p => p.PodGrupaProduktu).Distinct().ToList();
                var grupyProduktu = podGrupyProduktu.Select(p => p.GrupaProduktu).Distinct().ToList();

                var grupaViewModels = GetGrupaViewModels(grupyProduktu, podGrupyProduktu, produkty, ofertyProduktu);

                var klasyfikacjaViewModel = new KlasyfikacjaViewModel(grupaViewModels);
                generalViewModel.KlasyfikacjaViewModels.Add(klasyfikacjaViewModel);
            }

            return generalViewModel;
        }

        private List<GrupaViewModel> GetGrupaViewModels(List<GrupaProduktu> grupaProduktu, List<PodGrupaProduktu> podGrupaProduktus, List<Produkt> produkts, List<Oferta_Produktu> ofertaProduktus)
        {
            var grupaViewModels = new List<GrupaViewModel>();

            foreach (var singleGrupaProduktu in grupaProduktu)
            {
                var podGrupaProduktuProdukts = podGrupaProduktus.FindAll(x => x.ID_GrupyProduktu == singleGrupaProduktu.Id);
                var podGrupaProduktuViewModels = GetPodGrupaProduktuViewModels(podGrupaProduktuProdukts, produkts, ofertaProduktus);

                var grupaViewModel = new GrupaViewModel(podGrupaProduktuViewModels);
                grupaViewModels.Add(grupaViewModel);
            }

            return grupaViewModels;
        }

        private List<PodGrupaProduktuViewModel> GetPodGrupaProduktuViewModels(List<PodGrupaProduktu> podGrupaProduktus, List<Produkt> produkts, List<Oferta_Produktu> ofertaProduktus)
        {
            var podGrupaProduktuViewModels = new List<PodGrupaProduktuViewModel>();

            foreach (var singlePodGrupaProduktu in podGrupaProduktus)
            {
                var singlePodGrupaProduktuProdukt = produkts.FindAll(x => x.Id_PogrupyProduktu == singlePodGrupaProduktu.Id);
                var produktViewModels = GetProduktViewModels(singlePodGrupaProduktuProdukt, ofertaProduktus);

                var podGrupaProduktuViewModel = new PodGrupaProduktuViewModel(produktViewModels);
                podGrupaProduktuViewModels.Add(podGrupaProduktuViewModel);
            }

            return podGrupaProduktuViewModels;
        }

        private List<ProduktViewModel> GetProduktViewModels(List<Produkt> produkts, List<Oferta_Produktu> ofertaProduktus)
        {
            return produkts.Select(p => GetProduktViewModel(p, ofertaProduktus)).ToList();
        }

        private ProduktViewModel GetProduktViewModel(Produkt produkt, List<Oferta_Produktu> ofertaProduktus)
        {
            var ofertaProduktu = ofertaProduktus.Single(o => o.Id_produktu == produkt.ID);

            return new ProduktViewModel(produkt, ofertaProduktu);
        }


    }
}
