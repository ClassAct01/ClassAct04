using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FoodAPI.Models;
using System.Dynamic;
using System.Data.Entity;

namespace FoodAPI.Controllers
{
    public class FoodController : ApiController
    {
        // GET: Food
        [System.Web.Http.Route("api/FoodType/getAllFoodTypes")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllFoodTypes()
        {
            FoodEntities db = new FoodEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return getAllFoodTypeList(db.FoodTypes.ToList());
        }
            private List<dynamic> getAllFoodTypeList(List<FoodType> forClient)
        {
            List<dynamic> dynamicFoodTypes = new List<dynamic>();
            foreach (FoodType foodtype in forClient)
            {
                dynamic dynamicFoodType = new ExpandoObject();
                dynamicFoodType.ID = foodtype.FoodTypeID;
                dynamicFoodType.Description = foodtype.FoodTypeDescription;
                dynamicFoodTypes.Add(dynamicFoodType);
            }
            return dynamicFoodTypes;
        }

        [System.Web.Http.Route("api/FoodType/getAllFoodTypesWithFood")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllFoodTypesWithFood()
        {
            FoodEntities db = new FoodEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<FoodType> foodTypesList = db.FoodTypes.Include(zz => zz.Foods).ToList();
            return getAllFoodTypesWithFoods(foodTypesList);
        }

        private List<dynamic> getAllFoodTypesWithFoods(List<FoodType> forClient)
        {
            List<dynamic> dynamicFoodtypes = new List<dynamic>();
            foreach(FoodType foodT in forClient)
            {
                dynamic dynamicFoodT = new ExpandoObject();
                dynamicFoodT.ID = foodT.FoodTypeID;
                dynamicFoodT.Description = foodT.FoodTypeDescription;
                dynamicFoodT.Foods = getFoods(foodT);
                dynamicFoodtypes.Add(dynamicFoodtypes);
            }
            return dynamicFoodtypes;
        }

        private List<dynamic> getFoods(FoodType foodType)
        {
            List<dynamic> dynamicFoods = new List<dynamic>();
            foreach (Food food in foodType.Foods)
            {
                dynamic dynamicFood = new ExpandoObject();
                dynamicFood.ID = food.FoodID;
                dynamicFood.Description = food.FoodDescription;
                dynamicFood.FoodTypeID = food.FoodTypeID;
                dynamicFood.FoodColourID = food.FoodColourID;
                dynamicFoods.Add(dynamicFood);
            }
            return dynamicFoods;
        }
        [System.Web.Http.Route("api/FoodType/addFoodTypeWithFood")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> addFoodTypeWithFoods([FromBody] FoodType foodType)
        {
            if (foodType != null)
            {
                FoodEntities db = new FoodEntities();
                db.Configuration.ProxyCreationEnabled = false;
                db.FoodTypes.Add(foodType);
                db.SaveChanges();
                return getAllFoodTypesWithFood();
       
            }

            else
            {
                return null;
            }
        }

    }

        
    }
