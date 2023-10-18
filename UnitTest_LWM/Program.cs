using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GFXsys;

namespace UnitTest_LWM
{
    internal class Program
    {
        static int shield;
        static int health;
        static int lives;
        static int xp;
        static int level;
        static bool GameStart;
        static bool PlayOn;
        static ConsoleKeyInfo QuitKey;
        static void Main(string[] args)
        {

            UnitTestHealthSystem();
            UnitTestXPSystem();

            SetQuitKey();
            Continue();
            PlayOn = true;
            GameStart = true;
            VarSetGo(100, 100, 3);
            ShowHud();
            Continue();
            while (PlayOn)
            {
                TakeDamage(GetRNGdmg());
                ShowHud();
                Continue();
                if (health == 0)
                {
                    ShowHud();
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Revive?");
                    Continue();
                    ShowHud();
                    Revive();
                    ShowHud();
                    Continue();
                    ShowHud();
                    
                    
                    
                }
            }
            
           
        }

        static void SetQuitKey()
        {
            Console.WriteLine("Please Select your quit key...");
            QuitKey = Console.ReadKey();
            Console.Clear();
        }

        static void Continue()
        {
            Console.SetCursorPosition(0, 15);
            
            Console.WriteLine("[press your quit key to quit, or any other key to continue]");
            if (Console.ReadKey() == QuitKey)
            {
                Environment.Exit(0);
            }
                
            Console.Clear();
        }

        static int GetRNGdmg()
        {
            Random RDmg = new Random();
            return RDmg.Next(1, 50);
        }

        static void VarSetGo(int Sp, int Hp, int Lp)
        {
            shield = Sp;
            health = Hp;    
            lives = Lp;
            if (GameStart)
            {
                xp = 0;
                level = 1;
                GameStart = false;
            }
        }

        static void TakeDamage(int dmg)
        {
            if (dmg < 0)
            {
                dmg = 0;

                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Negative integers are not accepted.");
            }
            else if (dmg >= 0)
            {
                shield -= dmg;
                if (shield < 0)
                {
                    health += shield;
                    shield = 0;
                }
                if (health <= 0)
                {
                    health = 0;
                }
            }
        }


        static void Heal(int hpam)
        {
            if (hpam < 0)
            {
                hpam = 0;
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Negative integers are not accepted.");
            }
            else if(health <= 0)
            {
                health = 0;
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Cannot Heal.");
                return;
            }
            else
            {
                health += hpam;
                if (health >= 100)
                {
                    health = 100;
                }
            }
        }

        static void IncreaseXP(int exp)
        {
            if (exp < 0)
            {
                exp = 0;
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Negative integers not accepted.");
            }
            else if (health <= 0)
            {
                health = 0;
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Cannot gain xp");
                return;
            }
            else
            {
                xp += exp;
                if (xp >= (level * 100))
                {
                    xp -= level * 100;
                    level += 1;
                }
            }
        }

        static void RegenerateShield(int spam)
        {
            if (spam < 0)
            {
                spam = 0;
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Negative integers not accepted.");
            }
            else if (health <= 0)
            {
                health = 0;
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Cannot Regenerate.");
            }
            else
            {
                shield += spam;
                if (shield >= 100)
                {
                    shield = 100;
                }
            }
        }

        static void Revive()
        {

            if (lives > 0)
            {
                lives -= 1;
                VarSetGo(100, 100, lives);
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("You revived!");
            }
            else if (lives <= 0)
            {
                lives = 0;
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("You have no more lives!");
            }
        }

        static void ShowHud()
        {
            CellularGFX.GridProcGFX("7.7.7.7.7.7.7.7.7.7", 1, 0, 0);
            CellularGFX.GridProcGFX("3.0.0.0.0.0.0.0.0.3", 1, 0, 1);
            CellularGFX.GridProcGFX("2.0.0.0.0.0.0.0.0.2", 1, 0, 2);
            CellularGFX.GridProcGFX("5.0.0.0.0.0.0.0.0.5", 1, 0, 3);
            CellularGFX.GridProcGFX("9.0.0.0.0.0.0.0.0.9", 1, 0, 4);
            CellularGFX.GridProcGFX("4.0.0.0.0.0.0.0.0.4", 1, 0, 5);
            CellularGFX.GridProcGFX("8.0.0.0.0.0.0.0.0.8", 1, 0, 6);
            CellularGFX.GridProcGFX("7.7.7.7.7.7.7.7.7.7", 1, 0, 7);
            Console.SetCursorPosition(2, 1);
            if (health == 100)
            {
                Console.Write("Perfect Health");
            }
            else if (health <= 90 && health > 75)
            {
                Console.Write("Healthy");
            }
            else if (health <= 75 && health > 50)
            {
                Console.Write("Hurt");
            }
            else if (health <= 50 && health > 10)
            {
                Console.Write("Badly Hurt");
            }
            else if (health <= 10 && health >= 0)
            {
                Console.Write("Imminent Danger");
            }
            Console.SetCursorPosition(2, 2);
            Console.Write("Shields: ");
            Console.WriteLine(shield);
            Console.SetCursorPosition(2, 3);
            Console.Write("Health: ");
            Console.WriteLine(health);
            Console.SetCursorPosition(2, 4);
            Console.Write("Lives: ");
            Console.WriteLine(lives);
            Console.SetCursorPosition(2, 5);
            Console.Write("Xp: ");
            Console.WriteLine(xp);
            Console.SetCursorPosition(2, 6);
            Console.Write("Level: ");
            Console.WriteLine(level);
            Console.WriteLine("");
            
        }

        static void UnitTestHealthSystem()
        {
            Debug.WriteLine("Unit testing Health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            TakeDamage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            TakeDamage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            TakeDamage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            TakeDamage(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Heal()

            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);

            Debug.WriteLine("Unit testing Health System completed.");
            Console.Clear();
        }

        static void UnitTestXPSystem()
        {
            Debug.WriteLine("Unit testing XP / Level Up System started...");

            // IncreaseXP()

            // IncreaseXP() - no level up; remain at level 1
            xp = 0;
            level = 1;
            IncreaseXP(10);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 1);

            // IncreaseXP() - level up to level 2 (costs 100 xp)
            xp = 0;
            level = 1;
            IncreaseXP(105);
            Debug.Assert(xp == 5);
            Debug.Assert(level == 2);

            // IncreaseXP() - level up to level 3 (costs 200 xp)
            xp = 0;
            level = 2;
            IncreaseXP(210);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 3);

            // IncreaseXP() - level up to level 4 (costs 300 xp)
            xp = 0;
            level = 3;
            IncreaseXP(315);
            Debug.Assert(xp == 15);
            Debug.Assert(level == 4);

            // IncreaseXP() - level up to level 5 (costs 400 xp)
            xp = 0;
            level = 4;
            IncreaseXP(499);
            Debug.Assert(xp == 99);
            Debug.Assert(level == 5);

            Debug.WriteLine("Unit testing XP / Level Up System completed.");
            Console.Clear();
        }
    }
}
