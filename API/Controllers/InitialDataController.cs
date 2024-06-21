using Application.Exceptions;
using DataAccess;
using Domain;
using Implementation.UseCases;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private readonly CozaStoreContext _context;

        public InitialDataController(CozaStoreContext context)
        {
            _context = context;
        }

        // GET: api/<InitialDataController>
        [HttpGet]
        public IActionResult Get()
        {
            if (_context.Messages.Any())
            {
                throw new ConflictException("Database is already seeded");
            }
            _context.Messages.Add(new Domain.Message
            {
                Email = "test@gmail.com",
                FullName = "Test User",
                MessageText = "Test messageeeee",
                SendedAt = DateTime.Now,
                Subject = "Test subject"
            });
            Category Tshirts = new Category
            {
                Name = "T-shirts"
            };
            Category Shirts = new Category
            {
                Name = "Shirts"
            };
            Category Hoodies = new Category
            {
                Name = "Hoodies"
            };
            Category Suits = new Category
            {
                Name = "Suits"
            };
            Category Jackets = new Category
            {
                Name = "Jackets"
            };
            Category Dresses = new Category
            {
                Name = "Dresses"
            };
            Category Jeans = new Category
            {
                Name = "Jeans"
            };
            Category Shorts = new Category
            {
                Name = "Shorts"
            };
            Category Shoes = new Category
            {
                Name = "Shoes"
            };
            Category Sneakers = new Category
            {
                Name = "Sneakers"
            };
            Category Boots = new Category
            {
                Name = "Boots"
            };
            Brand Nike = new Brand
            {
                Name = "Nike"
            };
            Brand Adidas = new Brand
            {
                Name = "Adidas"
            };
            Brand Puma = new Brand
            {
                Name = "Puma"
            };
            Brand Levis = new Brand
            {
                Name = "Levi's"
            };
            Brand TommyHilfiger = new Brand
            {
                Name = "Tommy Hilfiger"
            };
            Brand TheNorthFace = new Brand
            {
                Name = "The North Face"
            };
            Brand Columbia = new Brand
            {
                Name = "Columbia"
            };
            Brand Fila = new Brand
            {
                Name = "Fila"
            };
            Brand Zara = new Brand
            {
                Name = "Zara"
            };
            Brand HM = new Brand
            {
                Name = "H&M"
            };
            Brand Lululemon = new Brand
            {
                Name = "Lululemon"
            };
            Brand UnderArmour = new Brand
            {
                Name = "Under Armour"
            };
            Brand NewBalance = new Brand
            {
                Name = "New Balance"
            };
            Brand Gucci = new Brand
            {
                Name = "Gucci"
            };
            Brand SteveMadden = new Brand
            {
                Name = "Steve Madden"
            };
            Brand ALDO = new Brand
            {
                Name = "ALDO"
            };
            Brand Kappa = new Brand
            {
                Name = "Kappa"
            };
            Color Red = new Color
            {
                Name = "Red"
            };
            Color Blue = new Color
            {
                Name = "Blue"
            };
            Color Green = new Color
            {
                Name = "Green"
            };
            Color Yellow = new Color
            {
                Name = "Yellow"
            };
            Color Purple = new Color
            {
                Name = "Purple"
            };
            Color Orange = new Color
            {
                Name = "Orange"
            };
            Color Black = new Color
            {
                Name = "Black"
            };
            Color White = new Color
            {
                Name = "White"
            };
            Color Pink = new Color
            {
                Name = "Pink"
            };
            Color Brown = new Color
            {
                Name = "Brown"
            };
            Color Grey = new Color
            {
                Name = "Grey"
            };
            Gender Male = new Gender
            {
                Name = "Male"
            };
            Gender Female = new Gender
            {
                Name = "Female"
            };
            Gender Unisex = new Gender
            {
                Name = "Unisex"
            };
            Size XS = new Size
            {
                Name = "XS"
            };
            Size S = new Size
            {
                Name = "S"
            };
            Size M = new Size
            {
                Name = "M"
            };
            Size L = new Size
            {
                Name = "L"
            };
            Size XL = new Size
            {
                Name = "XL"
            };
            Size XXL = new Size
            {
                Name = "XXL"
            };
            Size ThirtyEight = new Size
            {
                Name = "38"
            };
            Size ThirtyNine = new Size
            {
                Name = "39"
            };
            Size Fourty = new Size
            {
                Name = "40"
            };
            Size FourtyOne = new Size
            {
                Name = "41"
            };
            Size FourtyTwo = new Size
            {
                Name = "42"
            };
            Size FourtyThree = new Size
            {
                Name = "43"
            };
            Size FourtyFour = new Size
            {
                Name = "44"
            };
            Size FourtyFive = new Size
            {
                Name = "45"
            };
            Product p1 = new Product
            {
                Name = "Green Jacket",
                Category = Jackets,
                Brand = Nike,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 100,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Discounts = new List<Discount>
                {
                    new Discount
                    {
                        DiscountPercent = 10,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now.AddDays(20)
                    }
                },
                Description = "This is a green jacket",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    },
                    new ProductSize
                    {
                        Size = XL
                    }
                },
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Green
                    }
                },
                Gender = Male,
                Available = 200,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/ac943019-f373-4b9a-aa90-d4b1c3e9f91b.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/f1e4135d-3706-454f-a77d-413e7cce444a.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/641e2cea-56e8-417d-8935-0161a0bb752a.jpg"
                        }
                    }
                }
            };
            Product p2 = new Product
            {
                Name = "Blue Jacket",
                Category = Jackets,
                Brand = Adidas,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 50,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "This is a blue jacket",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },

                },
                Available = 0,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender= Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/fd25ed90-6dce-43b7-9ff4-847f9617193e.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/76329ec3-ebc7-470f-b54b-cd3aefcbbd00.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/b43415b7-48e8-4839-b309-f6376e6011d6.jpg"
                        }
                    }
                }
            };
            Product p3 = new Product
            {
                Name = "Beauty Shoes",
                Category = Shoes,
                Brand = Zara,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 30,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Beauty Shoes",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = ThirtyNine
                    },
                    new ProductSize
                    {
                        Size = Fourty
                    },
                    new ProductSize
                    {
                        Size = FourtyOne
                    },
                    new ProductSize
                    {
                        Size = FourtyTwo
                    },

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/32b661e0-c356-47df-8f3e-83e584cf4ec5.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/d654c619-2640-4133-8a7b-3ee4e1ddeeb2.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/9ea403e4-0f07-4046-b5c9-e06baadb1491.jpg"
                        }
                    }
                }
            };
            Product p4 = new Product
            {
                Name = "Red Hoodie",
                Category = Hoodies,
                Brand = Puma,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 40,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Comfortable red hoodie for casual wear.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Red
                    },
                    new ProductColor
                    {
                        Color = White
                    }
                },
                Gender = Unisex,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/e38a56e8-c931-4fe2-a779-b92f5b5d3b37.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/0e8532f0-4653-486a-b5e8-97a6848b261a.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/7d9c172f-121d-4ea8-b806-2879136af181.jpg"
                        }
                    }
                }
            };
            Product p5 = new Product
            {
                Name = "Black Leather Boots",
                Category = Boots,
                Brand = Gucci,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 120,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Stylish black leather boots for all occasions.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = ThirtyNine
                    },
                    new ProductSize
                    {
                        Size = Fourty
                    },

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    },
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/bc0856ad-ba3c-40bc-8f0f-f5136843806b.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/d2803655-8290-438d-ae24-f3d698872524.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/fd33d52c-c17e-40f2-8e78-fb01d3175f4c.jpg"
                        }
                    }
                }
            };
            Product p6 = new Product
            {
                Name = "Striped Polo Shirt",
                Category = Shirts,
                Brand = UnderArmour,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 60,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Classic striped polo shirt for a smart casual look.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = XS
                    },
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    },

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    },
                    new ProductColor
                    {
                        Color = White
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/f044399a-1c19-42ae-8183-4fc2090aa160.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/f26fd3cd-5278-4c05-9550-58fd4992c874.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/380f2a75-b8ac-4bea-a03d-8a9903ec0549.jpg"
                        }
                    }
                }
            };
            Product p7 = new Product
            {
                Name = "Denim Shorts",
                Category = Shorts,
                Brand = Levis,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 35,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Trendy denim shorts for summer days.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = L
                    },

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    },
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/6aa6facf-c463-4490-b163-48cd00477bbe.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/44388fee-9d94-41a0-8504-b6aa8395e42a.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/c6854ec1-a909-42b6-aae8-15d546c2ece5.jpg"
                        }
                    }
                }
            };
            Product p8 = new Product
            {
                Name = "White Sneakers",
                Category = Sneakers,
                Brand = Adidas,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 55,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Classic white sneakers for everyday wear.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = Fourty
                    },
                    new ProductSize
                    {
                        Size = FourtyOne
                    },
                    new ProductSize
                    {
                        Size = FourtyTwo
                    },
                    new ProductSize
                    {
                        Size = FourtyThree
                    },

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = White
                    }
                },
                Gender = Unisex,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/c5f2e1a9-df51-48fe-b8cc-1387357b9cfb.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/9e803ce7-8749-4bd6-ba70-5bd928b9ffb8.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/2586bbf3-30a1-4936-95fa-5bedc4c0bd0c.jpg"
                        }
                    }
                }
            };
            Product p9 = new Product
            {
                Name = "Cosmic Galaxy Hoodie",
                Category = Hoodies,
                Brand = HM,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 70,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Discounts = new List<Discount>
                {
                    new Discount
                    {
                        DiscountPercent = 15,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now.AddDays(20)
                    }
                },
                Description = "Embrace the cosmos with this stunning galaxy-themed hoodie.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = XS
                    },
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    },

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    },
                    new ProductColor
                    {
                        Color = Purple
                    }
                },
                Gender = Unisex,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/ab2347af-28e9-40fa-833b-febf3cd5b394.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/1bb796cb-9508-4709-a01c-3c471441f92f.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/96f8c2f6-d77e-423e-afc8-1b947780ee22.jpg"
                        }
                    }
                }
            };
            Product p10 = new Product
            {
                Name = "Eclipse Leather Jacket",
                Category = Jackets,
                Brand = TheNorthFace,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 150,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Make a bold statement with this sleek leather jacket inspired by lunar eclipses.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    },
                    new ProductSize
                    {
                        Size = XL
                    }

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/062e98e3-549e-437f-ac1d-cd91fa1b3a5c.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/978d83ba-61a5-4c29-8b75-87f76fe00ba6.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/3fb9a840-bd97-486e-9863-a495c5b6c648.jpg"
                        }
                    }
                }
            };
            Product p11 = new Product
            {
                Name = "Midnight Sky Jenas",
                Category = Jeans,
                Brand = SteveMadden,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 55,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Channel the beauty of the night sky with these stylish midnight blue jeans.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = L
                    },
                    new ProductSize
                    {
                        Size = XXL
                    }

                },
                Available = 0,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/484fbbf3-4d9f-4d79-82d8-f6fe80e9bbaa.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/42844e09-d7a3-4874-b4f4-01c4964a24e8.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/12a59047-6a87-4efd-82da-66f0619ece2b.jpg"
                        }
                    }
                }
            };
            Product p12 = new Product
            {
                Name = "Neon Dream Sneakers",
                Category = Sneakers,
                Brand = Puma,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 80,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Step into the future with these electrifying neon sneakers.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = ThirtyEight
                    },
                    new ProductSize
                    {
                        Size = Fourty
                    },
                    new ProductSize
                    {
                        Size = FourtyOne
                    },
                    new ProductSize
                    {
                        Size = FourtyTwo
                    },

                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Green
                    },
                    new ProductColor
                    {
                        Color = Pink
                    }
                },
                Gender = Unisex,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/aa9df264-d79d-4e40-a72f-d4b71beaee55.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/d7259e1a-04be-4f75-a611-feb70284affc.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/709e2c7a-2c4f-42d8-a53d-42b7f2cff7c8.jpg"
                        }
                    }
                }
            };
            Product p13 = new Product
            {
                Name = "Mystic Moonlight Dress",
                Category = Dresses,
                Brand = Lululemon,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 90,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Dance under the moonlight in this ethereal dress adorned with shimmering sequins.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Pink
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/e9010617-7c57-46f3-9d9a-7095f3e10d1a.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/2f03ce26-ac18-4111-af32-422ddac9f26a.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/52f696e8-b065-44e6-a179-62d88b5f2cf8.jpg"
                        }
                    }
                }
            };
            Product p14 = new Product
            {
                Name = "Galactic Tee",
                Category = Tshirts,
                Brand = TommyHilfiger,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 25,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Embrace your inner space enthusiast with this cosmic-themed t-shirt.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = XL
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/5890a314-d697-47f3-a937-53573e7af4b3.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/16fb9fad-d5a5-45bd-9ef7-208432ff0d49.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/7cec542b-65fd-46e5-8f04-3c114bc22c07.jpg"
                        }
                    }
                }
            };
            Product p15 = new Product
            {
                Name = "Nebula Shirt",
                Category = Shirts,
                Brand = Nike,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 40,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Dress to impress with this stylish shirt featuring a mesmerizing nebula print.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/5d00fd5d-d9db-4543-9e55-39d9e3d70998.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/befabb29-2e14-4d86-8e07-dc977acce1d2.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/61e5a7df-b190-4814-9815-c2173360ee7e.jpg"
                        }
                    }
                }
            };
            Product p16 = new Product
            {
                Name = "Space Explorer Jeans",
                Category = Jeans,
                Brand = Zara,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 250,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Command attention in any galaxy with this sleek and futuristic space explorer suit.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/1ac93b83-8891-43a7-879a-24524babd2a3.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/48ba34bd-d3eb-4a9c-99f2-c8534e86368d.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/13e11860-85fc-4304-9be7-9bb8b76c9c9e.jpg"
                        }
                    }
                }
            };
            Product p17 = new Product
            {
                Name = "Solar Flare Jacket",
                Category = Jackets,
                Brand = TheNorthFace,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 120,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Discounts = new List<Discount>
                {
                    new Discount
                    {
                        DiscountPercent = 10,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now.AddDays(20)
                    }
                },
                Description = "Ignite your style with this fiery solar flare-inspired jacket.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = L
                    },
                    new ProductSize
                    {
                        Size = XL
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Orange
                    },
                    new ProductColor
                    {
                        Color = Red
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/e9c740d6-2af8-4487-b2ff-a47c22f09c2c.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/356a1b32-fd6a-4a37-8365-23c09286568b.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/cc040d74-1a3a-4b25-b2d4-865aef244e9d.jpg"
                        }
                    }
                }
            };
            Product p18 = new Product
            {
                Name = "Stellar Sneakers",
                Category = Sneakers,
                Brand = Fila,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 90,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Discounts = new List<Discount>
                {
                    new Discount
                    {
                        DiscountPercent = 5,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now.AddDays(20)
                    }
                },
                Description = "Walk among the stars with these comfortable and stylish stellar sneakers.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = FourtyOne
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    },
                    new ProductColor
                    {
                        Color = White
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/0ce1fde9-1d2a-48f8-8e65-c17948a80d6e.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/cd72b936-f743-4e46-9f18-298f48de25cf.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/e2ba340c-f436-4e3e-a09e-8e30f1a6e11b.jpg"
                        }
                    }
                }
            };
            Product p19 = new Product
            {
                Name = "Lunar Eclipse Hoodie",
                Category = Hoodies,
                Brand = Gucci,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 80,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Capture the mystique of a lunar eclipse with this celestial hoodie.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = XS
                    },
                    new ProductSize
                    {
                        Size = S
                    }
                },
                Available = 0,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    },
                    new ProductColor
                    {
                        Color = Grey
                    }
                },
                Gender = Unisex,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/e9621020-2324-431f-b359-ce5acfadf226.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/206d7f8e-32f9-400b-b1f2-e8a612631fd2.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/4edd3a7f-0452-4c28-8412-231e2415c69d.jpg"
                        }
                    }
                }
            };
            Product p20 = new Product
            {
                Name = "Galactic Guardian Shorts",
                Category = Shorts,
                Brand = Zara,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 300,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Discounts = new List<Discount>
                {
                    new Discount
                    {
                        DiscountPercent = 20,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now.AddDays(20)
                    }
                },
                Description = "Protect the cosmos in style with this futuristic galactic guardian suit.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = XL
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    },
                    new ProductColor
                    {
                        Color = Grey
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/9a3818f1-0e4e-4215-9b77-778e684494c1.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/99d98aee-f995-4c15-aa1a-9066b21a4453.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/a74bf344-e3f9-4c2f-9111-da406139a69f.jpg"
                        }
                    }
                }
            };
            Product p21 = new Product
            {
                Name = "Celestial Sky Jeans",
                Category = Jeans,
                Brand = HM,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 60,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Embark on a cosmic journey in these star-studded celestial sky jeans.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = XL
                    },
                    new ProductSize
                    {
                        Size = XXL
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/7769f51b-5582-4158-ae9c-b0bdc62010b2.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/aa0fe246-5d9e-49c4-a159-b5a8f673a98c.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/9df1ccbe-1adf-4c0a-9170-5462b3a8f80b.jpg"
                        }
                    }
                }
            };
            Product p22= new Product
            {
                Name = "Comet Shorts",
                Category = Shorts,
                Brand = Nike,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 40,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Race through the galaxy in these speedy comet shorts.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/5dddd154-3f06-4cbd-8f6e-9cb8dc2004cb.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/05e27cdb-3372-442f-b320-bc9b8a1b875d.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/555d7d91-5f73-4010-b35b-32ccdcef0423.jpg"
                        }
                    }
                }
            };
            Product p23 = new Product
            {
                Name = "Cosmic Voyager Shoes",
                Category = Shoes,
                Brand = Columbia,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 100,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Discounts = new List<Discount>
                {
                    new Discount
                    {
                        DiscountPercent = 10,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now.AddDays(20)
                    }
                },
                Description = "Explore the universe in comfort and style with these cosmic voyager shoes.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = ThirtyNine
                    },
                    new ProductSize
                    {
                        Size = Fourty
                    },
                    new ProductSize
                    {
                        Size = FourtyOne
                    },
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Black
                    },
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/8817f759-ef68-4c61-94e5-7faaff9adcf3.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/ed94613e-a763-41c3-881c-5f5a0806cc36.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/146c6ef2-590b-4ed2-98b0-106122f70801.jpg"
                        }
                    }
                }
            };
            Product p24 = new Product
            {
                Name = "Retro Logo T-Shirt",
                Category = Tshirts,
                Brand = UnderArmour,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 20,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Step back in time with this cool retro logo t-shirt.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = White
                    },
                    new ProductColor
                    {
                        Color = Grey
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/edfd3e9c-2826-4067-8b4c-a41e7afde5b4.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/1411f08a-251a-4344-add6-ebe8d77f0017.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/98b6834c-a857-4bba-8f0d-bbab577f33cb.jpg"
                        }
                    }
                }
            };
            Product p25 = new Product
            {
                Name = "Floral Print Shirt",
                Category = Shirts,
                Brand = TommyHilfiger,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 45,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Bring a touch of nature to your wardrobe with this stylish floral print shirt.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = White
                    },
                    new ProductColor
                    {
                        Color = Green
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/5adec307-b112-4180-96b0-5a0e572b7ec2.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/ec6bd5b5-1f8f-4ff9-819f-8bcdec8430d8.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/2e10d2bc-820d-4d7e-a9ff-71110b3a084c.jpg"
                        }
                    }
                }
            };
            Product p26 = new Product
            {
                Name = "Cozy Winter Hoodie",
                Category = Hoodies,
                Brand = NewBalance,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 60,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Stay warm and stylish during the winter months with this cozy hoodie.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = XS
                    },
                    new ProductSize
                    {
                        Size = L
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    },
                    new ProductColor
                    {
                        Color = Grey
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/bacd8eba-7902-4054-8dcc-477af32089c9.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/3d4a94a3-d88b-4f76-82b3-1981dd65fe3f.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/1f302af5-0f1d-4507-aec5-d1f93538e2c7.jpg"
                        }
                    }
                }
            };
            Product p27 = new Product
            {
                Name = "Casual T-Shirt",
                Category = Tshirts,
                Brand = Kappa,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 200,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Elevate your professional wardrobe with this sleek and sophisticated business casual suit.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = XL
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/4de90d99-75d8-4b1a-a74a-8fe99ccbd9cc.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/0ba24783-ea18-4095-8c8a-d766fdb5afe3.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/733cd07a-92bd-410b-a88c-15b29f2f1abe.jpg"
                        }
                    }
                }
            };
            Product p28 = new Product
            {
                Name = "Brown Boots",
                Category = Boots,
                Brand = ALDO,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 200,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Step out in style with these chic brown boots.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = Fourty
                    },
                    new ProductSize
                    {
                        Size = FourtyOne
                    },
                    new ProductSize
                    {
                        Size = FourtyTwo
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Brown
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/e71acb20-4652-48f8-bc52-feebc76f7066.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/4b4c4893-7759-4d1b-9623-efb520b5a875.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/68c0ca1e-5fa3-4dc4-9ccc-995042597c16.jpg"
                        }
                    }
                }
            };
            Product p29 = new Product
            {
                Name = "Classic Blue Sneakers",
                Category = Sneakers,
                Brand = Nike,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 50,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Step out in style with these classic blue sneakers.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = Fourty
                    },
                    new ProductSize
                    {
                        Size = FourtyOne
                    },
                    new ProductSize
                    {
                        Size = FourtyTwo
                    }
                },
                Available = 0,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/e831f0f0-775b-4c9f-a524-931155e3c7b3.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/467b50ec-c8c3-4d31-aa08-f805f70f0104.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/359b9866-cfd9-46c1-b1b3-c2922c1cea75.jpg"
                        }
                    }
                }
            };
            Product p30 = new Product
            {
                Name = "Beach Shorts",
                Category = Shorts,
                Brand = Kappa,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 25,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Get ready for fun in the sun with these vibrant beach shorts.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    }
                },
                Available = 0,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Orange
                    }
                },
                Gender = Male,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/d3e4641d-e285-4982-bca1-eb5f155b851f.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/cd050312-544b-480c-aaae-61d2b3a9aa2b.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/131ee961-9788-4c06-8e60-fe568210a012.jpg"
                        }
                    }
                }
            };
            Product p31 = new Product
            {
                Name = "Casual Canvas Shoes",
                Category = Shoes,
                Brand = Gucci,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 40,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Keep it casual and comfortable with these classic canvas shoes.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = FourtyTwo
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Green
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/8a1baf14-3760-4aac-aec0-7b502515bede.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/1b4a8d04-4d81-469f-aa3d-fd81c27cd37b.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/2fe56b41-4aed-41a8-9d6c-6cc0cbe91393.jpg"
                        }
                    }
                }
            };
            Product p32 = new Product
            {
                Name = "Sporty Sneakers",
                Category = Sneakers,
                Brand = Puma,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 70,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Stay on the move with these comfortable and stylish sporty sneakers.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = Fourty
                    },
                    new ProductSize
                    {
                        Size = FourtyOne
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Pink
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/39e0b0b7-2bb7-4420-abdd-080bff37a683.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/3887cd35-270a-4d22-b558-c6a630705b6c.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/71c3427f-db82-4329-8f04-b73c98fc64d5.jpg"
                        }
                    }
                }
            };
            Product p33 = new Product
            {
                Name = "Trendy Denim Jacket",
                Category = Jackets,
                Brand = HM,
                Prices = new List<Price>
                {
                    new Price
                    {
                       ProductPrice = 70,
                       DateFrom = DateTime.Now,
                       DateTo = null
                    }
                },
                Description = "Stay on trend with this stylish denim jacket featuring distressed details.",
                Sizes = new List<ProductSize>
                {
                    new ProductSize
                    {
                        Size = S
                    },
                    new ProductSize
                    {
                        Size = M
                    },
                    new ProductSize
                    {
                        Size = L
                    }
                },
                Available = 100,
                Colors = new List<ProductColor>
                {
                    new ProductColor
                    {
                        Color = Blue
                    }
                },
                Gender = Female,
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/19524289-ffe9-4d96-8f79-8227624fd9c6.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/d4c6310f-95b6-4919-800a-77a5768f9dbd.jpg"
                        }
                    },
                    new ProductImage
                    {
                        Image = new Image
                        {
                            Path = "/images/products/19e26a9a-5d2a-4d25-98f5-5f6d6c533389.jpg"
                        }
                    }
                }
            };
            _context.Categories.AddRange(Tshirts, Shirts, Hoodies, Suits , Jackets, Jeans, Shorts, Dresses, Sneakers , Shoes, Boots);
            _context.Brands.AddRange(Adidas, Columbia, Fila, Gucci, HM, Kappa, Lululemon, NewBalance, Nike, Puma, TheNorthFace, TommyHilfiger, UnderArmour, Zara, ALDO, SteveMadden, Levis);
            _context.Colors.AddRange(Black, Blue, Brown, Green, Grey, Orange, Pink, Red, White, Yellow,Purple);
            _context.Sizes.AddRange(XS, S, M, L, XL, XXL, ThirtyEight,ThirtyNine,Fourty,FourtyOne,FourtyTwo,FourtyThree,FourtyFour,FourtyFive);
            _context.Genders.AddRange(Male,Female,Unisex);
            _context.Products.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33);

            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
         
        }

    
    }
}
