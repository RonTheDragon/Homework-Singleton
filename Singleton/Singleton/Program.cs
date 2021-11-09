using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Singleton
            new ObjectPooler();
            #endregion

            Game.StartGame();

            Console.ReadKey(true);
        }
    }


    static class Game
    {
        public static void StartGame()
        {
            Gun Slingshot = new Gun();
            Slingshot.Bullet = "Rock";
            Spawner GoblinCave = new Spawner();
            GoblinCave.Spawnable = "Goblin";

            GoblinCave.Spawn();
            Slingshot.Shoot();
        }
    }

    class Gun
    {
        public string Bullet;

        public void Shoot()
        {
            ObjectPooler.instance.SpawnObject(Bullet);
        }       
    }

    class Spawner
    {
        public string Spawnable;
        public void Spawn()
        {
            ObjectPooler.instance.SpawnObject(Spawnable);
        }
    }

    class ObjectPooler
    {
        public static ObjectPooler instance; 
        public ObjectPooler()
        {
            instance = this;
        }
        public void SpawnObject(string Name)
        {
            Console.WriteLine($"Spanwed {Name}");
        }
    }
}
