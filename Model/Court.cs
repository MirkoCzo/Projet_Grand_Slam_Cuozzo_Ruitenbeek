﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class Court
    {
        private int id;
        private bool isAvailable;
        private int nbSpectators;
        private bool covered;

        public bool Available()
        {
            return isAvailable;
        }
        public void Release()
        {
            isAvailable = true;
        }
        
    }
}