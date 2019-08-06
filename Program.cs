using System;
using System.Collections.Generic;

namespace hungryNinja
{
    class Program
    {
        

        class Food {
            public string Name;
            public int Calories;
            public bool IsSpicy;
            public bool IsSweet;

            public string GetInfo() {
                return $"Your {Name} has {Calories} calories. Is it spicy? {IsSpicy}. Is it sweet? {IsSweet}.";
            }

            public Food(string name, int calories, bool spicy, bool sweet) {
                Name = name;
                Calories = calories;
                IsSpicy = spicy;
                IsSweet = sweet;
            }
        }


        class Buffet {

            public List<Food> Menu;

            public Buffet() {
                
                Menu = new List<Food>() {
                    new Food("Peanut Sesame Noodle Bowl", 560, true, false),
                    new Food("Vegetaarian 4-Bean Chili", 340, false, false),
                    new Food("Fig Newton", 100, false, false),
                    new Food("Lemon-Lime Gatorade", 80, false, false),
                    new Food("Veggie Straws", 100, false, false),
                    new Food("Oreo", 160, false, true),
                    new Food("Fruit Snacks", 80, false, true),
                };
            }

            public Food Serve() {
                Random rand = new Random();
                int j = rand.Next(6);
                return Menu[j];
            }

            class Ninja {
                private int calorieIntake;
                public List<Food> FoodHistory;

                public Ninja() {
                    calorieIntake = 0;
                    FoodHistory = new List<Food>();
                }

                public bool IsFull {get;set;}
                public void Eat(Food item) {
                    if(calorieIntake <= 1000) {
                        calorieIntake += item.Calories;
                        FoodHistory.Add(item);
                        item.GetInfo();
                        IsFull = false;
                    }
                    else {
                        System.Console.WriteLine("This Ninja is full!");
                        IsFull = true;
                    }
                }
            }

            static void Main(string[] args)
            {
                var Ryan = new Ninja();
                var lunch = new Buffet();
                while(!Ryan.IsFull) {
                    Ryan.Eat(lunch.Serve());
                }
                foreach(var food in Ryan.FoodHistory) {
                    System.Console.WriteLine($"This Ninja ate: {food.Name} with {food.Calories} calories!");
                }
            }
        }
    }
}
