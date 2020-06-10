using System;
using System.Collections.Generic;
using System.Text;

namespace mktest
{
    public class Physical : IProduct
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Mrp { get; set; }

        protected void GenerateCommision()
        {
            Console.WriteLine("generate a commission payment to the agent.");
        }

        public virtual void ExecutePostOrder()
        {
            Console.WriteLine("generate a packing slip for shipping");

            this.GenerateCommision();
        }

    }

    public class Book : Physical
    {
        public override void ExecutePostOrder()
        {
            Console.WriteLine("create a duplicate packing slip for the royalty department.");

            base.GenerateCommision();
        }
    }

    public abstract class Virtual : IProduct
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Mrp { get; set; }

        public virtual void ExecutePostOrder()
        {
            Console.WriteLine("execute default delivery");

        }

    }

    public class Video : Virtual
    {
        public override void ExecutePostOrder()
        {
            if (this.Name.Equals("Learning to Ski,"))
            {
                Console.WriteLine("First Aid");

            }

        }
    }

    public class Membership : Virtual
    {
        private bool isActive = true;

        public Membership(bool isActive)
        {
            this.isActive = isActive;
        }

        public override void ExecutePostOrder()
        {
            if (isActive)
            {
                ActivateMemebership();
            }
            else
            {
                UpdgradeMemebership();
            }

            Console.WriteLine("e-mail the owner and inform them of the activation/upgrade.");

        }

        private void ActivateMemebership()
        {
            Console.WriteLine("activate that membership.");

        }

        private void UpdgradeMemebership()
        {
            Console.WriteLine("apply the upgrade.");

        }
    }
}
