using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebApplication1;
using WebApplication1.Models;

namespace NUnitTestProject1
{
    public class MockDbContext
    {
        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }

        public static Mock<IDataContext> GetMockContext()
        {
            var mockDataContext = new Mock<IDataContext>();

            mockDataContext.Setup(x => x.KlasyfikacjaProduktu)
                .Returns(MockDbContext.GetQueryableMockDbSet(new List<KlasyfikacjaProduktu>
                {
                    new KlasyfikacjaProduktu
                    {
                        Id = 1,
                        Nazwa_klasyfikacji = "Klasyfikacja1"
                    },
                    new KlasyfikacjaProduktu
                    {
                        Id = 2,
                        Nazwa_klasyfikacji = "Klasyfikacja2"
                    }
                }));

            mockDataContext.Setup(x => x.GrupaProduktu)
                .Returns(MockDbContext.GetQueryableMockDbSet(new List<GrupaProduktu>
                {
                    new GrupaProduktu
                    {
                        Id = 1,
                        Nazwa_grupy = "GrupaProduktu1"
                    },
                    new GrupaProduktu
                    {
                        Id = 2,
                        Nazwa_grupy = "GrupaProduktu2"
                    },
                    new GrupaProduktu
                    {
                        Id = 3,
                        Nazwa_grupy = "GrupaProduktu3"
                    }
                }));

            mockDataContext.Setup(x => x.Oferta)
                .Returns(MockDbContext.GetQueryableMockDbSet(new List<Oferta>
                {

                }));

            mockDataContext.Setup(x => x.PodGrupaProduktu)
                .Returns(MockDbContext.GetQueryableMockDbSet(new List<PodGrupaProduktu>
                {
                    new PodGrupaProduktu
                    {
                        Id = 1,
                        ID_GrupyProduktu = 1,
                        Nazwa = "PodGrupaProduktu1"
                    },
                    new PodGrupaProduktu
                    {
                        Id = 2,
                        ID_GrupyProduktu = 1,
                        Nazwa = "PodGrupaProduktu2"
                    },
                    new PodGrupaProduktu
                    {
                        Id = 3,
                        ID_GrupyProduktu = 1,
                        Nazwa = "PodGrupaProduktu3"
                    },
                    new PodGrupaProduktu
                    {
                        Id = 4,
                        ID_GrupyProduktu = 2,
                        Nazwa = "PodGrupaProduktu4"
                    },
                    new PodGrupaProduktu
                    {
                        Id = 5,
                        ID_GrupyProduktu = 2,
                        Nazwa = "PodGrupaProduktu5"
                    }
                }));

            mockDataContext.Setup(x => x.Produkt)
                .Returns(MockDbContext.GetQueryableMockDbSet(new List<Produkt>
                {
                    new Produkt
                    {
                        ID = 1,
                        Id_PogrupyProduktu = 1,
                        Nazwa = "Produkt1",
                        Cena_jednostkowa = 100,
                        Id_KlasyfikacjiProduktu = 1
                    },
                    new Produkt
                    {
                        ID = 2,
                        Id_PogrupyProduktu = 1,
                        Nazwa = "Produkt2",
                        Cena_jednostkowa = 200,
                        Id_KlasyfikacjiProduktu = 1
                    },                    
                    new Produkt
                    {
                        ID = 3,
                        Id_PogrupyProduktu = 2,
                        Nazwa = "Produkt3",
                        Cena_jednostkowa = 300,
                        Id_KlasyfikacjiProduktu = 1
                    },
                    new Produkt
                    {
                        ID = 4,
                        Id_PogrupyProduktu = 2,
                        Nazwa = "Produkt4",
                        Cena_jednostkowa = 400,
                        Id_KlasyfikacjiProduktu = 1
                    },
                    new Produkt
                    {
                        ID = 5,
                        Id_PogrupyProduktu = 1,
                        Nazwa = "Produkt5",
                        Cena_jednostkowa = 600,
                        Id_KlasyfikacjiProduktu = 2
                    },
                    new Produkt
                    {
                        ID = 6,
                        Id_PogrupyProduktu = 2,
                        Nazwa = "Produkt6",
                        Cena_jednostkowa = 50,
                        Id_KlasyfikacjiProduktu = 2
                    },
                    new Produkt
                    {
                        ID = 7,
                        Id_PogrupyProduktu = 4,
                        Nazwa = "Produkt7",
                        Cena_jednostkowa = 150,
                        Id_KlasyfikacjiProduktu = 2
                    },
                }));

            mockDataContext.Setup(x => x.Oferta_Produktu)
                .Returns(MockDbContext.GetQueryableMockDbSet(new List<Oferta_Produktu>
                {
                    new Oferta_Produktu
                    {
                        Id_oferty = 1,
                        Id_produktu = 1,
                        Liczba_sztuk = 2,
                        Upust_Procentowy = 5
                    },
                    new Oferta_Produktu
                    {
                        Id_oferty = 1,
                        Id_produktu = 2,
                        Liczba_sztuk = 1,
                        Upust_Procentowy = 0
                    },
                    new Oferta_Produktu
                    {
                        Id_oferty = 1,
                        Id_produktu = 3,
                        Liczba_sztuk = 4,
                        Upust_Procentowy = 10
                    },
                    new Oferta_Produktu
                    {
                        Id_oferty = 1,
                        Id_produktu = 4,
                        Liczba_sztuk = 3,
                        Upust_Procentowy = 15
                    },
                    new Oferta_Produktu
                    {
                        Id_oferty = 1,
                        Id_produktu = 5,
                        Liczba_sztuk = 10,
                        Upust_Procentowy = 5
                    },
                    new Oferta_Produktu
                    {
                        Id_oferty = 1,
                        Id_produktu = 6,
                        Liczba_sztuk = 5,
                        Upust_Procentowy = 20
                    },
                    new Oferta_Produktu
                    {
                        Id_oferty = 1,
                        Id_produktu = 7,
                        Liczba_sztuk = 2,
                        Upust_Procentowy = 10
                    }
                }));

            return mockDataContext;
        }
    }
}
