using System;
using System.Collections.Generic;
using System.Text;

namespace mktest
{
    public class Products : IProduct
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Mrp { get; set; }

        protected void GenerateCommision()
        {
            Logger.Log("generate a commission payment to the agent.");
        }

        public virtual void ExecutePostOrder()
        {
            Logger.Log("generate a packing slip for shipping.");

            this.GenerateCommision();
        }

    }

    public class Book : Products
    {
        public override void ExecutePostOrder()
        {
            Logger.Log("create a duplicate packing slip for the royalty department.");

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
            Logger.Log("execute default delivery");

        }

    }

    public class Video : Virtual
    {
        public override void ExecutePostOrder()
        {
            if (this.Name.Equals("Learning to Ski,"))
            {
                Logger.Log("First Aid");

            }
            else
            {
                base.ExecutePostOrder();
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

            Logger.Log("e-mail the owner and inform them of the activation/upgrade.");

        }

        private void ActivateMemebership()
        {
            Logger.Log("activate that membership.");

        }

        private void UpdgradeMemebership()
        {
            Logger.Log("apply the upgrade.");

        }
    }
}
