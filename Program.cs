using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HealthSystemAPI
{
    
    class Program
    {
        static int health = 100;
        static int lives = 3;
        static int shield = 50;
        static int score = 0;
        static string healthStatus;
        static void Main(string[] args)
        {
            UnitTest();
            
            //ShowHud();
            //TakeDamage(75);
            //ShowHud();
            //TakeDamage(50);
            //ShowHud();
            //HealthRegen(75);
            //ShowHud();
            //ShieldRegen(50);
            //ShowHud();
            //addLife();
            //ShowHud();
            //TakeDamage(200);
            //ShowHud();
            //die();
            //ShowHud();
            //die();
            //ShowHud();
            
            


            Console.ReadKey(true);
        }

        static void UnitTest()
        {

            Console.WriteLine(" ");
            Console.WriteLine("Tesing HealthRegen()... Health cannot overflow or be Negative integer");
            health = 100;
            HealthRegen(100);
            Debug.Assert(health <= 100);
            Debug.Assert(health >= 0);

            Console.WriteLine(" ");
            Console.WriteLine("Testing ShieldRegen()... Shield cannot overflow or be a negative integer");
            shield = 50;
            ShieldRegen(0);
            ShieldRegen(0);
            Debug.Assert(shield <= 50);

            Console.WriteLine(" ");
            Console.WriteLine("Testing TakeDamage()... damage cannot be negative integer or cause health to be below zero");
            health = 100;
            shield = 50;
            TakeDamage(0);
            TakeDamage(0);
            Debug.Assert(health <= 100);
            Debug.Assert(shield <= 50);

            Console.WriteLine(" ");
            Console.WriteLine("Testing addLife... life added when score 10000");
            score = 0;
            lives = lives + 1;
            Debug.Assert(score <= 10000);

            Console.WriteLine(" ");
            Console.WriteLine("Testing HighScore().. Score cannot be a negative integer");
            score = 0;
            HighScore();
            Debug.Assert(score <= 0);

            Console.WriteLine(" ");
            Console.WriteLine("Done! booting AAA game.");



            

            

            
        }

        static void ShowHud()
        {
            

            healthStatus = updateHealthStatus(health);

            Console.WriteLine("====================");
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("Health Status: " + healthStatus);   
            Console.WriteLine("====================");
            
            
        }
        
        static void ShieldRegen(int sp)
        {
            if (sp < 0)
            {
                Console.WriteLine("ERROR- shield cannot be negative value");
                
            }
            else
            {
                shield = shield + sp;
                if (shield >= 50)
                {
                    shield = 50;
                }
                //Console.WriteLine("Player has picked up " + sp + " shield points!");
            }
        }

        static void HealthRegen(int hp)
        {
            if (hp > 100)
            {
                Console.WriteLine("Error-- HP cannot be more than 100");
            }
            if (hp < 0)
            {
                Console.WriteLine("Error-- HP cannot be negative value");
            }
            else
            {
                health = health + hp;
                if (health >= 100)
                {
                    health = 100;
                }
                //Console.WriteLine("Player has gained up " + hp + " Health points!");
            }
        }

        static void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Console.WriteLine("Damage cannot be negative value");
            }
            else
            {
                int remainingDamage;
                remainingDamage = damage - shield;
                shield = shield - damage;
                //Console.WriteLine("Player is about to take " + damage + " damage");

                if (shield <= 0)
                {
                    shield = 0;
                    health = health - remainingDamage;
                }

                if (health <= 0)
                {
                    health = 0;
                    die();
                    
                }     
            }
        }

        static void addLife()
        {
            lives = lives + 1;
            //Console.WriteLine("Player gained life");
            if (lives >= 3)
            {
                lives = 3;
            } 

            
                
        }

        static void die()
        {
            lives = lives - 1;
            //Console.WriteLine("Player Died");
            if (lives > 0)
            {
                HealthRegen(100);
                ShieldRegen(100);
            }
            else
            {
                health = 0;
                shield = 0;
            }
            if (lives <= 0)
            {
                lives = 0;
            }
           

        }

        static string updateHealthStatus(int currentHealth)
        {
            if (currentHealth <= 100 && currentHealth >= 76)
            {
                return "Healthy";
               

            }
            if (currentHealth <= 75 && currentHealth >= 51)
            {
                return "Hurt";
            }
            if (currentHealth <= 50 && currentHealth >= 26)
            {
                return "Badly Hurt";
            }
            if (currentHealth <= 25 && currentHealth >= 1)
            {
                return "Dying";
            }
            if (currentHealth <= 0)
            {
                return "Dead";
            }
            else return null; 
        }

        static void HighScore()
        {

            if (score < 0)
            {
                Console.WriteLine("Score cannot be a negative integer");
            }
            score = 0;
            if(score >= 10000)
            {
                lives = lives + 1;
                    
            }


        }
    
    }
    
}
