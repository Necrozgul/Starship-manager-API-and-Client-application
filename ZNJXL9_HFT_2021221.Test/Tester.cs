using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Logic;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        [TestFixture]
        public class TestWithMock
        {
            #region MOQ-Setup
            //Érdemes lenne normál teszteket írni... 
            StarshipLogic cl;
            BrandLogic bl;
            WeaponLogic wl;
            public TestWithMock()
            {
                Mock<IStarshipRepository> mockStarshipRepository =
                    new Mock<IStarshipRepository>();

                Brand fakeBrand = new Brand()
                {
                    Id = 0,
                    Name = "ST1"
                };
                mockStarshipRepository.Setup((t) => t.Create(It.IsAny<Starship>()));
                mockStarshipRepository.Setup((t) => t.ReadAll()).Returns(
                    new List<Starship>()
                    {
                    new Starship()
                    {
                        Model = "ModelName",
                        BrandId = 0,
                        WeaponId = 1,
                        BasePrice = 300,
                        Id = 1
                    },
                    new Starship()
                    {
                        Model = "ModelName2",
                        BrandId = 0,
                        WeaponId = 11,
                        BasePrice = 100,
                        Id = 2
                    }
                    }.AsQueryable());
                cl = new StarshipLogic(mockStarshipRepository.Object);

                //Brand
                Mock<IBrandRepository> mockBrandRepository =
                    new Mock<IBrandRepository>();
                mockBrandRepository.Setup((t) => t.Create(It.IsAny<Brand>()));
                mockBrandRepository.Setup((t) => t.ReadAll()).Returns(
                    new List<Brand>()
                    {
                    new Brand(){ Name="Testbrand1",Id=1},
                    new Brand(){ Name="Testbrand2",Id=2},
                    }.AsQueryable());
                bl = new BrandLogic(mockBrandRepository.Object);

                //Weapon
                Mock<IWeaponRepository> mockWeaponRepository =
                    new Mock<IWeaponRepository>();
                mockWeaponRepository.Setup((t) => t.Create(It.IsAny<Weapon>()));
                mockWeaponRepository.Setup((t) => t.ReadAll()).Returns(
                    new List<Weapon>()
                    {
                    new Weapon(){ Name="Testweapon1",Id=1},
                    new Weapon(){ Name="Testweapon2",Id=2},
                    }.AsQueryable());
                wl = new WeaponLogic(mockWeaponRepository.Object);
            }
            #endregion
            
            #region CREATE
            [TestCase(3000, true)]
            [TestCase(2000, true)]
            public void CreateStarshipTest(int price, bool result)
            {
                if (result)
                {
                    Assert.That(() => cl.Create(new Starship()
                    {
                        Model = "Astra",
                        BasePrice = price
                    }), Throws.Nothing);
                }
                else
                {
                    Assert.That(() => cl.Create(new Starship()
                    {
                        Model = "Astra",
                        BasePrice = price
                    }), Throws.Exception);
                }
            }
            [Test]
            public void CreateBrandTest()
            {
                Assert.That(() => bl.Create(new Brand()
                {
                    Name = "BrandName1",
                    Id = 3
                }), Throws.Nothing);
            }
            [Test]
            public void CreateWeaponTest()
            {
                Assert.That(() => wl.Create(new Weapon()
                {
                    Name = "WeaponName1",
                    Id = 1
                }), Throws.Nothing);
            }
            #endregion
            
            #region NON-CRUD
            [Test]
            public void AVGPriceTest()
            {
                var result = cl.AVGPrice();
                Assert.That(result, Is.EqualTo(200));

            }
            [Test]
            public void AVGPriceByModelTest()
            {
                //ACT
                var result = cl.AVGPriceByModels().ToArray();

                //ASSERT
                Assert.That(result[0],
                    Is.EqualTo(new KeyValuePair<string, double>
                    ("ModelName", 300)));
            }
            [Test]
            public void MostUsedWeaponTest()
            {
                Assert.That(wl.MostUsedWeapon().Name == "Testweapon1");
            }
            [Test]
            public void GetModelAvarageTest()
            {
                Assert.That(() => cl.GetModelAverages(), Throws.Nothing);
            }
            [TestCase(1, false)]
            [TestCase(2, true),]
            public void GetTheCheapestStarShip(int id, bool r)
            {
                var result = cl.CheapestStarship();
                Assert.That((result.Id == id) == r);
            }
            [Test]
            public void MostUsedBrandTest()
            {
                Assert.That(bl.MostUsedBrand().Name == "Testbrand1");
            }
            [TestCase(1, true)]
            [TestCase(2, false)]
            public void GetTheMostExpensiveStarshipTest(int id, bool r)
            {
                var result = cl.MostExpensiveStarship();
                Assert.That((result.Id == id) == r);
            }

            #endregion
            
            #region FREE
            [Test]            
            public void GetOneStarshipTest()
            {
                Assert.That(() => cl.Read(1), Throws.Nothing);
            }
            
            [Test]
            public void GetAllStarshipTest()
            {
                Assert.That(() => cl.ReadAll(), Throws.Nothing);
            }

            [Test]
            public void GetOneBrandTest()
            {
                Assert.That(() => bl.Read(1), Throws.Nothing);
            }
            [Test]
            public void GetAllBrandTest()
            {
                Assert.That(() => bl.ReadAll(), Throws.Nothing);
            }

            
            [Test]
            public void GetOneWeaponTest()
            {
                Assert.That(() => wl.Read(1), Throws.Nothing);
            }
            [Test]
            public void GetAllWeaponTest()
            {
                Assert.That(() => wl.ReadAll(), Throws.Nothing);
            }
            #endregion

        }
    }
}
