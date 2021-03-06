﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Language.Review
{
    public class EarnedMark : WeightedMark
    {
        public int Possible { get; private set; }

        private double _Earned;
        public double Earned
        {
            get { return _Earned; }
            set
            {
                if (value < 0 || value > Possible)
                    throw new Exception("Invalid earned mark assigned");
                _Earned = value;
            }
        }

        public double Percent
        {  get { return (Earned / Possible) * 100; } }

        public double WeightedPercent
        {  get { return Percent * Weight / 100; } }

        // This constructor calls another constructor
        // BEFORE it runs it's own body of instructions.
        // Hooking up constructors in this fashion is
        // known as "daisy-chaining" your constructor
        // calls.
        public EarnedMark(WeightedMark markableItem, int possible, double earned)
            : this(markableItem.Name, markableItem.Weight, possible, earned)
        {
        }

        public EarnedMark(string name, int weight, int possible, double earned) : base(name, weight)
        {
            if (possible <= 0)
                throw new Exception("Invalid possible marks");
            Possible = possible;
            Earned = earned;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})\t - {2}% ({3}/{4}) \t- Weighted Mark {5}%",
                Name,
                Weight,
                Percent,
                Earned,
                Possible,
                WeightedPercent);
        }
    }
}
