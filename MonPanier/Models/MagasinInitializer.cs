﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonPanier.Models
{
    //public class MagasinInitializer : DropCreateDatabaseIfModelChanges<MagasinContext>
    // CreateDatabaseIfNotExists
    // DropCreateDatabaseAlways
    public class MagasinInitializer : CreateDatabaseIfNotExists<MyContext>
    {

        protected override void Seed(MyContext context)
        {

            // On crée un nouvelle user Admin
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); 
            var RoleManager = new RoleManager<IdentityRole>(new 
                                          RoleStore<IdentityRole>(context));

            string RAdmin = "Admin";
            string RUser = "User";
 
            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(RAdmin))
            {
                var roleresult = RoleManager.Create(new IdentityRole(RAdmin));
            }
            //Create Role User if it does not exist
            if (!RoleManager.RoleExists(RUser))
            {
                var roleresult = RoleManager.Create(new IdentityRole(RUser));
            }
            //Create User=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = "admin@admin.fr";
            user.Email = "admin@admin.fr";
            user.NomMagasin = "Casa Bio";
            var adminresult = UserManager.Create(user, "123456");

            // Un 2e User simple 
            var user2 = new ApplicationUser();
            user2.UserName = "Toto";
            user2.Email = "toto@toto.fr";
            user2.NomMagasin = "Chez Toto";
            var userresult = UserManager.Create(user2, "123456");

    
            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                //Ajoute l'utilisateur 'user' en rôle Admin
                var result = UserManager.AddToRole(user.Id, RAdmin);
            }
            if (userresult.Succeeded)
            {
                // Ajoute l'utilisateur 'user2' en rôle User    
                var result = UserManager.AddToRole(user2.Id, RUser);
            }
            base.Seed(context);


            // Regions
            var regions = new List<Region>
            {
                new Region{Numero =1, Nom = "Picardie", Produits = new List<Produit>()},
                new Region{Numero =2, Nom = "Haute-Normandie", Produits = new List<Produit>()},
                new Region{Numero =3, Nom = "Basse-Normandie", Produits = new List<Produit>()},
                new Region{Numero =4, Nom = "Île-de-France", Produits = new List<Produit>()},
                new Region{Numero =5, Nom = "Bretagne", Produits = new List<Produit>()},
                new Region{Numero =6, Nom = "Champagne-Ardenne", Produits = new List<Produit>()},
                new Region{Numero =7, Nom = "Alsace", Produits = new List<Produit>()},
                new Region{Numero =8, Nom = "Pays de la Loire", Produits = new List<Produit>()},
                new Region{Numero =9, Nom = "Centre", Produits = new List<Produit>()},
                new Region{Numero =10, Nom = "Bourgogne", Produits = new List<Produit>()},
                new Region{Numero =11, Nom = "Rhône-Alpes", Produits = new List<Produit>()},
                new Region{Numero =12, Nom = "Aquitaine", Produits = new List<Produit>()},
                new Region{Numero =13, Nom = "Provence-Alpes-Côte d'Azur", Produits = new List<Produit>()},
                new Region{Numero =14, Nom = "Corse", Produits = new List<Produit>()},
                new Region{Numero =15, Nom = "Midi-Pyrénées", Produits = new List<Produit>()},
                new Region{Numero =16, Nom = "Languedoc-Roussillon", Produits = new List<Produit>()},
                new Region{Numero =17, Nom = "Lorraine", Produits = new List<Produit>()},
                new Region{Numero =18, Nom = "Poitou-Charentes", Produits = new List<Produit>()},
                new Region{Numero =19, Nom = "Limousin", Produits = new List<Produit>()},
                new Region{Numero =20, Nom = "Auvergne", Produits = new List<Produit>()},
                new Region{Numero =21, Nom = "Nord-Pas-de-Calais", Produits = new List<Produit>()},
                new Region{Numero =22, Nom = "Franche-Comté", Produits = new List<Produit>()}
            };

            foreach (var temp in regions)
            {
                context.Regions.Add(temp);
            }
            context.SaveChanges();

            // Categories
            var categories = new List<Categorie>
            {
                new Categorie{Nom = "Fruits"},
                new Categorie{Nom = "Légumes"},
                new Categorie{Nom = "Crèmerie"},
                new Categorie{Nom = "Boissons"},
                new Categorie{Nom = "Boulangerie & Pâtisserie"},
                new Categorie{Nom = "Epicerie"},
                new Categorie{Nom = "Traiteur"},
                new Categorie{Nom = "Autres"},
            };
            foreach (var temp in categories)
            {
                context.Categories.Add(temp);
            }
            context.SaveChanges();


            // Produits
            var produits = new List<Produit>
            {
                new Produit{
                    Nom = "Orange bio",
                    CategorieId = 1, 
                    Description = "Variété : Navel (produit vendu au kilo)" , 
                    Prix = 3,  
                    DateValid = DateTime.Parse("2013-09-01") , 
                    Regions = new List<Region>(),
                    Quantite = 100,
                    ApplicationUser = user,
                    EnLigne = true
                },
                new Produit{
                    Nom = "Pamplemousse rose bio",
                    CategorieId = 2, 
                    Description = "Tomate en Or" , 
                    Prix = 4,  
                    DateValid = DateTime.Parse("2013-09-01") , 
                    Regions = new List<Region>(),
                    Quantite = 1,
                    ApplicationUser = user2,
                    EnLigne = true
                },
                new Produit{
                    Nom = "Tomate",
                    CategorieId = 2, 
                    Description = "Tomate en Or" , 
                    Prix = 10000,  
                    DateValid = DateTime.Parse("2013-09-01") , 
                    Regions = new List<Region>(),
                    Quantite = 1,
                    ApplicationUser = user2,
                    EnLigne = true
                }
            //    new Produit{Nom = "Noix",CategorieId = 1, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            //    new Produit{Nom = "Pomme de terre",CategorieId = 2, Description = "" , Prix = 0,  DateCreated = DateTime.Parse("2013-09-01"), Regions = new List<Region>()},
            };

            foreach (var temp in produits)
            {
                context.Produits.Add(temp);
            }
            context.SaveChanges();

            // On ajoute les regions a des produits
            AddOrUpdateRegon(context, "Orange bio", "Alsace");
            AddOrUpdateRegon(context, "Orange bio", "Lorraine");
            AddOrUpdateRegon(context, "Tomate", "Basse-Normandie");
            AddOrUpdateRegon(context, "Tomate", "Bourgogne");
            AddOrUpdateRegon(context, "Tomate", "Haute-Normandie");
            AddOrUpdateRegon(context, "Tomate", "Corse");
            //AddOrUpdateRegon(context, "Pomme", "Aquitaine");
            //AddOrUpdateRegon(context, "Pomme", "Auvergne");
            //AddOrUpdateRegon(context, "Pomme", "Basse-Normandie");

            context.SaveChanges();


            // Panier 

            // on créé le panier de l'utilisateur 
            Panier userPanier = new Panier { ContenuPaniers = new List<ContenuPanier>(), ApplicationUser = user };
            //nPanier.ApplicationUser = this;
            context.Paniers.Add(userPanier);


            // contenu du panier 
            var pro = context.Produits.Single(c => c.Nom == "Tomate");
            var contenuPanier = new ContenuPanier{Produit = pro,Quantite= 10};
            var pro1 = context.Produits.Single(c => c.Nom == "Tomate");
            var contenuPanier1 = new ContenuPanier { Produit = pro1, Quantite = 10 };
            var pro2 = context.Produits.Single(c => c.Nom == "Orange bio");
            var contenuPanier2 = new ContenuPanier { Produit = pro2, Quantite = 10 };

            userPanier.ContenuPaniers.Add(contenuPanier);
            userPanier.ContenuPaniers.Add(contenuPanier1);
            userPanier.ContenuPaniers.Add(contenuPanier2);

            context.SaveChanges();
        }


        // ajoute une region a un produit
        void AddOrUpdateRegon(MyContext context, string NomProduit, string NomRegion)
        {
            var pro = context.Produits.Single(c => c.Nom == NomProduit);
            var reg = context.Regions.Single(i => i.Nom == NomRegion);
            if (reg != null)
                reg.Produits.Add(pro);
        }
    }
}